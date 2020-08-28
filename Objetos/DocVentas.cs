using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICG_Inter.Objetos
{
    public class DocVentas
    {
        public string Serie { get; set; }
        public int Numero { get; set; }
        public double TotalDocumento { get; set; }

        public String FechaDoc { get; set; }
        public int DiasFac { get; set; }
    }

    public class ListaDocVentas : List<DocVentas>
    { 
    
    }

    


}
