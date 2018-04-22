using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFacebook.Models
{
    public class PostViewModel
    {
        public string Id { get; set; }
        public string Caption { get; set; }
        public string Text { get; set; }
        public DateTime PostTime { get; set; }
    }
}