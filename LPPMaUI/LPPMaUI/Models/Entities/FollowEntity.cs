using SQLite;


namespace LPPMaUI.Models.Entities
{
    [Table("follow")]
    public class FollowEntity : BaseEntity
    {
        public UserEntity Follower { get; set; }
        public Guid FollowerId { get; set; }
        public UserEntity Followed { get; set; }
        public Guid FollowedId { get; set; }
    }
}
