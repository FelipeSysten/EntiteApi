using Microsoft.EntityFrameworkCore;
using WebApplicationApi.Data;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;

namespace WebApplicationApi.Service
{
    public class StatusService : StatusInterface
    {

        private readonly AppDbContext _context;

        public StatusService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<ResponseModel<StatusModel>> BuscarStatusPorID(int idStatus)
        {
            ResponseModel<StatusModel> resposta = new ResponseModel<StatusModel>();
            try
            {
                var status = await _context.Status.FirstOrDefaultAsync(statusBanco => statusBanco.IdStatus == idStatus);

                if (status == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = status;
                resposta.Mensagem = "Status localizado!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<StatusModel>>> CriarStatus(CriarStatusDto criarStatusDto)
        {
            ResponseModel<List<StatusModel>> resposta = new ResponseModel<List<StatusModel>>();

            try
            {
                // Cria uma nova instância de StatusModel com os dados do DTO
                var status = new StatusModel
                {
                    NomeStatus = criarStatusDto.NomeStatus,
                    Descricao = criarStatusDto.Descricao
                };

                // Adiciona o novo status ao contexto
                _context.Status.Add(status);
                await _context.SaveChangesAsync();

                // Verifica se há pedidos no banco de dados
                var pedidos = await _context.Pedidos.ToListAsync();

                // Se existirem pedidos, associa o status aos pedidos
                if (pedidos.Any())
                {
                    foreach (var pedido in pedidos)
                    {
                        pedido.StatusId = status.IdStatus;
                    }

                    // Atualiza os pedidos com o novo status
                    _context.Pedidos.UpdateRange(pedidos);
                    await _context.SaveChangesAsync();
                }

                // Retorna todos os status, incluindo o novo
                resposta.Dados = await _context.Statuses.ToListAsync();
                resposta.Mensagem = "Status criado com sucesso!";
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                // Captura e exibe a mensagem de erro detalhada
                var errorMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                resposta.Mensagem = $"Erro ao criar status: {errorMessage}";
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<StatusModel>>> EditarStatus(EditarStatusDto editarStatusDto)
        {
            ResponseModel<List<StatusModel>> resposta = new ResponseModel<List<StatusModel>>();

            try
            {
                var status = await _context.Status
                    .FirstOrDefaultAsync(statusBanco => statusBanco.IdStatus == editarStatusDto.IdStatus);

                if (status == null)
                {
                    resposta.Mensagem = "Nenhum Status localizado!";
                    return resposta;
                }


                status.NomeStatus = editarStatusDto.NomeStatus;
                status.Descricao = editarStatusDto.Descricao;

                _context.Update(status);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Status.ToListAsync();
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

        public async Task<ResponseModel<List<StatusModel>>> ExcluirStatus(int idStatus)
        {
            ResponseModel<List<StatusModel>> resposta = new ResponseModel<List<StatusModel>>();
            try
            {
                var status = await _context.Status
                    .FirstOrDefaultAsync(statusBanco => statusBanco.IdStatus == idStatus);

                if (status == null)
                {
                    resposta.Mensagem = "Nenhum Status localizado!";
                    return resposta;
                }

                _context.Remove(status);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Status.ToListAsync();
                resposta.Mensagem = "Status Removido com Sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<StatusModel>>> ListarStatus()
        {
            ResponseModel<List<StatusModel>> resposta = new ResponseModel<List<StatusModel>>();
            try
            {
                var status = await _context.Status.ToListAsync();
                resposta.Dados = status;
                resposta.Mensagem = "Todos os status foram coletados!";

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
