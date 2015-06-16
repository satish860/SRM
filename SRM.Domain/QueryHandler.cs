using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain
{
    public class QueryHandler : IQueryHandler
    {
        private readonly IComponentContext containerContext;
        public QueryHandler(IComponentContext containerContext)
        {
            this.containerContext = containerContext;
        }
        public async Task<TOutput> Handle<TInput, TOutput>(TInput input)
        {
            var queryHandler = this.containerContext.Resolve<IQueryFor<TInput,TOutput>>();
            return await queryHandler.ExecuteFor(input);          
        }

        public async Task<IEnumerable<TOutput>> ExecuteAll<TOutput>()
        {
            var queryHandler = this.containerContext.Resolve<IQueryAll<TOutput>>();
            return await queryHandler.Execute();  
        }
    }
}
