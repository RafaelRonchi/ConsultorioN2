namespace API_Consultorio.Service.Interfaces
{
    public interface IConsultaService
    {
        Task<string> AgendarConsulta(ConsultaPostDTO consulta);

        Task<List<Consulta>> GetConsultasByMedico(int id);
        Task<List<Consulta>> GetConsultasByPaciente(int id);

        Task<List<Consulta>> GetConsultasByData(DateTime data);

        Task<string> DeleteConsulta(int id);


        

        
    }
}
