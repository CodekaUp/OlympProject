namespace OlympProject.WebApi.Models
{
    public class Animal
    {
        public enum Genders
        {
            Male,
            Female,
            Other,
        }
        public enum LifeStatuses
        {
            Alive,
            Dead,
        }
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
        public List<AnimalType> AnimalTypes { get; set; } = new();
        public List<LocationPoint> LocationPoints { get; set; } = new();
    }
}
