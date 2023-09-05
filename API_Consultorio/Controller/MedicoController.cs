using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultorio.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoService _medicoService;

        public MedicoController(IMedicoService medicoService)
        {
            _medicoService = medicoService;
        }

        [HttpGet]
        [Route("especialidade={especialidade}")]
        public async Task<ActionResult<IEnumerable<Medico>>> ListarMedicoEspecialidade(string especialidade)
        {
            var medicos = await _medicoService.ListarMedicoEspecialidade(especialidade);
            if (medicos is null) return NotFound();
            return Ok(medicos);
        }

        [HttpGet]
        public async Task<ActionResult<Medico>> ListarTodosMedicos()
        {
            var medicos = await _medicoService.ListarTodosMedicos();
            if (medicos is null) return NotFound();
            return Ok(medicos);
        }


        [HttpPost]
        public async Task<ActionResult<Medico>> CadastrarMedico(Medico medico)
        {
            return await _medicoService.CadastrarMedico(medico);
        }

        [HttpPatch]
        [Route("especialidade/{id}")]
        public async Task<ActionResult<Medico>> AtualizarEspecialidadeMedico(int id, string especialidade)
        {
            var medicos = await _medicoService.AtualizarEspecialidadeMedico(id, especialidade);
            if (medicos is null) return NotFound();
            return Ok(medicos);
        }

        [HttpPut]
        [Route("contato/{id}")]
        public async Task<ActionResult<Medico>> AtualizarMedico(int id, MedicoUpdateDTO medicoUpdateDTO)
        {
            var medicos = await _medicoService.AtualizarMedico(id, medicoUpdateDTO);
            if (medicos is null) return NotFound();
            return Ok(medicos);
        }
    }
}
