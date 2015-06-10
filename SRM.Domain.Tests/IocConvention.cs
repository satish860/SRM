using Autofac;
using Fixie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain.Tests
{
    public class IocConvention:Convention
    {
        private ILifetimeScope scope;
        public IocConvention()
        {
            InitializeContainer();
            ClassExecution
                .CreateInstancePerClass()
                .UsingFactory(GetFromContainer)
                .SortCases((caseA, caseB) => String.Compare(caseA.Name, caseB.Name, StringComparison.Ordinal));
        }

        private void InitializeContainer()
        {
            var componentAssembly = typeof(DomainModule).Assembly;
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyModules<DomainModule>(componentAssembly);
            var assembly=Assembly.GetExecutingAssembly();
            containerBuilder.RegisterAssemblyTypes(assembly)
                .AsSelf();
            IContainer container = containerBuilder.Build();
            this.scope = container.BeginLifetimeScope();
        }

        private object GetFromContainer(Type type)
        {
            return this.scope.Resolve(type);
        }
    }
}
