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
using ICG_Inter.Objetos;
using ICG_Inter.Datos;

namespace ICG_Inter
{
    public partial class Entradafiltros : Form
    {
        //static string conexionstring = "server= DSNT-DEV-SRV\\MSSQLSERVER01; User= sa ; Password= B1Admin; database = AGORA;";
        //SqlConnection conexion = new SqlConnection(conexionstring);
        
        public ProcesosDB ObjProcDB = new ProcesosDB();
        

        public Entradafiltros()
        {
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {
            ListaDocVentas ObjListaDocVentas = ObjProcDB.GetDocVentas();

            //ObjListaDocVentas = ObjProcDB.GetDocVentas();
           

            FacturasVenta v1 = new FacturasVenta(ObjListaDocVentas);
            this.Hide();
            v1.ShowDialog();
            this.Show();

      


        }

    }
}