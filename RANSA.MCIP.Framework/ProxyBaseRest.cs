using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RANSA.MCIP.Framework
{
    public class ProxyBaseRest : IDisposable
    {
        public Y DeserializarJSON<T, Y>(T request, string url, bool consultaSap = false)
        {
            var utilitarioRest = new UtilitarioRest();
            return utilitarioRest.DeserializarJSON<T, Y>(request, url, consultaSap: consultaSap);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }
        ~ProxyBaseRest()
        {
            Dispose(false);
        }
    }
}
