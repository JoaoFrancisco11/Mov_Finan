﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov_Finan
{
    public class Cliente
    {
        /* Classe destinada aos dados dos clientes.
         * Atributos: codigo, Nome, Saldo, Movimentacoes.
            Alguns dados não podem ser alterados, então foram encapsulados.
        */
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public decimal Saldo { get; private set; }
        public List<Movimentacao> Movimentacoes { get; private set;  }

        public Cliente()
        {
            Movimentacoes = new List<Movimentacao>();
        }
        public Cliente(string codigo, string nome):this()
        {
            Nome = nome;
            Codigo = codigo;
        }

        public Cliente(List<Movimentacao> movimentacoes)
        {
            Movimentacoes = movimentacoes;
        }

        public void RealizarSaque(decimal valor)
        {
            if (Saldo > valor)
            {
                decimal valorMenosTaxa = DescontarTaxa(valor);
                Saldo = Saldo - valor;
                AdicionarMovimentacao("SAQUE", valorMenosTaxa);
                Console.WriteLine($"Saque Realizado com sucesso. Saldo: {Saldo}");
            }
            else
            {
                Console.WriteLine("Valor insuficiente");
            }
        }
        public void RealizarDeposito(decimal valor)
        {
            if (valor >= 10)
            {
                decimal valorMenosTaxa = DescontarTaxa(valor);
                Saldo += valorMenosTaxa;
                AdicionarMovimentacao("DEPÓSITO", valorMenosTaxa);
                Console.WriteLine($"Depósito realizado com sucesso. Saldo: {Saldo}");
            }
            else
            {
                Console.WriteLine("Valor deve ser igual ou maior que R$10,00");
            }
        }

        private void AdicionarMovimentacao(string tipo, decimal valor)
        {
            Movimentacoes.Add(new Movimentacao(tipo, DescontarTaxa(valor)));
        }
        public virtual decimal DescontarTaxa(decimal valor)
        {
            return valor;
        }

    }
}