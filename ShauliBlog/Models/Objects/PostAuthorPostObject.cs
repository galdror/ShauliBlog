using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models.Objects
{
    public class PostAuthorPostObject
    {
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Display(Name = "Posts")]
        public IEnumerable<string> PostTitles { get; set; }
    }
}