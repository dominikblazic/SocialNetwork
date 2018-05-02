using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniFacebook.Domena.Models
{
    public class Post
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Caption { get; set; }

        [Required]
        [StringLength(450, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Text { get; set; }

        public DateTime PostTime { get; set; }
        public virtual ICollection<Like> Likes { get; set; }
        public int NrOfLikes { get; set; }

    }
}
