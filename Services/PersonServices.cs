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
            _person = database.GetCollection<Information>(settings.ColllectionName);
        }
    }
}
