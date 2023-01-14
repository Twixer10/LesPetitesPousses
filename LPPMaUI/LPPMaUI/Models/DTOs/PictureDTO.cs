using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPPMaUI.Models.DTOs
{
    public class PictureDTO
    {
        public List<IFormFile> Pictures { get; set; }
    }
}
