using MongoDB.Driver;
using WebApplicationTechLead1.Domain.Models;
using WebApplicationTechLead1.Infrastructure;
using WebApplicationTechLead1.Services.Queries;

namespace WebApplicationTechLead1.Services.Handlers
{
    public class TesteQueryHandler
    {
        private readonly MongoDBContext _mongoDBContext;

        public TesteQueryHandler(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public async Task<Teste> Handle(GetTesteByIdQuery query)
        {
            var teste = await _mongoDBContext.Testes.Find(t => t.TesteId == query.Id).FirstOrDefaultAsync();
            return teste;
        }

        public async Task<List<Teste>> Handle(GetAllTestesQuery query)
        {
            var collectionTestesAll = await _mongoDBContext.Testes.Find(_ => true).ToListAsync();
            return collectionTestesAll;
        }
    }




}
