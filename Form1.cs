using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace ICG_Inter
{
    public partial class Entradafiltros : Form
    {
        static string conexionstring = "server= DSNT-DEV-SRV\\MSSQLSERVER01; User= sa ; Password= B1Admin; database = AGORA;";
        SqlConnection conexion = new SqlConnection(conexionstring);

        public Entradafiltros()
        {
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            string query = "exec [SP_GET_DocumentoData]";
            SqlCommand comando = new SqlCommand(query, conexion);
            SqlDataAdapter data = new SqlDataAdapter(comando);
            DataTable tabla = new DataTable();
            data.Fill(tabla);

            FacturasVenta v1 = new FacturasVenta(tabla);
            this.Hide();
            v1.ShowDialog();
            this.Show();


        }

    }
}