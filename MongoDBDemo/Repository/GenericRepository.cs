using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MongoDBDemo.Repository
{
    public class GenericRepository : IGenericRepository
    {
        private readonly IMongoDatabase db;

        public GenericRepository(string database)
        {
            var client = new MongoClient();

            db = client.GetDatabase(database);
        }

        public void InsertDocument<T>(string table, List<T> documents)
        {
            var coll = db.GetCollection<T>(table);

            coll.InsertMany(documents);
        }

        public List<T> ReadDocument<T>(string table)
        {

            var collection = db.GetCollection<T>(table);

            return collection.Find(new BsonDocument()).ToList();
        }

        public T ReadDocumentById<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("_id", id);

            var data = collection.Find(filter).FirstOrDefault();

            return data;
        }

        public void Upsert<T>(string table, T document, Guid id)
        {
            var collection = db.GetCollection<T>(table);

            var result = collection.ReplaceOne(new BsonDocument("_id", id), document, new ReplaceOptions { IsUpsert = true });
        }

        public void DeleteDocument<T>(string table, Guid id)
        {
            var collection = db.GetCollection<T>(table);

            var filter = Builders<T>.Filter.Eq("_id", id);

            var result = collection.DeleteOne(filter);
        }
    }
}
