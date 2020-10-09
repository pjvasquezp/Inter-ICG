using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICG_Inter.Objetos
{
    public class ProductoDev
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public string Referencia { get; set; }
        public DateTime Fecha_Factura { get; set; }
        public string Descripcion { get; set; }
        public int UnidadesVenta { get; set; }
        public int UnidadesDevueltas { get; set; }
        public string RazonDevolucion { get; set; }
        public Decimal Precio { get; set; }
        public string Almacen { get; set; }
        public string Talla { get; set; }
        public string Color { get; set; }
        public string Retornable { get; set; }
        public bool Procesado { get; set; }
        public string CodBarra { get; set; }
        public string CodColor { get; set; }
        public byte[] FotoArticulo { get; set; }
        public int CodArticulo { get; set; }
        public int NumLinea { get; set; }
        public int Linea_Fact { get; set; }

    }

    public class ListaProductoDev : List<ProductoDev>
    {
    
    }

}
