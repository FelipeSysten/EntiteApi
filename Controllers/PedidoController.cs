using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;
using WebApplicationApi.Service;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly PedidoInterface _pedidoService;

        public PedidoController(PedidoInterface pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet("ListarPedidos")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ListarPedidos()
        {
            var pedidos = await _pedidoService.ListarPedidos();
            return Ok(pedidos);
        }

        [HttpGet("BuscarPedidoPorId/{idPedido}")]
        public async Task<ActionResult<ResponseModel<PedidoModel>>> BuscarPedidoPorId(int idPedido)
        {
            var pedido = await _pedidoService.BuscarPedidoPorID(idPedido);
            return Ok(pedido);
        }

        [HttpPost("CriarPedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> CriarPedido([FromBody] CriarPedidoDto criarPedidoDto)
        {
            var pedido = await _pedidoService.CriarPedido(criarPedidoDto);
            return Ok(pedido);
        }

        [HttpPut("EditarPedido")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> EditarPedido([FromBody] EditarPedidoDto editarPedidoDto)
        {
            var produto = await _pedidoService.EditarPedido(editarPedidoDto);
            return Ok(produto);
        }

        [HttpDelete("ExcluirPedido/{idPedido}")]
        public async Task<ActionResult<ResponseModel<List<PedidoModel>>>> ExcluirPedido(int idPedido)
        {
            var pedido = await _pedidoService.ExcluirPedido(idPedido);
            return Ok(pedido);
        }

    }
}
