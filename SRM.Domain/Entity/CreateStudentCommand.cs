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
        private string endPointUrl = "https://srmdb.documents.azure.com:443/";
        private string AuthorizationKey = "hJE9vaWWp2xUCKhG32iVMt4GROu4egyYwszwQstrkcRa5wjuclSi390plLNE2TE4ETxyFxfI50RJuQXWtQjEBg==";
        public CreateStudentCommand()
        {

        }

        public async Task Execute(Student input)
        {
            var client = new DocumentClient(new Uri(endPointUrl), AuthorizationKey);
            var database= await client.CreateDatabaseAsync(new Database { Id = "srm" });
            var collection = await client.CreateDocumentCollectionAsync(database.Resource.CollectionsLink, new DocumentCollection { Id = "studentCollection" });
            var student= await client.CreateDocumentAsync(collection.Resource.DocumentsLink, input);

        }
    }
}
