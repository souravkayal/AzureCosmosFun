using AzureCosmos.Model;
using AzureMongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver.Core;
using MongoDB.Driver.Builders;

namespace AzureCosmos.AzureMongo
{
    public class PersonRepository : MongoSetting
    {
        IMongoCollection<Person> _personCollection = null;
        public PersonRepository()
        {
            this._personCollection = mongoClient.GetDatabase(dbName).GetCollection<Person>(this.collectionName);
        }

        public void CreatePerson(Person Person)
        {
            try
            {
                _personCollection.InsertOne(Person);
            }
            catch (MongoCommandException ex)
            {
                throw;
            }
        }

        public List<Person> GetAllPerson(string CollectionName)
        {
            try
            {
                return _personCollection.Find(_ => true).ToList();
            }
            catch (MongoCommandException ex)
            {
                throw;
            }
        }

        public void UpdatePerson(Person Person)
        {
            var updatedPerson = Builders<Person>.Update.
                                Set(f => f.Name, Person.Name).
                                Set(f => f.Surname, Person.Surname).
                                Set(f => f.Age, Person.Age);

            _personCollection.UpdateOne(f => f.Name == "Sourav", updatedPerson);
        }

        public void DeletePerson(Person Person)
        {
            _personCollection.DeleteOne(f => f.Name == "Ram");
        }

    }
}
