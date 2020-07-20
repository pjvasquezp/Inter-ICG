using ICG_Inter.Datos;
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
    public partial class FacturasVenta : Form
    {
        public Documento_Cabecera ObjDocCab = new Documento_Cabecera();
        public ProcesosDB ObjProcDB = new ProcesosDB();

       // static string conexionstring = "server= DSNT-DEV-SRV\\MSSQLSERVER01; User= sa ; Password= B1Admin; database = AGORA;";
        //SqlConnection conexion = new SqlConnection(conexionstring);

        public DataTable tablagrid = new DataTable();
        public FacturasVenta()
        {
            InitializeComponent();
        }
        public FacturasVenta(DataTable table)
        {
            tablagrid = table;
            InitializeComponent();
        }

        private void FacturasVenta_Load(object sender, EventArgs e)
        {
            dgv_q.DataSource = tablagrid;
        }
        private void Dgv_q_DoubleClick(object sender, EventArgs e)
        {
            string Serie;
            int NumDoc;
            

            Serie = this.dgv_q.CurrentRow.Cells[0].Value.ToString();
            NumDoc = int.Parse(this.dgv_q.CurrentRow.Cells[1].Value.ToString());

            ListaDocDetalle MiObjDetalle = ObjProcDB.BuscarDocVentas(Serie, NumDoc);

            dgv_factura.DataSource = MiObjDetalle;

            //ObjDocCab.Cliente = tabla.Rows[0].ItemArray[11].ToString();
            //ObjDocCab.Direccion = tabla.Rows[0].ItemArray[50].ToString();
            //ObjDocCab.Fecha = DateTime.Parse(tabla.Rows[0].ItemArray[8].ToString());
            //ObjDocCab.Hora = tabla.Rows[0].ItemArray[9].ToString();
            //ObjDocCab.Impuesto = decimal.Parse(tabla.Rows[0].ItemArray[31].ToString());
            //ObjDocCab.Numero = int.Parse(tabla.Rows[0].ItemArray[15].ToString());
            //ObjDocCab.Poblacion = tabla.Rows[0].ItemArray[39].ToString();
            //ObjDocCab.Serie = tabla.Rows[0].ItemArray[14].ToString();
            //ObjDocCab.Tipo_Documento = tabla.Rows[0].ItemArray[42].ToString();
            //ObjDocCab.Vendedor = tabla.Rows[0].ItemArray[44].ToString();
            //ObjDocCab.Transporte
            //ObjDocCab.Fecha_Inicio


            //Documento_Detalle ObjDocDet = new Documento_Detalle();

            //ObjDocDet.Almacen = tabla.Rows[0].ItemArray[11].ToString();


            //dgv_factura.DataSource = tabla;

            //MessageBox.Show(Serie.ToString() + " " + NumDoc.ToString());

        }


        
    }
}
