using API_Consultorio.Model;

namespace API_Consultorio.Service
{
    public class MedicoService : IMedicoService
    {
        private readonly DataContext _context;

        public MedicoService(DataContext context)
        {
            _context = context;
        }

        public async Task<Medico> AtualizarEspecialidadeMedico(int id, string especialidade)
        {
            var existMedico = await _context.Medicos.FindAsync(id);
            if (existMedico is null) return null;

            existMedico.Especialidade = especialidade;
            await _context.SaveChangesAsync();
            return existMedico;
        }

        public async Task<Medico> AtualizarMedico(int id, MedicoUpdateDTO medico)
        {
            var existMedico = await _context.Medicos.FindAsync(id);
            if (existMedico is null) return null;

            existMedico.Telefone = medico.Telefone;
            existMedico.Endereco = medico.Endereco;

            await _context.SaveChangesAsync();
            return existMedico;
        }

        public async Task<Medico> CadastrarMedico(Medico medico)
        {
            _context.Medicos.Add(medico);
            await _context.SaveChangesAsync();
            return medico;
        }


        public async Task<IEnumerable<Medico>> ListarMedicoEspecialidade(string especialidade)
        {
            var Medicos = _context.Medicos.Where(m => m.Especialidade == especialidade).ToListAsync();
            if (Medicos is null) return null; 
            return await Medicos;
        }

        public async Task<List<Medico>> ListarTodosMedicos()
        {
            var medicos = await _context.Medicos.ToListAsync();
            if (medicos == null) return null;
            return medicos;

        }
    }
}
