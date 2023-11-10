using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        static bool ValidarPlaca(string placa)
        {
            string pattern = @"^[A-Za-z]{3}\d{1}[A-Za-z0-9]{1}\d{2}$";
            return Regex.IsMatch(placa, pattern);
        }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            string placa = Console.ReadLine().ToUpper();

            if (ValidarPlaca(placa))
            {
                veiculos.Add(placa);
                Console.WriteLine($"Entrada do veículo de placa: {placa} confirmada!");
            }
            else
            {
                Console.WriteLine($"Placa {placa} não reconhecida, verifique a placa digitada!");
            }
        }

        public void RemoverVeiculo()
        {
            if (!veiculos.Any())
            {
                Console.WriteLine("Não há veículos estacionados.");
                return;
            }

            Console.WriteLine("Digite a placa do veículo para remover:");
            string placa = Console.ReadLine().ToUpper();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                if (int.TryParse(Console.ReadLine(), out int horas))
                {
                    decimal valorTotal = (precoInicial + precoPorHora) * horas;
                    veiculos.Remove(placa);
                    Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
                    return;
                }
                else
                {
                    Console.WriteLine("Por favor, insira um valor numérico válido para a quantidade de horas.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                veiculos.ForEach((veiculo) =>
                {
                    Console.WriteLine($"* {veiculo}\n");
                });
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
