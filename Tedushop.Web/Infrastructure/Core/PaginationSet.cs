using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tedushop.Web.Infrastructure.Core
{
    public class PaginationSet<T>
    {
        public int Page { set; get; }

        public int Count
        {
            get
            {
                return (Items != null) ? Items.Count() : 0; 
            }
        }

        public int TotalPages { set; get; }
        public int TotalCount { set; get; } //Tổng số bản ghi
        public int MaxPage { set; get; }
        public IEnumerable<T> Items { set; get; } //Lưu 1 list Item 
    }
}