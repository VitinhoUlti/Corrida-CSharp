using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Corrida
{
    public partial class Form1 : Form
    {
        Pessoas Joe;
        Pessoas Bob;
        Pessoas Al;
        Cachorros Vitor;
        Cachorros Elson;
        Cachorros Miguel;
        Cachorros Esther;
        Random random = new Random();
        string apostador = null;

        Apostas joeaposta = new Apostas() { Dinheiro=0};
        Apostas bobaposta = new Apostas() { Dinheiro=0};
        Apostas alaposta = new Apostas() { Dinheiro = 0 };
        public Form1()
        {
            InitializeComponent();

            Joe = new Pessoas() { Nome = "Joe", Dinheiro = 50 };
            Bob = new Pessoas() { Nome = "Bob", Dinheiro = 75 };
            Al = new Pessoas() { Nome = "Al", Dinheiro = 45 };

            Vitor = new Cachorros() { Numero=1, Imagem=pictureBox1, Velocidade = 1 };
            Elson = new Cachorros() { Numero = 2, Imagem = pictureBox2, Velocidade = 1};
            Miguel = new Cachorros() { Numero = 3, Imagem = pictureBox3, Velocidade = 1 };
            Esther = new Cachorros() { Numero = 4, Imagem = pictureBox4, Velocidade = 1 };

            radioButton1.Text = $"{Joe.Nome} tem {Joe.Dinheiro} Reais";
            radioButton2.Text = $"{Bob.Nome} tem {Bob.Dinheiro} Reais";
            radioButton3.Text = $"{Al.Nome} tem {Al.Dinheiro} Reais";

            label4.Text = $"{Joe.Nome} não tem Apostas";
            label5.Text = $"{Bob.Nome} não tem Apostas";
            label6.Text = $"{Al.Nome} não tem Apostas";

            label2.Text = $"Aposta Minima: {numericUpDown1.Minimum} reais";
        }
        //eventos que apertei sem querer

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (joeaposta.Dinheiro == 0 || bobaposta.Dinheiro == 0 || alaposta.Dinheiro == 0) { }
            else
            {
                Cachorros.continua = true;

                Vitor.VolteAoNormal();
                Elson.VolteAoNormal();
                Miguel.VolteAoNormal();
                Esther.VolteAoNormal();

                while (Cachorros.continua)
                {
                    Vitor.Velocidade = random.Next(0, 2);
                    Elson.Velocidade = random.Next(0, 2);
                    Miguel.Velocidade = random.Next(0, 2);
                    Esther.Velocidade = random.Next(0, 2);

                    Vitor.Run();
                    Elson.Run();
                    Miguel.Run();
                    Esther.Run();
                }
                
                if (Cachorros.ganhador == joeaposta.Cachorro)
                {
                    bobaposta.Perdeu();
                    alaposta.Perdeu();
                    joeaposta.Ganhou();
                } else if (Cachorros.ganhador == bobaposta.Cachorro)
                {
                    bobaposta.Ganhou();
                    joeaposta.Perdeu();
                    alaposta.Perdeu();
                } else
                {
                    alaposta.Ganhou();
                    joeaposta.Perdeu();
                    bobaposta.Perdeu();
                }

                Joe.Dinheiro += (int)joeaposta.Dinheiroganhado;
                Bob.Dinheiro += (int)bobaposta.Dinheiroganhado;
                Al.Dinheiro += (int)alaposta.Dinheiroganhado;

                radioButton1.Text = $"{Joe.Nome} tem {Joe.Dinheiro} Reais";
                radioButton2.Text = $"{Bob.Nome} tem {Bob.Dinheiro} Reais";
                radioButton3.Text = $"{Al.Nome} tem {Al.Dinheiro} Reais";


            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = $"{Joe.Nome}";
            apostador = $"{Joe.Nome}";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = $"{Bob.Nome}";
            apostador = $"{Bob.Nome}";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = $"{Al.Nome}";
            apostador = $"{Al.Nome}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (apostador == $"{Joe.Nome}" || apostador == null)
            {
                joeaposta.Dinheiro = numericUpDown1.Value;
                joeaposta.Cachorro = (int)numericUpDown2.Value;
                joeaposta.Pessoa = Joe;

                label4.Text = $"{joeaposta.Pessoa.Nome} apostou {joeaposta.Dinheiro} reais no {joeaposta.Cachorro}";
            } else if (apostador == $"{Bob.Nome}")
            {
                bobaposta.Dinheiro = numericUpDown1.Value;
                bobaposta.Cachorro = (int)numericUpDown2.Value;
                bobaposta.Pessoa = Bob;

                label5.Text = $"{bobaposta.Pessoa.Nome} apostou {bobaposta.Dinheiro} reais no {bobaposta.Cachorro}";
            }
            else
            {
                alaposta.Dinheiro = numericUpDown1.Value;
                alaposta.Cachorro = (int)numericUpDown2.Value;
                alaposta.Pessoa = Al;

                label6.Text = $"{alaposta.Pessoa.Nome} apostou {alaposta.Dinheiro} reais no {alaposta.Cachorro}";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
