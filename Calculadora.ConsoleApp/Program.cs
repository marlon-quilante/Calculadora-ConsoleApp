namespace Calculadora.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            string[] historicoOperacoes = new string[100];
            int contadorHistorico = 0;

            //loop de execução - estrutura de repetição
            while (true)
            {
                //exibição do cabeçalho e do menu
                string opcao = Menu();

                try
                {
                    if (OpcaoSairFoiEscolhida(opcao))
                        break;

                    else if (OpcaoTabuadaFoiEscolhida(opcao))
                        ExibirTabuada();

                    else if (OpcaoHistoricoFoiEscolhida(opcao))
                    {
                        ExibirHistoricoOperacoes(contadorHistorico, historicoOperacoes);
                    }
                    else
                    {
                        decimal resultado = RealizarCalculo(opcao, contadorHistorico, historicoOperacoes);

                        ExibirResultado(resultado);

                        contadorHistorico++;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro! Pressione qualquer tecla para continuar...");
                    Console.ReadLine();
                    continue;
                }
            }
        }

        static string Menu()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Calculadora Tabajara 2025");
            Console.WriteLine("--------------------------------------");

            Console.WriteLine("\nSelecione uma opção...\n");

            Console.WriteLine("1 - Somar");
            Console.WriteLine("2 - Subtrair");
            Console.WriteLine("3 - Multiplicação");
            Console.WriteLine("4 - Divisão");
            Console.WriteLine("5 - Tabuada");
            Console.WriteLine("6 - Histórico de Operações");
            Console.WriteLine("S - Sair\n");

            return Console.ReadLine().ToUpper();
        }

        static bool OpcaoSairFoiEscolhida(string opcao)
        {
            return opcao == "S";
        }

        static bool OpcaoTabuadaFoiEscolhida(string opcao)
        {
            return opcao == "5";
        }

        static void ExibirTabuada()
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Tabuada");
            Console.WriteLine("--------------------------------------\n");
            
            Console.Write("Digite um número inteiro: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            for (int i = 1; i <= 10; i++)
                Console.WriteLine($"\n{numero} x {i} = {numero * i}");

            Console.Write("Pressione qualquer botão para continuar!");
            Console.ReadLine();
        }

        static bool OpcaoHistoricoFoiEscolhida(string opcao)
        {
            return opcao == "6";
        }

        static void ExibirHistoricoOperacoes(int contadorHistorico, string[] historicoOperacoes)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Histórico de Operações");
            Console.WriteLine("--------------------------------------\n");

            for (int i = 0; i < contadorHistorico; i++)
                Console.WriteLine(historicoOperacoes[i]);

            Console.Write("\nPressione qualquer botão para continuar!");
            Console.ReadLine();
        }

        static decimal RealizarCalculo(string opcao, int contadorHistorico, string[] historicoOperacoes)
        {
            decimal resultado = 0.0m;

            Console.Write("\nDigite o primeiro número: ");
            decimal primeiroNumero = decimal.Parse(Console.ReadLine());

            Console.Write("Digite o segundo número: ");
            decimal segundoNumero = decimal.Parse(Console.ReadLine());

            //estrutura de decisão se
            if (opcao == "1")
            {
                //soma
                resultado = primeiroNumero + segundoNumero;
                historicoOperacoes[contadorHistorico] = $"Soma -> {primeiroNumero} + {segundoNumero} = {resultado}";
            }

            else if (opcao == "2")
            {
                //subtração
                resultado = primeiroNumero - segundoNumero;
                historicoOperacoes[contadorHistorico] = $"Subtração -> {primeiroNumero} - {segundoNumero} = {resultado}";
            }

            else if (opcao == "3")
            {
                //multiplicação
                resultado = primeiroNumero * segundoNumero;
                historicoOperacoes[contadorHistorico] = $"Multiplicação -> {primeiroNumero} x {segundoNumero} = {resultado}";
            }

            else if (opcao == "4")
            {
                while (segundoNumero == 0)
                {
                    Console.WriteLine("\nDenominador não pode ser 0!\n");
                    Console.Write("Digite o segundo número novamente: ");
                    segundoNumero = Convert.ToDecimal(Console.ReadLine());
                }
                //divisão
                resultado = primeiroNumero / segundoNumero;
                historicoOperacoes[contadorHistorico] = $"Divisão -> {primeiroNumero} / {segundoNumero} = {resultado.ToString("F2")}";
            }

            else
            {
                Console.WriteLine("\nOpção inválida! Pressione qualquer tecla para continuar...");
                Console.ReadLine();
            }
            return resultado;
        }

        static void ExibirResultado(decimal resultado)
        {
            Console.WriteLine("\nResultado: " + resultado.ToString("F2"));

            Console.Write("\nPressione qualquer botão para continuar!");
            Console.ReadLine();
        }
    }
}
