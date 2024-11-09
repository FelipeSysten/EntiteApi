using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;
using WebApplicationApi.Service;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteInterface _clienteinterface;
        public ClienteController(ClienteInterface clienteinterface)
        {
            _clienteinterface = clienteinterface;
        }

        [HttpGet("ListaClientes")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ListarClientes()
        {
            var clientes = await _clienteinterface.ListarClientes();
            return Ok(clientes);
        }

        [HttpGet("BuscarClientePorId/{idCliente}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> BuscarClientePorId(int idCliente)
        {
            var cliente = await _clienteinterface.BuscarClientePorID(idCliente);
            return Ok(cliente);
        }

        [HttpGet("BuscarClientePorIdPedido/{idPedido}")]
        public async Task<ActionResult<ResponseModel<ClienteModel>>> BuscarClientePorIdPedido(int idPedido)
        {
            var cliente = await _clienteinterface.BuscarClientePorIdPedido(idPedido);
            return Ok(cliente);
        }

        [HttpPost("CriarCliente")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> CriarCliente(CriarClienteDto criarClienteDto)
        {
            var clientea = await _clienteinterface.CriarCliente(criarClienteDto);
            return Ok(clientea);
        }

        [HttpPut("EditarCliente")]

        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> EditarCliente(EditarClienteDto editarClienteDto)
        {
            var clientea = await _clienteinterface.EditarCliente(editarClienteDto);
            return Ok(clientea);
        }

        [HttpDelete("ExcluirCliente")]
        public async Task<ActionResult<ResponseModel<List<ClienteModel>>>> ExcluirCliente(int idCliente)
        {
            var clientea = await _clienteinterface.ExcluirCliente(idCliente);
            return Ok(clientea);
        }
    }
}
