using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Model
{
    [Table("IdentityUserRoles")]
    public class IdentityUserRole
    {
        [Key]
        public string UserId { get; set; }

        [Key]
        public string RoleId { get; set; }

        [Required]
        public string IdentityRole_Id { get; set; }

        [Required]
        public string ApplicationUser_Id { get; set; }

        [ForeignKey("IdentityRole_Id")]
        public virtual IdentityRole IdentityRole { get; set; }

        [ForeignKey("ApplicationUser_Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }

    }
}
