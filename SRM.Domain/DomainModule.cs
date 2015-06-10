﻿using Autofac;
using SRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain
{
    public class DomainModule:Autofac.Module
    {
        public DomainModule()
        {

        }

        protected override void Load(ContainerBuilder builder)
        {
            var assembly=Assembly.GetExecutingAssembly();
            var entityAssembly = typeof(CreateStudentCommand).Assembly;
            builder.RegisterAssemblyTypes(assembly,entityAssembly)
                .AsClosedTypesOf(typeof(ICommandHandler<>));
            builder.RegisterType<CommandBus>().As<ICommandBus>();
        }
    }
}