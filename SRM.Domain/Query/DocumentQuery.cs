using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents.Linq;
using SRM.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain.Query
{
    public class DocumentQuery : IQueryFor<string, SrmDocument>
    {

        public async Task<SrmDocument> ExecuteFor(string input)
        {
            var uri = new Uri(ConfigurationManager.AppSettings["dbUrl"]);
            var authKey = ConfigurationManager.AppSettings["dbAuthKey"];
            var dbId = ConfigurationManager.AppSettings["dbId"];

            using (var client = new DocumentClient(uri, authKey))
            {
                var database = client.CreateDatabaseQuery().Where(db => db.Id == dbId).FirstOrDefault();
                //TODO : Do we need this check.
                if (database == null)
                {
                    database = await client.CreateDatabaseAsync(new Database { Id = dbId });
                    var documentCollection = await client.CreateDocumentCollectionAsync(database.CollectionsLink,
                        new DocumentCollection
                        {
                            // LETS keep document and collection same as of now.
                            Id = dbId
                        });
                }

                return new SrmDocument
                {
                    DocumentLink = database.CollectionsLink,
                    Client = client
                };
            }
        }


    }
}
