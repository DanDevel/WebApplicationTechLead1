using WebApplicationTechLead1.Domain.Models;
using WebApplicationTechLead1.Services.Queries;

namespace WebApplicationTechLead1.Services.Handlers
{
    public class ClienteQueryHandler
    {
        private readonly ClienteService _clienteService;

        public ClienteQueryHandler(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<List<Cliente>> Handle(GetClientesQuery query)
        {
            return await _clienteService.GetClientesAsync();
        }

        public async Task<Cliente> Handle(GetClienteByIdQuery query)
        {
            return await _clienteService.GetClienteByIdAsync(query.Id);
        }
    }

}
