using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.Entities
{
    public class Sanction : EntityBase
    {
        public SanctionDuration Duration { get; set; }
        public SanctionType Type { get; set; }
        public User User { get; set; } = default!;
        public Guid UserId { get; set; }

    }
}
