using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApplicationApi.Models
{
    public class PedidoModel
    {
        [Key]
       
        public int IdPedido { get; set; }

        public DateTime DataPedido { get; set; }
        
        // Chave estrangeira para Cliente
        public int ClienteId { get; set; }

        [JsonIgnore] // Ignora a serialização dessa propriedade
        public ClienteModel Cliente { get; set; }
       

        // Chave estrangeira para Status
        public int StatusId { get; set; }
        [JsonIgnore] // Ignora a serialização dessa propriedade
        public StatusModel Status { get; set; } 


        [JsonIgnore] // Ignora a serialização dessa propriedade
        // Relação de muitos-para-muitos com Produto
        public ICollection<ProdutoModel> Produtos { get; set; }

        
    }
}
