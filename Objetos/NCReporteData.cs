using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICG_Inter.Objetos
{
    public class NCReporteData
    {
        public string NumSerie { get; set; }
        public int NumFactura { get; set; }
        public string SerieFel { get; set; }
        public int DocumentoFel { get; set; }
        public string FechaHoraCertificacion { get; set; }
        public string UUID { get; set; }
        public string CodBarra { get; set; }
        public int UnidadesDevueltas { get; set; }
        public decimal Precio { get; set; }
        public decimal TotalLinea { get; set; }
        public string Descripcion { get; set; }
        public string CODCLIENTE { get; set; }
        public string NIT { get; set; }
        public string NOMBRECLIENTE { get; set; }
        public string DIRECCION1 { get; set; }
        public int Num_Fact { get; set; }
        public string Serie_Fact { get; set; }

    }

    public class ListaNCReporteData : List<NCReporteData>
    { 
    
    }
        
}
