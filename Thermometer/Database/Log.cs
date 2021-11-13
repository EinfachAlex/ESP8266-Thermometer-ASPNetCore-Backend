using System;
using System.Collections.Generic;

#nullable disable

namespace Thermometer.Database
{
    public partial class Log
    {
        public double Temp { get; set; }
        public double Humi { get; set; }
        public double Co2 { get; set; }
        public double Timestamp { get; set; }
    }
}
