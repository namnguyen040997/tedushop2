using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Model
{
    [Table("IdentityUserLogins")]
    public class IdentityUserLogin
    {
        [Key]
        public string UserId { get; set; }

        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }

        [Required]
        public string ApplicationUser_Id { get; set; }

        [ForeignKey("ApplicationUser_Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
