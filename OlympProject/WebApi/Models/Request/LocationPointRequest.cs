namespace OlympProject.WebApi.Models.Request
{
    public class LocationPointRequest
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateTimeOfVisitLocationPoint { get; set; }
    }
}
