namespace Bytebank.Repository;

using Bytebank.Models;
using Bytebank.View;

public interface IContaRepository
{
    void CriarCliente() { }
    void DeletarCliente() { }
    void AtualizarCliente() { }
    void ListarClientes() { }
}

public class ContaRepository : IContaRepository
{
    // Lista para armazenar os clientes
    public static List<Cliente> listaUsuario = new List<Cliente>();

    public void CriarCliente() 
    {
        Console.WriteLine("Digite o nome do cliente: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite o cpf do cliente: ");
        string cpf = Console.ReadLine();

        Console.WriteLine("Digite o endereço do cliente: ");
        string endereco = Console.ReadLine();


        // Numero da conta do cliente
        long numeroAleatorio = 450;

        // Lista - instancio um cliente
        listaUsuario.Add(new Cliente(nome,cpf,endereco,numeroAleatorio,0));


        Console.WriteLine("Usuário criado com sucesso !");


        Thread.Sleep(2000);
        MenuByteBank.MostrarInterfacePrincipal();
    }

    public void DeletarCliente() 
    {
        Console.WriteLine("Digite o nome do usuário que você quer deletar: ");
        string nomeDeletar = Console.ReadLine();


        for (int i = 0; i < listaUsuario.Count; i++)
        {
            if (listaUsuario[i].NomeCliente == nomeDeletar)
            {
                listaUsuario.RemoveAt(i);

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nUsuário {nomeDeletar} deletado com sucesso !\n");
                Console.ResetColor();

                System.Threading.Thread.Sleep(2000);
                Console.Clear();
            }
        }


        MenuByteBank.MostrarInterfacePrincipal();
    }    

    public void AtualizarCliente() 
    {
        Console.WriteLine("Digite o nome do cliente para atualizar os dados: ");
        string nomeCliente = Console.ReadLine();

        listaUsuario.ForEach((Cliente cliente) =>
        {
            if(cliente.NomeCliente == nomeCliente)
            {
                Console.WriteLine("1 - Alterar o nome do cliente");
                Console.WriteLine("2 - Alterar cpf do cliente");
                Console.WriteLine("3 - Alterar o endereço do cliente");

                short respostaUsuario = short.Parse(Console.ReadLine());

                // Caso queira atualizar o nome do cliente
                if(respostaUsuario == 1)
                {
                    Console.WriteLine("Digite o nome do usuário atualizado: ");
                    string nomeAtualizado = Console.ReadLine();

                    cliente.NomeCliente = nomeAtualizado;
                }

                // Caso queira atualizar o cpf do cliente
                if (respostaUsuario == 2)
                {
                    Console.WriteLine("Digite o cpf do usuário atualizado: ");
                    string cpfAtualizado = Console.ReadLine();

                    cliente.CpfCliente = cpfAtualizado;
                }

                // Caso queira atualizar o endereço do cliente
                if (respostaUsuario == 3)
                {
                    Console.WriteLine("Digite o endereço do usuário atualizado: ");
                    string enderecoAtualizado = Console.ReadLine();

                    cliente.EnderecoCliente = enderecoAtualizado;
                }
            }
        });

        Thread.Sleep(2000);
        MenuByteBank.MostrarInterfacePrincipal();
    }

    public void ListarClientes() 
    {
        listaUsuario.ForEach((Cliente cliente) =>
        {
            Console.WriteLine(cliente.NomeCliente);
        });

        Thread.Sleep(2000);
        MenuByteBank.MostrarInterfacePrincipal();
    }

}
