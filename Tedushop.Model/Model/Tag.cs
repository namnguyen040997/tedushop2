using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Model
{
    [Table("Tags")]
    public class Tag
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Type { get; set; }

        public virtual IEnumerable<ProductTag> ProductTags { get; set; }

        public virtual IEnumerable<PostTag> PostTags { get; set; }
    }
}
