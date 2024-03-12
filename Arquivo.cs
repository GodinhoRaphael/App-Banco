using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AT {
    internal class Arquivo {

        public static List<Conta> Armazenar() {
            List<Conta> conta = new List<Conta>();
            if (File.Exists("contas.csv")) {
                using (StreamReader reader = new StreamReader("contas.csv")) {
                    while (!reader.EndOfStream) {
                        string line = reader.ReadLine();
                        string[] parts = line.Split(',');

                        if (parts.Length == 3) {
                            int id = int.Parse(parts[0]);
                            string nome = parts[1];
                            double saldo = double.Parse(parts[2]);

                            Conta NewConta = new Conta(id, nome, saldo);
                            conta.Add(NewConta);



                        }
                    }
                }
            }
            return conta;
        }

        public static void Save(List<Conta> conta) {
            using (StreamWriter writer = new StreamWriter("contas.csv")) {
                foreach (var contas in conta) {
                    string line = $"{contas.ID},{contas.nome},{contas.saldo}";
                    writer.WriteLine(line);
                }
            }
        }
    }
}
