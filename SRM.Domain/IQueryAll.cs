using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain
{
    public interface IQueryAll<TOutput>
    {
        Task<IEnumerable<TOutput>> Execute();
    }
}
