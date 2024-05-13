using MongoDB.Driver;
using WebApplicationTechLead1.Domain.Models;

namespace WebApplicationTechLead1.Infrastructure
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoCollection<Cliente> Clientes => _database.GetCollection<Cliente>("Clientes");
    }
}
