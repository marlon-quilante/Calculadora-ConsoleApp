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
                Console.Clear();
                Console.WriteLine("--------------------------------------");
                Console.WriteLine("Calculadora Tabajara 2025");
                Console.WriteLine("--------------------------------------");

                Console.WriteLine("\nSelecione uma opção...\n");

                Console.WriteLine("1 - Somar");
                Console.WriteLine("2 - Subtrair");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                Console.WriteLine("5 - Taboada");
                Console.WriteLine("6 - Histórico de Operações");
                Console.WriteLine("S - Sair\n");

                string opcao = Console.ReadLine().ToUpper();
                decimal resultado = 0.0m;

                try
                {
                    if (opcao == "S")
                        break;

                    if (opcao == "5")
                    {
                        Console.Clear();
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("Taboada");
                        Console.WriteLine("--------------------------------------\n");
                        Console.Write("Digite um número inteiro: ");
                        int numero = Convert.ToInt32(Console.ReadLine());

                        for (int i = 1; i <= 10; i++)
                        {
                            Console.WriteLine($"\n{numero} x {i} = {numero * i}");
                        }
                        Console.Write("\nPressione qualquer botão para continuar!");
                        Console.ReadLine();
                        continue;
                    }

                    if (opcao == "6")
                    {
                        Console.Clear();
                        Console.WriteLine("--------------------------------------");
                        Console.WriteLine("Histórico de Operações");
                        Console.WriteLine("--------------------------------------\n");

                        for (int i = 0; i < contadorHistorico; i++)
                        {
                            Console.WriteLine(historicoOperacoes[i]);
                        }

                        Console.Write("\nPressione qualquer botão para continuar!");
                        Console.ReadLine();
                        continue;
                    }

                    else
                    {
                        Console.Write("\nDigite o primeiro número: ");
                        decimal primeiroNumero = int.Parse(Console.ReadLine());

                        Console.Write("Digite o segundo número: ");
                        decimal segundoNumero = int.Parse(Console.ReadLine());

                        //decimal num = decimal.MaxValue;
                        //double num1 = double.MaxValue;
                        //float num2 = float.MaxValue;

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
                            continue;
                        }

                        Console.WriteLine("\nResultado: " + resultado.ToString("F2"));

                        Console.Write("\nPressione qualquer botão para continuar!");
                        Console.ReadLine();
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
    }
}
