using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sample.Models
{
    public class ChartData
    {
        public static List<ChartData> GetData()
        {
            var data = new List<ChartData>();

            data.Add(new ChartData("France", 65.62, 46.45));
            data.Add(new ChartData("Canada", 75.54, 63.78));
            data.Add(new ChartData("Germany", 60.45, 86.45));
            data.Add(new ChartData("USA", 34.73, 30.76));
            data.Add(new ChartData("Italy", 85.42, 23.79));
            data.Add(new ChartData("Spain", 55.9, 35.67));
            data.Add(new ChartData("Russia", 63.6, 89.56));
            data.Add(new ChartData("Sweden", 55.1, 67.45));
            data.Add(new ChartData("Japan", 77.2, 38.98));

            return data;
        }

        public ChartData(string label, double value1, double value2)
        {
            this.Label = label;
            this.Value1 = value1;
            this.Value2 = value2;
        }

        public string Label { get; set; }
        public double Value1 { get; set; }
        public double Value2 { get; set; }
    }
}