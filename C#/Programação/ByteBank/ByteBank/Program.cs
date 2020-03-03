using ByteBank.Funcionarios;
using ByteBank.Sistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            //CalcularBonificacao();
            UsarSistema();
            Console.ReadLine();
        }

        public static void CalcularBonificacao()
        {
            GerenciadorBonificacao gerenciadorBonificacao = new GerenciadorBonificacao();

            Auxiliar auxiliar = new Auxiliar("123.456.789-99");
            auxiliar.Nome = "Amemiya";

            Designer designer = new Designer("456.123.789-99");
            designer.Nome = "Rebeca";

            Diretor diretor = new Diretor("789.123.456-99");
            diretor.Nome = "Douglas";

            GerenteDeConta gerente = new GerenteDeConta("123.789.456-99");
            gerente.Nome = "Haru";

            gerenciadorBonificacao.Registrar(auxiliar);
            gerenciadorBonificacao.Registrar(designer);
            gerenciadorBonificacao.Registrar(diretor);
            gerenciadorBonificacao.Registrar(gerente);

            Console.WriteLine("Total " + gerenciadorBonificacao.GetTotalBonificacao());
        }

        public static void UsarSistema()
        {
            SistemaInterno sistemaInterno = new SistemaInterno();
            Diretor diretor = new Diretor("123.456.789-99");
            diretor.Senha = "123";

            ParceiroComercial parceiro = new ParceiroComercial();
            parceiro.Senha = "145";

            sistemaInterno.Logar(diretor, "123");
            sistemaInterno.Logar(diretor, "125");
            sistemaInterno.Logar(parceiro, "145");
            sistemaInterno.Logar(parceiro, "155");
        }
    }
}
