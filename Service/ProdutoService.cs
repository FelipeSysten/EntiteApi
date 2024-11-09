using Microsoft.EntityFrameworkCore;
using WebApplicationApi.Data;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Service
{
    public class ProdutoService : ProdutoInterface
    {

        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<ProdutoModel>> BuscarProdutoPorID(int idProduto)
        {
            ResponseModel<ProdutoModel> resposta = new ResponseModel<ProdutoModel>();
            try
            {
                var produto = await _context.Produtos.FirstOrDefaultAsync(produtoBanco => produtoBanco.IdProduto == idProduto);

                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = produto;
                resposta.Mensagem = "Produto localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> CriarProduto(CriarProdutoDto criarProdutoDto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = new ProdutoModel()
                {
                    NomeProduto = criarProdutoDto.NomeProduto,
                    TipoProduto = criarProdutoDto.TipoProduto,
                    ValorProduto = criarProdutoDto.ValorProduto

                };

                _context.Produtos.Add(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> EditarProduto(EditarProdutoDto editarProdutoDto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();

            try
            {
                var produto = await _context.Produtos
                    .FirstOrDefaultAsync(produtoBanco => produtoBanco.IdProduto == editarProdutoDto.IdProduto);

                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum Produto localizado!";
                    return resposta;
                }

                

                produto.NomeProduto = editarProdutoDto.NomeProduto;
                produto.TipoProduto = editarProdutoDto.TipoProduto;
                produto.ValorProduto = editarProdutoDto.ValorProduto;

                _context.Update(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto editado com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> ExcluirProduto(int idProduto)
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produto = await _context.Produtos
                    .FirstOrDefaultAsync(produtoBanco => produtoBanco.IdProduto == idProduto);

                if (produto == null)
                {
                    resposta.Mensagem = "Nenhum Produto localizado!";
                    return resposta;
                }

                _context.Remove(produto);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Produtos.ToListAsync();
                resposta.Mensagem = "Produto Removido com Sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ProdutoModel>>> ListarProdutos()
        {
            ResponseModel<List<ProdutoModel>> resposta = new ResponseModel<List<ProdutoModel>>();
            try
            {
                var produtos = await _context.Produtos.ToListAsync();
                resposta.Dados = produtos;
                resposta.Mensagem = "Todos os produtos foram coletados!";

                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
