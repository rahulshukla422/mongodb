using System;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBDemo
{
    public class AddressModel
    {
        [BsonId]
        public Guid Id { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string Zip { get; set; }
    }
}
