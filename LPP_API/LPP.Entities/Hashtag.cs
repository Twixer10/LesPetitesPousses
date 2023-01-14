using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Entities
{
    public class Hashtag : EntityBase
    {
        public string Name { get; set; } = default!;
        public List<Post> Post { get; set; } = default!;
        public List<Photo> Photo { get; set; } = default!;
    }
}