using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models.Objects
{
    public class PostCommentBriefObject
    {
        [Display(Name = "Post Title")]
        public string PostTitle { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
    }
}