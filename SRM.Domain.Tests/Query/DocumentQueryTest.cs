using SRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Should;
using Microsoft.Azure.Documents.Client;
using Fixie;

namespace SRM.Domain.Tests.Query
{
    public class DocumentQueryTest
    {
        private readonly IConnectionManager connectionManager;
        public DocumentQueryTest(IConnectionManager connectionManager)
        {
            this.connectionManager = connectionManager;
        }
        public async Task Should_be_Able_To_Get_Document()
        {
            var client = await this.connectionManager.GetOrCreateDatabase();
            client.ShouldNotBeNull();
            var collection = await this.connectionManager.GetOrCreateCollection("studentCollection");
            collection.DocumentsLink.ShouldNotBeEmpty();
        }
    }
}
