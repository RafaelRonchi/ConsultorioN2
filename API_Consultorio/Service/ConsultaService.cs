using API_Consultorio.Model;
using System.Runtime.CompilerServices;

namespace API_Consultorio.Service
{
    public class ConsultaService : IConsultaService
    {
        private readonly DataContext _context;
        
        public ConsultaService (DataContext context)
        {
            _context = context;
        }

        public async Task<Consulta> AgendarConsulta(ConsultaPostDTO consulta)
        {
            Consulta consulta1 = new Consulta();
            consulta1.Id = consulta.Id;
            consulta1.Data = consulta.Data;
            consulta1.Descricao = consulta.Descricao;
            consulta1.Prescricao = consulta.Prescricao;
            consulta1.MedicoID = consulta.MedicoID;
            consulta1.PacienteID = consulta.PacienteID;

            _context.Consultas.Add(consulta1);
            await _context.SaveChangesAsync();

            consulta1.Paciente = await _context.Pacientes.FirstOrDefaultAsync(x => x.Id == consulta1.PacienteID);
            consulta1.Medico = await _context.Medicos.FindAsync(consulta1.MedicoID);
            return consulta1;
        }

        public async Task<Consulta> DeleteConsulta(int id)
        {
            var consulta = _context.Consultas.FirstOrDefault(c => c.Id == id);
            if (consulta == null) {return null;}
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            return consulta;
        }

        public async Task<List<Consulta>> GetConsultasByData(DateTime data)
        {
            var consultas = await _context.Consultas
       .Where(c => c.Data == data)
       .Include(c => c.Paciente) // Carrega o paciente relacionado
       .Include(c => c.Medico)   // Carrega o médico relacionado
       .ToListAsync();
            return consultas;
        }

        public async Task<List<Consulta>> GetConsultasByMedico(int id)
        {
            var consultas = await _context.Consultas.Where(c => c.MedicoID == id)
                .Include(c => c.Paciente) // Carrega o paciente relacionado
       .Include(c => c.Medico)   // Carrega o médico relacionado
                .ToListAsync();
            if (consultas == null) return null;
            return consultas;
        }

        public async Task<List<Consulta>> GetConsultasByPaciente(int id)
        {
            var consultas = await _context.Consultas.Where(c => c.PacienteID == id)
                .Include(c => c.Paciente) // Carrega o paciente relacionado
       .Include(c => c.Medico)   // Carrega o médico relacionado
                .ToListAsync();
            if (consultas == null) return null;
            return consultas;
        }
    }
}
