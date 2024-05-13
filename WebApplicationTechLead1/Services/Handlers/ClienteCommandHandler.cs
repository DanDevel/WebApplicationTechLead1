using WebApplicationTechLead1.Domain.Models;
using WebApplicationTechLead1.Services.Commands;

namespace WebApplicationTechLead1.Services.Handlers
{
    public class ClienteCommandHandler
    {
        private readonly ClienteService _clienteService;

        public ClienteCommandHandler(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task Handle(AddClienteCommand command)
        {
            var cliente = new Cliente (command.NomeEmpresa, command.PorteEmpresa);
            await _clienteService.AddClienteAsync(cliente);
        }

        public async Task Handle(UpdateClienteCommand command)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(command.Id);
            if (cliente != null)
            {
                cliente.NomeEmpresa = command.NomeEmpresa;
                cliente.PorteEmpresa = command.PorteEmpresa;
                await _clienteService.UpdateClienteAsync(command.Id, cliente);
            }
        }

        public async Task Handle(DeleteClienteCommand command)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(command.Id);
            if (cliente != null)
            {
                await _clienteService.DeleteClienteAsync(command.Id);
            }
        }
    }

}
