namespace API_Consultorio.Service
{
    public class PacienteService : IPacienteService
    {
        private readonly DataContext _context;

        public PacienteService(DataContext context)
        {
            _context = context;
        }
        public async Task<Paciente> AtualizarEnderecoPaciente(int id, PacienteUpdateDTO endereco)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(x => x.Id == id);
            if (paciente == null) { return null; }
            paciente.Endereco = endereco.Endereco;
            _context.SaveChangesAsync();

            return paciente;
        }

        public async Task<Paciente> AtualizarPacienteTelefone(int id, PacienteUpdateTelDTO tel)
        {
            var paciente = await _context.Pacientes.FirstOrDefaultAsync(x => x.Id == id);
            if (paciente == null) { return null; }
            paciente.Telefone = tel.Telefone;
            _context.SaveChangesAsync();

            return paciente;
        }

        public async Task<Paciente> CadastrarPaciente(Paciente paciente)
        {
            _context.Pacientes.Add(paciente);
            await _context.SaveChangesAsync();

            return paciente;
        }

        public async Task<Paciente> GetPacientePorNome(string nome)
        {
            var paciente = _context.Pacientes.FirstOrDefault(x => x.Nome == nome);
            if (paciente == null) { return null; }
            return paciente;
        }

        public async Task<IEnumerable<Paciente>> ListarPacienteIdade(int idade)
        {
            IEnumerable<Paciente> pacientes = await _context.Pacientes.Where(p =>  p.Idade >= idade)
                .ToListAsync();

            return pacientes;
        }
    }
}
