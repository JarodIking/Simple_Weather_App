using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Simple_Weather_App
{
    public class WeatherData
    {
        public Coord? Coord { get; set; }
        public List<Weather>? Weather { get; set; }

        [JsonProperty("base")]
        public string? Base { get; set; }
        public Main? Main { get; set; }
        public int? Visibility { get; set; }
        public Wind? Wind { get; set; }
        public Rain? Rain { get; set; }
        public Clouds? Clouds { get; set; }
        public int? Dt { get; set; }
        public Sys? Sys { get; set; }
        public int? Timezone { get; set; }
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Cod { get; set; }
    }
}
