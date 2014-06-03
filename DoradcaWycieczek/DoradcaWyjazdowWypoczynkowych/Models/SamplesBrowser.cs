using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoradcaWyjazdowWypoczynkowych.Models
{
    public class SamplesBrowser
    {
        public class RadarChartData
        {
            public static List<RadarChartData> GetData()
            {
                var data = new List<RadarChartData>();

                data.Add(new RadarChartData("France", 65.62, 46.45));
                data.Add(new RadarChartData("Canada", 75.54, 63.78));
                data.Add(new RadarChartData("Germany", 60.45, 86.45));
                data.Add(new RadarChartData("USA", 34.73, 30.76));
                data.Add(new RadarChartData("Italy", 85.42, 23.79));
                data.Add(new RadarChartData("Spain", 55.9, 35.67));
                data.Add(new RadarChartData("Russia", 63.6, 89.56));
                data.Add(new RadarChartData("Sweden", 55.1, 67.45));
                data.Add(new RadarChartData("Japan", 77.2, 38.98));

                return data;
            }

            public RadarChartData(string label, double value1, double value2)
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
}