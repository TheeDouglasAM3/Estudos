namespace _07_ByteBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; set; }
        public static int TotalDeContasCriadas { get; private set; }
        public Cliente Titular { get; set; }

        private short _numAgencia;
        public short NumAgencia {
            get {
                return _numAgencia;
            }
            set {
                if (value <= 0)
                    return;

                _numAgencia = value;
            }
        }
        public string NumConta { get; set; }

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

        public ContaCorrente(short numAgencia, string numConta)
        {
            NumAgencia = numAgencia;
            NumConta = numConta;
            TaxaOperacao = 30 / TotalDeContasCriadas;
            TotalDeContasCriadas++;
        }

        public bool Sacar(double valor)
        {
            if (_saldo < valor)
                return false;

            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            if (valor > 0)
                _saldo += valor;
        }

        public bool Tranferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
                return false;

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}