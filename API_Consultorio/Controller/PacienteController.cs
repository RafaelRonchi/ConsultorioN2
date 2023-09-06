using API_Consultorio.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Consultorio.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteService;

        public PacienteController(IPacienteService pacienteService)
        {
            _pacienteService = pacienteService;
        }

        [HttpPatch]
        [Route("{id}")]
        public async Task<ActionResult<Paciente>> AtualizarEnderecoPaciente(int id, PacienteUpdateDTO pacienteUpdateDTO)
        {
            var paciente = await _pacienteService.AtualizarEnderecoPaciente(id, pacienteUpdateDTO);
            if (paciente is null) return NotFound();
            return Ok(paciente);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Paciente>> AtualizarPacienteTelefone(int id, PacienteUpdateTelDTO pacienteUpdateDTO)
        {
            var paciente = await _pacienteService.AtualizarPacienteTelefone(id, pacienteUpdateDTO);
            if (paciente is null) return NotFound();
            return Ok(paciente);
        }

        [HttpPost]
        public async Task<ActionResult<Paciente>> CadastrarPaciente(Paciente paciente)
        {
            var pacienteR = await _pacienteService.CadastrarPaciente(paciente);
            if (pacienteR is null) return NotFound();
            return Ok(pacienteR);
        }

        [HttpGet]
        [Route("nome={nome}")]
        public async Task<ActionResult<Paciente>> GetPacientePorNome(string nome)
        {
            var pacienteR = await _pacienteService.GetPacientePorNome(nome);
            if (pacienteR is null) return NotFound();
            return Ok(pacienteR);
        }

        [HttpGet]
        [Route("pacientes/idade")]
        public async Task<ActionResult<IEnumerable<Paciente>>> ListarPacienteIdade(int idade)
        {
            var paciente = await _pacienteService.ListarPacienteIdade(idade);
            if (paciente is null) return NotFound();
            return Ok(paciente);
        }


        [HttpGet]
        public async Task<ActionResult<Medico>> ListarTodosPacientes()
        {
            var pacientes = await _pacienteService.ListarTodosPaciente();
            if (pacientes is null) return NotFound();
            return Ok(pacientes);
        }

    }
}
