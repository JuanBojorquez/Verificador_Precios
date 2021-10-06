using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verificador_Precios
{
    public partial class Form2 : Form
    {
        private int segundos = 0;
        public Form2()
        {
            InitializeComponent();
            segundos = 0;
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, 100);
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, pictureBox1.Height + 250);

        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            segundos++;

            if (segundos == 2)
            {
                timer1.Enabled = false;
                this.Close();
                Form1 princ = new Form1();
                princ.Show();

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
