using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniFacebook.Models
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Caption { get; set; }

        [Required(ErrorMessage = "Post cannot be empty")]
        [RegularExpression(@"^.{5,}$", ErrorMessage = "Minimum 5 characters required")]
        [StringLength(450, ErrorMessage = "The post cannot be longer than 450 characters")]
        public string Text { get; set; }

        public DateTime PostTime { get; set; }
        
    }
}