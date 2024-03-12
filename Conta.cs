using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AT {
    internal class Conta : IOperacoes {
        public int ID { get; private set; }
        public string nome { get; private set; }
        public double saldo { get; private set; }

        public Conta(int id, string nome, double saldo) {
            ID = id;
            this.nome = nome;
            this.saldo = saldo;
        }

        public void Credito(double valor) {
            if (valor > 0) {
                saldo += valor;
            } else {
                Console.WriteLine("O valor de retirada deve ser um numero real maior que zero.");
            }

        }

        public void Debito(double valor) {
            if (valor > 0) {
                saldo -= valor;
            } else {
                Console.WriteLine("O valor de retirada deve ser um numero real maior que zero.");
            }
        }

        public override string ToString() {
            return $"ID da conta: {ID}\nNome na conta: {nome}\nSaldo na conta: {saldo}";
        }
    }
}
