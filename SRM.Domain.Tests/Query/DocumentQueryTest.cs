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
        private readonly IQueryHandler queryHandler;
        public DocumentQueryTest(IQueryHandler queryHandler)
        {
            this.queryHandler = queryHandler;
        }
        public async Task Should_be_Able_To_Get_Document()
        {
            var srmDocument = await this.queryHandler.Handle<string, SrmDocument>(string.Empty);
            srmDocument.ShouldNotBeNull();
            var client = srmDocument.Client;
            client.ShouldNotBeNull();
        }
    }
}
