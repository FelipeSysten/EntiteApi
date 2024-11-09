using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Service
{
    public interface ClienteInterface
    {
        Task<ResponseModel<List<ClienteModel>>> ListarClientes();
        Task<ResponseModel<ClienteModel>> BuscarClientePorID(int idCliente);
        Task<ResponseModel<ClienteModel>> BuscarClientePorIdPedido (int idPedido);

        Task<ResponseModel<List<ClienteModel>>> CriarCliente(CriarClienteDto criarClienteDto);

        Task<ResponseModel<List<ClienteModel>>> EditarCliente(EditarClienteDto editarClienteDto);

        Task<ResponseModel<List<ClienteModel>>> ExcluirCliente(int idCliente);
    }
}
