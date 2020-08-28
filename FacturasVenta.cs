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
using Microsoft.VisualBasic;
using ICG_Inter.Funciones;
using System.Diagnostics;

namespace ICG_Inter
{
    public partial class FacturasVenta : Form
    {
        public Documento_Cabecera ObjDocCab = new Documento_Cabecera();
        public Documento_Detalle DocDetalleSeleccionado = new Documento_Detalle();
        public ProductoDev ProductoDevSeleccionado = new ProductoDev();
        public Buildsxml ObjBuildXml = new Buildsxml();
        string RutaExeFirmado = "C:\\Users\\pjvas\\OneDrive\\Proyectos\\ICG Desarrollo\\xml\\";

        public ProcesosDB ObjProcDB = new ProcesosDB();
        public ListaProductoDev ObjListaProductosDev = new ListaProductoDev();
        public ListaNotasCredito ObjListaNotasCredito = new ListaNotasCredito();

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
            dgv_q.DataSource = ObjListaDocVentas;
            textBox1.Select();
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
            txt_cliente2.Text = MiObjCabecera.Codigo_Cliente.ToString(); ;
            txt_vendedor2.Text = MiObjCabecera.Vendedor;
            txt_fecha.Text = MiObjCabecera.Fecha.ToString();
            txt_hora.Text = MiObjCabecera.Hora;
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
        }

        private void dgv_Doc_DoubleClick(object sender, EventArgs e)
        {
            ListaNotasCredito ObjListaNCR = new ListaNotasCredito();
            ProductoDev ObjProductoDev = new ProductoDev();
            ObjProductoDev.Serie = this.dgv_Doc.CurrentRow.Cells[0].Value.ToString();
            ObjProductoDev.Numero = int.Parse(this.dgv_Doc.CurrentRow.Cells[1].Value.ToString());
            ObjProductoDev.Fecha_Factura = DateTime.Parse(this.txt_fecha.Text);
            ObjProductoDev.Referencia = this.dgv_Doc.CurrentRow.Cells[2].Value.ToString();
            ObjProductoDev.Descripcion = this.dgv_Doc.CurrentRow.Cells[3].Value.ToString();
            ObjProductoDev.Talla = this.dgv_Doc.CurrentRow.Cells[4].Value.ToString();
            ObjProductoDev.Color = this.dgv_Doc.CurrentRow.Cells[5].Value.ToString();
            ObjProductoDev.UnidadesVenta = int.Parse(this.dgv_Doc.CurrentRow.Cells[6].Value.ToString());
            ObjProductoDev.Precio = decimal.Parse(this.dgv_Doc.CurrentRow.Cells[7].Value.ToString());
            ObjProductoDev.Almacen = this.dgv_Doc.CurrentRow.Cells[11].Value.ToString(); 
            ObjProductoDev.Retornable = this.dgv_Doc.CurrentRow.Cells[10].Value.ToString();
            ObjProductoDev.CodBarra = this.dgv_Doc.CurrentRow.Cells[12].Value.ToString();

            ObjProductoDev.Procesado = false;

            //Validacion de mas de 30 dias
            //if (DateTime.Parse(Fecha_Factura).Date. )
            //{

            //}


            if (ObjProductoDev.Retornable == "T")
            {

                FormDevolucion v1 = new FormDevolucion(ref ObjProductoDev);
                v1.ShowDialog();
                this.Show();

                if (ObjProductoDev.RazonDevolucion != null && ObjProductoDev.UnidadesDevueltas != 0 )
                {
                    if (ObjProductoDev.Procesado)
                    {
                        ObjListaNCR = ObjProcDB.ValidarDevolucion(ObjProductoDev.Serie, ObjProductoDev.Numero, ObjProductoDev.CodBarra, ObjProductoDev.UnidadesDevueltas);

                        if (ObjListaNCR.Count > 0)
                        {
                            bool procesar = false;
                            foreach (var item in ObjListaNCR)
                            {
                                procesar = ValidarDevolucion(item);
                                if (procesar)
                                {
                                    ObjListaProductosDev.Add(ObjProductoDev);
                                    CargarGridProductosDev(ObjListaProductosDev);
                                    //pictureBox1.Image = "C:\Users\pjvas\Pictures\Prueba.jpg";
                                }
                            }
                         
                        }

                        else
                        {
                            ObjListaProductosDev.Add(ObjProductoDev);
                            CargarGridProductosDev(ObjListaProductosDev);
                        }
                        
                    }
                }
            }

            else
            {
                MessageBox.Show("Producto no acepta Devolución", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        void CargarGridProductosDev(ListaProductoDev ObjListaProductosDev)
        {
            Dgv_ProductosDev.DataSource = null;
            Dgv_ProductosDev.DataSource = ObjListaProductosDev;
            Dgv_ProductosDev.Refresh();
        }


        public bool ValidarDevolucion(NotasCredito ObjNCR)
        {
            bool Procesar = false;
            var result = MessageBox.Show("El Articulo " + ObjNCR.CodBarra + " La Factura " + ObjNCR.Serie_Fact + " " + ObjNCR.Num_Fact +
                                        " Posee Devoluciones Previas " + ObjNCR.Serie + "-" + ObjNCR.Numero + "\r\n" +
                                        " Desea Verificar Devoluciones?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ListaNotasCredito ObjListaNCR = new ListaNotasCredito();
                    ObjListaNCR = ObjProcDB.ValidarDevolucion(ObjNCR.Serie_Fact, ObjNCR.Num_Fact, ObjNCR.CodBarra, ObjNCR.UnidadesDevueltas);
                    ConsultaDevolucion v1 = new ConsultaDevolucion(ObjListaNCR);
                    this.Hide();
                    v1.ShowDialog();
                    this.Show();

                    var result2 = MessageBox.Show("Se va a procesar la Devolución? " + "\r\n"
                    , "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result2 == DialogResult.Yes)
                    {
                        ObjListaNotasCredito.Add(ObjNCR);
                        Procesar = true;
                        //exitoso = ObjProcDB.InsertarNotasCredito(ObjNotaCredito);
                    }
                }

            return Procesar;

        }
        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            bool exitoso = false;
            string SerieFacDocumento = "";
            string SerieFacActual = "";
            Int32 NumDocDocument = 0;
            Int32 NumDocActual = 0;
            int NumLinea = 1;

            foreach (DataGridViewRow Row in Dgv_ProductosDev.Rows)
            {
                String strFila = Row.Index.ToString();
                ListaNotasCredito ObjListaNCR = new ListaNotasCredito();
                NotasCredito ObjNotaCredito = new NotasCredito();

                SerieFacDocumento = Row.Cells[0].Value.ToString();
                NumDocDocument = int.Parse(Row.Cells[1].Value.ToString());

                if (SerieFacDocumento == SerieFacActual && NumDocDocument == NumDocActual)
                {
                    NumLinea = NumLinea + 1;

                }
                else
                {
                    NumLinea = 1;

                }

                if (SerieFacActual != "" && NumDocActual != 0 && NumDocDocument != NumDocActual)
                {
                    

                    bool Exitoso = ObjProcDB.EjecutarNotasCredito();
                    if (Exitoso)
                    {
                        ObjBuildXml.ContruyeXML(SerieFacActual, NumDocDocument);
                        RutaExeFirmado = RutaExeFirmado + "llamarEXE.exe";
                        Process.Start(RutaExeFirmado);

                        MessageBox.Show("La Devolucion de la Factura " + SerieFacDocumento + " - " + 
                            NumDocDocument + " se Proceso correctamente",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("La Devolucion de la Factura " + SerieFacDocumento + " - " + 
                            NumDocDocument + " No se Proceso correctamente",
                            "Información",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    

                }               

                ObjNotaCredito.Serie = "PPZX";
                ObjNotaCredito.Numero = 0;

                ObjNotaCredito.Fecha_Fact = DateTime.Parse(Row.Cells[2].Value.ToString());
                ObjNotaCredito.Serie_Fact = Row.Cells[0].Value.ToString(); 
                ObjNotaCredito.Num_Fact = Int32.Parse(Row.Cells[1].Value.ToString());

                ObjNotaCredito.Referencia = Row.Cells[3].Value.ToString();
                ObjNotaCredito.Descripcion = Row.Cells[4].Value.ToString();
                ObjNotaCredito.Unidades = Int32.Parse(Row.Cells[5].Value.ToString());
                ObjNotaCredito.UnidadesDevueltas = Int32.Parse(Row.Cells[6].Value.ToString());
                ObjNotaCredito.RazonDevolucion = Row.Cells[7].Value.ToString();
                ObjNotaCredito.Precio = decimal.Parse(Row.Cells[8].Value.ToString());
                ObjNotaCredito.Almacen = Row.Cells[9].Value.ToString();
                ObjNotaCredito.Talla = Row.Cells[10].Value.ToString();
                ObjNotaCredito.Color = Row.Cells[11].Value.ToString();
                ObjNotaCredito.CodBarra = Row.Cells[13].Value.ToString();
                ObjNotaCredito.NumLinea = NumLinea;
                ObjNotaCredito.Total = ObjNotaCredito.UnidadesDevueltas * ObjNotaCredito.Precio;

                SerieFacActual = SerieFacDocumento;
                NumDocActual = NumDocDocument;


                //ObjListaNCR = ObjProcDB.ValidarDevolucion(ObjNotaCredito.Serie, ObjNotaCredito.Numero, ObjNotaCredito.CodBarra, ObjNotaCredito.UnidadesDevueltas)

                ObjListaNotasCredito.Add(ObjNotaCredito);
                exitoso = ObjProcDB.InsertarNotasCredito(ObjNotaCredito);

                ValidarProceso(exitoso, SerieFacDocumento, NumDocDocument, NumLinea);
                                    
            }

            ObjBuildXml.ContruyeXML(SerieFacActual, NumDocDocument);
            try
            {
                Process.Start(RutaExeFirmado + "llamarEXE.exe");

                MessageBox.Show("Firmado de la Devolucion de la Factura " + 
                    SerieFacActual + " - " + NumDocDocument +
                    " Procesada Correctamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            catch (Exception)
            {

                MessageBox.Show("Error al Procesar el Firmado de " + NumLinea + " de la Devolucion de la Factura " + 
                    SerieFacActual + " " + NumDocDocument
                    , "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

        }

        private void ValidarProceso(bool exitoso, string SerieFac, Int32 NumDoc, int NumLinea) 
        {
            if (exitoso)
            {
                //MessageBox.Show("Linea " + NumLinea + " de la Devolucion de la Factura " + SerieFac + " - " + NumDoc +
                //    " Procesada Correctamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                MessageBox.Show("Error al Procesar la Linea " + NumLinea + " de la Devolucion de la Factura " + SerieFac + " " + NumDoc
                    , "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Serie = "";
            int Numero = 0; 

            if (e.KeyChar == (Char)13)
            {
                Serie = Strings.Mid(textBox1.Text, 1, 4);
                Numero = int.Parse(Strings.Mid(textBox1.Text, 5, 15));

                foreach (DataGridViewRow Row in dgv_q.Rows)
                {
                    String strFila = Row.Index.ToString();


                    string SerirFac = Row.Cells[0].Value.ToString();
                    Int32 NumDoc = int.Parse(Row.Cells[1].Value.ToString());


                    if (SerirFac == Serie && NumDoc == Numero)
                    {
                        //RowsCells[0].de
                       dgv_q.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Green;

                        //dgv_q.ClearSelection();
                        dgv_q.Rows[Int16.Parse(strFila)].Selected = true;
                        dgv_q.Focus();                                        
                        dgv_q.Refresh();

                        dgv_q.FirstDisplayedScrollingRowIndex = Int16.Parse(strFila);

                    }


                }

            }
            
        }

        private void btnBuscar2_Click(object sender, EventArgs e)
        {
            string Serie = "";
            int Numero = 0;
            Boolean SwFind = false;
            Serie = txtSerie.Text;
            bool success = Int32.TryParse(txtNumero.Text, out Numero);
            if (success)
            {
                Numero = int.Parse(txtNumero.Text);
            }

            else
            {
                MessageBox.Show("Numero de Documento invalido");
                txtNumero.SelectAll();                
                return;
            }
            

            foreach (DataGridViewRow Row in dgv_q.Rows)
            {
                
                String strFila = Row.Index.ToString();


                string SerirFac = Row.Cells[0].Value.ToString();
                Int32 NumDoc = int.Parse(Row.Cells[1].Value.ToString());


                if (SerirFac == Serie && NumDoc == Numero)
                {
                    //RowsCells[0].de
                    dgv_q.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Green;

                    //dgv_q.ClearSelection();
                    dgv_q.Rows[Int16.Parse(strFila)].Selected = true;
                    dgv_q.Focus();
                    dgv_q.Refresh();

                    dgv_q.FirstDisplayedScrollingRowIndex = Int16.Parse(strFila);
                    SwFind = true;
                }


            }

            if (!SwFind)
            {
                MessageBox.Show("Esta Serie y/o Factura no esta se encuentra");
            }
        }


    }
}
