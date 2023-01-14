using LPPMaUI.Models.Entities;

namespace LPPMaUI.Models.DTOs
{
    public class ProductDTO
    {
        public Guid Id { get; set; } = default!;
        //public List<PictureProduct>? Pictures { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Price { get; set; } = default!;
        public bool IsSold { get; set; } = default!;
        public UserDTO Seller { get; set; } = default!;
        public Guid SellerId { get; set; } = default!;
        public UserDTO? Buyer { get; set; }
        public Guid? BuyerId { get; set; }
        public List<UserDTO>? Interesteds { get; set; }
        //public List<Comment>? Comments { get; set; }

        public ProductDTO() { }

        public ProductDTO(ProductEntity product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            IsSold = product.IsSold;
            SellerId = product.SellerId;
            BuyerId = product.BuyerId;
        }

        public ProductEntity ToProduct()
        {
            return new ProductEntity()
            {
                Id = Id,
                Name = Name,
                Description = Description,
                Price = Price,
                IsSold = IsSold,
                SellerId = SellerId,
                BuyerId = BuyerId,
            };
        }
    }
}
