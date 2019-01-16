using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Stock
    {
        public DateTime Date { get; set; }
        public string Symbol { get; set; }
        public float Open { get; set; }
        public float Close { get; set; }
        public float Low { get; set; }
        public float High { get; set; }
        public double Volume { get; set; }
        public double Performance { get; set; }
    }
}
