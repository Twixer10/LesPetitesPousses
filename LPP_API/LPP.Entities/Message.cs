namespace LPP.Entities
{
    public class Message : EntityBase
    {
        public User User { get; set; } = default!;
        public Guid UserId { get; set; }
        public string Texte { get; set; } = default!;
        public bool IsRead { get; set; } = default!;
        public Chat Chat { get; set; } = default!;
        public Guid ChatId { get; set; }
    }
}
