namespace Bytebank.Models;
public class Conta
{
    public long NumeroDaConta { get; set; }
    public decimal SaldoDaConta { get; set; }
    public Cliente cliente { get; set; }


    // Construtor
    public Conta(long numeroDaConta, decimal saldoDaConta)
    {
        NumeroDaConta = numeroDaConta;
        SaldoDaConta = saldoDaConta;
    }


}
