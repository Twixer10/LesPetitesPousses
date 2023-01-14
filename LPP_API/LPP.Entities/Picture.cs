using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Entities
{
    public abstract class Picture<TEntity> : EntityBase where TEntity : EntityBase 
    {
        
        public string PictureURL { get; set; } = default!;
        public Guid ItemId { get; set; } = default!;
        public TEntity Item { get; set; } = default!;
    }
}
