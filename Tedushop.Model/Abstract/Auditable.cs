using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Abstract
{
    public class Auditable : IAuditable
    {
        public DateTime? CreatedDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDesciption { get; set; }
        public bool Status { get; set; }
    }
}
