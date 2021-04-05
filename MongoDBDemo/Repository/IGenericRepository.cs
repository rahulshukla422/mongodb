using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDBDemo.Repository
{
    public interface IGenericRepository
    {
        public void InsertDocument<T>(string table, List<T> documents);

        public List<T> ReadDocument<T>(string table);

        public T ReadDocumentById<T>(string table, Guid id);

        public void Upsert<T>(string table, T document, Guid id);

        public void DeleteDocument<T>(string table, Guid id);
    }
}
