using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Entities
{
    public class Post : EntityBase
    {
        public string Title { get; set; } = default!;
        public string Texte { get; set; } = default!;
        public List<PicturePost> Pictures { get; set; } = default!;
        public int Like { get; set; }
        public int Dislike { get; set; }
        public List<Hashtag> Hashtags { get; set; } = default!;
        public List<Comment> Comments { get; set; } = default!;
        public List<Category> Categories { get; set; } = default!;
        public User User { get; set; } = default!;
        public Guid UserId { get; set; }
    }
}
