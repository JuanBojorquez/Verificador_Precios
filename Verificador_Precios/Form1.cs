using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Verificador_Precios
{
    public partial class Form1 : Form
    {
        


        private static MySqlDataReader resultado;

        private String codigo = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Location = new Point(this.Width / 2 - pictureBox1.Width / 2, 0);
            label1.Location = new Point(this.Width / 2 - label1.Width / 2, pictureBox1.Height + 10);
            pictureBox2.Location = new Point(this.Width/2 - pictureBox2.Width/2,this.Height/2);
        }

        public void metodo(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                //MessageBox.Show("vamos a buscar el producto "+codigo);
                try
                {

                    MySqlConnection servidor;
                    servidor = new MySqlConnection("server = 127.0.0.1; user = root; database = verificador_productos; SSL Mode = None; ");
                    servidor.Open();
                    string query = "SELECT producto_nombre, producto_precio, producto_cantidad, producto_imagen FROM productos WHERE producto_codigo =" + codigo + ";";
                    //MessageBox.Show(query);
                    MySqlCommand consulta;
                    consulta = new MySqlCommand(query, servidor);
                    resultado = consulta.ExecuteReader();
                    if (resultado.HasRows)
                    {
                        resultado.Read();
                        Form3 prod = new Form3(resultado);
                        this.Hide();
                        prod.Show();

                    }
                    else
                    {
                        Form2 Error = new Form2();
                        this.Hide();
                        Error.Show();
                    }
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.ToString(), "Titulo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                codigo = "";
            }
            else
            {
                codigo += e.KeyChar;
            }
        }
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            metodo(sender, e);
        }



    }
    }