using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corrida
{
    internal class Apostas
    {
        public decimal Dinheiro { get; set; }
        public Pessoas Pessoa { get; set; }
        public int Cachorro { get; set; }
        public decimal Dinheiroganhado = 0;

        public decimal Ganhou()
        {
            Dinheiroganhado = Dinheiro * 2;
            return Dinheiro;
        }
        public decimal Perdeu()
        {
            Dinheiroganhado = -Dinheiro;
            return -Dinheiro;
        }
    }
}
