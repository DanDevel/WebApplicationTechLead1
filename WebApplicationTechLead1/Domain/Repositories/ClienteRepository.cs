using WebApplicationTechLead1.Domain.Models;

namespace WebApplicationTechLead1.Domain.Repositories
{
    public interface IClienteRepository
    {
        Task<List<Cliente>> GetClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task AddClienteAsync(Cliente cliente);
        Task UpdateClienteAsync(int id, Cliente cliente);
        Task DeleteClienteAsync(int id);
    }
}
