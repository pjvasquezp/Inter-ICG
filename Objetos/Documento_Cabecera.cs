using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ICG_Inter
{
    public class Documento_Cabecera
    {
        public string Tipo_Documento { get; set; }
        public int Numero { get; set; }
        public DateTime Fecha_Inicio { get; set; }
        public string Serie { get; set; }
        public DateTime Fecha { get; set; }
        public string Hora { get; set; }
        public string Transporte { get; set; }
        public int Codigo_Cliente { get; set; }
        public string Cliente { get; set; }
        public string Direccion { get; set; }
        public string Poblacion { get; set; }
        public string Vendedor { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total_BrutoImponible { get; set; }
        public decimal Descuentos { get; set; }
        public decimal Total_Neto { get; set; }





    }
}
