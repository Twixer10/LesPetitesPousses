namespace LPP.Entities;

public class Follow : EntityBase
{
    public User Follower { get; set; }
    public Guid FollowerId { get; set; }
    
    public User Followed { get; set; }
    public Guid FollowedId { get; set; }
}