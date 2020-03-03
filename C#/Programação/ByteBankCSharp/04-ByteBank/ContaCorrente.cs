public class ContaCorrente
{
    public string titular;
    public short numAgencia;
    public string numConta;
    public double saldo = 100;

    public bool Sacar(double valor)
    {
        if(this.saldo < valor)
            return false;
        
        this.saldo -= valor;
        return true;
    }

    public void Depositar(double valor)
    {
        if(valor > 0)
            this.saldo += valor;
    }

    public bool Tranferir(double valor, ContaCorrente contaDestino)
    {
        if (this.saldo < valor)
            return false;
       
        this.saldo -= valor;
        contaDestino.Depositar(valor);
        return true;
    }
}