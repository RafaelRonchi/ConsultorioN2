namespace ConsultorioN2.DTO
{
    public class PacienteDTO
    {
        public string Nome { get; set; } = string.Empty;
        public DateTime DataDeNascimento { get; set; } = DateTime.Now;
        public string CPF { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;
    }
}
