using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corrida
{
    internal class Cachorros
    {
        Random random = new Random();
        public int Numero { get; set; }
        public PictureBox Imagem { get; set; }
        public int Localização { get; set; }
        public int Velocidade { get; set; }
        public bool CorreuRapido { get; set; }
        public static bool continua = true;
        public static int ganhador = 1;

        public bool Run()
        {
            var p = Imagem.Location;

            if (p.X <= 640)
            {
                p.X += Velocidade;
            }

            Imagem.Location = p;

            if (p.X >= 640)
            {
                continua = false;
                ganhador = this.Numero;
                MessageBox.Show($"{this.Numero} foi o ganhador");
                return true;
            }
            else
            {
                return false;
            }
        }
        public void VolteAoNormal()
        {
            var p = Imagem.Location;
            p.X = 14;
            Imagem.Location = p;
        }
    }
}
