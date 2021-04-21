using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msa.Dal.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable
        where T : class
    {
        IRepository<T> Rep { get; }
        bool Save();
    }
}
