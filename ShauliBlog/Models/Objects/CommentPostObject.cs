using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models.Objects
{
    public class CommentPostObject
    {
        [Display(Name = "Comment")]
        public string CommentTitle { get; set; }

        [Display(Name = "Post")]
        public string PostTitle { get; set; }
    }
}