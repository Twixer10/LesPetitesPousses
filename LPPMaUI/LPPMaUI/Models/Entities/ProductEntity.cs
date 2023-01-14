using SQLite;

namespace LPPMaUI.Models.Entities
{
    [Table("product")]
    public class ProductEntity : BaseEntity
    {
        /*public List<string> PicturesUrl { get; set; } *//// TODO: changer en objet
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Price { get; set; }
        public bool IsSold { get; set; }
        public UserEntity Seller { get; set; } = default!;
        public Guid SellerId { get; set; }
        public UserEntity? Buyer { get; set; }
        public Guid? BuyerId { get; set; }
        //public List<UserEntity> Interesteds { get; set; }
        //public List<string> Comments { get; set; } /// TODO: changer en objet
    }
}
