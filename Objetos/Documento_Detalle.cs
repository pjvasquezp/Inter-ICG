using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICG_Inter
{
    public class Documento_Detalle
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public int Unidades { get; set; }
        public int Devoluciones { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Descuento { get; set; }
        public Decimal Total { get; set; }
        public string Almacen { get; set; }
        public String Retornable { get; set; }
        public string CodColor { get; set; }
        public string CodBarra { get; set; }
        public byte[] FotoArticulo { get; set; }
        public int CodigoArticulo { get; set; }
        public int NumLinea { get; set; }
    }

    

    public class ListaDocDetalle : List<Documento_Detalle>
    {

    }


}
