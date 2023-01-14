using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Entities
{
    public class Comment : EntityBase
    {
        public string Texte { get; set; } = default!;
        public int Like { get; set; }
        public int Dislike { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; } = default!;


    }
}
