using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tedushop.Data.Infrastructure
{
    public class Disposable : IDisposable //Cho phép lớp nào kế thừa từ nó có thể tạo ra các phương thức tự động huỷ => Giải phóng bộ nhớ
    {
        private bool isDiposed;
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if(!isDiposed && disposing)
            {
                DisposeCore();
            }
            isDiposed = true;
        }
        protected virtual void DisposeCore()
        {

        }
    }
}
