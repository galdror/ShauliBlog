using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShauliBlog.Models
{
    public class Post
    {
        public int ID { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Url)]
        [Display(Name = "Website Link")]
        public string Website { get; set; }

        [Required]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date")]
        public DateTime PostDate { get; set; }


        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Content")]
        public string Content { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Image")]
        public string Image { get; set; }

        [DataType(DataType.ImageUrl)]
        [Display(Name = "Video")]
        public string Video { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}