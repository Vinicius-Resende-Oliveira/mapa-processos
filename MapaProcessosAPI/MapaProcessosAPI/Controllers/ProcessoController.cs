using Microsoft.AspNetCore.Mvc;
using MP.Application.DTOs.Request;
using MP.Application.DTOs.Result;
using MP.Application.Interfaces;

namespace MP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoController : ControllerBase
    {
        private readonly IProcessoOpenApp _processoApp;

        public ProcessoController(IProcessoOpenApp processoApp)
        {
            _processoApp = processoApp;
        }

        [HttpGet]
        public async Task<ActionResult<List<GetProcessoResult>>> GetAll()
        {
            return Ok(await _processoApp.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            GetByIdProcessoRequest request = new GetByIdProcessoRequest { Id = id };

            return Ok(await _processoApp.GetByIdAsync(request));
        }


        [HttpGet("{id}/SubProcessos")]
        public async Task<IActionResult> GetSubProcessos(Guid id)
        {
            GetByIdProcessoRequest request = new GetByIdProcessoRequest { Id = id };

            return Ok(await _processoApp.GetSubProcessosAsync(request));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            RemoveProcessoRequest request = new RemoveProcessoRequest { Id = id };
            await _processoApp.RemoveAsync(request);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddProcessoRequest request)
        {
            var result = await _processoApp.AddAsync(request);
            return Created($"Processo/{result.Id}", result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProcessoRequest request)
        {
            request.Id = id;

            return Ok(await _processoApp.UpdateAsync(request));
        }

        [HttpPost("UpdateProcessoPai")]
        public async Task<IActionResult> UpdateProcessoPai(Guid id, UpdateProcessoPaiRequest request)
        {
            request.Id = id;

            return Ok(await _processoApp.UpdateProcessoPaiAsync(request));
        }
    }
}
