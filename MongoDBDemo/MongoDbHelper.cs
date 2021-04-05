using MongoDBDemo.Repository;
using System;
using System.Collections.Generic;

namespace MongoDBDemo
{
    public class MongoDbHelper
    {
        IGenericRepository _repository;

        string collection = "Users"; // This is table name
        public MongoDbHelper(string database)
        {
            _repository = new GenericRepository(database);  // "AddressBook" will be database name
        }

        public void InsertDocument<T>(string table, List<T> document)
        {
            _repository.InsertDocument<T>(collection, document);
        }

        public List<T> ReadDocument<T>(string table)
        {
            return _repository.ReadDocument<T>(collection);
        }
        public void UpsertDocument<T>(string table, T record, Guid id)
        {
            _repository.Upsert<T>(collection, record, id);
        }
        public T ReadDocumentById<T>(string table, Guid id)
        {
            return _repository.ReadDocumentById<T>(collection, id);
        }

        public void DeleteDocument<T>(string table, Guid id)
        {
            _repository.DeleteDocument<T>(collection, id);
        }

    }
}
