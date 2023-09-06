using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Weather_App
{
    public class WeatherData
    {
        public Coord? coord { get; set; }
        public List<Weather>? weather { get; set; }
        public string? Base { get; set; }
        public Main? main { get; set; }
        public int? visibility { get; set; }
        public Wind? wind { get; set; }
        public Rain? rain { get; set; }
        public Clouds? clouds { get; set; }
        public int? dt { get; set; }
        public Sys? sys { get; set; }
        public int? timezone { get; set; }
        public int? id { get; set; }
        public string? name { get; set; }
        public int? cod { get; set; }
    }
}
