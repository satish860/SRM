using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain
{
    public class CommandBus : ICommandBus
    {
        private readonly IComponentContext container;
        public CommandBus(IComponentContext context)
        {
            this.container = context;
        }

        public async Task Send<TInput>(TInput input)
        {
            var commandhandlers = this.container.Resolve<IEnumerable<ICommandHandler<TInput>>>();
            IList<Task> taskList=new List<Task>();
            foreach (var handler in commandhandlers)
            {
                taskList.Add(handler.Execute(input));
            }
            await Task.WhenAll(taskList);
        }
    }
}
