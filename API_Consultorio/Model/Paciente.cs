namespace API_Consultorio.Model
{
    public class Paciente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; } = 0;
        public DateTime DataDeNascimento { get; set; } = DateTime.Now;
        public string CPF { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string Endereco { get; set; } = string.Empty;
        public string Sexo { get; set; } = string.Empty;

        


    }
}
