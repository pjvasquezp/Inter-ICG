using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICG_Inter.Objetos
{
    public class MotivosDevolucion
    {
        public int IdMotivo { get; set; }
        public string Descripcion { get; set; }
    }

    public class ListaMotivosDev : List<MotivosDevolucion>
    {

    }
}
