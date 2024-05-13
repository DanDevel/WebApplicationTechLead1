using MongoDB.Driver;
using WebApplicationTechLead1.Domain.Models;
using static System.Net.Mime.MediaTypeNames;

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

        public IMongoCollection<Teste> Testes => _database.GetCollection<Teste>("testes");
    }
}
