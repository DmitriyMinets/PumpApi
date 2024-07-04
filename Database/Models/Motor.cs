namespace Database.Models
{
    public class Motor : BaseEntity
    {
        public string Name { get; set; } = null!;
        public double Power { get; set; }
        public double Current {  get; set; }
        public double RatedSpeed { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
    }
}
