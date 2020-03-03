using System;

namespace A01_ByteBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        public Cliente Titular { get; set; }
        public short NumAgencia { get; }
        public string NumConta { get; }

        private double _saldo = 100;
        public double Saldo {
            get {
                return _saldo;
            }

            set {
                if (value < 0)
                    return;

                _saldo = value;
            }
        }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public ContaCorrente(short numAgencia, string numConta)
        {

            if (numAgencia <= 0)
                throw new ArgumentException("short numAgencia deve ser maior do que 0.", nameof(numAgencia));

            if (numConta == "")
                throw new ArgumentException("string numConta não pode ser nulo ou vazio.", nameof(numConta));

            NumAgencia = numAgencia;
            NumConta = numConta;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        public void Sacar(double valor)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para o saque", nameof(valor));

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
            
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
                _saldo += valor;
        }

        public void Tranferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
                throw new ArgumentException("Valor inválido para a tranferência", nameof(valor));

            try
            {
                Sacar(valor);
            }
            catch (SaldoInsuficienteException e)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperaçãoFinanceiraException("operação não realizada!", e);
            }
            
            contaDestino.Depositar(valor);
        }
    }
}