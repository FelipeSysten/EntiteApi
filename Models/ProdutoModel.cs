using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplicationApi.Models
{
    public class ProdutoModel
    {
        [Key]
        public int IdProduto { get; set; }

        public string NomeProduto { get; set; } = string.Empty;
        public string TipoProduto { get; set; } = string.Empty;
        public decimal ValorProduto { get; set; }

        // Relação de muitos-para-muitos com Pedido
        [JsonIgnore] // Ignora a serialização dessa propriedade para evitar ciclos
        public ICollection<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>(); // Adicione esta linha
    }
}
