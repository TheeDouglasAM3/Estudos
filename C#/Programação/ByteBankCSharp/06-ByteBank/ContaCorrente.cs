namespace _06_ByteBank
{
    public class ContaCorrente
    {
        public Cliente Titular { get; set; }
        public short NumAgencia { get; set; }
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