using System.Threading.Tasks;
using WebApplicationTechLead1.Domain.Models;
using WebApplicationTechLead1.Domain.Repositories;

namespace WebApplicationTechLead1.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<List<Cliente>> GetClientesAsync()
        {
            return await _clienteRepository.GetClientesAsync();
        }

        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _clienteRepository.GetClienteByIdAsync(id);
        }

        public async Task AddClienteAsync(Cliente cliente)
        {
            await _clienteRepository.AddClienteAsync(cliente);
        }

        public async Task UpdateClienteAsync(int id, Cliente cliente)
        {
            await _clienteRepository.UpdateClienteAsync(id, cliente);
        }

        public async Task DeleteClienteAsync(int id)
        {
            await _clienteRepository.DeleteClienteAsync(id);
        }
    }
}
