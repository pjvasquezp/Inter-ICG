
using ICG_Inter.Objetos;
using System;
using System.Data;
using System.Data.SqlClient;

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
                    withBlock.SerieDocumento = dr.GetString(0);
                    withBlock.NumDocumento = dr.GetInt32(1);


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
                        withBlock.Serie = dr.GetString(14);
                        withBlock.Numero = dr.GetInt32(15);
                        withBlock.Referencia = dr.GetString(21);
                        withBlock.Descripcion = dr.GetString(22);
                        withBlock.Unidades = Int16.Parse(dr.GetDouble(25).ToString());
                        withBlock.Precio = decimal.Parse(dr.GetString(26).ToString());
                        withBlock.Descuento = int.Parse(dr.GetDouble(28).ToString());
                        withBlock.Total = Decimal.Parse(dr.GetDouble(29).ToString());
                        withBlock.Almacen = dr.GetString(34);

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
                    withBlock.Serie = dr.GetString(14);
                    withBlock.Numero = dr.GetInt32(15);
                   // withBlock.Tipo_Documento = dr.GetString(14);
                    withBlock.Cliente = dr.GetString(15);
                    withBlock.Direccion = dr.GetString(15);
                    withBlock.Fecha = DateTime.Parse(dr.GetDateTime(8).ToString());
                    //withBlock.Fecha_Inicio = DateTime(dr.GetDateTime().ToString());
                    withBlock.Hora = dr.GetString(9);
                    withBlock.Impuesto = decimal.Parse(dr.GetDecimal(31).ToString());
                    withBlock.Poblacion = dr.GetString(39);
                    withBlock.Transporte = dr.GetString(39);
                    withBlock.Vendedor = dr.GetString(39);                 
                }
                dr.Close();
            }
            catch (Exception ex)
            {
            }

            return ObjDocumentoCabecera ;
        }

    }
}
