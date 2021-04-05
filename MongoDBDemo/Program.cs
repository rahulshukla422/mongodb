using System;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace MongoDBDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            MongoDbHelper mongoDbHelper = new MongoDbHelper("Customer");

            // sample document model
            var doc = new List<PersonModel>
            {
              new PersonModel
              {
                FirstName = "Tom",
                LastName = "Herry",
              },
               new PersonModel
              {
                FirstName = "Elon",
                LastName = "Musk",
              },
              new PersonModel
              {
                FirstName = "Jemmy",
                LastName = "wells",
                PrimaryAddress = new AddressModel
                {
                    Street = "112 St",
                    City = "Loss ",
                    Zip = "Az8w7"
                }
              }
            };

            // To insert the bulk record
            mongoDbHelper.InsertDocument<PersonModel>("Users", doc);

            // To read the record from the document
            var data = mongoDbHelper.ReadDocument<PersonModel>("Users");
            foreach (var item in data)
            {
                Console.WriteLine($"Id: {item.Id}, First Name : {item.FirstName}, Last Name : {item.LastName}");

                if (item.PrimaryAddress != null)
                {
                    Console.WriteLine($"Adddress: {item.PrimaryAddress.Street},{item.PrimaryAddress.City}, {item.PrimaryAddress.Zip}");
                }
                Console.WriteLine();
            }
            var updateRecord = data.First(x => x.FirstName == "Tom");
            updateRecord.PrimaryAddress = new AddressModel
            {
                Street = "London",
                City = "St",
                Zip = "12345"
            };

            // To update the existing record
            mongoDbHelper.UpsertDocument("Users", updateRecord, updateRecord.Id);

            // To read the document by given id
            var filterdData = mongoDbHelper.ReadDocumentById<PersonModel>("Users", updateRecord.Id);

            Console.WriteLine($"Id: {filterdData.Id}, First Name : {filterdData.FirstName}, Last Name : {filterdData.LastName}");

            if (filterdData.PrimaryAddress != null)
            {
                Console.WriteLine($"Adddress: {filterdData.PrimaryAddress.Street},{filterdData.PrimaryAddress.City}, {filterdData.PrimaryAddress.Zip}");
            }

            // To delete the document by first name
            mongoDbHelper.DeleteDocument<PersonModel>("Users", filterdData.Id);
            Console.ReadLine();
        }
    }
}
