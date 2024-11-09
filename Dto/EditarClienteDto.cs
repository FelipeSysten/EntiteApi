namespace WebApplicationApi.Dto
{
    public class EditarClienteDto
    {
        public int IdCliente { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public string EmailCliente { get; set; } = string.Empty;
        public DateTime DataNascimentoCliente { get; set; }
    }
}
