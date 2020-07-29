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
        public ListaProductoDev ObjListaProductosDev = new ListaProductoDev();

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
            //txt_direccion.Text = MiObjCabecera.Direccion;

            //txt_poblacion2.Text = MiObjCabecera.Poblacion;
            txt_cliente2.Text = MiObjCabecera.Codigo_Cliente.ToString(); ;
            txt_vendedor2.Text = MiObjCabecera.Vendedor;
            txt_fecha.Text = MiObjCabecera.Fecha.ToString();
            txt_hora.Text = MiObjCabecera.Hora;
            //txt_transporte.Text = MiObjCabecera.Transporte;
            txt_serie.Text = MiObjCabecera.Serie;
            txt_num.Text = MiObjCabecera.Numero.ToString();
            //txt_bruto.Text = MiObjCabecera.Total_BrutoImponible.ToString();
            //txt_base.Text = MiObjCabecera.Total_BrutoImponible.ToString();
            //txt_impuesto.Text = MiObjCabecera.Impuesto.ToString();
            //txt_precioneto.Text = MiObjCabecera.Total_Neto.ToString();

            //fecha inicio
            //tipo docu

            ListaDocDetalle MiObjDetalle = ObjProcDB.BuscarDocVentasDetalle(Serie, NumDoc);
            
            dgv_Doc.DataSource = MiObjDetalle;

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

        private void dgv_Doc_DoubleClick(object sender, EventArgs e)
        {
            ProductoDev ObjProductoDev = new ProductoDev();
            ObjProductoDev.Serie = this.dgv_Doc.CurrentRow.Cells[0].Value.ToString();
            ObjProductoDev.Numero = int.Parse(this.dgv_Doc.CurrentRow.Cells[1].Value.ToString());
            ObjProductoDev.Referencia = this.dgv_Doc.CurrentRow.Cells[2].Value.ToString();
            ObjProductoDev.Descripcion = this.dgv_Doc.CurrentRow.Cells[3].Value.ToString();
            ObjProductoDev.Talla = this.dgv_Doc.CurrentRow.Cells[4].Value.ToString();
            ObjProductoDev.Color = this.dgv_Doc.CurrentRow.Cells[5].Value.ToString();
            ObjProductoDev.UnidadesVenta = int.Parse(this.dgv_Doc.CurrentRow.Cells[6].Value.ToString());
            ObjProductoDev.Precio = decimal.Parse(this.dgv_Doc.CurrentRow.Cells[7].Value.ToString());
            ObjProductoDev.Almacen = this.dgv_Doc.CurrentRow.Cells[8].Value.ToString();
            



            FormDevolucion v1 = new FormDevolucion(ObjProductoDev);
            v1.ShowDialog();
            this.Show();



            ObjListaProductosDev.Add(ObjProductoDev);
            CargarGridProductosDev(ObjListaProductosDev);
            //pictureBox1.Image = "C:\Users\pjvas\Pictures\Prueba.jpg";
        }

        void CargarGridProductosDev(ListaProductoDev ObjListaProductosDev)
        {
            Dgv_ProductosDev.DataSource = null;
            Dgv_ProductosDev.DataSource = ObjListaProductosDev;
            Dgv_ProductosDev.Refresh();
        }
    }
}
