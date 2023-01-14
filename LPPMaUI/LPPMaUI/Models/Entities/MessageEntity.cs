using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPPMaUI.Models.Entities
{
    [Table("message")]
    public class MessageEntity : BaseEntity
    {
        public Guid UserId { get; set; }
        public string Text { get; set; } = default!;
    }
}
