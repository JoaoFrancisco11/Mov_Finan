#region Codigo
using Mov_Finan;

List<Cliente> Clientes = new List<Cliente>();
ConsultarCliente();

void ConsultarCliente()
{
    Console.WriteLine("Olá! Bem vindo ao banco LL.");
    Console.WriteLine("Digite o seu código: ");
    string codigo = Console.ReadLine();
    Cliente cliente = null;

    foreach (Cliente cli in Clientes)
    {
        if (cli.Codigo == codigo)
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
            string codigoClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite o seu nome: ");
            string nomeClienteNovo = Console.ReadLine();
            Console.WriteLine("Digite PF para Pessoa Física ou PJ para Pessoa Jurídica:");
            string tipoPessoa = Console.ReadLine();
            if (tipoPessoa == "PF")
            {
                cliente = new PessoaFisica(codigoClienteNovo, nomeClienteNovo);
            }
            else
            {
                cliente = new PessoaJuridica(codigoClienteNovo, nomeClienteNovo);
            }
            Clientes.Add(cliente);
            ExibirMenu(cliente);

        }
        else
            ConsultarCliente();
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
            ExibirExtrato(cliente); break;
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
    Console.Write("----------- Extrato -----------\n");
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
    Console.WriteLine("Digite o valor que deseja depositar: ");
    decimal valor = Convert.ToDecimal(Console.ReadLine());
    cliente.RealizarDeposito(valor);
    Console.WriteLine("Deseja realizar outra transação? Digite S ou N");
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

#endregion