namespace ConsultorioN2.DTO
{
    public class MedicoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string CRM { get; set; } = string.Empty;
        public string Especialidade { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; } = DateTime.Now;
        public string Sexo { get; set; } = string.Empty;
    }
}
