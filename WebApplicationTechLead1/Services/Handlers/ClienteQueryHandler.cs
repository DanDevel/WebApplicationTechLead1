using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplicationTechLead1.Domain.Models;
using WebApplicationTechLead1.Infrastructure;
using WebApplicationTechLead1.Services.Queries;

namespace WebApplicationTechLead1.Services.Handlers
{
    public class ClienteQueryHandler
    {
        private readonly MongoDBContext _mongoDBContext;

        public ClienteQueryHandler(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public async Task<List<Teste>> Handle(GetClientesQuery query)
        {
            var testes = await _mongoDBContext.Testes.Find(_ => true).ToListAsync();
            return testes;
        }

        public async Task<Teste> Handle(GetClienteByIdQuery query)
        {
            var teste = await _mongoDBContext.Testes.Find(t => t.Id == query.Id.ToString()).FirstOrDefaultAsync();
            return teste;
        }

    }
}
