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
        private readonly IQueryHandler queryHander;

        public CreateStudentCommand(IQueryHandler queryHander)
        {
            this.queryHander = queryHander;
        }

        public async Task Execute(Student input)
        {
            var document =await this.queryHander.Handle<string, SrmDocument>(string.Empty);
            await document.Client.CreateDocumentAsync(document.DocumentLink, input);
        }
    }
}
