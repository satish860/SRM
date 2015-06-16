using SRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Linq;

namespace SRM.Domain.Query
{
    public class StudentQuery : IQueryAll<Student>
    {
        private readonly IConnectionManager connectionManager;

        public StudentQuery(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }

        public async Task<IEnumerable<Student>> Execute()
        {
            var db =await this.connectionManager.GetOrCreateDatabase();
            var collection = await this.connectionManager.GetOrCreateCollection("studentCollection");
            return db.CreateDocumentQuery<Student>(collection.DocumentsLink).ToArray();
        }
    }
}
