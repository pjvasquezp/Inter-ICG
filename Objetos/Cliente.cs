using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ICG_Inter.Objetos
{
    public class Cliente
    {
        public int CodCliente { get; set; }
        public string NombreCliente { get; set; }
        public string CIFCliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
    }
}
