using Microsoft.EntityFrameworkCore;
using WebApplicationApi.Data;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Service
{
    public class ClienteService : ClienteInterface
    {

        private readonly AppDbContext _context;

        public ClienteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ClienteModel>> BuscarClientePorID(int idCliente)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
            try
            {
                var cliente = await _context.Clientes.FirstOrDefaultAsync(clienteBanco => clienteBanco.IdCliente == idCliente);

                if (cliente == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = cliente;
                resposta.Mensagem = "Cliente localizado!";
                return resposta;

            }
            catch (Exception ex) 
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ClienteModel>> BuscarClientePorIdPedido(int idPedido)
        {
            ResponseModel<ClienteModel> resposta = new ResponseModel<ClienteModel>();
            try
            {
               var pedido = await _context.Pedidos
                    .Include(c => c.Cliente)
                    .FirstOrDefaultAsync(pedidoBanco => pedidoBanco.IdPedido == idPedido);
                if (pedido == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta; 
                }

                resposta.Dados = pedido.Cliente;
                resposta.Mensagem = "Cliente Localizado!";
                return resposta;    

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> CriarCliente(CriarClienteDto criarClienteDto)
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();

            try
            {
                var cliente = new ClienteModel()
                {
                    NomeCliente = criarClienteDto.NomeCliente,
                    EmailCliente = criarClienteDto.EmailCliente,
                    DataNascimentoCliente = criarClienteDto.DataNascimentoCliente

                };

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.ToListAsync();
                resposta.Mensagem = "Cliente criado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> EditarCliente(EditarClienteDto editarClienteDto)
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();

            try
            {
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(clienteBanco => clienteBanco.IdCliente == editarClienteDto.IdCliente);
                   
                    if(cliente == null)
                {
                    resposta.Mensagem = "Nenhum cliente localizado!";
                    return resposta;
                }

                    cliente.NomeCliente = editarClienteDto.NomeCliente;
                    cliente.EmailCliente = editarClienteDto.EmailCliente;
                    cliente.DataNascimentoCliente = editarClienteDto.DataNascimentoCliente;

                _context.Update(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.ToListAsync();
                resposta.Mensagem = "Cliente editado com sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;

            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> ExcluirCliente(int idCliente)
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
            try
            {
                var cliente = await _context.Clientes
                    .FirstOrDefaultAsync(clienteBanco => clienteBanco.IdCliente == idCliente);
              
                if(cliente == null)
                    {
                    resposta.Mensagem = "Nenhum Cliente localizado!";
                    return resposta;
                }

                _context.Remove(cliente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Clientes.ToListAsync();
                resposta.Mensagem = "Cliente Removido com Sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ClienteModel>>> ListarClientes()
        {
            ResponseModel<List<ClienteModel>> resposta = new ResponseModel<List<ClienteModel>>();
            try
            {
                var clientes = await _context.Clientes.ToListAsync();
                resposta.Dados = clientes;
                resposta.Mensagem = "Todos os clientes foram coletados!";

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
