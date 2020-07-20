using System;
using System.Collections.Generic;
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
        public int Unidades { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Descuento { get; set; }
        public Decimal Total { get; set; }
        public string Almacen { get; set; }
    }

    

    public class ListaDocDetalle : List<Documento_Detalle>
    {

    }


}
