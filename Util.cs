using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT {
    internal class Util {
        static List<Conta> conta = new List<Conta>();

        public static double ChecarSaldo() {
            double saldo;
            bool inputValido = false;

            do {
                Console.WriteLine("Digite o saldo inicial da conta: ");
                string input = Console.ReadLine();

                if (!double.TryParse(input, out saldo)) {
                    Console.WriteLine("\nEntrada invalida. O saldo deve ser um numero real.\n");
                } else if (saldo < 0 ){
                    Console.WriteLine("\nO saldo deve ser um numero real maior ou igual a zero.\n");
                } else {
                    inputValido = true;
                }

            } while (!inputValido);
            return saldo;
        }

        public static int ChecarID(List<Conta> conta) {
            int ID;
            do {
                Console.WriteLine("Digite o ID da conta: ");
                var check = int.TryParse(Console.ReadLine(), out ID);

                if(!check) {
                    Console.WriteLine("\nEntrada invalida. O ID da conta deve ser um numero inteiro positivo.\n");
                }
                else if (ID <= 0) {
                    Console.WriteLine("\nO ID da conta não pode ser menor que 0.\n");

                }
            } while (ID <= 0);
            return ID;

        }

        public static bool ChecarID2(List<Conta> conta, int ID) {// ChecarConta

            return conta.Exists(c => c.ID == ID);
        }

        public static int ValidaNum(string num) {
            int result;
            bool validar = int.TryParse(num, out result);
            
            while(!validar) {
                Console.WriteLine("\nDigite um valor numerico:\n");
                num = Console.ReadLine();
                validar = int.TryParse(num, out result);
            }
            return result;
        }

        public static double ValidaDouble(string saldo) {
            double result;
            bool validar = double.TryParse(saldo, out result);

            while (!validar) {
                Console.WriteLine("\nDigite um valor numerico:\n");
                saldo = Console.ReadLine();
                validar = double.TryParse(saldo, out result);
            }
            return result;
        }

        public static string ChecarNome() {
            string nome = "";
            while (string.IsNullOrEmpty(nome) || nome.Split(' ').Length < 2) {
                Console.WriteLine("Digite o nome da pessoa da conta: ");
                nome = Console.ReadLine();
                if (string.IsNullOrEmpty(nome) || nome.Split(' ').Length < 2) {
                    Console.WriteLine("\nO nome da pessoa deve conter nome e sobrenome.");
                }
            }
            return nome;
        }

        public static void SacarDebito(Conta conta) {
            double valor;

            do {
                Console.WriteLine("Quanto deseja sacar: ");
                valor = ValidaDouble(Console.ReadLine());
                if (valor > 0) {
                    if (conta.saldo >= valor) {
                        conta.Debito(valor);
                        Console.WriteLine("Saque feito com sucesso.");
                        break;
                    } else {
                        Console.WriteLine("Saldo insuficiente para saque.");
                    }
                } else {
                    Console.WriteLine("O valor para saque deve ser um número real maior do que zero.");
                }
            } while (true);
        }

        public static void DepositarCredito(Conta conta) {
            double valor;

            bool quit = false;
            while (!quit) {
                Console.WriteLine("Digite o valor que deseja depositar: ");
                valor = ValidaDouble(Console.ReadLine());
                if (valor > 0) {
                    conta.Credito(valor);
                    Console.WriteLine("Deposito feito com sucesso.");
                    quit = true;
                }
            }
        }
    }
}
