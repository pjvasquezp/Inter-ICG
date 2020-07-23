using ICG_Inter.Datos;
using ICG_Inter.Objetos;
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

        //public DataTable tablagrid = new DataTable();
        public ListaDocVentas ObjListaDocVentas = new ListaDocVentas();
        public FacturasVenta()
        {
            InitializeComponent();
        }
        public FacturasVenta(ListaDocVentas ObjListaDoc)
        {
            ObjListaDocVentas = ObjListaDoc;
            InitializeComponent();
        }

        private void FacturasVenta_Load(object sender, EventArgs e)
        {
            //ListaDocVentas ObjListaDocVentas = new ListaDocVentas();
            dgv_q.DataSource = ObjListaDocVentas;
        }
        private void Dgv_q_DoubleClick(object sender, EventArgs e)
        {
            string Serie;
            int NumDoc;
            

            Serie = this.dgv_q.CurrentRow.Cells[0].Value.ToString();
            NumDoc = int.Parse(this.dgv_q.CurrentRow.Cells[1].Value.ToString());

            Documento_Cabecera MiObjCabecera = ObjProcDB.BuscarDocVentasCabecera(Serie, NumDoc);
            txtcliente.Text = MiObjCabecera.Cliente;
            txt_cliente2.Text = MiObjCabecera.Cliente;
            txt_direccion.Text = MiObjCabecera.Direccion;
            //txt_poblacion.Text = MiObjCabecera.Poblacion;
            txt_poblacion2.Text = MiObjCabecera.Poblacion;
            //txt_vendedor.Text = MiObjCabecera.Codigo_Cliente;
            txt_vendedor2.Text = MiObjCabecera.Vendedor;
            txt_fecha.Text = MiObjCabecera.Fecha.ToString();
            txt_hora.Text = MiObjCabecera.Hora;
            txt_transporte.Text = MiObjCabecera.Transporte;
            txt_serie.Text = MiObjCabecera.Serie;
            txt_num.Text = MiObjCabecera.Numero.ToString();
            txt_bruto.Text = MiObjCabecera.Total_BrutoImponible.ToString();
            txt_base.Text = MiObjCabecera.Total_BrutoImponible.ToString();
            txt_impuesto.Text = MiObjCabecera.Impuesto.ToString();
            txt_precioneto.Text = MiObjCabecera.Total_Neto.ToString();

            //fecha inicio
            //tipo docu

            ListaDocDetalle MiObjDetalle = ObjProcDB.BuscarDocVentasDetalle(Serie, NumDoc);
            
            txt_cliente.DataSource = MiObjDetalle;

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
