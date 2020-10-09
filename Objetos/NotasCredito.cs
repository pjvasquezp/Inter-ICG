using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICG_Inter.Objetos
{
    public class NotasCredito
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public DateTime FechaNC { get; set; }
        public string Referencia { get; set; }
        public string Descripcion { get; set; }
        public int Unidades { get; set; }
        public int UnidadesDevueltas { get; set; }
        public string RazonDevolucion { get; set; }
        public Decimal Precio { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public string Almacen { get; set; }
        public int NumLinea { get; set; }
        public Decimal Descuento { get; set; }
        public int CodArticulo { get; set; }
        public string Serie_Fact { get; set; }
        public int Num_Fact { get; set; }
        public DateTime Fecha_Fact { get; set; }
        public Decimal Precio_Sin_iva { get; set; }
        public Decimal Total { get; set; }
        public string CodBarra { get; set; }
        public String CodColor { get; set; }
        public int Linea_Fact { get; set; }

    }

    public class ListaNotasCredito : List<NotasCredito>
    {

    }
}
