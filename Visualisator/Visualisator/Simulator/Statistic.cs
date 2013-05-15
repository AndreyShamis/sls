﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Visualisator.Simulator
{
    class Statistic
    {
        public string   FileName        { set; get; }
        public string   SourceMAC       { set; get; }
        public string   DesctinationMAC { set; get; }
        public long     FileSize        { set; get; }
        public double   Time            { set; get; }
        public bool     TdlsUse         { set; get; }
        public short    PercentInTdls   { set; get; }
        public double   Speed           { set; get; }

        public Statistic()
        {
                
        }
    }
}