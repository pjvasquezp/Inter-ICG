using ICG_Inter.Datos;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICG_Inter
{
    public partial class LoadinForm : Form
    {
        DAConnectionSQL AppConexion = new DAConnectionSQL();
       
        public LoadinForm()
        {
            InitializeComponent();
        }

        private void LoadinForm_Load(object sender, EventArgs e)
        {
            bool Conectar = false;
            timer1.Start();
            toolStripStatusLabel1.Text = "Validando Conexion con el Servidor";

            Conectar = ProbarConexion();

            if (Conectar)
            {
                Entradafiltros ObjForm1 = new Entradafiltros(AppConexion);
                this.Hide();
                ObjForm1.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error al Intentar conectar con el servidor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private bool ProbarConexion()
        {
            bool Exitoso = false;

            try
            {
                AppConexion.Open();
                if (AppConexion.Con.State == ConnectionState.Open)
                {
                    Exitoso = true;
                    toolStripStatusLabel1.Text = "Conectado al Servidor";

                }

                else
                {
                    toolStripStatusLabel1.Text = "Error al Conectar con Servidor";
                }
            }
            catch (Exception)
            {
                Exitoso = false;
                MessageBox.Show("Error al Intentar conectar con el servidor", "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            return Exitoso;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(35);
            
            if (progressBar1.Value == progressBar1.Maximum)
            {
                this.Hide();
                timer1.Stop();

                

            }
        }
    }
}
