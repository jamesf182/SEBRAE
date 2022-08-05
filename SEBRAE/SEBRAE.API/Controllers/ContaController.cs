using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEBRAE.Application.DTOs;
using SEBRAE.Application.Interfaces;

namespace SEBRAE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        private readonly IContaService _contaService;

        public ContaController(IContaService contaService)
        {
            _contaService = contaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContaDTO>>> Get()
        {
            var contas = await _contaService.GetContas();

            if (contas == null)
            {
                return NotFound("Contas não encontradas.");
            }
            return Ok(contas);
        }

        [HttpGet("{id:int}", Name = "GetConta")]
        public async Task<ActionResult<ContaDTO>> GetById(int id)
        {
            var conta = await _contaService.GetById(id);

            if (conta == null)
            {
                return NotFound("Conta não encontrada.");
            }
            return Ok(conta);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ContaDTO contaDTO)
        {
            if (contaDTO == null)
                return BadRequest("Dados inválidos.");

            await _contaService.Add(contaDTO);

            return new CreatedAtRouteResult("GetConta", new { id = contaDTO.Id },
                contaDTO);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ContaDTO ContaDTO)
        {
            if (ContaDTO == null)
                return BadRequest("Dados inválidos.");

            if (id != ContaDTO.Id)
                return BadRequest("Dados inválidos.");
            
            await _contaService.Update(ContaDTO);

            return Ok(ContaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var conta = await _contaService.GetById(id);
            if (conta == null)
            {
                return NotFound("Conta não encontrada.");
            }

            await _contaService.Remove(id);

            return Ok(conta);
        }
    }
}
