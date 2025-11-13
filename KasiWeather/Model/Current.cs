using System.Text.Json.Serialization;

namespace _6.KasiWeather.Model
{
    public class Current
    {
        [JsonPropertyName("Weather_code")]
        public int WeatherCode { get; set; }
    }
}
