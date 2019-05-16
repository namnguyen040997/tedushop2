using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Model.Abstract
{
    public interface IAuditable
    {
        DateTime? CreatedDate { get; set; }
        string CreateBy { get; set; }
        DateTime? UpdateDate { get; set; }
        string UpdateBy { get; set; }

        string MetaKeyword { get; set; }
        string MetaDesciption { get; set; }

        bool Status { get; set; }
    }
}
