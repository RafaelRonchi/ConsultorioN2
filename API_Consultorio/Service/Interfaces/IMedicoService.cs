namespace API_Consultorio.Service.Interfaces
{
    public interface IMedicoService
    {
        Task<Medico> AtualizarMedico(int id ,MedicoUpdateDTO medico);
        Task<IEnumerable<Medico>> ListarMedicoEspecialidade(string especialidade);
        Task<Medico> CadastrarMedico(Medico medico);
        Task<Medico> AtualizarEspecialidadeMedico(int id, string especialidade);


        //método extra da dupla:
        Task<List<Medico>> ListarTodosMedicos();
    }
}
