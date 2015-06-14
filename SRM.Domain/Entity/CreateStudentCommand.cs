using SRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using Newtonsoft.Json;

namespace SRM.Domain.Entity
{
    public class CreateStudentCommand:ICommandHandler<Student>
    {
        private readonly IConnectionManager connectionManager;
       
        public CreateStudentCommand(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task Execute(Student input)
        {
            try
            {
                var client= await this.connectionManager.GetOrCreateDatabase();
                var collection = await this.connectionManager.GetOrCreateCollection("studentCollection");
                var student = await client.CreateDocumentAsync(collection.DocumentsLink, input);
            }
            catch (Exception ex)
            {

            }
        }
        
    }
}
