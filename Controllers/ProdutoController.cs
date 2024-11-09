using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;
using WebApplicationApi.Service;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoInterface _produtoService;

        public ProdutoController(ProdutoInterface produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet("ListarProdutos")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ListarProdutos()
        {
            var produtos = await _produtoService.ListarProdutos();
            return Ok(produtos);
        }
        [HttpGet("BuscarProdutoPorId/{idProduto}")]
        public async Task<ActionResult<ResponseModel<ProdutoModel>>> BuscarProdutoPorId(int idProduto)
        {
            var produto = await _produtoService.BuscarProdutoPorID(idProduto);
            return Ok(produto);
        }

        [HttpPost("CriarProduto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> CriarProduto([FromBody] CriarProdutoDto criarProdutoDto)
        {
            var produto = await _produtoService.CriarProduto(criarProdutoDto);
            return Ok(produto);
        }

        [HttpPut("EditarProduto")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> EditarProduto([FromBody] EditarProdutoDto editarProdutoDto)
        {
            var produto = await _produtoService.EditarProduto(editarProdutoDto);
            return Ok(produto);
        }

        [HttpDelete("ExcluirProduto/{idProduto}")]
        public async Task<ActionResult<ResponseModel<List<ProdutoModel>>>> ExcluirProduto(int idProduto)
        {
            var produto = await _produtoService.ExcluirProduto(idProduto);
            return Ok(produto);
        }
    }
}
