using KasiWeather.Model;
using KasiWeather;
using System.Text.Json;

namespace _6.KasiWeather.Helper
{
    public static class WeatherHelper
    {
        public static string BaseUrl = "https://api.open-meteo.com/v1/forecast";
        public static readonly HttpClient client = new HttpClient();
        public static List<City> GenerateCities()
        {
            return new List<City>() {
                                { new City(1, "Cape Town", -33.9249, 18.4241)},
                                { new City(2, "Johannesburg", -26.2041, 28.0473) },
                                { new City(3, "Durban", -29.8587, 31.0218) },
                                { new City(4, "Pretoria", -25.7479, 28.2293)},
                                { new City(5, "Port Elizabeth", -33.9611, 25.6141)},
                                { new City(6, "Bloemfontein", -29.1163, 26.2156)},
                                { new City(7, "London", 51.5074, -0.1278)},
                                { new City(8, "Paris", 48.8566, 2.3522)},
                                { new City(9, "New York", 40.7128, -74.0060)},
                                { new City(10, "Tokyo", 35.6895, 139.6917)},
                                { new City(11, "Sydney", -33.8688, 151.2093)},
                                };
        }

        public static void ShoWAllCities(List<City> cities)
        {
            Console.WriteLine("---------------------------------------------------------------");
            foreach (var city in cities)
            {
                Console.WriteLine($"{city.Id} - {city.Name}");
            }
            Console.WriteLine("---------------------------------------------------------------");
        }

        public static City GetCityById(int id, List<City> cities)
        {
            return cities.FirstOrDefault(c => c.Id == id);
        }

        public static async Task GetWeatherAsync(City city)
        {
            try
            {
                // Construct the API URL with city, API key, and units (metric for Celsius)
                string url = $"{BaseUrl}?latitude={city.Latitude}&longitude={city.Longitude}&current=weather_code";

                HttpResponseMessage response = await client.GetAsync(url);

                // Check if the request was successful
                response.EnsureSuccessStatusCode();

                string jsonResponse = await response.Content.ReadAsStringAsync();

                // Deserialize the JSON response into our C# objects
                var weatherData = JsonSerializer.Deserialize<WeatherResponse>(jsonResponse, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                if (weatherData != null)
                {
                    // Display the weather information
                    var weather = DecodeWeatherCode(weatherData.Current.WeatherCode);
                    Console.WriteLine($"\n--- Current Weather in {city.Name} ---");
                    Console.WriteLine($"Weather: {weather}");
                    Console.WriteLine($"\n--------------------------------------");
                }
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\nRequest error: {e.Message}");
                Console.WriteLine("Please ensure the city Id is valid.");
            }
            catch (JsonException e)
            {
                Console.WriteLine($"\nError parsing weather data: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nAn unexpected error occurred: {e.Message}");
            }
        }

        public static string DecodeWeatherCode(int code) => code switch
        {
            0 => "Clear sky",
            1 => "Mainly clear",
            2 => "partly cloudy",
            3 => "Overcast",
            >= 51 and <= 56 => "Drizzle",
            >= 61 and <= 69 => "Rain",
            >= 71 and <= 79 => "Snow",
            >= 80 and <= 82 => "Rain showers",
            >= 85 and <= 86 => "Snow showers",
            >= 95 and <= 99 => "Thunderstorm",
            _ => "Weather cannot be determined!"
        };
    }
}
