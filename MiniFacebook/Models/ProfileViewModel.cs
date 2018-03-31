using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniFacebook.Models
{
    public class ProfileViewModel
    {
        [Display(Name = "UserPhoto")]
        public byte[] UserPhoto { get; set; }
    }
}