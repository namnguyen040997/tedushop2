using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Model
{
    [Table("IdentityUserClaims")]
    public class IdentityUserClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string UserId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        [Required]
        public string ApplicationUser_Id { get; set; }

        [ForeignKey("ApplicationUser_Id")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
