namespace ConsultorioN2.DTO
{
    public class ConsultaPostDTO
    {
        public int Id { get; set; }
        public DateTime Data { get; set; } = DateTime.Now;
        public string Descricao { get; set; } = string.Empty;
        public string Prescricao { get; set; } = string.Empty;

        public int MedicoID { get; set; }
        public int PacienteID { get; set; }
    }
}
