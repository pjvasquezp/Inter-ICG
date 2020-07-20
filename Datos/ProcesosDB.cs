
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

        public ListaDocDetalle BuscarDocVentas(string Serie, int NumDoc)
        {
            ListaDocDetalle ObjListaDocDetalle = new ListaDocDetalle();

            var ConClass = new DAConnectionSQL();


            SqlCommand cmd = new SqlCommand();
            cmd.CommandType =  CommandType.Text;
            cmd.Connection = ConClass.Con;
            cmd.CommandText = "exec [SP_Get_DocumentosVentas] '" + Serie + "'," + NumDoc;


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

    }
}
