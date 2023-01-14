using SQLite;

namespace LPPMaUI.Models.Entities
{
    public class BaseEntity
    {
        [PrimaryKey]
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
