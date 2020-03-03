using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class ItemPedido : BaseModel
    {
        [Required]
        [DataMember]
        public Pedido Pedido { get; private set; }
        [Required]
        [DataMember]
        public string ProdutoCodigo { get; private set; }
        [Required]
        [DataMember]
        public string ProdutoNome { get; private set; }
        [Required]
        [DataMember]
        public int Quantidade { get; private set; }
        [Required]
        [DataMember]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PrecoUnitario { get; private set; }
        [DataMember]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Subtotal => Quantidade * PrecoUnitario;

        public ItemPedido()
        {

        }

        public ItemPedido(Pedido pedido, string produtoCodigo, string produtoNome, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            ProdutoCodigo = produtoCodigo;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        internal void AtualizaQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }
    }
}
