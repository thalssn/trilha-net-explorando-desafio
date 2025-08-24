using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;



bool exibirMenu = true;
Suite suiteCadastrada = null;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("Bem-vindo ao sistema de reservas do hotel!");
    Console.WriteLine("Digite sua opção: \n");
    Console.WriteLine("1 - Fazer reserva");
    Console.WriteLine("2 - Cadastrar novo quarto");
    Console.WriteLine("3 - Consultar quartos disponíveis");
    Console.WriteLine("4 - Encerrar \n");


    string entrada = Console.ReadLine();

    switch (entrada)
    {
        case "1":

            List<Pessoa> hospedes = new List<Pessoa>();

            Pessoa p1 = new Pessoa(nome: "Vinicius");
            Pessoa p2 = new Pessoa(nome: "Thalisson");

            hospedes.Add(p1);
            hospedes.Add(p2);

            Suite suite = suiteCadastrada != null ? suiteCadastrada : new Suite(tipoSuite: "Premium", capacidade: 4, valorDiaria: 300);

            Reserva reserva = new Reserva(diasReservados: 11);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            Console.WriteLine("\nDetalhes da Reserva\n");
            Console.WriteLine($"Tipo da Suíte: {reserva.Suite.TipoSuite}");
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");

            foreach (Pessoa p in hospedes)
            {
                Console.WriteLine($"- {p.Nome}");
            }

            decimal valorTotal = reserva.CalcularValorDiaria();
            decimal valorOriginal = reserva.DiasReservados * reserva.Suite.ValorDiaria;

            Console.WriteLine($"Valor total da reserva: R${valorOriginal:N2}");

            if (reserva.DiasReservados >= 10)
            {
                Console.WriteLine($"Desconto de 10% aplicado: R${valorOriginal - valorTotal:N2}");
                Console.WriteLine($"Valor final com desconto: R${valorTotal:N2}");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadLine();
            break;

        case "2":
            Console.WriteLine("Opção 2 selecionada: Cadastrar Novo Quarto");
            Console.WriteLine("Digite o tipo da suite: ");
            string tipoSuite = Console.ReadLine();

            Console.WriteLine("Digite a capacidade da suite:");
            int capacidade = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            suiteCadastrada = new Suite(tipoSuite: tipoSuite, capacidade: capacidade, valorDiaria: valorDiaria);

            Console.WriteLine($"\nSuite {suiteCadastrada.TipoSuite} cadastrada com sucesso!");
            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadLine();
            break;

        case "3":

            Console.WriteLine("Opção 3 selecionada: Consultar Quartos disponíveis");
            if (suiteCadastrada != null)
            {
                Console.WriteLine($"Tipo da suite: {suiteCadastrada.TipoSuite}, capacidade: {suiteCadastrada.Capacidade}, valor da diária R${suiteCadastrada.ValorDiaria}.");
            }
            else
            {
                Console.WriteLine("Nenhuma suite foi cadastrada. Por favor, cadastre uma nova suite!");
            }

            Console.WriteLine("\nPressione uma tecla para continuar...");
            Console.ReadLine();
            break;

        case "4":
            Console.WriteLine("Encerrando o programa...");
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida!");
            Console.WriteLine("Pressione uma tecla para continuar...");
            Console.ReadLine();
            break;
    }
}
