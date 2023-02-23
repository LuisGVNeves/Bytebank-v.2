using Bytebank.Repository;
using Bytebank.Services;

namespace Bytebank.View;

public class MenuByteBank
{

    // Criar, ler, deletar, atualizar cliente
    public static ContaRepository contaRepository = new ContaRepository();

    // Instanciei um objeto do tipo BancoServico
    public static BancoServico bancoServico = new BancoServico();

    public static void MostrarMenu()
    {
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(@"╔═════════════════════════                          ═════════════════════════╗");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(@"            ════════════════ BOAS VINDAS BYTEBANK ════════════════    ");
        Console.ResetColor();
        Console.WriteLine(@"╚═════════════════════════                          ═════════════════════════╝");

        Console.ResetColor();
        Console.WriteLine("\n\n     ByteBank é um banco terminal feito em C#, com conhecimentos aprendidos");
        Console.WriteLine("     na escola Imã Learning Place.");
        Console.Write("\n\n     Deseja iniciar o BYTEBANK? Sim ou Não: ");


        string respostaUsuario = Console.ReadLine().ToUpper();


        if(respostaUsuario == "SIM")
        {
            MostrarInterfacePrincipal();
        }
        else
        {
            System.Environment.Exit(0);
        }

    }


    public static void MostrarInterfacePrincipal()
    {
        Console.Clear();

        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("╔═════════════════════════    INTERFACE BYTEBANK   ════════════════════════╗");
        Console.ResetColor();

        Console.WriteLine("\n                        1  -  Cadastrar novo cliente");

        Console.WriteLine("                        2  -  Atualizar dados do cliente");

        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("                        3  -  Deletar um cliente");
        Console.ResetColor();

        Console.WriteLine("                        4  -  Listar todos os clientes do banco");

        Console.WriteLine("                        5  -  Manipular conta Cliente");


        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("                        6  -  Para sair do programa");
        Console.ResetColor();

        Console.Write("\n                           Digite a opção desejada: ");

        short resposta = short.Parse(Console.ReadLine());


        if(resposta == 1)
        {
            contaRepository.CriarCliente();
        }
        if(resposta == 2)
        {
            contaRepository.AtualizarCliente();
        }
        if (resposta == 3)
        {
            contaRepository.DeletarCliente();
        }
        if (resposta == 4)
        {
            contaRepository.ListarClientes();
        }
        if (resposta == 5)
        {
            bancoServico.ManipularConta();
        }
        if (resposta == 6)
        {
            System.Environment.Exit(0);
        }
    }
}
