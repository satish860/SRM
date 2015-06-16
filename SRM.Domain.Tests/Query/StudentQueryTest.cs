using SRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should;

namespace SRM.Domain.Tests.Query
{
    public class StudentQueryTest 
    {
        private readonly IQueryHandler hander;
        public StudentQueryTest(IQueryHandler hander)
        {
            this.hander = hander;
        }

        public async Task Should_be_Able_To_Get_All_Student()
        {
            var students=await this.hander.ExecuteAll<Student>();
            students.Count().ShouldBeGreaterThan(0);
            var student = students.First();
            student.Name.ShouldNotBeEmpty();
        }
    }
}
