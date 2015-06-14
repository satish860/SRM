using Microsoft.Azure.Documents.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain.Entity
{
    /// <summary>
    /// Carries the Document db instance.
    /// </summary>
    public class SrmDocument
    {
        public DocumentClient Client { get; set; }
        public string DocumentLink { get; set; }
        //TODO : Do we need database as well?
    }
}

