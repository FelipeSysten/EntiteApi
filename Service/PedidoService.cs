using Microsoft.EntityFrameworkCore;
using WebApplicationApi.Data;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Service
{
    public class PedidoService : PedidoInterface
    {

        private readonly AppDbContext _context;

        public PedidoService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<PedidoModel>> BuscarPedidoPorID(int idPedido)
        {
            ResponseModel<PedidoModel> resposta = new ResponseModel<PedidoModel>();
            try
            {
                var pedido = await _context.Pedidos.FirstOrDefaultAsync(pedidoBanco => pedidoBanco.IdPedido == idPedido);

                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = pedido;
                resposta.Mensagem = "Pedido localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> CriarPedido(CriarPedidoDto criarPedidoDto)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();

            try
            {
                // Buscar o Status pelo StatusId
                var status = await _context.Statuses
                    .FirstOrDefaultAsync(s => s.IdStatus == criarPedidoDto.StatusId);

                if (status == null)
                {
                    resposta.Mensagem = "Status não encontrado!";
                    return resposta;
                }

                // Criar o Pedido
                var pedido = new PedidoModel
                {
                    ClienteId = criarPedidoDto.ClienteId,
                    DataPedido = criarPedidoDto.DataPedido,
                    Status = status  // Vincula o Status encontrado
                };

                // Adicionar os Produtos
                var produtos = await _context.Produtos
                    .Where(p => criarPedidoDto.ProdutoIds.Contains(p.IdProduto))
                    .ToListAsync();

                if (produtos.Count != criarPedidoDto.ProdutoIds.Count)
                {
                    resposta.Mensagem = "Alguns produtos não foram encontrados!";
                    return resposta;
                }

                pedido.Produtos = produtos;

                // Adicionar o Pedido ao contexto
                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();

                // Retornar a resposta com todos os pedidos
                resposta.Dados = await _context.Pedidos.ToListAsync();
                resposta.Mensagem = "Pedido criado com sucesso!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> EditarPedido(EditarPedidoDto editarPedidoDto)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();

            try
            {
                // Busca o pedido existente pelo Id
                var pedido = await _context.Pedidos
                    .Include(p => p.Produtos) // Inclui os produtos para permitir atualização
                    .FirstOrDefaultAsync(pedidoBanco => pedidoBanco.IdPedido == editarPedidoDto.IdPedido);

                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum Pedido localizado!";
                    return resposta;
                }

                // Atualiza a Data do Pedido
                pedido.DataPedido = editarPedidoDto.DataPedido;
                

                // Atualiza o Status do Pedido
                var status = await _context.Statuses.FirstOrDefaultAsync(s => s.IdStatus == editarPedidoDto.StatusId);
                if (status == null)
                {
                    resposta.Mensagem = "Status não encontrado!";
                    return resposta;
                }
                pedido.StatusId = status.IdStatus;

                // Atualiza a lista de Produtos do Pedido
                var produtos = await _context.Produtos
                    .Where(p => editarPedidoDto.ProdutoIds.Contains(p.IdProduto))
                    .ToListAsync();

                if (produtos.Count != editarPedidoDto.ProdutoIds.Count)
                {
                    resposta.Mensagem = "Um ou mais produtos não foram encontrados.";
                    return resposta;
                }

                // Limpa a lista atual e adiciona os novos produtos
                pedido.Produtos.Clear();
                foreach (var produto in produtos)
                {
                    pedido.Produtos.Add(produto);
                }

                // Salva as mudanças no banco de dados
                _context.Update(pedido);
                await _context.SaveChangesAsync();

                // Preenche a resposta com a lista de pedidos atualizada
                resposta.Dados = await _context.Pedidos.ToListAsync();
                resposta.Mensagem = "Pedido editado com sucesso!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> ExcluirPedido(int idPedido)
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();
            try
            {
                var pedido = await _context.Pedidos
                    .FirstOrDefaultAsync(pedidoBanco => pedidoBanco.IdPedido == idPedido);

                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum Pedido localizado!";
                    return resposta;
                }

                _context.Remove(pedido);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Pedidos.ToListAsync();
                resposta.Mensagem = "Pedido Removido com Sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PedidoModel>>> ListarPedidos()
        {
            ResponseModel<List<PedidoModel>> resposta = new ResponseModel<List<PedidoModel>>();
            try
            {
                var pedidos = await _context.Pedidos.ToListAsync();
                resposta.Dados = pedidos;
                resposta.Mensagem = "Todos os pedidos foram coletados!";

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
