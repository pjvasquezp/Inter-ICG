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
using System.Threading;
using ICG_Inter.Properties;

namespace ICG_Inter
{
    public partial class FacturasVenta : Form
    {
        public string TipoSerie = "X";
        public Documento_Cabecera ObjDocCab = new Documento_Cabecera();
        public Documento_Detalle DocDetalleSeleccionado = new Documento_Detalle();
        public ProductoDev ProductoDevSeleccionado = new ProductoDev();
        public Buildsxml ObjBuildXml = new Buildsxml();
        public int TotalProducDev;
 
        string RutaExeFirmado = Settings.Default.PathFirmFEL;
        NotasCredito ObjNotaCredit = new NotasCredito();

        public DAConnectionSQL ObjDaConnexion;
        public ProcesosDB ObjProcDB = new ProcesosDB();
        public ListaProductoDev ObjListaProductosDev = new ListaProductoDev();
        public ListaNotasCredito ObjListaNotasCredito = new ListaNotasCredito();

        public ListaDocVentas ObjListaDocVentas = new ListaDocVentas();
        public FacturasVenta()
        {
            InitializeComponent();
        }
        public FacturasVenta(ListaDocVentas ObjListaDoc, DAConnectionSQL ObjDAConnecion)
        {
            ObjListaDocVentas = ObjListaDoc;
            ObjDaConnexion = ObjDAConnecion;
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

            Documento_Cabecera MiObjCabecera = ObjProcDB.BuscarDocVentasCabecera(ObjDaConnexion, Serie, NumDoc);
            txtcliente.Text = MiObjCabecera.Cliente;
            txt_cliente2.Text = MiObjCabecera.Cliente;
            txt_cliente2.Text = MiObjCabecera.Codigo_Cliente.ToString(); ;
            txt_vendedor2.Text = MiObjCabecera.Vendedor;
            txt_fecha.Text = MiObjCabecera.Fecha.ToString();
            txt_hora.Text = MiObjCabecera.Hora;
            txt_serie.Text = MiObjCabecera.Serie;
            txt_num.Text = MiObjCabecera.Numero.ToString();

            int daysDiff = ((TimeSpan)(DateAndTime.Now.Date - MiObjCabecera.Fecha.Date)).Days;

            if (daysDiff >= 60 )
            {
                TipoSerie = "Y";
            }
            else
            {
                TipoSerie = "X";
            }


            if (daysDiff > 30)
            {
                
                if (!ValidarFechaDevolucion(MiObjCabecera.Fecha.Date))
                {
                    return;
                }
            }
           
                      

            ListaDocDetalle MiObjDetalle = ObjProcDB.BuscarDocVentasDetalle(ObjDaConnexion, Serie, NumDoc);

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
            ObjProductoDev.CodColor = this.dgv_Doc.CurrentRow.Cells[13].Value.ToString();

            ObjProductoDev.Procesado = false;
          

            if (ObjProductoDev.Retornable == "T")
            {

                FormDevolucion v1 = new FormDevolucion(ref ObjProductoDev, ObjDaConnexion);
                v1.ShowDialog();
                this.Show();

                if (ObjProductoDev.RazonDevolucion != null && ObjProductoDev.UnidadesDevueltas != 0)
                {
                    if (ObjProductoDev.Procesado)
                    {
                        ObjListaNCR = ObjProcDB.ValidarDevolucion(ObjDaConnexion, ObjProductoDev.Serie, ObjProductoDev.Numero, ObjProductoDev.CodBarra, ObjProductoDev.UnidadesDevueltas);
                       // TotalProducDev = (from NotasCredito in ObjListaNCR where NotasCredito.UnidadesDevueltas != 0 select sum(NotasCredito));
                     
                        if (ObjListaNCR.Count > 0)
                        {
                            bool procesar = false;
                            foreach (var item in ObjListaNCR)
                            {
                                TotalProducDev = (from NotasCredito in ObjListaNCR select NotasCredito.UnidadesDevueltas).Sum();
                                procesar = ValidarDevolucion(item, TotalProducDev + ObjProductoDev.UnidadesDevueltas);
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
                            bool procesar = false;
                            TotalProducDev = (from ProductoDev in ObjListaProductosDev 
                                              where ProductoDev.CodBarra.ToString() == ObjProductoDev.CodBarra.ToString()
                                              select ProductoDev.UnidadesDevueltas).Sum();

                            if (ObjProductoDev.UnidadesDevueltas + TotalProducDev > ObjProductoDev.UnidadesVenta)
                            {
                                MessageBox.Show("El Articulo " + ObjProductoDev.CodBarra + " de la Factura " + ObjProductoDev.Serie + " " + ObjProductoDev.Numero +
                                        " Ya esta incluida para Procesar como Devolucions", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            
                            foreach (var someobject in ObjListaProductosDev)
                            {                                
                                if (someobject.CodBarra.ToString() == dgv_Doc.CurrentRow.Cells[12].Value.ToString())   
                                {
                                    procesar = true;
                                    someobject.UnidadesDevueltas = ObjProductoDev.UnidadesDevueltas + TotalProducDev;
                                }
                            }

                            if (procesar)
                            {
                                Dgv_ProductosDev.DataSource = null;
                                Dgv_ProductosDev.DataSource = ObjListaProductosDev;
                            }
                            else
                            {
                                ObjListaProductosDev.Add(ObjProductoDev);
                                CargarGridProductosDev(ObjListaProductosDev);
                            }

                        }

                    }
                }
            }

            else
            {
                MessageBox.Show("Producto no acepta Devolución", "Notificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private bool ValidarFechaDevolucion(DateTime FechaDev)
        {
            bool Valido = false;
            int daysDiff = ((TimeSpan)(DateAndTime.Now.Date - FechaDev)).Days;
            string PassSupervisor;
            if (daysDiff > 30)
            {
                FormPass MyFormPass = new FormPass(ObjDaConnexion);   //(ObjListaNCR);
                //this.Hide();
                MyFormPass.ShowDialog();
                Valido = MyFormPass.PasswordValido; 
                this.Show();
            }
            //Entrada de datos medianta un inputbox
            //PassSupervisor = Microsoft.VisualBasic.Interaction.InputBox("Ingrese Nombre ", "Registro de Datos Personales", "*", 100, 0);

            return Valido;
        }

        void CargarGridProductosDev(ListaProductoDev ObjListaProductosDev)
        {
            Dgv_ProductosDev.DataSource = null;
            Dgv_ProductosDev.DataSource = ObjListaProductosDev;
            Dgv_ProductosDev.Refresh();
        }

        public bool ValidarDevolucion(NotasCredito ObjNCR, int TotalDevoluciones)
        {
            bool Procesar = false;
            var result = MessageBox.Show("El Articulo " + ObjNCR.CodBarra + " La Factura " + ObjNCR.Serie_Fact + " " + ObjNCR.Num_Fact +
                                        " Posee Devoluciones Previas " + ObjNCR.Serie + "-" + ObjNCR.Numero + "\r\n" +
                                        " Desea Verificar Devoluciones?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ListaNotasCredito ObjListaNCR = new ListaNotasCredito();
                ObjListaNCR = ObjProcDB.ValidarDevolucion(ObjDaConnexion, ObjNCR.Serie_Fact, ObjNCR.Num_Fact, ObjNCR.CodBarra, ObjNCR.UnidadesDevueltas);
                ConsultaDevolucion v1 = new ConsultaDevolucion(ObjListaNCR);
                this.Hide();
                v1.ShowDialog();
                this.Show();

                var result2 = MessageBox.Show("Se va a procesar la Devolución? " + "\r\n"
                , "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result2 == DialogResult.Yes)
                {
                    if (TotalDevoluciones >= ObjListaNCR[0].Unidades)
                    {
                        MessageBox.Show("No se pueden Devolver mas unidades de las vendidas " + "\r\n"
                , "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        ObjListaNotasCredito.Add(ObjNCR);
                        Procesar = true;
                    }
                    
                    //exitoso = ObjProcDB.InsertarNotasCredito(ObjNotaCredito);
                }
            }

            return Procesar;

        }

        private void BtnProcesar_Click(object sender, EventArgs e)
        {
            bool Exitoso = false;
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


                    Exitoso = ObjProcDB.EjecutarNotasCredito(ObjDaConnexion);

                    
                    
                    ObjNotaCredit = BusarUlimaNotaCredito();
                    if (Exitoso)
                    {
                        ObjBuildXml.ContruyeXML(ObjNotaCredit.Serie, ObjNotaCredit.Numero);
                        
                        Process.Start(RutaExeFirmado + "llamarEXE.exe");

                        var stopwatch = Stopwatch.StartNew();
                        Thread.Sleep(6000); //tiempo de pausa
                        stopwatch.Stop();

                        FrmPrintNCR MyFormPrintNCR = new FrmPrintNCR(ObjDaConnexion, ObjNotaCredit);   //(ObjListaNCR);
                        MyFormPrintNCR.Show();
                        this.Show();


                        MessageBox.Show("La Devolucion de la Factura " + SerieFacDocumento + " - " +
                            NumDocDocument + " se Proceso correctamente",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("La Devolucion de la Factura " + SerieFacDocumento + " - " +
                            NumDocDocument + " No se Proceso correctamente",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                }

                ObjNotaCredito.Serie = TipoSerie;
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
                ObjNotaCredito.CodColor = Row.Cells[14].Value.ToString();
                ObjNotaCredito.NumLinea = NumLinea;
                ObjNotaCredito.Total = ObjNotaCredito.UnidadesDevueltas * ObjNotaCredito.Precio;
                
                SerieFacActual = SerieFacDocumento;
                NumDocActual = NumDocDocument;


                //ObjListaNCR = ObjProcDB.ValidarDevolucion(ObjNotaCredito.Serie, ObjNotaCredito.Numero, ObjNotaCredito.CodBarra, ObjNotaCredito.UnidadesDevueltas)

                ObjListaNotasCredito.Add(ObjNotaCredito);
                Exitoso = ObjProcDB.InsertarNotasCredito(ObjDaConnexion, ObjNotaCredito, TipoSerie);

                ValidarProceso(Exitoso, SerieFacDocumento, NumDocDocument, NumLinea);                                

            }
                ObjListaProductosDev.Clear();
                Dgv_ProductosDev.DataSource = null;
                Dgv_ProductosDev.Refresh();

                MessageBox.Show("Proceso Completado Correctamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                Exitoso = ObjProcDB.EjecutarNotasCredito(ObjDaConnexion);

                ObjNotaCredit = BusarUlimaNotaCredito();

                ObjBuildXml.ContruyeXML(ObjNotaCredit.Serie, ObjNotaCredit.Numero);
                try
                {
                    Process.Start(RutaExeFirmado + "llamarEXE.exe");

                    MessageBox.Show("Firmado de la Devolucion de la Factura " +
                    SerieFacActual + " - " + NumDocDocument +
                    " Procesada Correctamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    var stopwatch = Stopwatch.StartNew();
                    Thread.Sleep(6000); //tiempo de pausa
                    stopwatch.Stop();

                    FrmPrintNCR MyFormPrintNCR = new FrmPrintNCR(ObjDaConnexion, ObjNotaCredit);   //(ObjListaNCR);
                    MyFormPrintNCR.Show();
                    this.Show();

                }
                catch (Exception)
                {

                    MessageBox.Show("Error al Procesar el Firmado de " + NumLinea + " de la Devolucion de la Factura " +
                    SerieFacActual + " " + NumDocDocument
                    , "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


        }

        private NotasCredito BusarUlimaNotaCredito()
        {
            NotasCredito UltimaNotaCredito = ObjProcDB.BuscarNotacredito(ObjDaConnexion, TipoSerie);

            return UltimaNotaCredito;
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

       

        private void EliminarLinea(Object sender, EventArgs e)
        {
            string CodBarEliminar = "";
            bool Borrar = false;
            //MessageBox.Show("OK");
            foreach (var someobject in ObjListaProductosDev)
            {
                if (someobject.CodBarra.ToString() == Dgv_ProductosDev.CurrentRow.Cells[13].Value.ToString()) // There will only one item where Number == 1.  
                {
                    Borrar = true;
                   CodBarEliminar = Dgv_ProductosDev.CurrentRow.Cells[13].Value.ToString();                    
                }
            }

            if (Borrar)
            {
                ObjListaProductosDev.RemoveAll(x => x.CodBarra == CodBarEliminar);
            }
            //ObjListaProductosDev.Remove(someobject);
            Dgv_ProductosDev.DataSource = null;
            Dgv_ProductosDev.DataSource = ObjListaProductosDev;
        }  

        private void Dgv_ProductosDev_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                     //seleciona la fila del click derecho
                var hti = dgv_Doc.HitTest(e.X, e.Y);
                Dgv_ProductosDev.ClearSelection();
                                
                Dgv_ProductosDev.Rows[hti.RowIndex].Selected = true;

                //creo menu conextual con dos items
                ContextMenu cm = new ContextMenu();
                MenuItem mi = new MenuItem();
                mi.Text = "Eliminar Devolución";
                mi.Click += EliminarLinea; //metodo al dar click
                cm.MenuItems.Add(mi);

                cm.Show(Dgv_ProductosDev, new Point(e.X, e.Y));
                }
                catch (Exception)
                {

                    MessageBox.Show(" No ha seleccionado ninguna Fila, intente Nuevamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }





            }
        }
    }
}
