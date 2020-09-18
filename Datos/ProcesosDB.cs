
using ICG_Inter.DataSet;
using ICG_Inter.Objetos;
using ICG_Inter.Properties;
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
        //***************************************************
            public string Bodega = Settings.Default.Bodega;
            public string SerieTienda = Settings.Default.SERIETIENDA;
        //***************************************************

        public void DACliente()
        {
            DAConnectionSQL DASQLConnection = new DAConnectionSQL();
        }

        public ListaDocVentas GetDocVentas(DAConnectionSQL ObjDaConnexion, ProductoXCB ObjProducto , Int32 Cod_Cli, int TipoFecha)
        {
            ListaDocVentas ObjListaDocVentas = new ListaDocVentas();

            string StrinSQL = "";
            //var ConClass = new DAConnectionSQL();
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;

            StrinSQL = "exec[SP_GET_DocumentoData]";
            StrinSQL = StrinSQL + " '" + ObjProducto.Referencia + "', '" + ObjProducto.Color + "',";
            StrinSQL = StrinSQL + " '" + ObjProducto.Talla + "', '" + Cod_Cli + "', " + TipoFecha + "";


            cmd.CommandText = StrinSQL;

            if (ObjDaConnexion.Con.State == ConnectionState.Closed)
            {
                ObjDaConnexion.Open();
            }
            
            
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

                 dr.Close();
            }


            return ObjListaDocVentas;
        }
        public ListaDocDetalle BuscarDocVentasDetalle(DAConnectionSQL ObjDaConnexion,string Serie, int NumDoc)
        {
            ListaDocDetalle ObjListaDocDetalle = new ListaDocDetalle();
           
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType =  CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;
            cmd.CommandText = "exec [SP_Get_VentasDocumentos] '" + Serie + "'," + NumDoc;


            if (ObjDaConnexion.Con.State == ConnectionState.Closed)
            {
                ObjDaConnexion.Open();
            }
            
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


                        if (dr["COLOR"].GetType() == typeof(DBNull))
                        {
                            withBlock.Color = "";
                        }
                        else
                        {
                            withBlock.Color = dr.GetString(19);
                        }
                       
                        withBlock.Talla = dr.GetString(20);
                        withBlock.Retornable = dr.GetString(44);
                        if (dr["CODCOLOR"].GetType() == typeof(DBNull)) //!dr.IsDBNull(GetString(45)))
                        {
                            withBlock.CodColor = "";
                        }
                        else
                        {
                        withBlock.CodColor  = dr.GetString(45);
                        }

                    //int.Parse(dr.GetString(45));
                        withBlock.CodBarra = withBlock.Referencia + withBlock.CodColor + withBlock.Talla;


                    //withBlock.FotoArticulo = byte.Parse(dr.GetByte(44).GetType()); //MemoryStream(dr.GetByte(44));

                    ObjListaDocDetalle.Add(ObjDocDetalle);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                dr.Close();
                MessageBox.Show("Test");
            }

            return ObjListaDocDetalle;
        }

        public Documento_Cabecera BuscarDocVentasCabecera(DAConnectionSQL ObjDaConnexion,string Serie, int NumDoc)
        {
            Documento_Cabecera ObjDocumentoCabecera = new Documento_Cabecera();

            //var ConClass = new DAConnectionSQL();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;
            cmd.CommandText = "exec [SP_Get_VentasDocumentos] '" + Serie + "'," + NumDoc;

            if (ObjDaConnexion.Con.State == ConnectionState.Closed)
            {
                ObjDaConnexion.Open();
            }
           
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
                    withBlock.Poblacion = dr.GetString(36);
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
                dr.Close();
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }

            return ObjDocumentoCabecera ;
        }

        public ListaMotivosDev GetMotivosDev(DAConnectionSQL ObjDaConnexion)
        {
            ListaMotivosDev ObjListaMotivosDev = new ListaMotivosDev();

            //var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;
            cmd.CommandText = "Select * from MOTIVOSDEVOLUCION ";


            if (ObjDaConnexion.Con.State == ConnectionState.Closed)
            {
                ObjDaConnexion.Open();
            }
                        
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
            catch (Exception ex)
            {
                dr.Close();
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return ObjListaMotivosDev;
        }

        public DataTable GetDataNCRAll(DateTime FechaDesde, DateTime FechaHasta, string TipoSerie ,DAConnectionSQL ObjDaConnexion)
        {

            DataTable DTNotasNCR = new DataTable();
            string StrinSQL = "";
            string FiltroSerie;
            //var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;

            if (TipoSerie == "A")
            {
                FiltroSerie = "Like '" + SerieTienda + "%";

            }
            else if (TipoSerie == "X")
            {
                FiltroSerie = " = '" + SerieTienda + "X";
            }

            else
            {
                FiltroSerie = " = '" + SerieTienda + "Y";
            }

            StrinSQL = "Select T0.NUMSERIE, T0.NUMFACTURA,T0.SERIEFEL, T0.DOCUMENTOFEL,T0.FECHAHORACERTIFICACI, T0.UUID, T1.CodBarra, ";
            StrinSQL = StrinSQL + " T1.UnidadesDevueltas, T1.Precio, (T1.UnidadesDevueltas * Precio) as TotalLinea, T1.Descripcion, T3.CODCLIENTE, ";
            StrinSQL = StrinSQL + " T3.CIF as NIT, T3.NOMBRECLIENTE ,T3.DIRECCION1, T1.Numero_Fact, T1.Serie_Fact ";
            StrinSQL = StrinSQL + " from FACTURASVENTACAMPOSLIBRES T0 INNER JOIN NotaC_Join T1 ON T0.NUMSERIE = T1.Serie and T0.NUMFACTURA = T1.Numero ";
            StrinSQL = StrinSQL + " INNER JOIN ALBVENTACAB T2 ON T1.Serie_Fact = T2.NumSerie and T1.Numero_Fact = T2.NUMFAC  ";
            StrinSQL = StrinSQL + " INNER JOIN CLIENTES T3 ON T2.CODCLIENTE = T3.CODCLIENTE ";
            StrinSQL = StrinSQL + " where (T0.SERIEFEL is not NULL AND DOCUMENTOFEL IS NOT NULL) and (T0.SERIEFEL <> '' AND DOCUMENTOFEL <> '') and ";
            StrinSQL = StrinSQL + " (T0.FECHAHORACERTIFICACI >= '" + FechaDesde.ToString("yyyy-MM-dd") + "' and T0.FECHAHORACERTIFICACI <= '" + FechaHasta.ToString("yyyy-MM-dd") + "') AND ";
            StrinSQL = StrinSQL + " T0.NUMSERIE " + FiltroSerie + "'" ;

            cmd.CommandText = StrinSQL;
                        
            if (ObjDaConnexion.Con.State == ConnectionState.Closed)
            { 
                ObjDaConnexion.Open();
            }

            try
            {
                DTNotasNCR.Load(cmd.ExecuteReader());

                return DTNotasNCR;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return DTNotasNCR;
        }

        public DataTable GetDataNCR(NotasCredito ONotaCredito, DAConnectionSQL ObjDaConnexion)
        {

            DataTable DTNotasNCR = new DataTable();
            string StrinSQL = "";

            //var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;

            StrinSQL = "Select T0.NUMSERIE, T0.NUMFACTURA,T0.SERIEFEL, T0.DOCUMENTOFEL,T0.FECHAHORACERTIFICACI, T0.UUID, T1.CodBarra, ";
            StrinSQL = StrinSQL + " T1.UnidadesDevueltas, T1.Precio, (T1.UnidadesDevueltas * Precio) as TotalLinea, T1.Descripcion, T3.CODCLIENTE, ";
            StrinSQL = StrinSQL + "T3.CIF as NIT, T3.NOMBRECLIENTE ,T3.DIRECCION1, T1.Numero_Fact, T1.Serie_Fact ";
            StrinSQL = StrinSQL + "from FACTURASVENTACAMPOSLIBRES T0 INNER JOIN NotaC_Join T1 ON T0.NUMSERIE = T1.Serie and T0.NUMFACTURA = T1.Numero ";
            StrinSQL = StrinSQL + "INNER JOIN ALBVENTACAB T2 ON T1.Serie_Fact = T2.NumSerie and T1.Numero_Fact = T2.NUMFAC ";
            StrinSQL = StrinSQL + "INNER JOIN CLIENTES T3 ON T2.CODCLIENTE = T3.CODCLIENTE ";
            StrinSQL = StrinSQL + "where T0.NUMSERIE = '"+ ONotaCredito.Serie + "' and T0.NUMFACTURA = " + ONotaCredito.Numero;

            cmd.CommandText = StrinSQL;

            if (ObjDaConnexion.Con.State == ConnectionState.Closed)
            {
                ObjDaConnexion.Open();
            }

            try
            {
                DTNotasNCR.Load(cmd.ExecuteReader());

                return DTNotasNCR;

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return DTNotasNCR;
        }

        public ProductoXCB GetProductoxCodigo(DAConnectionSQL ObjDaConnexion,string CodigoBarra)
        {
            ProductoXCB ObjProductoCXB = new ProductoXCB();

            //var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;
            cmd.CommandText = "SP_Get_ArticuloXCodigoBarra '" + CodigoBarra + "' ";

            if (ObjDaConnexion.Con.State == ConnectionState.Closed)
            {
                ObjDaConnexion.Open();
            }

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
            catch (Exception ex)
            {

                dr.Close();
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return ObjProductoCXB;
        }

        public bool GetPasswordSupervisor (DAConnectionSQL ObjDaConnexion, string PasswordSupervisor)
        {
            bool Valido = false;

            //var ConClass = new DAConnectionSQL();
            string StrinSQL = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;

            StrinSQL = "SELECT CODVENDEDOR, NOMVENDEDOR,PASSWORDWEB ";
            StrinSQL = StrinSQL + "FROM VENDEDORES WHERE PASSWORDWEB = '" + PasswordSupervisor + "'";

            cmd.CommandText = StrinSQL;


            if (ObjDaConnexion.Con.State == ConnectionState.Closed)
            {
                ObjDaConnexion.Open();
            }


            SqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    dr.GetString(2);
                }

                if (dr.HasRows)
                {
                    Valido = true;
                }
                else
                {
                    Valido = false;
                }

                dr.Close();

            }
            catch (Exception ex)
            {

                dr.Close();
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return Valido;
        }
        public Cliente GetCliente(DAConnectionSQL ObjDaConnexion,int CodCliente)
        {
            Cliente ObjCliente = new Cliente();

            //var ConClass = new DAConnectionSQL();
            string StrinSQL = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;

            StrinSQL = "SELECT CODCLIENTE, NOMBRECLIENTE,CIF,DIRECCION1, TELEFONO1,TELEFONO2";
            StrinSQL = StrinSQL + " FROM CLIENTES where CODCLIENTE = " + CodCliente;

            cmd.CommandText = StrinSQL;


            if (ObjDaConnexion.Con.State == ConnectionState.Closed)
            {
                ObjDaConnexion.Open();
            }


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
            catch (Exception ex)
            {

                dr.Close();
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return ObjCliente;
        }        
        public int BuscarNumeroDoc(SqlCommand CMD, String TipoSerie)
        {
            int NumeroDoc = 0;

            CMD.CommandText = " SELECT MAX(NUMFACTURA) FROM FACTURASVENTA where NUMSERIE LIKE  '" + SerieTienda +"%'"; //'" + SERIE + "'";

            if (CMD.Connection.State == ConnectionState.Closed)
            {
                CMD.Connection.Open();
            }
            

            SqlDataReader dr = CMD.ExecuteReader();

            try
            {                             

                while (dr.Read())
                {
                    NumeroDoc = dr.GetInt32(0);
                }
                dr.Close();
                
            }
            catch (Exception ex)
            {

                dr.Close();
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return NumeroDoc;
        }
        public int BuscarCodigoArticulo(SqlCommand CMD, string Referencia)
        {
            int CodigoArticuloBD = 0;
                        
            CMD.CommandText = "Select CODARTICULO from ARTICULOS where REFPROVEEDOR = '" + Referencia + "'";

            SqlDataReader dr = CMD.ExecuteReader();
            try
            {
                if (CMD.Connection.State == ConnectionState.Closed)
                {
                    CMD.Connection.Open();
                }
                                

                while (dr.Read())
                {
                    CodigoArticuloBD = dr.GetInt32(0);
                }
                dr.Close();

            }
            catch (Exception ex)
            {
                dr.Close();
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return CodigoArticuloBD;
        }
        public NotasCredito BuscarNotacredito(DAConnectionSQL ObjDaConnexion, string TipoSerie)
        {

                NotasCredito notasCredito = new NotasCredito();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;
            cmd.CommandText = "select MAX(Serie) as Serie, MAX(NUMERO) as Numero from NotaC_Join where serie = '" + SerieTienda + TipoSerie + "'";

            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (ObjDaConnexion.Con.State == ConnectionState.Closed)
                {
                    ObjDaConnexion.Open();

                }

                while (dr.Read())
                {
                        notasCredito.Serie = dr.GetString(0);
                        notasCredito.Numero = dr.GetInt32(1);
                }

                dr.Close();
            }               
                 
            
            catch (Exception ex)
            {

                dr.Close();
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return notasCredito;
        }
        public ListaNotasCredito ValidarDevolucion(DAConnectionSQL ObjDaConnexion,string SerieDoc, Int32 NumeroDoc ,string CodBar, int CantdadDev)
        {
            ListaNotasCredito ObjListaNotasCredito = new ListaNotasCredito();
            bool existe = false;
            //var ConClass = new DAConnectionSQL();
            string StrinSQL = "";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;
                        

            StrinSQL = "Select * ";
            StrinSQL = StrinSQL + " FROM NotaC_Join where Serie_Fact = '" + SerieDoc + "' and Numero_Fact = " + NumeroDoc + "  And ";
            StrinSQL = StrinSQL + "CodBarra = '" + CodBar + "' ";

            cmd.CommandText = StrinSQL;
            SqlDataReader dr = cmd.ExecuteReader();
            try
            {
                if (ObjDaConnexion.Con.State == ConnectionState.Closed)
                {
                    //ObjDaConnexion.Open();
                    cmd.Connection.Open();
                }

               
                while (dr.Read())
                {
                    NotasCredito ObjNotaCredito = new NotasCredito();
                    var withBlock = ObjNotaCredito;
                    if (dr[0] != DBNull.Value){ withBlock.FechaNC = DateTime.Parse(dr.GetDateTime(0).ToString());}
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
                    if (dr[17] != DBNull.Value) { withBlock.FechaNC = DateTime.Parse(dr.GetDateTime(0).ToString()); }
                    //withBlock.Fecha_Fact = DateTime.Parse(dr.GetDateTime(17).ToString());
                    withBlock.Serie_Fact = dr.GetString(18);
                    withBlock.Num_Fact = dr.GetInt32(19);

                    ObjListaNotasCredito.Add(ObjNotaCredito);
                }

                dr.Close();
            }
            catch (Exception ex)
            {

                dr.Close();
                System.Windows.Forms.MessageBox.Show("Error" + ex.Message);
            }


            return ObjListaNotasCredito; //CodigoArticuloBD;
        }
        public bool InsertarNotasCredito(DAConnectionSQL ObjDaConnexion, NotasCredito ObjNotasCredito, string TipoSerie)
        {
            bool ExisteNC = false;
            bool exitoso = false;
            string StrinSQL = "";



            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;
            
            ObjNotasCredito.CodArticulo = BuscarCodigoArticulo(cmd, ObjNotasCredito.Referencia);
            ObjNotasCredito.Numero = BuscarNumeroDoc(cmd, TipoSerie) + 1;


            //ExisteNC = ValidarDevolucion(cmd, ObjNotasCredito.Serie, ObjNotasCredito.Numero, ObjNotasCredito.CodBarra, ObjNotasCredito.UnidadesDevueltas);


            StrinSQL = "INSERT INTO NotaC_Join ";
            StrinSQL = StrinSQL + "(Fecha_Notac,Serie,Numero,Referencia,Descripcion,UnidadesVenta,UnidadesDevueltas, ";
            StrinSQL = StrinSQL + "RazonDevolucion,Precio,Talla,Color,CodBarra,Almacen,NumLinea,Dtco,CodArticulo, ";
            StrinSQL = StrinSQL + "Precio_Sin_Iva, Fecha_Fact, Serie_Fact , Numero_Fact) ";
            StrinSQL = StrinSQL + "VALUES ('" + DateTime.Now.Date.ToString("MM/dd/yyyy") + "','" + SerieTienda + TipoSerie + "'," + ObjNotasCredito.Numero + ",";
            StrinSQL = StrinSQL + "'" + ObjNotasCredito.Referencia + "','" + ObjNotasCredito.Descripcion + "',"; 
            StrinSQL = StrinSQL + ObjNotasCredito.Unidades + "," + ObjNotasCredito.UnidadesDevueltas + ",'" + ObjNotasCredito.RazonDevolucion + "',";
            StrinSQL = StrinSQL + ObjNotasCredito.Precio + ",'" + ObjNotasCredito.Talla + "','";
            StrinSQL = StrinSQL + ObjNotasCredito.CodColor + "','" + ObjNotasCredito.CodBarra + "','" + Bodega + "'," + ObjNotasCredito.NumLinea + ",'";
            StrinSQL = StrinSQL + ObjNotasCredito.Descuento + "'," + ObjNotasCredito.CodArticulo + "," + ObjNotasCredito.Precio_Sin_iva + ",'"; 
            StrinSQL = StrinSQL + ObjNotasCredito.Fecha_Fact.Date.ToString("MM/dd/yyyy") + "','" + ObjNotasCredito.Serie_Fact + "'," + ObjNotasCredito.Num_Fact + ")";

            cmd.CommandText = StrinSQL;                  

            try
            {
                if (ObjDaConnexion.Con.State == ConnectionState.Closed)
                {
                    ObjDaConnexion.Open();                  
                }
                
                cmd.ExecuteNonQuery();

                exitoso = true;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error al ejecutar el Qyery " + ex.Message,"Información",MessageBoxButtons.OK, MessageBoxIcon.Error);;
            }

            return exitoso;
        }
        public bool BuscarDocumetoAFirmar(DAConnectionSQL ObjDaConnexion)
        {

            bool exitoso = false;
            string StrinSQL = "";

            //var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;

            StrinSQL = "JOIN_NC_CAB";

            cmd.CommandText = StrinSQL;

            try
            {
                if (ObjDaConnexion.Con.State == ConnectionState.Closed)
                {
                    ObjDaConnexion.Open();
                }

                cmd.ExecuteNonQuery();
                
                exitoso = true;
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show("Error al ejecutar el Qyery " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

            return exitoso;
        }
        public bool EjecutarNotasCredito(DAConnectionSQL ObjDaConnexion)
        {
            
            bool exitoso = false;
            string StrinSQL = "";

            //var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ObjDaConnexion.Con;
                        
            StrinSQL = "JOIN_NC_CAB";
            
            cmd.CommandText = StrinSQL;

            try
            {
                if (ObjDaConnexion.Con.State == ConnectionState.Closed)
                {
                    ObjDaConnexion.Open();
                }
                cmd.ExecuteNonQuery();
                
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
