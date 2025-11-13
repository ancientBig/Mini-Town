
namespace KasiWeather
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public City(int id, string name, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            Latitude = latitude;
            Longitude = longitude;
        }

        public override string ToString()
        {
            return $"{Name} (Lat: {Latitude}, Lon: {Longitude})";
        }
    }
}
