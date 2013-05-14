﻿namespace Visualisator
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtConsole = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStopMedium = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.openDLGOpenSimulationSettings = new System.Windows.Forms.OpenFileDialog();
            this.button4 = new System.Windows.Forms.Button();
            this.btnShowMediumInfo = new System.Windows.Forms.Button();
            this.tmrGUISlow = new System.Windows.Forms.Timer(this.components);
            this.lblUpdateIntervalDescr = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtUpdateInterval = new System.Windows.Forms.TextBox();
            this.btnSetUpdateInterval = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetMediumSendRatio = new System.Windows.Forms.Button();
            this.txtMediumSendRatio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtTDLSSendDelay = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.txtBSSSendDelay = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.txtTDLSSendDelayWait = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.txtBSSSendDelayWait = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnUpdateMediumListenDist = new System.Windows.Forms.Button();
            this.txtMediumListenDistance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnUpdateMediumRecDist = new System.Windows.Forms.Button();
            this.txtMediumReceiveDistance = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmdCreateOneAPTwoSta = new System.Windows.Forms.Button();
            this.cmdAdd1APforSTA = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtConsole.Enabled = false;
            this.txtConsole.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtConsole.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txtConsole.Location = new System.Drawing.Point(694, 70);
            this.txtConsole.Multiline = true;
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConsole.Size = new System.Drawing.Size(253, 97);
            this.txtConsole.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(700, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Console";
            // 
            // btnStopMedium
            // 
            this.btnStopMedium.Location = new System.Drawing.Point(802, 3);
            this.btnStopMedium.Name = "btnStopMedium";
            this.btnStopMedium.Size = new System.Drawing.Size(62, 19);
            this.btnStopMedium.TabIndex = 5;
            this.btnStopMedium.Text = "Stop Med";
            this.btnStopMedium.UseVisualStyleBackColor = true;
            this.btnStopMedium.Click += new System.EventHandler(this.BtnStopMediumClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(870, 28);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 19);
            this.button2.TabIndex = 6;
            this.button2.Text = "Save";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(870, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 19);
            this.button3.TabIndex = 7;
            this.button3.Text = "Load";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openDLGOpenSimulationSettings
            // 
            this.openDLGOpenSimulationSettings.FileName = "openFileDialog1";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(694, 3);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 19);
            this.button4.TabIndex = 8;
            this.button4.Text = "Create";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnShowMediumInfo
            // 
            this.btnShowMediumInfo.Location = new System.Drawing.Point(802, 28);
            this.btnShowMediumInfo.Name = "btnShowMediumInfo";
            this.btnShowMediumInfo.Size = new System.Drawing.Size(62, 19);
            this.btnShowMediumInfo.TabIndex = 9;
            this.btnShowMediumInfo.Text = "Medium";
            this.btnShowMediumInfo.UseVisualStyleBackColor = true;
            this.btnShowMediumInfo.Click += new System.EventHandler(this.btnShowMediumInfo_Click);
            // 
            // tmrGUISlow
            // 
            this.tmrGUISlow.Enabled = true;
            this.tmrGUISlow.Interval = 500;
            this.tmrGUISlow.Tick += new System.EventHandler(this.tmrGUISlow_Tick);
            // 
            // lblUpdateIntervalDescr
            // 
            this.lblUpdateIntervalDescr.AutoSize = true;
            this.lblUpdateIntervalDescr.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUpdateIntervalDescr.Location = new System.Drawing.Point(700, 182);
            this.lblUpdateIntervalDescr.Name = "lblUpdateIntervalDescr";
            this.lblUpdateIntervalDescr.Size = new System.Drawing.Size(83, 13);
            this.lblUpdateIntervalDescr.TabIndex = 10;
            this.lblUpdateIntervalDescr.Text = "Update Interval";
            // 
            // txtUpdateInterval
            // 
            this.txtUpdateInterval.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtUpdateInterval.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateInterval.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtUpdateInterval.ForeColor = System.Drawing.Color.Navy;
            this.txtUpdateInterval.Location = new System.Drawing.Point(842, 182);
            this.txtUpdateInterval.Name = "txtUpdateInterval";
            this.txtUpdateInterval.Size = new System.Drawing.Size(57, 18);
            this.txtUpdateInterval.TabIndex = 11;
            this.txtUpdateInterval.Text = "500";
            this.txtUpdateInterval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSetUpdateInterval
            // 
            this.btnSetUpdateInterval.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetUpdateInterval.Location = new System.Drawing.Point(905, 182);
            this.btnSetUpdateInterval.Name = "btnSetUpdateInterval";
            this.btnSetUpdateInterval.Size = new System.Drawing.Size(39, 18);
            this.btnSetUpdateInterval.TabIndex = 12;
            this.btnSetUpdateInterval.Text = "Set";
            this.btnSetUpdateInterval.UseVisualStyleBackColor = true;
            this.btnSetUpdateInterval.Click += new System.EventHandler(this.btnSetUpdateInterval_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 26);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aPToolStripMenuItem,
            this.sTAToolStripMenuItem});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // aPToolStripMenuItem
            // 
            this.aPToolStripMenuItem.CheckOnClick = true;
            this.aPToolStripMenuItem.Name = "aPToolStripMenuItem";
            this.aPToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.aPToolStripMenuItem.Text = "Access Point";
            this.aPToolStripMenuItem.Click += new System.EventHandler(this.aPToolStripMenuItem_Click);
            // 
            // sTAToolStripMenuItem
            // 
            this.sTAToolStripMenuItem.Name = "sTAToolStripMenuItem";
            this.sTAToolStripMenuItem.Size = new System.Drawing.Size(141, 22);
            this.sTAToolStripMenuItem.Text = "Station";
            this.sTAToolStripMenuItem.Click += new System.EventHandler(this.sTAToolStripMenuItem_Click);
            // 
            // btnSetMediumSendRatio
            // 
            this.btnSetMediumSendRatio.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSetMediumSendRatio.Location = new System.Drawing.Point(905, 200);
            this.btnSetMediumSendRatio.Name = "btnSetMediumSendRatio";
            this.btnSetMediumSendRatio.Size = new System.Drawing.Size(39, 18);
            this.btnSetMediumSendRatio.TabIndex = 15;
            this.btnSetMediumSendRatio.Text = "Set";
            this.btnSetMediumSendRatio.UseVisualStyleBackColor = true;
            this.btnSetMediumSendRatio.Click += new System.EventHandler(this.btnSetMediumSendRatio_Click);
            // 
            // txtMediumSendRatio
            // 
            this.txtMediumSendRatio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMediumSendRatio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediumSendRatio.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMediumSendRatio.ForeColor = System.Drawing.Color.Navy;
            this.txtMediumSendRatio.Location = new System.Drawing.Point(842, 200);
            this.txtMediumSendRatio.Name = "txtMediumSendRatio";
            this.txtMediumSendRatio.Size = new System.Drawing.Size(57, 18);
            this.txtMediumSendRatio.TabIndex = 14;
            this.txtMediumSendRatio.Text = "10";
            this.txtMediumSendRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(700, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Medium Send ratio";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(904, 258);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 18);
            this.button1.TabIndex = 21;
            this.button1.Text = "Set";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtTDLSSendDelay
            // 
            this.txtTDLSSendDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtTDLSSendDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDLSSendDelay.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTDLSSendDelay.ForeColor = System.Drawing.Color.Navy;
            this.txtTDLSSendDelay.Location = new System.Drawing.Point(842, 258);
            this.txtTDLSSendDelay.Name = "txtTDLSSendDelay";
            this.txtTDLSSendDelay.Size = new System.Drawing.Size(57, 18);
            this.txtTDLSSendDelay.TabIndex = 20;
            this.txtTDLSSendDelay.Text = "1";
            this.txtTDLSSendDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(711, 258);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "TDLS Send Delay";
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.Location = new System.Drawing.Point(905, 216);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(39, 20);
            this.button5.TabIndex = 18;
            this.button5.Text = "Set";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // txtBSSSendDelay
            // 
            this.txtBSSSendDelay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtBSSSendDelay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBSSSendDelay.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBSSSendDelay.ForeColor = System.Drawing.Color.Navy;
            this.txtBSSSendDelay.Location = new System.Drawing.Point(842, 218);
            this.txtBSSSendDelay.Name = "txtBSSSendDelay";
            this.txtBSSSendDelay.Size = new System.Drawing.Size(57, 18);
            this.txtBSSSendDelay.TabIndex = 17;
            this.txtBSSSendDelay.Text = "1";
            this.txtBSSSendDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(711, 221);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "BSS Send Delay";
            // 
            // button6
            // 
            this.button6.Enabled = false;
            this.button6.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.Location = new System.Drawing.Point(904, 277);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(40, 18);
            this.button6.TabIndex = 27;
            this.button6.Text = "Set";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // txtTDLSSendDelayWait
            // 
            this.txtTDLSSendDelayWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTDLSSendDelayWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTDLSSendDelayWait.Enabled = false;
            this.txtTDLSSendDelayWait.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtTDLSSendDelayWait.ForeColor = System.Drawing.Color.Navy;
            this.txtTDLSSendDelayWait.Location = new System.Drawing.Point(842, 279);
            this.txtTDLSSendDelayWait.Name = "txtTDLSSendDelayWait";
            this.txtTDLSSendDelayWait.Size = new System.Drawing.Size(57, 18);
            this.txtTDLSSendDelayWait.TabIndex = 26;
            this.txtTDLSSendDelayWait.Text = "1";
            this.txtTDLSSendDelayWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(711, 279);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "TDLS Send Delay Wait";
            // 
            // button7
            // 
            this.button7.Enabled = false;
            this.button7.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.Location = new System.Drawing.Point(905, 238);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(39, 18);
            this.button7.TabIndex = 24;
            this.button7.Text = "Set";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // txtBSSSendDelayWait
            // 
            this.txtBSSSendDelayWait.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtBSSSendDelayWait.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBSSSendDelayWait.Enabled = false;
            this.txtBSSSendDelayWait.Font = new System.Drawing.Font("Tahoma", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBSSSendDelayWait.ForeColor = System.Drawing.Color.Navy;
            this.txtBSSSendDelayWait.Location = new System.Drawing.Point(842, 238);
            this.txtBSSSendDelayWait.Name = "txtBSSSendDelayWait";
            this.txtBSSSendDelayWait.Size = new System.Drawing.Size(57, 18);
            this.txtBSSSendDelayWait.TabIndex = 23;
            this.txtBSSSendDelayWait.Text = "2";
            this.txtBSSSendDelayWait.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(711, 238);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "BSS Send Delay Wait";
            // 
            // btnUpdateMediumListenDist
            // 
            this.btnUpdateMediumListenDist.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdateMediumListenDist.Location = new System.Drawing.Point(904, 344);
            this.btnUpdateMediumListenDist.Name = "btnUpdateMediumListenDist";
            this.btnUpdateMediumListenDist.Size = new System.Drawing.Size(30, 19);
            this.btnUpdateMediumListenDist.TabIndex = 33;
            this.btnUpdateMediumListenDist.Text = "Set";
            this.btnUpdateMediumListenDist.UseVisualStyleBackColor = true;
            this.btnUpdateMediumListenDist.Click += new System.EventHandler(this.btnUpdateMediumListenDist_Click);
            // 
            // txtMediumListenDistance
            // 
            this.txtMediumListenDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMediumListenDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediumListenDistance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMediumListenDistance.ForeColor = System.Drawing.Color.Navy;
            this.txtMediumListenDistance.Location = new System.Drawing.Point(841, 346);
            this.txtMediumListenDistance.Name = "txtMediumListenDistance";
            this.txtMediumListenDistance.Size = new System.Drawing.Size(57, 17);
            this.txtMediumListenDistance.TabIndex = 32;
            this.txtMediumListenDistance.Text = "200";
            this.txtMediumListenDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(707, 346);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 13);
            this.label7.TabIndex = 31;
            this.label7.Text = "Medium Listen Distance";
            // 
            // btnUpdateMediumRecDist
            // 
            this.btnUpdateMediumRecDist.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdateMediumRecDist.Location = new System.Drawing.Point(904, 326);
            this.btnUpdateMediumRecDist.Name = "btnUpdateMediumRecDist";
            this.btnUpdateMediumRecDist.Size = new System.Drawing.Size(30, 19);
            this.btnUpdateMediumRecDist.TabIndex = 30;
            this.btnUpdateMediumRecDist.Text = "Set";
            this.btnUpdateMediumRecDist.UseVisualStyleBackColor = true;
            this.btnUpdateMediumRecDist.Click += new System.EventHandler(this.btnUpdateMediumRecDist_Click);
            // 
            // txtMediumReceiveDistance
            // 
            this.txtMediumReceiveDistance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.txtMediumReceiveDistance.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMediumReceiveDistance.Font = new System.Drawing.Font("Tahoma", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtMediumReceiveDistance.ForeColor = System.Drawing.Color.Navy;
            this.txtMediumReceiveDistance.Location = new System.Drawing.Point(841, 328);
            this.txtMediumReceiveDistance.Name = "txtMediumReceiveDistance";
            this.txtMediumReceiveDistance.Size = new System.Drawing.Size(57, 17);
            this.txtMediumReceiveDistance.TabIndex = 29;
            this.txtMediumReceiveDistance.Text = "100";
            this.txtMediumReceiveDistance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(707, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(128, 13);
            this.label8.TabIndex = 28;
            this.label8.Text = "Medium Receive Distance";
            // 
            // cmdCreateOneAPTwoSta
            // 
            this.cmdCreateOneAPTwoSta.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdCreateOneAPTwoSta.Location = new System.Drawing.Point(694, 28);
            this.cmdCreateOneAPTwoSta.Name = "cmdCreateOneAPTwoSta";
            this.cmdCreateOneAPTwoSta.Size = new System.Drawing.Size(36, 19);
            this.cmdCreateOneAPTwoSta.TabIndex = 34;
            this.cmdCreateOneAPTwoSta.Text = "1/2";
            this.cmdCreateOneAPTwoSta.UseVisualStyleBackColor = true;
            this.cmdCreateOneAPTwoSta.Click += new System.EventHandler(this.cmdCreateOneAPTwoSta_Click);
            // 
            // cmdAdd1APforSTA
            // 
            this.cmdAdd1APforSTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cmdAdd1APforSTA.Location = new System.Drawing.Point(736, 28);
            this.cmdAdd1APforSTA.Name = "cmdAdd1APforSTA";
            this.cmdAdd1APforSTA.Size = new System.Drawing.Size(36, 19);
            this.cmdAdd1APforSTA.TabIndex = 35;
            this.cmdAdd1APforSTA.Text = "1/4";
            this.cmdAdd1APforSTA.UseVisualStyleBackColor = true;
            this.cmdAdd1APforSTA.Click += new System.EventHandler(this.cmdAdd1APforSTA_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 375);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.cmdAdd1APforSTA);
            this.Controls.Add(this.btnUpdateMediumListenDist);
            this.Controls.Add(this.cmdCreateOneAPTwoSta);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.txtMediumListenDistance);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnUpdateMediumRecDist);
            this.Controls.Add(this.txtMediumReceiveDistance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtTDLSSendDelayWait);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtBSSSendDelayWait);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtBSSSendDelay);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTDLSSendDelay);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnSetMediumSendRatio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMediumSendRatio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSetUpdateInterval);
            this.Controls.Add(this.txtUpdateInterval);
            this.Controls.Add(this.lblUpdateIntervalDescr);
            this.Controls.Add(this.btnShowMediumInfo);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnStopMedium);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.button2);
            this.Name = "MainForm";
            this.Text = "SLS - Smart Link Selection - Visualisator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtConsole;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStopMedium;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openDLGOpenSimulationSettings;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnShowMediumInfo;
        private System.Windows.Forms.Timer tmrGUISlow;
        private System.Windows.Forms.Label lblUpdateIntervalDescr;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox txtUpdateInterval;
        private System.Windows.Forms.Button btnSetUpdateInterval;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTAToolStripMenuItem;
        private System.Windows.Forms.Button btnSetMediumSendRatio;
        private System.Windows.Forms.TextBox txtMediumSendRatio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtTDLSSendDelay;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtBSSSendDelay;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.TextBox txtTDLSSendDelayWait;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.TextBox txtBSSSendDelayWait;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnUpdateMediumListenDist;
        private System.Windows.Forms.TextBox txtMediumListenDistance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnUpdateMediumRecDist;
        private System.Windows.Forms.TextBox txtMediumReceiveDistance;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button cmdCreateOneAPTwoSta;
        private System.Windows.Forms.Button cmdAdd1APforSTA;
    }
}

