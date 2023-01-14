using LPP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.DTO
{
    public class ProductDto
    { 
        public Guid Id { get; set; } = default!;
        //public List<PictureProduct>? Pictures { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Price { get; set; } = default!;
        public bool IsSold { get; set; } = default!;
        public UserDto Seller { get; set; } = default!;
        public Guid SellerId { get; set; } = default!;
        public UserDto? Buyer { get; set; }
        public Guid? BuyerId { get; set; }
        public List<UserDto>? Interesteds { get; set; }
        //public List<Comment>? Comments { get; set; }

        public ProductDto() { }

        public ProductDto(Product product) {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            IsSold = product.IsSold;
            Seller = new UserDto(product.Seller);
            SellerId = product.SellerId;
            Buyer = product.Buyer is not null ? new UserDto(product.Buyer) : null;
            BuyerId = product.BuyerId;
        }

        public Product ToProduct()
        {
            return new Product()
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
