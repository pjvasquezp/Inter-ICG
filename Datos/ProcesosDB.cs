
using ICG_Inter.Objetos;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;

namespace ICG_Inter.Datos
{
    public class ProcesosDB
    {       

        public void DACliente()
        {
            DAConnectionSQL DASQLConnection = new DAConnectionSQL();
        }

        public ListaDocVentas GetDocVentas()
        {
            ListaDocVentas ObjListaDocVentas = new ListaDocVentas();

            var ConClass = new DAConnectionSQL();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = ConClass.Con;
            cmd.CommandText = "exec [SP_GET_DocumentoData]"; //+ Serie + "'," + NumDoc;

            ConClass.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            try
            {

                while (dr.Read())
                {
                    DocVentas ObjDocVentas = new DocVentas();

                    var withBlock = ObjDocVentas;
                    withBlock.Serie = dr.GetString(0);
                    withBlock.Numero = dr.GetInt32(1);
                    withBlock.TotalDocumento = dr.GetDouble(2);
                    withBlock.FechaDoc = dr.GetString(3).ToString();

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
                    withBlock.Direccion = dr.GetString(43);
                    withBlock.Fecha = DateTime.Parse(dr.GetDateTime(4).ToString());
                    //withBlock.Fecha_Inicio = DateTime(dr.GetDateTime().ToString());
                    withBlock.Hora = dr.GetString(5);
                    withBlock.Impuesto = decimal.Parse(dr.GetDouble(27).ToString());
                    withBlock.Poblacion = dr.GetString(36);
                    //withBlock.Transporte = dr.GetString(39);
                    withBlock.Vendedor = dr.GetString(38);      
                    withBlock.Total_BrutoImponible = decimal.Parse(dr.GetDouble(26).ToString());
                    withBlock.Impuesto = decimal.Parse(dr.GetDouble(27).ToString());
                    withBlock.Total_Neto = decimal.Parse(dr.GetDouble(28).ToString());
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

    }
}
