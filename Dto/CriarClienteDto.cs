namespace WebApplicationApi.Dto
{
    public class CriarClienteDto
    {
        public string NomeCliente { get; set; } = string.Empty;
        public string EmailCliente { get; set; } = string.Empty;

        public DateTime DataNascimentoCliente { get; set; }
    }
}
