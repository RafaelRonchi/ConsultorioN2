namespace API_Consultorio.Service.Interfaces
{
    public interface IPacienteService
    {
        Task<Paciente> AtualizarPacienteTelefone(int id, PacienteUpdateTelDTO tel);
        Task<IEnumerable<Paciente>> ListarPacienteIdade(int idade);
        Task<Paciente> CadastrarPaciente(Paciente paciente);
        Task<Paciente> AtualizarEnderecoPaciente(int id, PacienteUpdateDTO endereco);
    
        //metodo extra da dupla
        Task<Paciente> GetPacientePorNome(string nome);

        Task<List<Paciente>> ListarTodosPaciente();


    }
}
