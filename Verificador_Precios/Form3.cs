using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Verificador_Precios
{
    public partial class Form3 : Form
    {
        Form1 prn = new Form1();

        private int segundos = 0;


        public Form3(MySqlDataReader resultado)
        {
            InitializeComponent();
            pictureBox1.Location = new Point(this.Width - pictureBox1.Width, this.Height/2);
            label1.Text = "Producto: "+resultado.GetString(0);
            label2.Text = "Precio: "+resultado.GetString(1);
            label3.Text = "En Stock: "+resultado.GetString(2);
            pictureBox1.ImageLocation = resultado.GetString(3);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            segundos = 0;
            if (resultado.GetString(2) == "0")
            {
                pictureBox2.Visible = true;
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Location = new Point(this.Width / 4 - 50, this.Height/2 + 25);
            label2.Location = new Point(this.Width / 4 - 50, this.Height/2);
            label3.Location = new Point(this.Width / 4 - 50, this.Height/2 - 25);
            pictureBox2.Location = new Point(this.Width/2 - pictureBox2.Width/2 - 25, this.Height - pictureBox2.Height - 100);

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            segundos++;

            if (segundos == 4)
            {
                timer1.Enabled = false;
                this.Close();
                prn.Show();
                segundos = 0;
            }
        }
        private void Form3_KeyPress(object sender, KeyPressEventArgs e)
        {
            prn.metodo(sender, e);
            this.Refresh();
        }
    }
}
