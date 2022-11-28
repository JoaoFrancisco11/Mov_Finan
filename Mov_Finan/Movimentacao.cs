using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mov_Finan
{
    public class Movimentacao: Cliente
    {
        public List<string> Tipo = new List<string>();
        public List<decimal> Valor= new List<decimal>();
        
        public Movimentacao(string tipo, decimal valor) 
        {
            Tipo.Add(tipo);
            Valor.Add(valor);
        }
    }
}
