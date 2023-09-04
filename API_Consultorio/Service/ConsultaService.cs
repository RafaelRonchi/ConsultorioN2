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

        public async Task<string> AgendarConsulta(ConsultaPostDTO consulta)
        {
            Consulta consulta1 = new Consulta();
            consulta1.Data = consulta.Data;
            consulta1.Descricao = consulta.Descricao;
            consulta1.Prescricao = consulta.Prescricao;
            consulta1.MedicoID = consulta.MedicoID;
            consulta1.PacienteID = consulta.PacienteID;

            _context.Consultas.Add(consulta1);
            await _context.SaveChangesAsync();
            return $"Consulta agendada para a data: {consulta1.Data}";
        }

        public async Task<string> DeleteConsulta(int id)
        {
            var consulta = _context.Consultas.FirstOrDefault(c => c.Id == id);
            if (consulta == null) {return null;}
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();

            return "Consulta removida do sistema com sucesso.";
        }

        public async Task<List<Consulta>> GetConsultasByData(DateTime data)
        {
            var consultas = await _context.Consultas.Where(c => c.Data == data)
                .ToListAsync();
            if(consultas == null) return null;
            return consultas;

        }

        public async Task<List<Consulta>> GetConsultasByMedico(int id)
        {
            var consultas = await _context.Consultas.Where(c => c.MedicoID == id)
                .ToListAsync();
            if (consultas == null) return null;
            return consultas;
        }

        public async Task<List<Consulta>> GetConsultasByPaciente(int id)
        {
            var consultas = await _context.Consultas.Where(c => c.PacienteID == id)
                .ToListAsync();
            if (consultas == null) return null;
            return consultas;
        }
    }
}
