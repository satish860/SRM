using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace SRM.Domain
{
    public interface IConnectionManager
    {
        Task<DocumentClient> GetOrCreateDatabase(string databaseName=null);

        Task<DocumentCollection> GetOrCreateCollection(string collectionName,string databaseName=null);

    }
}
