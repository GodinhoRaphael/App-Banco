using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using System.Runtime.CompilerServices;
using static AT.Crud;
using static AT.Arquivo;
using static AT.Util;

namespace AT {
    internal class Program {
        static int Menu() {
            int resposta;

            Console.WriteLine("\nBem-vindo ao Banco!\n");
            Console.WriteLine("[1] Inclusão de conta.");
            Console.WriteLine("[2] Alteração de saldo.");
            Console.WriteLine("[3] Exclusão de conta.");
            Console.WriteLine("[4] Relatórios gerenciais.");
            Console.WriteLine("[5] Saída do programa.");
            resposta = ValidaNum(Console.ReadLine());
            return resposta;
        }

        static void Main(string[] args) {
            bool quit = false;
            var conta =Armazenar();

            while (!quit) {

                int resposta = Menu();
                switch (resposta) {
                    case 1: Incluir(ref conta); break;

                    case 2: Alteracao(ref conta); break;

                    case 3: Excluir(ref conta); break;

                    case 4: Gerenciar(ref conta); break;

                    case 5: quit = true; break;
                }
            }
            Save(conta);
        }
    }
}