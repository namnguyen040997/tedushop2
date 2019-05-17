using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Model
{
    [Table("ApplicationUsers")]
    public class ApplicationUser
    {
        [Key]
        public string Id { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public DateTime? Birthday { get; set; }

        public string Email { get; set; }

        [Required]
        public bool EmailConfirmed { get; set; }

        public string PasswordHash { get; set; }

        public string SecurityStamp { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public bool PhoneNumberConfirmed { get; set; }

        [Required]
        public bool TwoFactorEnabled { get; set; }

        public DateTime? LockoutEndDateUtc { get; set; }

        [Required]
        public bool LockoutEnabled { get; set; }

        [Required]
        public int AccessFailedCount { get; set; }

        public string UserName { get; set; }

        public virtual IEnumerable<IdentityUserLogin> IdentityUserLogins { get; set; }

        public virtual IEnumerable<IdentityUserClaim> IdentityUserClaims{ get; set; }
    }
}
