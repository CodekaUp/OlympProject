namespace OlympProject.WebApi.Models
{
    public class LocationPoint
    {
        public long Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateTimeOfVisitLocationPoint { get; set; }
        public Animal? Animal { get; set; }
    }
}
