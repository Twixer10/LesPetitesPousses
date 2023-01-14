using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPPMaUI.Models.Entities
{
    [Table("chatMessage")]
    public class ChatMessageEntity : BaseEntity
    {
        public Guid ChatId { get; set; }
        public ChatEntity Chat { get; set; }
        public Guid MessageId { get; set; }
        public MessageEntity Message { get; set; }
    }
}
