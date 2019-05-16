using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Model
{
    [Table("Errors")]
    public class Error
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Message { get; set; }

        public string StackTrace { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
