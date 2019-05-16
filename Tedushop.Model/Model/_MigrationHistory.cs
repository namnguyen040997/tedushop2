using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Model
{
    [Table("_MigrationHistory")]
    public class _MigrationHistory
    {
        [Key]
        public string MigrationId { get; set; }

        [Key]
        public string ContextKey { get; set; }

        [Required]
        public Byte Model { get; set; }

        [Required]
        public string ProductVersion { get; set; }
    }
}
