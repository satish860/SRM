using SRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain.Entity
{
    public class CreateStudentCommand:ICommandHandler<Student>
    {
        public Task Execute(Student input)
        {
            throw new NotImplementedException();
        }
    }
}
