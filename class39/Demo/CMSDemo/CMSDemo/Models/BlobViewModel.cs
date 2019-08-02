using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CMSDemo.Models
{
    public class BlobViewModel
    {
        [Required]
        public IFormFile Image { get; set; }
    }
}
