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
        int ProductosDev;
        int CantDevolucion;
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
            int sum = 0;
            for (int i = 0; i < DGV_NotasCredito.Rows.Count; ++i)
            {
                //sum += Convert.ToInt32(DGV_NotasCredito.Rows[i].Cells[1].Value);
            }
            
            if (CantDevolucion > sum)
            {
                MessageBox.Show("Test");
            }  

        }

        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
