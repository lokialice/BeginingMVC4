using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HaveYouSeenMe.Models
{
    public class PictureModel
    {
        [Required]
        public HttpPostedFileBase PictureFile { get; set; }
    }
}