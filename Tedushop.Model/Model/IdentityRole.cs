using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Model
{
    [Table("IdentityRoles")]
    public class IdentityRole
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
