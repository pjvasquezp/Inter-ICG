
using ICG_Inter.Objetos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ICG_Inter.Datos
{
    public class ProcesosDB
    {       

        public void DACliente()
        {
            DAConnectionSQL DASQLConnection = new DAConnectionSQL();
        }

        public ListaDocVentas GetDocVentas(ProductoXCB ObjProducto , Int32 Cod_Cli, int TipoFecha)
        {
            ListaDocVentas ObjListaDocVentas = new ListaDocVentas();

            string StrinSQL = "";
            var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConClass.Con;

            StrinSQL = "exec[SP_GET_DocumentoData]";
            StrinSQL = StrinSQL + " '" + ObjProducto.Referencia + "', '" + ObjProducto.Color + "',";
            StrinSQL = StrinSQL + " '" + ObjProducto.Talla + "', '" + Cod_Cli + "', " + TipoFecha + "";


            cmd.CommandText = StrinSQL;

            ConClass.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    DocVentas ObjDocVentas = new DocVentas();

                    var withBlock = ObjDocVentas;
                    withBlock.FechaDoc = dr.GetDateTime(0).ToString();
                    withBlock.Serie = dr.GetString(1);
                    withBlock.Numero = dr.GetInt32(2);
                    withBlock.TotalDocumento = dr.GetDouble(3);
                    withBlock.DiasFac = dr.GetInt32(4);



                    ObjListaDocVentas.Add(ObjDocVentas);
                }
                dr.Close();

            }
            catch (Exception)
            {

                throw;
            }


            return ObjListaDocVentas;
        }
        public ListaDocDetalle BuscarDocVentasDetalle(string Serie, int NumDoc)
        {
            ListaDocDetalle ObjListaDocDetalle = new ListaDocDetalle();

            var ConClass = new DAConnectionSQL();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType =  CommandType.Text;
            cmd.Connection = ConClass.Con;
            cmd.CommandText = "exec [SP_Get_VentasDocumentos] '" + Serie + "'," + NumDoc;


            ConClass.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            

            try
            {
                
                while (dr.Read())
                {
                    Documento_Detalle ObjDocDetalle = new Documento_Detalle();

                    var withBlock = ObjDocDetalle;
                        withBlock.Serie = dr.GetString(10);
                        withBlock.Numero = dr.GetInt32(11);
                        withBlock.Referencia = dr.GetString(17);
                        withBlock.Descripcion = dr.GetString(18);
                        withBlock.Unidades = Int16.Parse(dr.GetDouble(21).ToString());
                        withBlock.Precio = decimal.Parse(dr.GetString(22).ToString());
                        withBlock.Descuento = int.Parse(dr.GetDouble(24).ToString());
                        withBlock.Total = Decimal.Parse(dr.GetDouble(25).ToString());
                        withBlock.Almacen = dr.GetString(30);
                        withBlock.Color = dr.GetString(19);
                        withBlock.Talla = dr.GetString(20);
                        withBlock.Retornable = dr.GetString(44);
                        withBlock.CodColor = dr.GetString(45); //int.Parse(dr.GetString(45));
                        withBlock.CodBarra = withBlock.Referencia + withBlock.CodColor + withBlock.Talla;


                    //withBlock.FotoArticulo = byte.Parse(dr.GetByte(44).GetType()); //MemoryStream(dr.GetByte(44));

                    ObjListaDocDetalle.Add(ObjDocDetalle);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
            }

            return ObjListaDocDetalle;
        }

        public Documento_Cabecera BuscarDocVentasCabecera(string Serie, int NumDoc)
        {
            Documento_Cabecera ObjDocumentoCabecera = new Documento_Cabecera();

            var ConClass = new DAConnectionSQL();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConClass.Con;
            cmd.CommandText = "exec [SP_Get_VentasDocumentos] '" + Serie + "'," + NumDoc;

            ConClass.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    
                    var withBlock = ObjDocumentoCabecera;
                    withBlock.Serie = dr.GetString(10);
                    withBlock.Numero = dr.GetInt32(11);
                   // withBlock.Tipo_Documento = dr.GetString(35);
                    withBlock.Cliente = dr.GetString(7);
                    withBlock.Codigo_Cliente = dr.GetInt32(6);
                    withBlock.Direccion = dr.GetString(43);
                    withBlock.Fecha = DateTime.Parse(dr.GetDateTime(4).ToString());
                    //withBlock.Fecha_Inicio = DateTime(dr.GetDateTime().ToString());
                    withBlock.Hora = dr.GetString(5);
                    withBlock.Impuesto = decimal.Parse(dr.GetDouble(27).ToString());
                    withBlock.Poblacion = dr.GetString(37);
                    //withBlock.Transporte = dr.GetString(39);
                    withBlock.Vendedor = dr.GetString(38);      
                    withBlock.Total_BrutoImponible = decimal.Parse(dr.GetDouble(28).ToString());
                    withBlock.Impuesto = decimal.Parse(dr.GetDouble(27).ToString());
                    withBlock.Total_Neto = decimal.Parse(dr.GetDouble(26).ToString());
                    //withBlock.Codigo_Cliente = dr.GetString(6);
                    
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }

            return ObjDocumentoCabecera ;
        }

        public ListaMotivosDev GetMotivosDev()
        {
            ListaMotivosDev ObjListaMotivosDev = new ListaMotivosDev();

            var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConClass.Con;
            cmd.CommandText = "Select * from MOTIVOSDEVOLUCION ";

            ConClass.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    MotivosDevolucion ObjMotivoDev = new MotivosDevolucion();

                    var withBlock = ObjMotivoDev;
                    withBlock.IdMotivo = dr.GetInt32(0);
                    withBlock.Descripcion = dr.GetString(1);

                    ObjListaMotivosDev.Add(ObjMotivoDev);
                }
                dr.Close();

            }
            catch (Exception)
            {

                throw;
            }


            return ObjListaMotivosDev;
        }

        public ProductoXCB GetProductoxCodigo(string CodigoBarra)
        {
            ProductoXCB ObjProductoCXB = new ProductoXCB();

            var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConClass.Con;
            cmd.CommandText = "SP_Get_ArticuloXCodigoBarra '" + CodigoBarra + "' ";

            ConClass.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    //MotivosDevolucion ObjMotivoDev = new MotivosDevolucion();

                    var withBlock = ObjProductoCXB;
                    withBlock.CodigoArticulo = (dr.GetInt32(0).ToString());
                    withBlock.BarCoder = (dr.GetString(1).ToString());

                    withBlock.NombreArticulo = dr.GetString(4);
                    withBlock.Referencia = dr.GetString(5);
                    withBlock.Talla = dr.GetString(6);
                    withBlock.Color = dr.GetString(7).ToString();


                    //ObjListaMotivosDev.Add(ObjMotivoDev);
                }
                dr.Close();

            }
            catch (Exception)
            {

                throw;
            }


            return ObjProductoCXB;
        }

        public Cliente GetCliente(int CodCliente)
        {
            Cliente ObjCliente = new Cliente();

            var ConClass = new DAConnectionSQL();
            string StrinSQL = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConClass.Con;

            StrinSQL = "SELECT CODCLIENTE, NOMBRECLIENTE,CIF,DIRECCION1, TELEFONO1,TELEFONO2";
            StrinSQL = StrinSQL + " FROM CLIENTES where CODCLIENTE = " + CodCliente;

            cmd.CommandText = StrinSQL;

            ConClass.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    var withBlock = ObjCliente;
                    withBlock.CodCliente = dr.GetInt32(0);
                    withBlock.NombreCliente = dr.GetString(1);
                    withBlock.CIFCliente = dr.GetString(2);
                    withBlock.Direccion = dr.GetString(3);
                    withBlock.Telefono1 = dr.GetString(4);
                    withBlock.Telefono1 = dr.GetString(5);
                }
                dr.Close();

            }
            catch (Exception)
            {

                throw;
            }


            return ObjCliente;
        }        
        public int BuscarNumeroDoc(SqlCommand CMD)
        {
            int NumeroDoc = 0;

            CMD.CommandText = " SELECT MAX(NUMFACTURA) FROM FACTURASVENTA WHERE NUMSERIE = 'PPZX'"; //'" + SERIE + "'";



            try
            {
                CMD.Connection.Open();
                SqlDataReader dr = CMD.ExecuteReader();

                while (dr.Read())
                {
                    NumeroDoc = dr.GetInt32(0);
                }

                CMD.Connection.Close();
            }
            catch (Exception)
            {

                throw;
            }


            return NumeroDoc;
        }
        public int BuscarCodigoArticulo(SqlCommand CMD, string Referencia)
        {
            int CodigoArticuloBD = 0;
                        
            CMD.CommandText = "Select CODARTICULO from ARTICULOS where REFPROVEEDOR = '" + Referencia + "'";

            

            try
            {
                CMD.Connection.Open();
                SqlDataReader dr = CMD.ExecuteReader();

                while (dr.Read())
                {
                    CodigoArticuloBD = dr.GetInt32(0);
                }

                CMD.Connection.Close();
            }
            catch (Exception)
            {

                throw;
            }


            return CodigoArticuloBD;
        }
        public ListaNotasCredito ValidarDevolucion(string SerieDoc, Int32 NumeroDoc ,string CodBar, int CantdadDev)
        {
            ListaNotasCredito ObjListaNotasCredito = new ListaNotasCredito();
            bool existe = false;
            var ConClass = new DAConnectionSQL();
            string StrinSQL = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConClass.Con;


            StrinSQL = "Select * ";
            StrinSQL = StrinSQL + " FROM NotaC_Join where Serie_Fact = '" + SerieDoc + "' and Numero_Fact = " + NumeroDoc + "  And ";
            StrinSQL = StrinSQL + "CodBarra = '" + CodBar + "' ";

            cmd.CommandText = StrinSQL;

            try
            {
                cmd.Connection.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    NotasCredito ObjNotaCredito = new NotasCredito();
                    var withBlock = ObjNotaCredito;
                    withBlock.FechaNC = DateTime.Parse(dr.GetDateTime(0).ToString());  //dr.Getdate(0);
                    withBlock.Serie = dr.GetString(1);
                    withBlock.Numero = dr.GetInt32(2);
                    withBlock.Referencia = dr.GetString(3);
                    withBlock.Descripcion = dr.GetString(4);
                    withBlock.Unidades = dr.GetInt32(5);
                    withBlock.UnidadesDevueltas = dr.GetInt32(6);
                    withBlock.RazonDevolucion = dr.GetString(7);
                    withBlock.Precio = decimal.Parse(dr.GetDecimal(8).ToString());
                    withBlock.Talla = dr.GetString(9).ToString();
                    withBlock.Color = dr.GetString(10);
                    withBlock.CodBarra = dr.GetString(11);
                    withBlock.Almacen = dr.GetString(12);
                    withBlock.Fecha_Fact = DateTime.Parse(dr.GetDateTime(17).ToString());
                    withBlock.Serie_Fact = dr.GetString(18);
                    withBlock.Num_Fact = dr.GetInt32(19);

                    ObjListaNotasCredito.Add(ObjNotaCredito);
                }

                cmd.Connection.Close();
            }
            catch (Exception)
            {

                throw;
            }


            return ObjListaNotasCredito; //CodigoArticuloBD;
        }
        public bool InsertarNotasCredito(NotasCredito ObjNotasCredito)
        {
            bool ExisteNC = false;
             bool exitoso = false;
            string StrinSQL = "";

            var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConClass.Con;
            
            ObjNotasCredito.CodArticulo = BuscarCodigoArticulo(cmd, ObjNotasCredito.Referencia);
            ObjNotasCredito.Numero = BuscarNumeroDoc(cmd) + 1;


            //ExisteNC = ValidarDevolucion(cmd, ObjNotasCredito.Serie, ObjNotasCredito.Numero, ObjNotasCredito.CodBarra, ObjNotasCredito.UnidadesDevueltas);


            StrinSQL = "INSERT INTO NotaC_Join ";
            StrinSQL = StrinSQL + "(Fecha_Notac,Serie,Numero,Referencia,Descripcion,UnidadesVenta,UnidadesDevueltas, ";
            StrinSQL = StrinSQL + "RazonDevolucion,Precio,Talla,Color,CodBarra,Almacen,NumLinea,Dtco,CodArticulo, ";
            StrinSQL = StrinSQL + "Precio_Sin_Iva, Fecha_Fact, Serie_Fact , Numero_Fact) ";
            StrinSQL = StrinSQL + "VALUES ('" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "','" + ObjNotasCredito.Serie + "'," + ObjNotasCredito.Numero + ",";
            StrinSQL = StrinSQL + "'" + ObjNotasCredito.Referencia + "','" + ObjNotasCredito.Descripcion + "',"; 
            StrinSQL = StrinSQL + ObjNotasCredito.Unidades + "," + ObjNotasCredito.UnidadesDevueltas + ",'" + ObjNotasCredito.RazonDevolucion + "',";
            StrinSQL = StrinSQL + ObjNotasCredito.Precio + ",'" + ObjNotasCredito.Talla + "','";
            StrinSQL = StrinSQL + ObjNotasCredito.Color + "','" + ObjNotasCredito.CodBarra + "','" + ObjNotasCredito.Almacen + "'," + ObjNotasCredito.NumLinea + ",'";
            StrinSQL = StrinSQL + ObjNotasCredito.Descuento + "'," + ObjNotasCredito.CodArticulo + "," + ObjNotasCredito.Precio_Sin_iva + ",'"; 
            StrinSQL = StrinSQL + ObjNotasCredito.Fecha_Fact.Date.ToString("MM/dd/yyyy") + "','" + ObjNotasCredito.Serie_Fact + "'," + ObjNotasCredito.Num_Fact + ")";

            cmd.CommandText = StrinSQL;                  

            try
            {
                ConClass.Open();
                cmd.ExecuteNonQuery();
                ConClass.Close();
                exitoso = true;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error al ejecutar el Qyery " + ex.Message,"Información",MessageBoxButtons.OK, MessageBoxIcon.Error);;
            }

            return exitoso;
        }

        public bool EjecutarNotasCredito()
        {
            
            bool exitoso = false;
            string StrinSQL = "";

            var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConClass.Con;
                        
            StrinSQL = "JOIN_NC_CAB";
            
            cmd.CommandText = StrinSQL;

            try
            {
                ConClass.Open();
                cmd.ExecuteNonQuery();
                ConClass.Close();
                exitoso = true;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error al ejecutar el Qyery " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            return exitoso;
        }
    }
}
