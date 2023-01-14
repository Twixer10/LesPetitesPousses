using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Entities
{
    public class Product : EntityBase
    {
        public List<PictureProduct>? Pictures { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public int Price { get; set; }
        public bool IsSold { get; set; }
        public User Seller { get; set; } = default!;
        public Guid SellerId { get; set; }
        public User? Buyer { get; set; }
        public Guid? BuyerId { get; set; }
        public List<User>? Interesteds { get; set; }
        public List<Comment>? Comments { get; set; }
    }
}
