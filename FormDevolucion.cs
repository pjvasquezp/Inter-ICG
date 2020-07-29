using ICG_Inter.Datos;
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
    public partial class FormDevolucion : Form
    {
        public ProcesosDB objProcesosDB = new ProcesosDB();
        public ProductoDev ObjProducto = new ProductoDev();
        public FormDevolucion()
        {
            InitializeComponent();
        }
        public FormDevolucion(ProductoDev ObjProductoDev)
        {
            ObjProducto = ObjProductoDev;
            InitializeComponent();
        }

        private void FormDevolucion_Load(object sender, EventArgs e)
        {
            txt_serie.Text = ObjProducto.Serie;
            txt_numero.Text = ObjProducto.Numero.ToString();
            txt_codiart.Text = ObjProducto.Referencia;
            txt_des.Text = ObjProducto.Descripcion;
            txt_talla.Text = ObjProducto.Talla;
            txt_color.Text = ObjProducto.Color;
            txt_dades.Text = ObjProducto.UnidadesVenta.ToString();
            txt_precio.Text = ObjProducto.Precio.ToString();
            txt_alma.Text = ObjProducto.Almacen;
            CBMotivodDev.DataSource = objProcesosDB.GetMotivosDev();
            CBMotivodDev.DisplayMember = "DESCRIPCION";
            CBMotivodDev.ValueMember = "IDMOTIVO";


        }
    }
}
