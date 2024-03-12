using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AT.Util;
using static AT.Arquivo;

namespace AT {
    internal class Crud {

        public static void Incluir(ref List<Conta> conta) {
            int ID;
            do {
                ID = ChecarID(conta);
                if (ChecarID2(conta, ID)) {
                    Console.WriteLine("Esse ID de conta ja existe. Escolha outro ID para sua conta.");
                }
            } while (ChecarID2(conta, ID));

            string nome = ChecarNome();
            double saldo = ChecarSaldo();

            Conta NewConta = new Conta(ID, nome, saldo);
            conta.Add(NewConta);
            Console.WriteLine("Nova conta criada.");

        }

        public static void Alteracao(ref List<Conta> conta) {
            int resposta;
            bool quit = false;
            while (!quit) {
                Conta contas;
                Console.WriteLine("Digite o ID da conta que deseja alterar ou [0] para voltar ao menu: ");
                resposta = ValidaNum(Console.ReadLine());
                int ID = resposta;
                contas = conta.Find(c => c.ID == ID);
                if (contas != null) {
                    Console.WriteLine("Deseja sacar[1] ou depositar dinheiro[2]: \n");
                    int option;
                    option = ValidaNum(Console.ReadLine());
                    if (option == 1) {
                        SacarDebito(contas);
                        quit = true;
                    } else if (option == 2) {
                        DepositarCredito(contas);
                        quit = true;
                    }
                } else if (resposta == 0) {
                    quit = true;
                } else {
                    Console.WriteLine("\nO ID digitado não existe.\n");
                }
            }
        }

        public static void Excluir(ref List<Conta> conta) {
            int resposta;
            bool quit = false;
            while (!quit) {
                Conta contas;
                Console.WriteLine("Digite o ID da conta que deseja excluir ou [0] para voltar ao menu: ");
                resposta = ValidaNum(Console.ReadLine());
                int ID = resposta;
                contas = conta.Find(c => c.ID == ID);
                if (conta.Exists(c => c.ID == ID)) {
                    if (contas.saldo == 0) {
                        var itemToRemove = conta.Single(r => r.ID == ID);
                        conta.Remove(itemToRemove);
                        Console.WriteLine("\nConta excluida com sucesso.");
                        quit = true;
                    } else if (contas.saldo > 0) {
                        Console.WriteLine("\nVoce precisa sacar o dinheiro antes de excluir a conta.");
                    }
                } else if (resposta == 0) {
                    quit = true;
                } else {
                    Console.WriteLine("\nEsse ID de conta não existe.");
                }
            }
        }

        public static void Gerenciar(ref List<Conta> conta) {
            int resposta;
            bool quit = false;
            while (!quit) {
                Console.WriteLine("\n[1] Listar clientes com saldo negativo.");
                Console.WriteLine("[2] Lista clientes a partir de um saldo base.");
                Console.WriteLine("[3] Listar todos os clientes.");
                Console.WriteLine("[4] Voltar para o menu.");
                resposta = ValidaNum(Console.ReadLine());
                if (resposta == 1) {
                    ListarSaldoNegativo(ref conta);
                    quit = true;
                } else if (resposta == 2) {
                    ListarSaldoValor(ref conta);
                    quit = true;
                } else if (resposta == 3) {
                    ListarTodos(ref conta);
                    quit = true;
                } else if (resposta == 4) {
                    quit = true;
                }
            }
        }

        public static void ListarSaldoNegativo(ref List<Conta> conta) {
            Console.WriteLine("Listando contas com saldo negativo:\n");
            foreach (var contas in conta) {
                if (contas.saldo <= 0) {
                    Console.WriteLine("ID da conta: " + contas.ID + "\n" + "Nome na conta: " + contas.nome + "\n" + "Saldo na conta: " + contas.saldo);
                } else {
                    Console.WriteLine("Nao existe conta com saldo negativo no sistema.");
                }
            }
        }

        public static void ListarSaldoValor(ref List<Conta> conta) {
            double valor;
            bool quit = false;
            while (!quit) {
                Console.WriteLine("Digite o valor do saldo que deseja ter como base para pesquisa: ");
                valor = ValidaDouble(Console.ReadLine());
                Console.WriteLine("Listando contas com base nesse valor:\n");
                foreach (var contas in conta) {
                    if (contas.saldo > valor) {
                        Console.WriteLine("ID da conta: " + contas.ID + "\n" + "Nome na conta: " + contas.nome + "\n" + "Saldo na conta: " + contas.saldo + "\n");
                        quit = true;
                    }
                }
            }
        }

        public static void ListarTodos(ref List<Conta> conta) {
            Console.WriteLine("Listando todas as contas:\n");
            foreach (var contas in conta) {
                Console.WriteLine(contas);
            }
            Console.WriteLine("\nNão existe mais nenhuma conta no sistema.");
        }
    }
}
