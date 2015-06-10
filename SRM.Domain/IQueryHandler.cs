using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain
{
    public interface IQueryHandler
    {
        Task<TOutput> Handle<TInput, TOutput>(TInput input);

        Task<TOutput> ExecuteAll<TOutput>();
    }
}
