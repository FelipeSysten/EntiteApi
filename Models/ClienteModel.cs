using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationApi.Models
{
    public class ClienteModel
    {
        [Key]
        public int IdCliente { get; set; }

        public string NomeCliente { get; set; } = string.Empty;
        public string EmailCliente { get; set; } = string.Empty;
        public string NumeroCliente { get; set; } = string.Empty;
        public DateTime DataNascimentoCliente { get; set; }

        // Relação de um-para-muitos com Pedido
        public ICollection<PedidoModel> Pedidos { get; set; }
    }

}
