using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CasaDoCodigo.Models
{
    public class Produto : BaseModel
    {
        public Produto()
        {

        }
            
        public int CategoriaId { get; private set; }

        [Required]
        public Categoria Categoria { get; private set; }
        [Required]
        public string Codigo { get; private set; }
        [Required]
        public string Nome { get; private set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Preco { get; private set; }

        public Produto(string codigo, string nome, decimal preco, Categoria categoria)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Preco = preco;
            this.Categoria = categoria;
        }

        public Produto(int id, string codigo, string nome, decimal preco, Categoria categoria)
    : this(codigo, nome, preco, categoria)
        {
            Id = id;
        }
    }
}
