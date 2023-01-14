using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LPP.DTO
{
    public class PicturesDto
    {
        public List<IFormFile>? Pictures { get; set; }
    }
}
