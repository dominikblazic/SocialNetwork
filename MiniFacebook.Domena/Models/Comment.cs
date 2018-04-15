using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebook.Domena.Models
{
    public class Comment
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public DateTime CommentTime { get; set; }
    }
}
