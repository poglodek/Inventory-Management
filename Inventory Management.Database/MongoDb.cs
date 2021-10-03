using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Database.Entity;
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
        public T GetDocumentById<T>(string collectionName, Guid id)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id",id);
            return collection.Find(filter).FirstOrDefault();
        }
        public List<T> GetDocumentsByPropertyName<T>(string collectionName, string propertyName, object value)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq(propertyName, value);
            return collection.Find(filter).ToList();
        }
        public List<T> GetDocuments<T>(string collectionName)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            return collection.AsQueryable<T>().ToList();
        }

        public bool RemoveDocument<T>(string collectionName, Guid id)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.DeleteOne(filter);
            return true;
        }

        public void UpdateDocument<T>(string collectionName, T document, Guid id)
        {
            var collection = _mongoDatabase.GetCollection<T>(collectionName);
            var filter = Builders<T>.Filter.Eq("_id", id);
            collection.ReplaceOne(filter, document, new ReplaceOptions { IsUpsert = false });
        }
    }
}
