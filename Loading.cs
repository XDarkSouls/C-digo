using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Projeto_de_Aptidão_Profissional
{
    public partial class Loading : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        //metodo para criar a elipse
        private static extern IntPtr Cantos
       (
           int nLeftRect, // Coordenada x do canto superior esquerdo
           int nTopRect, // Coordenada y do canto inferior esquerdo
           int nRightRect, // Coordenada x do canto inferior direito
           int nBottomRect, // Coordenada y do canto inferior esquerdo
           int nWidthEllipse, // Altura da ellipse
           int nHeightEllipse // Comprimento da ellipse
       );


        //propriedades do form 
        public Loading()
        {
            InitializeComponent();

            //desenha os cantos
            Region = System.Drawing.Region.FromHrgn(Cantos(0, 0, Width, Height, 50, 50));
        }


        //Metodo Tick do timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            //aumenta o tamanho da barra
            Progresso.Width += 1;

            //if para verificar se a barra chegou ao seu comprimento maximo, para parar o timer e iniciar o form login
            if (Progresso.Width >= 516)
            {
                Progresso.Width = 518;
                timer1.Stop();

                //inicia o form login e fecha o form loading
                Login Call2 = new Login();
                Call2.Show();
                this.Hide();
               
            }
        }


        //metodo load do form loading
        private void Loading_Load(object sender, EventArgs e)
        {
            Progresso.Width = 0;
        }
    }
}
