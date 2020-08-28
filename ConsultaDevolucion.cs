using ICG_Inter.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICG_Inter
{
    public partial class ConsultaDevolucion : Form
    {
        public ListaNotasCredito ObjListaNotasCredito = new ListaNotasCredito();
        public ConsultaDevolucion()
        {
            InitializeComponent();
        }

        public ConsultaDevolucion(ListaNotasCredito ObjListaNCR)
        {
            ObjListaNotasCredito = ObjListaNCR;
            InitializeComponent();
        }

        private void ConsultaDevolucion_Load(object sender, EventArgs e)
        {
            DGV_NotasCredito.DataSource = ObjListaNotasCredito;
        }
    }
}
