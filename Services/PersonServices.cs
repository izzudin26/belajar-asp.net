using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mongonets.Models;
using MongoDB.Driver;

namespace mongonets.Services
{
    public class PersonServices
    {
        private readonly IMongoCollection<Information> _person;

        public PersonServices(InformationDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _person = database.GetCollection<Information>(settings.CollectionName);
        }

        public List<Information> get() => _person.Find(doc => true).ToList();
        public Information Get(string id) => _person.Find<Information>(docs => docs.Id == id).FirstOrDefault();
        public Information create(Information person)
        {
             _person.InsertOne(person);
            return person;
        }

        public void Update(string id, Information person)
        {
            _person.ReplaceOne(docs => docs.Id == id, person);
        }

        public void destroy(string id)
        {
            _person.DeleteOne(docs => docs.Id == id);
        }
    }
}
