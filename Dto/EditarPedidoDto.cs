namespace WebApplicationApi.Dto
{
    public class EditarPedidoDto
    {
        public int IdPedido { get; set; }
        public DateTime DataPedido { get; set; }
        public int StatusId { get; set; }
        public List<int> ProdutoIds { get; set; } = new List<int>();
    }
}
