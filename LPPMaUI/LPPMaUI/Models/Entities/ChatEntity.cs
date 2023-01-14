using SQLite;

namespace LPPMaUI.Models.Entities
{
    [Table("chat")]
    public class ChatEntity : BaseEntity
    {
        public UserEntity Receiver { get; set; } = default!;
        public UserEntity Current { get; set; } = default!;
        public string ProductImage { get; set; } = default!;
        public bool IsRead { get; set; } = default!;
    }
}
