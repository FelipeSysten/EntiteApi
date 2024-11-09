using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationApi.Dto;
using WebApplicationApi.Models;
using WebApplicationApi.Service;

namespace WebApplicationApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly StatusInterface _statusService;

        public StatusController(StatusInterface statusService)
        {
            _statusService = statusService;
        }

        [HttpGet("ListarStatus")]
        public async Task<ActionResult<ResponseModel<List<StatusModel>>>> ListarStatus()
        {
            var status = await _statusService.ListarStatus();
            return Ok(status);
        }
        [HttpGet("BuscarStatusPorId/{idStatus}")]
        public async Task<ActionResult<ResponseModel<StatusModel>>> BuscarStatusPorId(int idStatus)
        {
            var statu = await _statusService.BuscarStatusPorID(idStatus);
            return Ok(statu);
        }

        [HttpPost("CriarStatus")]
        public async Task<ActionResult<ResponseModel<List<StatusModel>>>> CriarStatus([FromBody] CriarStatusDto criarStatusDto)
        {
            var statu = await _statusService.CriarStatus(criarStatusDto);
            return Ok(statu);
        }

        [HttpPut("EditarStatus")]
        public async Task<ActionResult<ResponseModel<List<StatusModel>>>> EditarStatus([FromBody] EditarStatusDto editarStatusDto)
        {
            var statu = await _statusService.EditarStatus(editarStatusDto);
            return Ok(statu);
        }

        [HttpDelete("ExcluirStatus/{idStatus}")]
        public async Task<ActionResult<ResponseModel<List<StatusModel>>>> ExcluirStatus(int idStatus)
        {
            var statu = await _statusService.ExcluirStatus(idStatus);
            return Ok(statu);
        }

    }
}
