using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Service
{
    public interface ProdutoInterface
    {
        Task<ResponseModel<List<ProdutoModel>>> ListarProdutos();
        Task<ResponseModel<ProdutoModel>> BuscarProdutoPorID(int idProduto);
        Task<ResponseModel<List<ProdutoModel>>> CriarProduto(CriarProdutoDto criarProdutoDto);
        Task<ResponseModel<List<ProdutoModel>>> EditarProduto(EditarProdutoDto editarProdutoDto);
        Task<ResponseModel<List<ProdutoModel>>> ExcluirProduto(int idProduto);
    }
}
