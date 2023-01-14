using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPPMaUI.Models.Entities
{
    [Table("Image")]
    public class ImageGalleryEntity : BaseEntity
    {
        public string ImageUrl { get; set; } = default!;
       
        
    }
}


