#region Codigo
using BancoLL;

List<String> Clientes = new List<string>();
ConsultarCliente();

void ConsultarCliente()
{
    Console.WriteLine("Olá! Bem vindo ao banco LL.");
    Console.WriteLine("Digite o seu código: ");
    string codigo = Console.ReadLine();
    Cliente cliente = null;

    foreach (Cliente cli in Clientes)
    {
        if (cli.codigo == codigo)
        {
            cliente = cli;
        }
    }
    if (cliente == null)
    {
        Console.WriteLine("Desculpe, mas este cliente não existe. Deseja cadastrar? Digite S ou N");
        string cadastrarCliente = Console.ReadLine();
        if (cadastrarCliente == "S")
        {
            Console.WriteLine("Digite seu código:");
            string codigoCliente = Console.ReadLine();

        }
    }
}

void ExibirMenu(Cliente cliente)
{
    Console.WriteLine($"Olá, {cliente.Nome}");
    Console.WriteLine("Digite a opção desejada:");
    Console.WriteLine("1 - Extrato");
    Console.WriteLine("2 - Saque");
    Console.WriteLine("3 - Depósito");

    string menu = Console.ReadLine();

    switch (menu)
    {
        case "1":
            ExibirMenu(cliente); break;
        case "2":
            RealizarSaque(cliente); break;
        case "3":
            RealizarDeposito(cliente);break;
        default:
            Console.WriteLine("A opção selecionada não existe. Escolha dentre as opções válidas.");
            ExibirMenu(cliente); break;
    }
}

void ExibirExtrato(Cliente cliente)
{
    Console.Write("----------- Extrato -----------");
    foreach (Movimentacao mov in cliente.Movimentacoes)
    {
        Console.WriteLine($"{mov.Tipo} - {mov.Valor}");
    }
    Console.WriteLine("Deseja exibir o menu novamente? Digite S ou N");
    string consultarCliente = Console.ReadLine();
    if(consultarCliente == "S")
    {
        ConsultarCliente();
    }

}

void RealizarSaque(Cliente cliente)
{
    Console.WriteLine("Digite o valor que deseja sacar: ");
    decimal valor = Convert.ToDecimal(Console.ReadLine());
    cliente.RealizarSaque(valor);
    Console.WriteLine("Desejar realizar outra transação? Digite S/N");
    string realizarOutraTransacao = Console.ReadLine();
    if(realizarOutraTransacao == "S")
    {
        ExibirMenu(cliente);
    }
    else
    {
        Console.WriteLine("É sempre um prazer atender você! Até a próxima");
    }
}

void RealizarDeposito(Cliente cliente)
{

}