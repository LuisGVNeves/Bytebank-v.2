namespace Bytebank.Models;

public class Cliente : Conta
{
    // Auto properties
    public string NomeCliente { get; set; }
    public string CpfCliente { get; set; }
    public string EnderecoCliente { get; set; }


    // Construtor = Constroi objeto
    public Cliente(string nomeCliente, string cpfCliente, string enderecoCliente, long numeroDaConta, decimal saldoDaConta) 
        : base(numeroDaConta,saldoDaConta)
    {
        NomeCliente = nomeCliente;
        CpfCliente = cpfCliente;
        EnderecoCliente = enderecoCliente;
        NumeroDaConta = numeroDaConta;
        SaldoDaConta = saldoDaConta;
    }




}
