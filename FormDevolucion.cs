using ICG_Inter.Datos;
using ICG_Inter.Objetos;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICG_Inter
{
    public partial class FormDevolucion : Form
    {
        public DAConnectionSQL ObjDaConnexion; 
        public ProcesosDB objProcesosDB = new ProcesosDB();
        public ProductoDev ObjProducto = new ProductoDev();
        public int Unidadesventas = 0;
        public int UnidadesDev = 0;
        public int UnidTotalDev;
        public UserSistemas oUserSistemasLog = new UserSistemas();
        public FormDevolucion()
        {
            InitializeComponent();
        }
        public FormDevolucion(ref ProductoDev ObjProductoDev, DAConnectionSQL ObjDAConnecion, UserSistemas oUserSistemas)
        {
            ObjDaConnexion = ObjDAConnecion;
            oUserSistemasLog = oUserSistemas;
            InitializeComponent();

            this.Text = this.Text + " USER .: " + oUserSistemasLog.NOMVENDEDOR + " :.";

            ObjProducto = ObjProductoDev;
            CargaInfo(ref ObjProductoDev);
            
        }

        private void FormDevolucion_Load(object sender, EventArgs e)
        { 
           
            
        }

        private void CargaInfo(ref ProductoDev ObjProductoDev)
        {
            Unidadesventas = ObjProductoDev.UnidadesVenta;
            txt_serie.Text = ObjProductoDev.Serie;
            txt_numero.Text = ObjProductoDev.Numero.ToString();
            txt_codiart.Text = ObjProductoDev.Referencia;
            txt_des.Text = ObjProductoDev.Descripcion;
            txt_talla.Text = ObjProductoDev.Talla;
            txt_color.Text = ObjProductoDev.Color;
            txt_dades.Text = ObjProductoDev.UnidadesVenta.ToString();
            txt_precio.Text = ObjProductoDev.Precio.ToString();
            txt_alma.Text = ObjProductoDev.Almacen;
            CBMotivodDev.DataSource = objProcesosDB.GetMotivosDev(ObjDaConnexion);
            CBMotivodDev.DisplayMember = "DESCRIPCION";
            CBMotivodDev.ValueMember = "IDMOTIVO";

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (IsNumeric(textBox7.Text) && textBox7.Text != "")
            {
                UnidadesDev = int.Parse(textBox7.Text);
                if (UnidadesDev > Unidadesventas)
                {
                    MessageBox.Show("Valor Devuelto no puede ser mayor a la unidades vendidas",
                            "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    ObjProducto.UnidadesDevueltas = UnidadesDev;
                }
                
            }

            else
            {
                MessageBox.Show("Valor no permitidoo", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //return ObjProducto;
            if (UnidadesDev == 0)
            {
                MessageBox.Show("Debe selecionar la cantidad a devoolver","Notificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            else
            {
                if (UnidadesDev > Unidadesventas)
                {
                    MessageBox.Show("Debe selecionar una cantidad menor a devolver","Notificación", MessageBoxButtons.OK , MessageBoxIcon.Error);
                }

                else
                {
                    ObjProducto.UnidadesDevueltas = UnidadesDev;
                    ObjProducto.RazonDevolucion = CBMotivodDev.Text;
                    ObjProducto.Procesado = true;

                    this.Dispose();
                }
            }

        }



        private void CBMotivodDev_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ObjProducto.RazonDevolucion = CBMotivodDev.SelectedText.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ObjProducto = null;
            //ObjProducto.
            this.Close();
        }

        private void FormDevolucion_Leave(object sender, EventArgs e)
        {
            ObjProducto = null;
        }
    }

}
