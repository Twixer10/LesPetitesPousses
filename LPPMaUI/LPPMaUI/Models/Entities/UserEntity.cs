using SQLite;

namespace LPPMaUI.Models.Entities
{
    [Table("user")]
    public class UserEntity : BaseEntity
    {
        public string Firstname { get; set; } = default!;
        public string Lastname { get; set; } = default!;
        public string Pseudo { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string? PictureURL { get; set; }
        public Guid? PictureId { get; set; }
        public bool IsAdmin { get; set; } = default!;
        public int Karma { get; set; }
        public int Report { get; set; }
        //public List<Sanction> Sanctions { get; set; } = default!;
        //public List<User> Blocked { get; set; } = default!;
        //public List<Photo> Photos { get; set; } = default!;
        //public List<Product> InterestedProducts { get; set; } = default!;
        //public List<Product> SoldProduct { get; set; } = default!;
        //public List<Product> BoughtProducts { get; set; } = default!;
        //public List<Chat> SellerChats { get; set; } = default!;
        //public List<Chat> InterestedChats { get; set; } = default!;
        //public List<Comment> Comments { get; set; } = default!;
        //public List<Post> Posts { get; set; } = default!;
    }
}
