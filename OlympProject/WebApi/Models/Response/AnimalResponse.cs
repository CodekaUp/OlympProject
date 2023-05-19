using static OlympProject.WebApi.Models.Animal;

namespace OlympProject.WebApi.Models.Response
{
    public class AnimalResponse
    {
        public long Id { get; set; }
        public float Weight { get; set; }
        public float Length { get; set; }
        public float Height { get; set; }
        public Genders Gender { get; set; }
        public LifeStatuses LifeStatus { get; set; }
        public DateTime ChippingDateTime { get; set; }
        public int ChipperId { get; set; }
        public long ChippingLocationId { get; set; }
        public DateTime? DeathDateTime { get; set; }
    }
}
