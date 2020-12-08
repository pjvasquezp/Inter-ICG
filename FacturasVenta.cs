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
using System.Windows.Media.Imaging;
using System.IO;

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
        public bool SWDevol = false;
        public UserSistemas oUserSistemasLog = new UserSistemas();



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
        public FacturasVenta(ListaDocVentas ObjListaDoc, DAConnectionSQL ObjDAConnecion, UserSistemas oUserSistemas)
        {
            oUserSistemasLog = oUserSistemas;
            ObjListaDocVentas = ObjListaDoc;
            ObjDaConnexion = ObjDAConnecion;
            InitializeComponent();
            this.Text = this.Text + " USER .: " + oUserSistemasLog.NOMVENDEDOR + " :.";
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
            string RutaImagen;


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

            if (MiObjCabecera.RutaFotoCliente != null)
            {
                if (System.IO.File.Exists(MiObjCabecera.RutaFotoCliente))
                {
                    RutaImagen = MiObjCabecera.RutaFotoCliente;
                }
                else
                {
                    RutaImagen = Settings.Default.PathImagCUST + "NOIMAGEN" + ".jpg";
                }
                //RutaImagen = MiObjCabecera.RutaFotoCliente;
                //RutaImagen = Settings.Default.PathImagCUST + "NOIMAGEN" + ".jpg";
                PBClientes.Image = Image.FromFile(RutaImagen);
            }
            else
            {
                RutaImagen = Settings.Default.PathImagCUST + "NOIMAGEN" + ".jpg";
                PBClientes.Image = Image.FromFile(RutaImagen);
            }

            //if (System.IO.File.Exists(Settings.Default.PathImagCUST + MiObjCabecera.Codigo_Cliente.ToString() + ".jpg"))
            //{
            //    RutaImagen = Settings.Default.PathImagCUST + MiObjCabecera.Codigo_Cliente.ToString() + ".jpg";
            //    PBClientes.Image = Image.FromFile(RutaImagen);
            //}
            //else
            //{
            //    RutaImagen = Settings.Default.PathImagCUST + "NOIMAGEN" + ".jpg";
            //    PBClientes.Image = Image.FromFile(RutaImagen);
            //}

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

            TotalProducDev = (from ProductoDev in MiObjDetalle
                              select ProductoDev.Devoluciones).Sum();

            dgv_Doc.DataSource = MiObjDetalle;

            DibujaGrid(ref dgv_Doc);
        }

        private void DibujaGrid(ref DataGridView Dgv_ProductosDev)
        {
            foreach (DataGridViewRow Row in Dgv_ProductosDev.Rows)
            {
                

                if (int.Parse(Row.Cells[7].Value.ToString()) > 0) //Row.Cells[0].Value > 0
                {
                    SWDevol = true;
                    Row.Cells[7].Style.BackColor = Color.Yellow;
                    Row.Cells[7].Style.ForeColor = Color.Red;

                }

                else
                {
                    SWDevol = false;
                    Row.Cells[7].Style.BackColor = Color.White;
                    Row.Cells[7].Style.ForeColor = Color.Black;

                }
            }

        }

        private void dgv_Doc_DoubleClick(object sender, EventArgs e)
        {
            string RutaImagen;
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
            ObjProductoDev.Precio = decimal.Parse(this.dgv_Doc.CurrentRow.Cells[10].Value.ToString());
            ObjProductoDev.Almacen = this.dgv_Doc.CurrentRow.Cells[12].Value.ToString();
            ObjProductoDev.Retornable = this.dgv_Doc.CurrentRow.Cells[11].Value.ToString();
            ObjProductoDev.CodBarra = this.dgv_Doc.CurrentRow.Cells[13].Value.ToString();
            ObjProductoDev.CodColor = this.dgv_Doc.CurrentRow.Cells[14].Value.ToString();
            ObjProductoDev.CodArticulo = int.Parse(this.dgv_Doc.CurrentRow.Cells[15].Value.ToString());
            ObjProductoDev.NumLinea = int.Parse(this.dgv_Doc.CurrentRow.Cells[16].Value.ToString());
            ObjProductoDev.Linea_Fact = int.Parse(this.dgv_Doc.CurrentRow.Cells[16].Value.ToString());



            ObjProductoDev.Procesado = false;

            byte[] FotoItem = ObjProcDB.BuscarFotoArticulo(ObjDaConnexion, ObjProductoDev.CodArticulo);

            PBArticulos.Image = byteArrayToImage(FotoItem);

            if (FotoItem != null)
            {
                PBArticulos.Image = byteArrayToImage(FotoItem);
            }
            else
            {
                RutaImagen = Settings.Default.PathImagCUST + "NOIMAGEN" + ".jpg";
                PBArticulos.Image = Image.FromFile(RutaImagen);
            }



            if (ObjProductoDev.Retornable == "T")
            {

                FormDevolucion v1 = new FormDevolucion(ref ObjProductoDev, ObjDaConnexion, oUserSistemasLog);
                v1.ShowDialog();
                this.Show();

                if (ObjProductoDev.RazonDevolucion != null && ObjProductoDev.UnidadesDevueltas != 0)
                {
                    if (ObjProductoDev.Procesado)
                    {
                        ObjListaNCR = ObjProcDB.ValidarDevolucion(ObjDaConnexion, ObjProductoDev.Serie, ObjProductoDev.Numero, ObjProductoDev.CodBarra, ObjProductoDev.UnidadesDevueltas, ObjProductoDev.Linea_Fact);
                       // TotalProducDev = (from NotasCredito in ObjListaNCR where NotasCredito.UnidadesDevueltas != 0 select sum(NotasCredito));
                     
                        if (ObjListaNCR.Count > 0)
                        {
                            bool procesar = false;
                            //Debe ser una sola validacion
                            //foreach (var item in ObjListaNCR)
                            //{
                                TotalProducDev = (from NotasCredito in ObjListaNCR select NotasCredito.UnidadesDevueltas).Sum();
                                //procesar = ValidarDevolucion( ObjListaNCR[0], TotalProducDev + ObjProductoDev.UnidadesDevueltas);
                                procesar = ValidarDevolucion(ObjProductoDev, TotalProducDev + ObjProductoDev.UnidadesDevueltas);
                            if (procesar)
                                {
                                    ObjListaProductosDev.Add(ObjProductoDev);
                                    CargarGridProductosDev(ObjListaProductosDev);

                                }
                            //}

                        }
                        else
                        {
                            bool procesar = false;
                            TotalProducDev = (from ProductoDev in ObjListaProductosDev 
                                              where ProductoDev.CodBarra.ToString() == ObjProductoDev.CodBarra.ToString() &
                                              ProductoDev.NumLinea == ObjProductoDev.NumLinea
                                              select ProductoDev.UnidadesDevueltas).Sum();

                            if (ObjProductoDev.UnidadesDevueltas + TotalProducDev > ObjProductoDev.UnidadesVenta)
                            {
                                MessageBox.Show("El Artículo " + ObjProductoDev.CodBarra + " de la Factura " + ObjProductoDev.Serie + " " + ObjProductoDev.Numero +
                                        " Ya esta incluida para Procesar como Devolución", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }
                            
                            foreach (var someobject in ObjListaProductosDev)
                            {                                
                                if (someobject.CodBarra.ToString() == dgv_Doc.CurrentRow.Cells[13].Value.ToString())   
                                {
                                    procesar = true;
                                    someobject.UnidadesDevueltas = ObjProductoDev.UnidadesDevueltas + TotalProducDev;

                                }
                                //ObjListaProductosDev.Add(ObjProductoDev);
                                //CargarGridProductosDev(ObjListaProductosDev);
                            }

                            if (procesar)
                            {
                                ObjListaProductosDev.Add(ObjProductoDev);
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
        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            if (byteArrayIn != null)
            {
                using (MemoryStream mStream = new MemoryStream(byteArrayIn))
                {
                    return Image.FromStream(mStream);
                }
            }

            else
            {
                return null;

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

        public bool ValidarDevolucion(ProductoDev OProductosDevNCR, int TotalDevoluciones)
        {
            bool Procesar = false;
            int TotalProducXProc = (from DevxProcesar in ObjListaProductosDev select DevxProcesar.UnidadesDevueltas).Sum();

            if (TotalDevoluciones > OProductosDevNCR.UnidadesVenta)  //ObjListaNCR[0].Unidades)
            {
                var result = MessageBox.Show("El Artículo " + OProductosDevNCR.CodBarra + " de la Factura " + OProductosDevNCR.Serie + " " + OProductosDevNCR.Numero +
                                " Posee Devoluciones Previas " +  "\r\n" +
                                " Desea Verificar Devoluciones?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ListaNotasCredito ObjListaNCR = new ListaNotasCredito();
                    ObjListaNCR = ObjProcDB.ValidarDevolucion(ObjDaConnexion, OProductosDevNCR.Serie, OProductosDevNCR.Numero, 
                        OProductosDevNCR.CodBarra, OProductosDevNCR.UnidadesDevueltas, OProductosDevNCR.Linea_Fact);
                    ConsultaDevolucion v1 = new ConsultaDevolucion(ObjListaNCR);
                    this.Hide();
                    v1.ShowDialog();
                    this.Show();
                }
                else
                { MessageBox.Show("No se pueden Devolver más unidades de las vendidas en esta Factura " + "\r\n"
                  , "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else if (TotalDevoluciones + TotalProducXProc > OProductosDevNCR.UnidadesVenta)
            {
                MessageBox.Show("No se puede devolver mas de lo permitido, Solo Puede Procesar lo Pendiente " + "\r\n"
            , "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            else
            {
                NotasCredito ObjNCR = new NotasCredito();

                ObjNCR.Almacen = OProductosDevNCR.Almacen;
                ObjNCR.CodArticulo = OProductosDevNCR.CodArticulo;
                ObjNCR.CodBarra = OProductosDevNCR.CodBarra ;
                ObjNCR.CodColor = OProductosDevNCR.CodColor ;
                ObjNCR.Color = OProductosDevNCR.Color ;
                ObjNCR.Descripcion = OProductosDevNCR.Descripcion ;
                ObjNCR.Fecha_Fact = OProductosDevNCR.Fecha_Factura;
                ObjNCR.Num_Fact = OProductosDevNCR.Numero ;
                ObjNCR.Precio = OProductosDevNCR.Precio ;
                //ObjNCR. = OProductosDevNCR. ;

                ObjListaNotasCredito.Add(ObjNCR);
                Procesar = true;
            }

            //var result2 = MessageBox.Show("Se va a procesar la Devolución? " + "\r\n"
            //, "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (result2 == DialogResult.Yes)
            //{

            //}

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
            NotasCredito ObjNotaCreditoProc2 = new NotasCredito();
            this.Cursor = Cursors.WaitCursor;

            foreach (DataGridViewRow Row in Dgv_ProductosDev.Rows)
            {
                String strFila = Row.Index.ToString();
                //ListaNotasCredito ObjListaNCR = new ListaNotasCredito();
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
                    //Procesa Nota de Credito  
                    NotasCredito ObjNotaCreditoProc = new NotasCredito();
                    //Exitoso = ObjProcDB.EjecutarNotasCredito(ObjDaConnexion);

                    this.Cursor = Cursors.WaitCursor;
                    ObjNotaCreditoProc = ObjProcDB.InsertarNotasCredito(ObjDaConnexion, ObjListaNotasCredito, TipoSerie, oUserSistemasLog);

                    ObjListaNotasCredito.Clear();

                    //ValidarProceso(Exitoso, SerieFacDocumento, NumDocDocument, NumLinea);

                    //ObjNotaCredit = BusarUlimaNotaCredito();
                    if (ObjNotaCreditoProc.Numero != 0)
                    {
                        ObjBuildXml.ContruyeXML(ObjNotaCreditoProc.Serie, ObjNotaCreditoProc.Numero);
                        
                        Process.Start(RutaExeFirmado + "llamarEXE.exe");

                        var stopwatch = Stopwatch.StartNew();
                        Thread.Sleep(8000); //tiempo de pausa
                        stopwatch.Stop();

                        FrmPrintNCR MyFormPrintNCR = new FrmPrintNCR(ObjDaConnexion, ObjNotaCreditoProc);   //(ObjListaNCR);
                        MyFormPrintNCR.Show();
                        this.Show();


                        MessageBox.Show("La Devolución de la Factura " + SerieFacDocumento + " - " +
                            NumDocDocument + " se Proceso correctamente",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("La Devoluci+on de la Factura " + SerieFacDocumento + " - " +
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
                ObjNotaCredito.Linea_Fact = Int32.Parse(Row.Cells[15].Value.ToString());


                SerieFacActual = SerieFacDocumento;
                NumDocActual = NumDocDocument;


                //ObjListaNCR = ObjProcDB.ValidarDevolucion(ObjNotaCredito.Serie, ObjNotaCredito.Numero, ObjNotaCredito.CodBarra, ObjNotaCredito.UnidadesDevueltas)

                ObjListaNotasCredito.Add(ObjNotaCredito);                            

            }
                ObjListaProductosDev.Clear();
                Dgv_ProductosDev.DataSource = null;
                Dgv_ProductosDev.Refresh();

                MessageBox.Show("Proceso Completado Correctamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                //Exitoso = ObjProcDB.EjecutarNotasCredito(ObjDaConnexion);
                this.Cursor = Cursors.WaitCursor;
                ObjNotaCreditoProc2 = ObjProcDB.InsertarNotasCredito(ObjDaConnexion, ObjListaNotasCredito, TipoSerie, oUserSistemasLog);
                ObjListaNotasCredito.Clear();

                //ObjNotaCredit = BusarUlimaNotaCredito();

                ObjBuildXml.ContruyeXML(ObjNotaCreditoProc2.Serie, ObjNotaCreditoProc2.Numero);
                try
                {
                    Process.Start(RutaExeFirmado + "llamarEXE.exe");

                    MessageBox.Show("Firmado de la Devolución de la Factura " +
                    SerieFacActual + " - " + NumDocDocument +
                    " Procesada Correctamente ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    var stopwatch = Stopwatch.StartNew();
                    Thread.Sleep(8000); //tiempo de pausa
                    stopwatch.Stop();

                    FrmPrintNCR MyFormPrintNCR = new FrmPrintNCR(ObjDaConnexion, ObjNotaCreditoProc2);   //(ObjListaNCR);
                    MyFormPrintNCR.Show();
                    this.Show();

                this.Cursor = Cursors.Default;
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
                MessageBox.Show("Error al Procesar la Linea " + NumLinea + " de la Devolución de la Factura " + SerieFac + " " + NumDoc
                    , "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string Serie = "";
            int Numero = 0; 

            if (e.KeyChar == (Char)13)
            {
                if (textBox1.Text != "")
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
                MessageBox.Show("Numero de Documento invalido", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("Esta Serie y/o Factura no esta se encuentra registrada", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void BtCancelar_Click(object sender, EventArgs e)
        {
            txt_serie.Text = "";
            txtSerie.Text = "";
            txt_num.Text = "";
            txtcliente.Text = "";
            txt_cliente2.Text = "";
            txt_fecha.Text = "";
            txt_hora.Text = "";
            txt_vendedor2.Text = "";
            textBox1.Text = "";
            txtNumero.Text = "";
            dgv_Doc.DataSource = null;
            Dgv_ProductosDev.DataSource = null;
            PBClientes.Image = null;
            PBArticulos.Image = null;

        }

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool Exitoso = false;
            string Serie;
            Int32 Numero;
            if (e.KeyChar == (Char)13)
            {
                if (txtSerie.Text != "" && txtNumero.Text != "")  
                {
                    Serie = txtSerie.Text;
                    Numero = int.Parse(txtNumero.Text);

                    foreach (DataGridViewRow Row in dgv_q.Rows)
                    {
                        String strFila = Row.Index.ToString();


                        string SerirFac = Row.Cells[0].Value.ToString();
                        Int32 NumDoc = int.Parse(Row.Cells[1].Value.ToString());


                        if (SerirFac == Serie && NumDoc == Numero)
                        {
                            Exitoso = true;
                            dgv_q.Rows[Convert.ToInt32(strFila)].DefaultCellStyle.BackColor = Color.Green;

                            //dgv_q.ClearSelection();
                            dgv_q.Rows[Int16.Parse(strFila)].Selected = true;
                            dgv_q.Focus();
                            dgv_q.Refresh();

                            dgv_q.FirstDisplayedScrollingRowIndex = Int16.Parse(strFila);
                        }
                    }
                    if (!Exitoso)
                    {
                        MessageBox.Show(" No Existe Documento " + Serie + " - " + Numero , "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show(" Debe ingresar Serie y NÚmero de Documento ", "Información", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }


            }
        }

        private void Dgv_ProductosDev_DoubleClick(object sender, EventArgs e)
        {
            string NumSerie;
            Int32 NumFactura = 0;
            String CodigoBarras="";

            NumSerie = this.Dgv_ProductosDev.CurrentRow.Cells[0].Value.ToString();
            NumFactura = int.Parse(this.Dgv_ProductosDev.CurrentRow.Cells[1].Value.ToString());
            CodigoBarras = this.Dgv_ProductosDev.CurrentRow.Cells[13].Value.ToString();

            var result = MessageBox.Show("Desea Elimar esta Linea del Proceso " + "\r\n" +
                                " Desea Verificar Devoluciones?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ObjListaProductosDev.RemoveAll(x => x.Serie == NumSerie && x.Numero == NumFactura && x.CodBarra == CodigoBarras);
                 Dgv_ProductosDev.DataSource = null;
                Dgv_ProductosDev.DataSource = ObjListaProductosDev;
                Dgv_ProductosDev.Refresh();
            }
        }
    }
}
