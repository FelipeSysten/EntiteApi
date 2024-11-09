using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Service
{
    public interface PedidoInterface
    {
        Task<ResponseModel<List<PedidoModel>>> ListarPedidos();
        Task<ResponseModel<PedidoModel>> BuscarPedidoPorID(int idPedido);
        Task<ResponseModel<List<PedidoModel>>> CriarPedido(CriarPedidoDto criarPedidoDto);

        Task<ResponseModel<List<PedidoModel>>> EditarPedido(EditarPedidoDto editarPedidoDto);

        Task<ResponseModel<List<PedidoModel>>> ExcluirPedido(int idPedido);
    }
}
