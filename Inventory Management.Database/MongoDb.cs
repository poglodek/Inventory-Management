using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace Inventory_Management.Database
{
    public class MongoDb
    {
        private IMongoDatabase _mongoDatabase;

        public MongoDb(string database)
        {
            var client = new MongoClient();
            _mongoDatabase = client.GetDatabase(database);
        }

        public bool InsertDocument<T>(string collectionName, T document)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            collection.InsertOne(document);
            return true;
        }
    }
}
