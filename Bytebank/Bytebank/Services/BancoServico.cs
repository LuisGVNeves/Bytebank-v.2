using Bytebank.Models;
using Bytebank.Repository;
using Bytebank.View;

namespace Bytebank.Services;

public class BancoServico
{

    // Método para manipular a conta
    public void ManipularConta()
    {
        Console.WriteLine("Digite o nome do cliente: ");
        string nome = Console.ReadLine();

        // Percorrer a lista para fornecer os metodos de deposito, saque e transferencia
        for (int i = 0; i < ContaRepository.listaUsuario.Count; i++)
        {
            if(nome == ContaRepository.listaUsuario[i].NomeCliente)
            {
                Console.WriteLine("1 - Sacar dinheiro");
                Console.WriteLine("2 - Depositar dinheiro");
                Console.WriteLine("3 - Realizar transferencia");
                Console.WriteLine("4 - Checar Saldo");

                short respostaUsuario = short.Parse(Console.ReadLine());

                // Se usuario quiser sacar
                if(respostaUsuario == 1)
                {
                    FazerSaque(ContaRepository.listaUsuario[i]);
                }
                if(respostaUsuario == 2)
                {
                    FazerDeposito(ContaRepository.listaUsuario[i]);
                }
                if(respostaUsuario == 3)
                {
                    FazerTransferencia(ContaRepository.listaUsuario[i]);
                }
                if (respostaUsuario == 4)
                {
                    ChecarSaldo(ContaRepository.listaUsuario[i]);
                }
            }
        }
        

    }


    // Método de fazer deposito
    public void FazerDeposito(Cliente cliente)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine(@"╔═════════════════════════ AREA DEPOSITO ════════════════════════╗");
        Console.ResetColor();


        Console.WriteLine("Digite o valor do deposito: ");
        decimal valorDeposito = decimal.Parse(Console.ReadLine());

        if(valorDeposito > 0)
        {
            cliente.SaldoDaConta += valorDeposito;
            Console.Clear();

            Console.WriteLine($"Quantidade de {valorDeposito} depositado com sucesso !");
            Console.WriteLine($"ID de transação: {Guid.NewGuid()}");

            Thread.Sleep(2000);

            MenuByteBank.MostrarInterfacePrincipal();
        }
        else
        {
            Console.WriteLine("Não é possivel depositar valores negativos ! ");

            Thread.Sleep(2000);

            MenuByteBank.MostrarInterfacePrincipal();
        }
    }


    // Método de fazer saque
    public void FazerSaque(Cliente cliente)
    {
        Console.Write("Digite o valor a sacar: ");
        decimal valorSacar = decimal.Parse(Console.ReadLine());

        if(valorSacar > 0 && cliente.SaldoDaConta >= valorSacar)
        {
            cliente.SaldoDaConta -= valorSacar;

            Console.Clear();
            Console.WriteLine($"Quantidade {valorSacar} sacada com sucesso ! ID transação: {Guid.NewGuid()}");
            Thread.Sleep(2000);

            MenuByteBank.MostrarInterfacePrincipal();
        }
        else
        {
            Console.WriteLine("Quantidade inferior a zero, ou o saldo é insuficiente");

            Thread.Sleep(2000);
            MenuByteBank.MostrarInterfacePrincipal();
        }
    }


    // Método de realizar transferencia
    public void FazerTransferencia(Cliente cliente)
    {
        Console.WriteLine("Digite o valor a transferir: ");
        decimal valorTransferencia = decimal.Parse(Console.ReadLine());

        // Se valor da transferencia for maior que zero, e o saldo da conta de quem transfere for maior ou igual ao valor da transferencia
        if(valorTransferencia > 0 && cliente.SaldoDaConta > valorTransferencia)
        {
            // Usuario que vai realizar a transferencia
            cliente.SaldoDaConta -= valorTransferencia;

            Console.WriteLine("Digite o nome do cliente que irá receber a transferência: ");
            string clienteReceberTransferencia = Console.ReadLine();


            // Percorrendo a minha lista de clientes
            for (int i = 0; i < ContaRepository.listaUsuario.Count; i++)
            {
                // Se lista percorrida, acessando o nome de cada cliente, for igual ao cliente que vai receber a transferencia, então o cliente da lista, vai ter o saldo incrementado no valor da transferencia
                if (ContaRepository.listaUsuario[i].NomeCliente == clienteReceberTransferencia)
                {
                    ContaRepository.listaUsuario[i].SaldoDaConta += valorTransferencia;

                    Console.Clear();

                    Console.WriteLine($"Quantidade {valorTransferencia} realizada com sucesso ! ID transação: {Guid.NewGuid()}");
                    Thread.Sleep(2000);

                    MenuByteBank.MostrarInterfacePrincipal();
                }
          
            }
        }
        else
        {
            Console.Write("Saldo negativo !");
            Thread.Sleep(2000);

            MenuByteBank.MostrarInterfacePrincipal();
        }
    }


    // Método checar saldo
    public void ChecarSaldo(Cliente cliente)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine(@"╔═════════════════════════ SALDO USUÁRIOS BYTEBANK ════════════════════════╗");
        Console.ResetColor();

        Console.WriteLine($"Cliente: {cliente.NomeCliente}");
        Console.WriteLine($"Saldo atual: {cliente.SaldoDaConta}");

        Thread.Sleep(2000);
        MenuByteBank.MostrarInterfacePrincipal();
    }


}
