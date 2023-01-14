using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Entities
{
    public class Chat : EntityBase
    {
        public User Seller { get; set; } = default!;
        public Guid SellerId { get; set; } = default!;
        public User Buyer { get; set; } = default!;
        public Guid BuyerId { get; set; } = default!;
        
        public Product Product { get; set; } = default!;
        public Guid ProductId { get; set; } = default!;
        public List<Message> Messages { get; set; } = default!;
    }
}
