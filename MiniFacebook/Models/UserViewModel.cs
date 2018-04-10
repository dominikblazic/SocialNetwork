using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFacebook.Models
{
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public byte[] UserPhoto { get; set; }
        public string DrzavaNaziv { get; set; }
    }
}