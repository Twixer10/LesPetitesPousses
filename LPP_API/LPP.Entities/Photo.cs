namespace LPP.Entities
{
    public class Photo : EntityBase
    {
        public string? Description { get; set; }
        public int Like { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = default!;
        public List<PicturePhoto> Pictures { get; set; } = default!;
        public List<Comment> Comments { get; set; } = default!;
        public List<Hashtag> Hashtags { get; set; } = default!;
    }
}
