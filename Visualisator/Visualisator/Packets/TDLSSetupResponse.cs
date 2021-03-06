﻿using System;
namespace Visualisator.Packets
{
    [Serializable()]
    class TDLSSetupResponse : SimulatorPacket
    {
        public bool freq5000Support = false;
        private bool _width40Support    = false;
        private Int32 _prefferedChannel = 0;
        public int PrefferedChannel
        {
            get { return _prefferedChannel; }
            set { _prefferedChannel = value; }
        }
        public bool Width40Support
        {
            get { return _width40Support; }
            set { _width40Support = value; }
        }

        public TDLSSetupResponse(SimulatorPacket pack)
            : base(pack)
        {
        }
    }
}