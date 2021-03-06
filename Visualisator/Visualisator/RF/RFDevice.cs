﻿using System;
using System.Text;
using System.Drawing;
using Visualisator.Packets;
using System.Collections;
using System.Threading;
using System.Windows.Forms;

namespace Visualisator
{
    [Serializable()]
    class RFDevice: ISerializable,IRFDevice
    { 
        public  RFStatus RF_STATUS = RFStatus.None;
        private string RfSync = "";
        protected String DOCpath = "";
        protected Hashtable     _RFpeers = new Hashtable(new ByteArrayComparer());
        protected Boolean       _Enabled = true;
        public StringBuilder    _LOG            =   new StringBuilder();
        public int x { set; get; }
        public int y { set; get; }
        public int z { set; get; }
        private Color           _vColor;
        private short           _OperateChannel =   0;
        private MAC             _address        =   new MAC();
        private Int32 _DoubleRecieved = 0;
        private Int32 _AllReceivedPackets = 0;
        protected static string ImagesPath = Application.StartupPath.ToString() + @"\..\..\Images\";

        /// <summary>
        /// Provide information about retransmited DATA packets
        /// </summary>
        public int                  DataRetransmited                { set; get; }

        /// <summary>
        /// Provide information about retransmited ACK for data packets
        /// </summary>
        public int                  DataAckRetransmitted            { set; get; }
        protected  static Random randomWait = new Random();
        protected static Random randomRssi = new Random();

        public Frequency Freq { set; get; }
        public Bandwidth BandWidth { set; get; }
        public Standart80211 Stand80211 { set; get; }

        public ArrayList FrequencySupport   = new ArrayList();
        public ArrayList BandWithSupport    = new ArrayList();
        public ArrayList StandartSupport    = new ArrayList();
        
        

        public string MACOfAnotherPeer { set; get; } //mac of another device with him we working now
        public bool Passive { set; get; }
        public int MACLastTrnsmitRate { set; get; }
        public double guiNoiseRssi { set; get; }

        public string SSID { set; get; }
        public string BSSID { set; get; }
        public Color DefaultColor { set; get; }

        public bool TDLSisEnabled { set; get; }
        public bool TDLSisWork { set; get; }
        public bool TDLSAutoStart { set; get; }

        private long _badPackets;
        public long BadPackets
        {
            set { _badPackets = value; }
            get { return _badPackets; }
        }

        #region Noise
        /// <summary>
        /// Noise Level
        /// </summary>
        public double NoiseLevel { set; get; }

        /// <summary>
        /// Effect of distance between us and the device that we working with it currently
        /// </summary>
        public double NoiseRSSI { set; get; }
        /// <summary>
        /// Effect of noise of devices working on the same channel as our channel but in other BSSS
        /// </summary>
        public double NoiseOnSameChannel { set; get; }

        /// <summary>
        /// Effect of noise of device working on the nearest channels. Example: if we on channel 6 so the nearest channel is 5,7
        /// </summary>
        public double NoiseNearestChannels { set; get; }

        /// <summary>
        /// Effect of noise of device working on the near channels. Example: if we on channel 6 so the nearest channel is 4,8
        /// </summary>
        public double NoiseNeartChannels { set; get; }
        #endregion


        //[MethodImpl(MethodImplOptions.Synchronized)]
        //=====================================================================
        /// <summary>
        /// Update RF decie peers in this peer
        /// </summary>
        public void UpdateRFPeers()
        {
            if (Medium._objects == null)
                return;
            try
            {
                double dist = 0;
                foreach (RFDevice devi in Medium._objects)
                {
                    if(devi.getMACAddress().Equals(this.getMACAddress()))
                        continue;

                    dist = GetSTADist(this.x, this.y, devi.x, devi.y);

                    if (dist <= Medium.ListenDistance*2)
                    {
                        RFpeer _peer = new RFpeer()
                        {
                            Distance    = dist,
                            BSSID       = devi.BSSID,
                            MAC         = devi.getMACAddress(),
                            Freq        = devi.Freq,
                            Stand80211  = devi.Stand80211,
                            BandWidth   = GetBestIntersectionBandwith(devi.BandWithSupport),// devi.BandWidth,
                            Channel     = devi.getOperateChannel(),
                            RSSI        = GetRSSI(devi.x, devi.y),
                            isPassive   = devi.Passive,
                        };
                        
                        if (_RFpeers.Contains(_peer.MAC))
                            _RFpeers[_peer.MAC] = _peer;
                        else
                            _RFpeers.Add(_peer.MAC, _peer);
                    }

                }
            }
            catch (Exception ex) { AddToLog("Update RFpeers :" + ex.Message); }
        }

        //protected  AutoResetEvent _ev = new AutoResetEvent(true);

        protected  bool DebugLogEnabled = false;
        protected bool ListenBeacon = false;

        //=====================================================================
        public bool getListenBeacon()
        {
            return ListenBeacon;
        }

        //=====================================================================
        protected Int32 DoubleRecieved
        {
            get { return _DoubleRecieved; }
            set { _DoubleRecieved = value; }
        }

        //=====================================================================
        public Int32 getDoubleRecieved()
        {
            return DoubleRecieved;
        }

        //=====================================================================
        /// <summary>
        /// Chacking if RF device with given MAC address axist
        /// </summary>
        /// <param name="mac">MAC address of rf device</param>
        /// <returns>True if exist</returns>
        public bool CheckMacExistance(string mac)
        {
            if (_RFpeers.Contains(mac))
                return true;

            return false;
        }

        public bool isEnabled()
        {
            return _Enabled;
        }
        //=====================================================================
        public double getRetransmitionRate()
        {
            if (MACOfAnotherPeer == null)
                return -1;
            try
            {
                RFpeer tempPeer = (RFpeer)_RFpeers[MACOfAnotherPeer];

                short Recounter = tempPeer.RetransmitionCounter;
                long counter = tempPeer.TransmitCounter;

                if (counter == 0)
                    return 0;
                double ret = 100 * Recounter / counter; 
                if(ret > 100)
                    ret = 100;
                return ret;
            }
            catch(Exception)
            {
                //MessageBox.Show("getRetransmitionRate" + ex.Message);
            }

            return -1;
        }
        protected ArrayList _AssociatedWithAPList = new ArrayList();
        protected ArrayList _PointerToAllRfDevices = null;
        //protected Hashtable _RSSI_all = new Hashtable(new ByteArrayComparer());

        protected Int32 _DataReceived = 0;
        protected Int32 _DataAckReceived = 0;
        protected Int32 _DataSent = 0;

        #region SeterGeter



        public Color VColor
        {
            get { return _vColor; }
            set { _vColor = value; }
        }

        public int AllReceivedPackets
        {
            get { return _AllReceivedPackets; }
            set { _AllReceivedPackets = value; }
        }
        //=====================================================================
        protected Int32 DataSent
        {
            get { return _DataSent; }
            set { _DataSent = value; }
        }
        //=====================================================================
        protected Int32 DataReceived
        {
            get { return _DataReceived; }
            set { _DataReceived = value; }
        }
        //=====================================================================
        protected Int32 DataAckReceived
        {
            get { return _DataAckReceived; }
            set { _DataAckReceived = value; }
        }
        //=====================================================================
        public Int32 getDataRecieved(){
            return DataReceived;
        }
        //=====================================================================
        public Int32 getDataAckRecieved()
        {
            return DataAckReceived;
        }
        //=====================================================================
        public Int32 getDataSent()
        {
            return DataSent;
        }

        #endregion

        //=====================================================================
        /// <summary>
        /// Return Best Intersection Bandwith for use in TDLS
        /// </summary>
        /// <param name="otherBandWith">Array list of supported Bandwith for other device</param>
        /// <returns>Return Best Intersection Bandwith</returns>
        public Bandwidth GetBestIntersectionBandwith(ArrayList otherBandWith)
        {
            Bandwidth ret = Bandwidth._20MHz;

            if (this.BandWithSupport.Contains(Bandwidth._40Mhz) && otherBandWith.Contains(Bandwidth._40Mhz))
                ret = Bandwidth._40Mhz;

            return ret;
        }

        //=====================================================================
        public string DumpAll()
        {
            String ret = "";
            ret += "OperateChannel     :    " + this._OperateChannel;
            ret += "\r\nFrequency       :   " + this.Freq.ToString();
            ret += "\r\nBandwith        :   " + this.BandWidth.ToString();
            ret += "\r\n80211 Standart  :   " + this.Stand80211.ToString();
            ret += "\r\n_address        :   " + this.getMACAddress();
            ret += "\r\nFrequencySupport:   " + ObjectDumper.Dump(this.FrequencySupport);
            ret += "\r\nBandWithSupport :   " + ObjectDumper.Dump(this.BandWithSupport);
            ret += "\r\nStandartSupport :   " + ObjectDumper.Dump(this.StandartSupport);
            return (ret);
        }
        //=====================================================================
        /// <summary>
        /// Return Status Of RF status
        /// </summary>
        /// <returns>True if device not busy</returns>
        public bool RFWorking()
        {
            if (!RF_STATUS.Equals(RFStatus.None))
                return true;
                
            return false;
        }

        //=====================================================================
        /// <summary>
        /// Function for calculate RSSI by coordinates of another peer
        /// </summary>
        /// <param name="x">Coordinates of Another device</param>
        /// <param name="y">Coordinates of Another device</param>
        /// <returns>RSSI - short</returns>
        protected short GetRSSI(int x, int y)
        {
            short ret = 0;
            double dist;
            try{
                dist = GetSTADist( this.x,this.y, x, y);
                if (dist > 0.0 && dist < 100){
                    // formula for wolfram: plot [y= -13*log_2(x),{y,16,-95},{x,60,0}] 
                    // http://www.wolframalpha.com/input/?i=plot+%5By%3D+-13*log_2%28x%29%2C%7By%2C16%2C-95%7D%2C%7Bx%2C60%2C0%7D%5D+
                    ret = (short)Convert.ToInt32(Math.Round(-13*Math.Log(dist, 2)));
                }
            }
            catch (Exception ex) { AddToLog("GETRSSI:[" + this.GetType() + "] " + ex.Message); }
            return ret;
        }

        //=====================================================================    
        /// <summary>
        /// Function for check if need to skip received packet
        /// </summary>
        /// <param name="NoiseRssi">Given Noisr RSSI</param>
        /// <param name="Rate">Rate of Packet</param>
        /// <returns>Return true in need to skip packet</returns>
        static protected bool MissPacket(double NoiseRssi, int Rate)
        {
            bool ret = true;

            if (NoiseRssi > 1)
            {
                int given_chance    = randomRssi.Next(10, 100);
                int chance          = randomRssi.Next(1, (int) NoiseRssi);

                if (chance >= given_chance)
                    ret = false;
            }
            return ret;
        }

        //=====================================================================
        /// <summary>
        /// Independ on RSSI return Noize level
        /// </summary>
        /// <param name="MAC">Macc address</param>
        /// <returns>Return NOIZE level</returns>
        protected double GetNoiseRSSI(string MAC)
        {
            double retVale = 0;
            if (!_RFpeers.Contains(MAC))
                UpdateRFPeers();
            if (_RFpeers.Contains(MAC))
            {
                RFpeer _peer = (RFpeer)_RFpeers[MAC];
                //TODO :: Need optimize 
                // formula for wolfram: plot [y=x^2 +150x +(75^2) ,{y,0,100},{x,-60,-100}] 
                // http://www.wolframalpha.com/input/?i=plot+%5By%3Dx%5E2+%2B150x+%2B%2875%5E2%29+%2C%7By%2C0%2C100%7D%2C%7Bx%2C-60%2C-100%7D%5D+
                double NoiseRssi = Math.Pow(_peer.RSSI , 2) + 150 * _peer.RSSI + Math.Pow(75, 2);

                if (_peer.RSSI <= -75)
                {
                    if (NoiseRssi > 100)
                        retVale = 100;
                    else
                        retVale = NoiseRssi;
                }
                else{
                    retVale = 0;
                }
            }
        
            guiNoiseRssi = retVale;
            return retVale;
        }

        //=====================================================================
        /// <summary>
        /// Calculate distance between two given coordinates
        /// </summary>
        /// <param name="myX">Coordiantes of this device</param>
        /// <param name="myY">Coordiantes of this device</param>
        /// <param name="x">Coordiantes of other device</param>
        /// <param name="y">Coordiantes of other device</param>
        /// <returns>Distance between two given devices</returns>
        static protected double GetSTADist(int myX,int myY, int x,int y)
        {
            return Math.Sqrt(Math.Pow(x - myX, 2)  + Math.Pow(y - myY, 2));
        }

        //=====================================================================
        public string getMACAddress()
        {
            return _address.getMAC();
        }

        #region Constructot
        //=====================================================================
        public RFDevice(int x, int y, int z)
        {
            this.SetVertex(x,y,z);
        }

        //=====================================================================
        public RFDevice(RFDevice ver)
        {
            this.SetVertex(ver.x, ver.y, ver.z);
        }

        //=====================================================================
        public RFDevice()
        {
            this.SetVertex(0, 0, 0);
        }
        #endregion

        //=====================================================================
        public SimulatorPacket CreatePacket()
        {
            SimulatorPacket pack = new SimulatorPacket(this.getOperateChannel())
            {
                SSID               = this.SSID,
                Source             = getMACAddress(),
                X                  = this.x,
                Y                  = this.y,
                PacketFrequency    = this.Freq,
                PacketStandart     = this.Stand80211,
                PacketBandWith     = this.BandWidth,
            };
            return(pack);
        }

        public SimulatorPacket CreatePacket(bool inTDLS)
        {
            SimulatorPacket pack = new SimulatorPacket(this.getOperateChannel())
            {
                SSID                = this.SSID,
                Source              = getMACAddress(),
                X                   = this.x,
                Y                   = this.y,
                PacketFrequency     = this.Freq,
                PacketStandart      = this.Stand80211,
                PacketBandWith      = this.BandWidth,
            };
            return (pack);
        }

        //=====================================================================
        public void setOperateChannel(short NewChannel)
        {
            
            _OperateChannel = NewChannel;
            if (NewChannel > 0 && NewChannel < 15)
            {
                this.Freq = Frequency._2400GHz;
                this.Stand80211 = Standart80211._11n;
            }
            else
                this.Freq = Frequency._5200GHz;
        }

        //=====================================================================
        public short getOperateChannel()
        {
            return (_OperateChannel);
        }

        //=====================================================================
        protected bool RF_Ready()
        {
            return RF_STATUS.Equals(RFStatus.None);
        }

        //=====================================================================
        public void EnableBandwithSupportFor40MHz()
        {
            BandWidth = Bandwidth._40Mhz;
            if (!BandWithSupport.Contains(Bandwidth._40Mhz))
                BandWithSupport.Add(Bandwidth._40Mhz);
        }

        //=====================================================================
        public void DisableBandwithSupportFor40MHz()
        {
            BandWidth = Bandwidth._20MHz;
            BandWithSupport.Remove(Bandwidth._40Mhz);
        }

        //=====================================================================
        public void Enable()
        {
            DataRetransmited        = 0;
            DataAckRetransmitted    = 0;
            this.Passive = true;
            _Enabled = true;
            BandWithSupport.Add(Bandwidth._20MHz);
        }
        public bool BandWidthCheckCheckSupport(Bandwidth ban)
        {
            if(this.BandWithSupport.Contains(ban))
            {
                return true;
            }

            return false;
        }

        //*********************************************************************
        public void SendData(SimulatorPacket pack)
        {

            CheckScanConditionOnSend();
            int Rate = pack.getTransmitRate();
            int sleep = (int)(600 / Rate);
            lock (RfSync)
            {
                try{
                    RF_STATUS = RFStatus.Tx;
                    short OperateChannel = this.getOperateChannel();
                    int try_counter = 0;
                    while (!Medium.Registration(this.Freq, OperateChannel, this.x, this.y, sleep))
                    {
                        Thread.Sleep(new TimeSpan(randomWait.Next(20, 50)));
                        if (try_counter++ > 200)
                            return;
                    }
                    this.MACLastTrnsmitRate = pack.getTransmitRate();
                    Medium.SendData(pack);   
                }
                catch(Exception ex){
                    AddToLog("SendData:[" + this.GetType() + "] " + ex.Message);
                    MessageBox.Show("SendData :" + ex.Message);
                }

                RF_STATUS = RFStatus.None;
            }
            if (pack.GetType() == typeof(Data)){
                _DataSent++;
            }
        }

        //=====================================================================
        public virtual void CheckScanConditionOnSend(){}

        //=====================================================================
        /// <summary>
        /// Add new standart to support list
        /// </summary>
        /// <param name="newStandart">Standart80211 will be added</param>
        public void AddStandartSupport(Standart80211 newStandart)
        {
            if(!this.StandartSupport.Contains(newStandart))
            {
                StandartSupport.Add(newStandart);
            }
        }

        //=====================================================================
        /// <summary>
        /// Remove standart from support list
        /// </summary>
        /// <param name="removeStandart">Standart80211 will be removed</param>
        public void RemoveStandartSupport(Standart80211 removeStandart)
        {
            if (this.StandartSupport.Contains(removeStandart))
            {
                StandartSupport.Remove(removeStandart);
            }
        }

        //=====================================================================
        /// <summary>
        /// Check if given standart supported by RF device
        /// </summary>
        /// <param name="standart">Standart80211</param>
        /// <returns>True if supported</returns>
        public bool StandartSupported(Standart80211 standart)
        {
            return this.StandartSupport.Contains(standart);
        }

        //=====================================================================
        public void MACsandACK(string Destination , Guid _DataGuid,int TXrate)
        {
            DataAck da = new DataAck(CreatePacket());
            da.Destination = Destination;
            da.PacketChannel = this.getOperateChannel();
            //da.PacketBand = this.getOperateBand();
            da.PacketBandWith = this.BandWidth;
            da.PacketStandart = this.Stand80211;
            da.PacketFrequency = this.Freq;
            da.Source = this.getMACAddress();//.ToString();
            da.GuiDforDataPacket = _DataGuid;
            da.setTransmitRate(TXrate);
            this.SendData(da);
            
        }

        //=====================================================================
        public void Disable()
        {
            _Enabled = false;
        }

        //=====================================================================
        public void AddToLog(string newLogEntry)
        {
            _LOG.Append( "[" + this.getMACAddress() + "] - " + newLogEntry + "\r\n");
        }

        //=====================================================================
        public void ClearLog()
        {
            _LOG.Clear();
        }
        //=====================================================================
        public virtual void ParseReceivedPacket(SimulatorPacket pack) { }

        //=====================================================================
        private bool checkIfHaveDataReceive()
        {
            return Medium.MediumHaveAIRWork(this, ListenBeacon);
        }

        private Guid prev_guid = new Guid();
        //=====================================================================
        /// <summary>
        /// Function for Listen And Receive Packets
        /// </summary>
        /// <param name="sender">Value for know info about received packets</param>
        /// <param name="args">Not used - needed by event</param>
        public void Listen(object sender, EventArgs args)
        {

            //while (_Enabled)
            //{
            //SpinWait.SpinUntil(checkIfHaveDataReceive);
            //SpinWait.SpinUntil(RF_Ready);
            if (((SimulatorPacket)sender).PacketChannel != this.getOperateChannel())
                return;
            if (((SimulatorPacket)sender).PacketFrequency != this.Freq)
                return;
            

            double dist = GetSTADist(((SimulatorPacket) sender).X, ((SimulatorPacket) sender).Y, this.x, this.y);
            if(dist > Medium.ReceiveDistance)
                return;

            string desinationOfReceivedPacket = ((SimulatorPacket)sender).Destination;

            if ((this.GetType() == typeof(STA) && desinationOfReceivedPacket.Equals("FF:FF:FF:FF:FF:FF")) || desinationOfReceivedPacket.Equals(this.getMACAddress()))
            {
                double t = GetNoiseRSSI(((SimulatorPacket) sender).Source);
                if (sender.GetType() == typeof(Data))
                {
                    if (!MissPacket(t, ((SimulatorPacket)sender).getTransmitRate() ))
                    {
                        _badPackets++;
                        return;
                    }
                        
                }

                //SpinWait.SpinUntil(ListenCondition);//,1);
                prev_guid = new Guid();
                SimulatorPacket pack = null;

                lock (RfSync)
                {
                    RF_STATUS = RFStatus.Rx;
                    pack = Medium.ReceiveData(this);
                    RF_STATUS = RFStatus.None;
                }
                if (pack == null){ }
                else //if (pack != null )//&& (prev_guid != pack.GuidD || pack.IsRetransmit))
                {
                    //  Only if we have received packet before
                    //  but flag Rentransmit is UP
                    if (prev_guid == pack.GuidD)
                        pack.IsReceivedRetransmit = true;

                    if (pack.GetType() != typeof(Beacon))
                        prev_guid = pack.GuidD;

                    AllReceivedPackets += 1;

                    //Thread newThread = new Thread(() => ParseReceivedPacket(pack),1);
                    //newThread.Name = "ParseReceivedPacket of " + this.getMACAddress();
                    //newThread.Start();
                    ThreadPool.QueueUserWorkItem(new WaitCallback((s) => ParseReceivedPacket(pack)));
                }
            }
        }

        //=====================================================================
        public double GetNoiseOnSameChannel()
        {
            //short devisesCounter = 0;
            //UpdateRFPeers();

            int points = 0;
            double val = 0;
            foreach (DictionaryEntry device in _RFpeers)
            {
                RFpeer dev = (RFpeer)((DictionaryEntry)device).Value;
                if (dev.Channel == getOperateChannel())
                {
                    // formula for wolfram: plot [y= -15*log_2(x),{y,16,-95},{x,60,0}] 
                    // http://www.wolframalpha.com/input/?i=plot+%5By%3D+-15*log_2%28x%29%2C%7By%2C16%2C-95%7D%2C%7Bx%2C60%2C0%7D%5D+

                    val += Medium.ListenDistance - dev.Distance;
                    points++;
                }

            }
            return val/points;
        }

        //=====================================================================
        private bool ListenCondition()
        {
            return ( RF_Ready());
            //checkIfHaveDataReceive() &&
        }
        //=====================================================================
        public void SetVertex(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            UpdateRFPeers();
        }
        
        //*********************************************************************
        /// <summary>
        /// 
        /// </summary>
        /// <param name="MAC"></param>
        /// <returns></returns>
        protected short GetTXRate(string MAC)
        {
            short retVale = 0;
            if (!_RFpeers.Contains(MAC))
                UpdateRFPeers();
            if (_RFpeers.Contains(MAC))
            {
                RFpeer _peer = (RFpeer)_RFpeers[MAC];

                if (_peer.Freq == Frequency._5200GHz)
                {
                    if (_peer.BandWidth == Bandwidth._20MHz)
                        retVale = getRateOn5_2RSSI20M(_peer.RSSI);
                    else if (_peer.BandWidth == Bandwidth._40Mhz)
                        retVale = getRateOn5_2RSSI40M(_peer.RSSI);
                }
                else if (_peer.Freq == Frequency._2400GHz)
                {
                    if (_peer.BandWidth == Bandwidth._20MHz)
                        retVale = getRateOn2_4RSSI20M(_peer.RSSI);
                    else if (_peer.BandWidth == Bandwidth._40Mhz)
                        retVale = getRateOn2_4RSSI40M(_peer.RSSI);
                }
                //if (_peer.BandWidth == Bandwidth._40Mhz)
                //    retVale*=2;
            }  
            return retVale;
        }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RSSI"></param>
        /// <returns></returns>
        static short getRateOn2_4RSSI20M(short RSSI)
        {
            short retVal = -64;

            if (RSSI >= -64)
                retVal = 144;
            else if (RSSI == -65)
                retVal = 130;
            else if (RSSI == -66)
                retVal = 115;
            else if (RSSI < -66 && RSSI >= -70)
                retVal = 86;
            else if (RSSI < -70 && RSSI >= -74)
                retVal = 57;
            else if (RSSI < -74 && RSSI >= -77)
                retVal = 43;
            else if (RSSI < -77 && RSSI >= -79)
                retVal = 28;
            else if (RSSI < -79)// && RSSI >= -82)
                retVal = 14;

            return retVal;

        }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RSSI"></param>
        /// <returns></returns>
        static short getRateOn2_4RSSI40M(short RSSI)
        {
            short retVal = -64;

            if (RSSI >= -64)
                retVal = 300;
            else if (RSSI == -65)
                retVal = 270;
            else if (RSSI == -66)
                retVal = 240;
            else if (RSSI < -66 && RSSI >= -70)
                retVal = 180;
            else if (RSSI < -70 && RSSI >= -74)
                retVal = 120;
            else if (RSSI < -74 && RSSI >= -77)
                retVal = 90;
            else if (RSSI < -77 && RSSI >= -79)
                retVal = 60;
            else if (RSSI < -79)// && RSSI >= -82)
                retVal = 30;

            return retVal;

        }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RSSI"></param>
        /// <returns></returns>
        static short getRateOn5_2RSSI20M(short RSSI)
        {
            short retVal = -61;

            if (RSSI >= -61)
                retVal = 144;
            else if (RSSI == -62)
                retVal = 130;
            else if (RSSI == -63)
                retVal = 115;
            else if (RSSI < -63 && RSSI >= -67)
                retVal = 86;
            else if (RSSI < -67 && RSSI >= -71)
                retVal = 57;
            else if (RSSI < -71 && RSSI >= -74)
                retVal = 43;
            else if (RSSI < -74 && RSSI >= -76)
                retVal = 28;
            else if (RSSI < -76)// && RSSI >= -79)
                retVal = 14;

            return retVal;

        }
        //=====================================================================
        /// <summary>
        /// 
        /// </summary>
        /// <param name="RSSI"></param>
        /// <returns></returns>
        static short getRateOn5_2RSSI40M(short RSSI)
        {
            short retVal = -61;

            if (RSSI >= -61)
                retVal = 300;
            else if (RSSI == -62)
                retVal = 270;
            else if (RSSI == -63)
                retVal = 240;
            else if (RSSI < -63 && RSSI >= -67)
                retVal = 180;
            else if (RSSI < -67 && RSSI >= -71)
                retVal = 120;
            else if (RSSI < -71 && RSSI >= -74)
                retVal = 90;
            else if (RSSI < -74 && RSSI >= -76)
                retVal = 60;
            else if (RSSI < -76)// && RSSI >= -79)
                retVal = 30;

            return retVal;

        }

        //*********************************************************************
        protected void CreateFolder()
        {

            // To create a string that specifies the path to a subfolder under your  
            // top-level folder, add a name for the subfolder to folderName. 
            String mac = this.getMACAddress();
            mac = mac.Replace(":", "-");
            string pathString = System.IO.Path.Combine(Medium.VisualisatorWorkDir, mac);
            DOCpath = pathString;
            System.IO.Directory.CreateDirectory(pathString);
        }
    }
}
