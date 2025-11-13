using _6.KasiWeather.Helper;
using KasiWeather;
using KasiWeather.Model;
using System.Text.Json;

public class Program
{
    
    public static void Main(String[] args)
    {
        List<City> cities = WeatherHelper.GenerateCities();

        Console.WriteLine($"Please enter Id to get Weather:");
        WeatherHelper.ShoWAllCities(cities);

        try
        {
            int cityId = int.Parse(Console.ReadLine());

            if (cityId <= 0 || cityId > 11)
            {
                Console.WriteLine("\n Goodbye...");
                System.Environment.Exit(0);
            }
            else
            {
                var city = WeatherHelper.GetCityById(cityId, cities);
                if (city == null)
                {
                    Console.WriteLine("\n City is not found");
                    System.Environment.Exit(0);
                }
                else
                {
                    WeatherHelper.GetWeatherAsync(city).Wait();
                }
            }
            System.Environment.Exit(0);
        }
        catch (Exception ex)
        {
            Console.WriteLine("\n There was an error while processing your request");
            Console.WriteLine(ex.Message);
            System.Environment.Exit(0);
        }
        
    }
}