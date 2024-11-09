using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationApi.Models
{
    [Table("Statuses")]  // Define explicitamente o nome da tabela
    public class StatusModel
    {
        [Key]
        public int IdStatus { get; set; }
        public string NomeStatus { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public ICollection<PedidoModel> Pedidos { get; set; } = new List<PedidoModel>();
    }
}
