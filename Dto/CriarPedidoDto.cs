namespace WebApplicationApi.Dto
{
    public class CriarPedidoDto
    {
        public int ClienteId { get; set; }
        public DateTime DataPedido { get; set; }
        public int StatusId { get; set; }  // Mudei de string para int para o ID do status
        public List<int> ProdutoIds { get; set; } = new List<int>();
    }
}
