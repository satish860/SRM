using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain
{
    public interface IQueryFor<TInput,TOutput>
    {
        Task<TOutput> ExecuteFor(TInput input);
    }
}
