using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Pedido : BaseModel
    {
        public Pedido(string clienteId)
        {
            ClienteId = clienteId;
            Cadastro = new Cadastro();
        }

        public Pedido(string clienteId, Cadastro cadastro)
        {
            ClienteId = clienteId;
            Cadastro = cadastro;
        }

        public List<ItemPedido> Itens { get; private set; } = new List<ItemPedido>();

        [ForeignKey("CadastroId")]
        public int CadastroId { get; set; }
        [Required]
        public virtual Cadastro Cadastro { get; private set; }
        [Required]
        public string ClienteId { get; set; }
    }
}
