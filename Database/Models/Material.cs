namespace Database.Models
{
    public class Material : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
