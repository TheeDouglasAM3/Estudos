using ByteBank.Modelos;
using ByteBank.SistemaAgencia.Comparators;
using ByteBank.SistemaAgencia.Extends;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            FinalTest();

            Console.ReadLine();
        }

        public static void FinalTest()
        {
            var contas = new List<ContaCorrente>
            {
                new ContaCorrente(124, 234568),
                new ContaCorrente(123, 456790),
                null,
                new ContaCorrente(99, 2345),
                new ContaCorrente(99, 1345)
            };

            var contasOrdenada = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach (var conta in contasOrdenada)
            {
                Console.WriteLine($"Conta Número: {conta.Numero} // Agência: {conta.Agencia}");
            }
        }

        public static void TestWhere()
        {
            var contas = new List<ContaCorrente>
            {
                new ContaCorrente(124, 234568),
                new ContaCorrente(123, 456790),
                null,
                new ContaCorrente(99, 2345),
                new ContaCorrente(99, 1345)
            };

            var listaContasSemNulo = contas.Where(conta => conta != null);

            IOrderedEnumerable<ContaCorrente> contasOrdenada =
                listaContasSemNulo.OrderBy(conta =>  conta.Numero);

            foreach (var conta in contasOrdenada)
            {
                Console.WriteLine($"Conta Número: {conta.Numero} // Agência: {conta.Agencia}");
            }
        }

        public static void TestOrderByMonth()
        {
            var meses = new List<string>()
            {
                "janeiro", "fevereiro", "março", "abril", "maio",
                "junho", "julhos", "agosto", "setembro", "outubro",
                "novembro", "dezembro"
            };

            //IOrderedEnumerable<string> mesesOrdenado = meses.OrderBy(mes => mes);
            var mesesOrdenado = meses.OrderBy(mes => mes);

            foreach (var mes in mesesOrdenado)
            {
                Console.WriteLine($"Mês: {mes}");
            }
        }

        public static void TestOrderBy()
        {
            var contas = new List<ContaCorrente>
            {
                new ContaCorrente(124, 234568),
                new ContaCorrente(123, 456790),
                null,
                null,
                new ContaCorrente(124, 234567),
                new ContaCorrente(123, 456789),
                null,
                new ContaCorrente(99, 2345),
                new ContaCorrente(99, 1345)
            };

            //contas.Sort(); ~~> chama implementacao dada em IComparable
            //contas.Sort(new ComparadorContaCorrentePorAgenciaENumero());

            //IOrderedEnumerable<ContaCorrente> contasOrdenada = contas.OrderBy(conta => conta.Numero);
            //IOrderedEnumerable<ContaCorrente> contasOrdenada = contas.OrderBy(conta => { return conta.Numero; });
            IOrderedEnumerable<ContaCorrente> contasOrdenada =
                contas.OrderBy(conta =>
                {
                    if (conta == null)
                        return int.MaxValue;

                    return conta.Numero;
                });

            /**foreach (var conta in contas)
            {
                Console.WriteLine($"Conta Número: {conta.Numero} // Agência: {conta.Agencia}");
            }**/

            foreach (var conta in contasOrdenada)
            {
                if (conta == null)
                {
                    Console.WriteLine("Conta nula!");
                }
                else
                {
                    Console.WriteLine($"Conta Número: {conta.Numero} // Agência: {conta.Agencia}");
                }
            }
        }

        public static void TestSort()
        {
            var idades = new List<int>();
            idades.Add(1);
            idades.Add(2);
            idades.Add(4);
            idades.Add(8);

            idades.Remove(4);

            idades.AddMultiple(2, 3, 4, 5, 6, 7);

            idades.Sort();

            foreach (int idade in idades)
            {
                Console.WriteLine(idade);
            }

            Console.WriteLine("----------------");
            Console.WriteLine($"Qtd de idades no array: {idades.Count}");

            var nomes = new List<string>()
            {
                "Douglas", "Willian", "Maria", "Adalberto"
            };

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }
        }
    }
}
