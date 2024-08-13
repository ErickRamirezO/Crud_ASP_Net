using WebApplication1.Models;
namespace WebApplication1.Data;
public interface IClienteDataAccessLayer
{
    IEnumerable<ClienteSql> GetAllClientes();
    ClienteSql GetClienteById(int id);
    void AddCliente(ClienteSql cliente);
    void UpdateCliente(ClienteSql cliente);
    void DeleteCliente(int id);
}
