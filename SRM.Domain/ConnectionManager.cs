﻿using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Linq;

namespace SRM.Domain
{
    public class ConnectionManager : IConnectionManager
    {
        private Database database = null;
        private DocumentClient client = null;
        private IDictionary<string, DocumentCollection> documentCollections;
        private string endPointUrl = "https://srmdb.documents.azure.com:443/";
        private string AuthorizationKey = "hJE9vaWWp2xUCKhG32iVMt4GROu4egyYwszwQstrkcRa5wjuclSi390plLNE2TE4ETxyFxfI50RJuQXWtQjEBg==";
        public ConnectionManager()
        {
            this.documentCollections = new Dictionary<string, DocumentCollection>();
        }



        public async Task<DocumentClient> GetOrCreateDatabase(string databaseName = null)
        {
            if (database == null)
                return await Task.FromResult(client);
            this.client = new DocumentClient(new Uri(endPointUrl), AuthorizationKey);
            var queryDatabase = client.CreateDatabaseQuery().Where(p => p.Id == "srm").ToArray();
            if (queryDatabase.Any())
            {
                database = queryDatabase.First();
            }
            else
            {
                database = await client.CreateDatabaseAsync(new Database { Id = "srm" });
            }
            return client;
        }

        public async Task<DocumentCollection> GetOrCreateCollection(string collectionName, string databaseName = null)
        {
            if (documentCollections.ContainsKey(collectionName))
                return documentCollections[collectionName];

            var collections = client.CreateDocumentCollectionQuery(database.SelfLink).Where(p => p.Id == collectionName).ToArray();
            DocumentCollection collection = null;
            if (collections.Any())
            {
                collection = collections.First();
            }
            else
            {
                collection = await client.CreateDocumentCollectionAsync(database.CollectionsLink, new DocumentCollection { Id = "studentCollection" });
            }
            documentCollections.Add(collectionName, collection);
            return collection;
        }
    }
}