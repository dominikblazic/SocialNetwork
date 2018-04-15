using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebook.Domena.Models
{
    public class Post
    {
        public string Id { get; set; }
        public string Caption { get; set; }
        public string Text { get; set; }
        public DateTime PostTime { get; set; }
    }
}
