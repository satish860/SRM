using Autofac;
using SRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SRM.Domain.Tests
{
    public class StudentTests
    {
        private ICommandBus commandBus;
        public StudentTests(ICommandBus commandBus)
        {
            this.commandBus = commandBus;
        }
        public async Task Should_be_able_add_new_Student()
        {
            await this.commandBus.Send<Student>(new Student { Name = "Satish" });

        }
    }
}
