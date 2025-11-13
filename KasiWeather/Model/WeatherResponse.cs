using _6.KasiWeather.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace KasiWeather.Model
{
    public class WeatherResponse
    {
        [JsonPropertyName("latitude")]
        public decimal Latitude {  get; set; }
        [JsonPropertyName("longitude")]
        public decimal Longitude { get; set; }
        [JsonPropertyName("current")]
        public Current Current { get; set; }
    }
}
