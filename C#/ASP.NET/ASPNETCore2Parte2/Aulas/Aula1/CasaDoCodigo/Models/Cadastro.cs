using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Models
{
    public class Cadastro : BaseModel
    {
        public Cadastro()
        {
        }

        public virtual Pedido Pedido { get; set; }

        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; } = "";

        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; } = "";

        internal void Update(Cadastro novoCadastro)
        {
            Bairro = novoCadastro.Bairro;
            CEP = novoCadastro.CEP;
            Complemento = novoCadastro.Complemento;
            Email = novoCadastro.Email;
            Endereco = novoCadastro.Endereco;
            Municipio = novoCadastro.Municipio;
            Nome = novoCadastro.Nome;
            Telefone = novoCadastro.Telefone;
            UF = novoCadastro.UF;
        }

        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Endereco é obrigatório")]
        public string Endereco { get; set; } = "";

        [Required(ErrorMessage = "Complemento é obrigatório")]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; } = "";

        [Required(ErrorMessage = "Municipio é obrigatório")]
        public string Municipio { get; set; } = "";

        [Required(ErrorMessage = "UF é obrigatório")]
        public string UF { get; set; } = "";

        [Required(ErrorMessage = "CEP é obrigatório")]
        public string CEP { get; set; } = "";

    }
}
