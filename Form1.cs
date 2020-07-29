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
        public string Cod_Art = "";
        public Int32 Cod_Cli = 0;

        //static string conexionstring = "server= DSNT-DEV-SRV\\MSSQLSERVER01; User= sa ; Password= B1Admin; database = AGORA;";
        //SqlConnection conexion = new SqlConnection(conexionstring);

        public ProcesosDB ObjProcDB = new ProcesosDB();
        

        public Entradafiltros()
        {
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {

            ListaDocVentas ObjListaDocVentas = ObjProcDB.GetDocVentas(Cod_Art, Cod_Cli);

            //ObjListaDocVentas = ObjProcDB.GetDocVentas();
           

            FacturasVenta v1 = new FacturasVenta(ObjListaDocVentas);
            this.Hide();
            v1.ShowDialog();
            this.Show();

      


        }

        private void Txt_Codiente_TextChanged(object sender, EventArgs e)
        {
            if (txt_Codiente.Text != "")
            {
                if (IsNumeric(txt_Codiente.Text))
                {
                    Cod_Cli = int.Parse(txt_Codiente.Text);
                }
                else
                    MessageBox.Show("Valor incorrecto");
            }
            else Cod_Cli = 0;
            
        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public void Txt_Codart_TextChanged(object sender, EventArgs e)
        {
            if (txt_Codart.Text != "")
            {
                Cod_Art = txt_Codart.Text;
            }
            else Cod_Art = "";
        }
    }
}