using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Service
{
    public interface StatusInterface
    {
        Task<ResponseModel<List<StatusModel>>> ListarStatus();
        Task<ResponseModel<StatusModel>> BuscarStatusPorID(int idStatus);
        Task<ResponseModel<List<StatusModel>>> CriarStatus(CriarStatusDto criarStatusDto);
        Task<ResponseModel<List<StatusModel>>> EditarStatus(EditarStatusDto editarStatusDto);
        Task<ResponseModel<List<StatusModel>>> ExcluirStatus(int idStatus);
    }
}
