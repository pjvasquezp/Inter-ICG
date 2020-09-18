using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using ICG_Inter.Objetos;
using ICG_Inter.Datos;
using System.Net.Configuration;

namespace ICG_Inter
{
    public partial class Entradafiltros : Form
    {
        public DAConnectionSQL ObjDaConnexion = new DAConnectionSQL();
        public ProductoXCB ObjProductoxCB = new ProductoXCB();
        public Cliente ObjCliente = new Cliente();
        int CodCLiente = 0;
        public string Cod_Art = "";
        public string Des_Articulo = "";

        int TipoFecha = 30;

        //static string conexionstring = "server= DSNT-DEV-SRV\\MSSQLSERVER01; User= sa ; Password= B1Admin; database = AGORA;";
        //SqlConnection conexion = new SqlConnection(conexionstring);

        public ProcesosDB ObjProcDB = new ProcesosDB();


        public Entradafiltros()
        {
            InitializeComponent();
        }

        public Entradafiltros(DAConnectionSQL ObjDAConnecion)
        {
            ObjDaConnexion = ObjDAConnecion;
            InitializeComponent();
        }

        private void Btn_aceptar_Click(object sender, EventArgs e)
        {

            ListaDocVentas ObjListaDocVentas = ObjProcDB.GetDocVentas(ObjDaConnexion,ObjProductoxCB, CodCLiente, TipoFecha);

            if (cmb_fechainicio.Text == "Seleccione ---")
            {
                TipoFecha = 30;
            }

            FacturasVenta v1 = new FacturasVenta(ObjListaDocVentas, ObjDaConnexion);
            this.Hide();
            v1.ShowDialog();
            this.Show();
        }

        private void Txt_CodCliente_TextChanged(object sender, EventArgs e)
        {
            if (Txt_CodCliente.Text != "")
            {
                if (IsNumeric(Txt_CodCliente.Text))
                {
                    CodCLiente = int.Parse(Txt_CodCliente.Text);
                }
                else
                    MessageBox.Show("Valor incorrecto");
            }
            else CodCLiente = 0;

        }

        public bool IsNumeric(string value)
        {
            return value.All(char.IsNumber);
        }

        public void Txt_Codart_TextChanged(object sender, EventArgs e)
        {
            if (txt_Codart.Text != "")
            {
                Cod_Art = TxtCodArticulo.Text;
            }
            else Cod_Art = "";
        }

        private void txt_Codart_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
            {
                if (txt_Codart.Text == "")
                {
                    TxtDescripcion.Text = "";
                    TxtCodArticulo.Text = "";
                    txtReferencia.Text = "";
                    TxtColor.Text = "";
                    txtTalla.Text = "";
                }

                else
                {

                    ObjProductoxCB = ObjProcDB.GetProductoxCodigo(ObjDaConnexion, txt_Codart.Text);

                    if (ObjProductoxCB.CodigoArticulo != null)
                    {
                        TxtDescripcion.Text = ObjProductoxCB.NombreArticulo;
                        TxtCodArticulo.Text = ObjProductoxCB.CodigoArticulo;
                        Cod_Art = ObjProductoxCB.Referencia;
                        txtReferencia.Text = ObjProductoxCB.Referencia;


                        TxtColor.Text = ObjProductoxCB.Color.ToString();
                        txtTalla.Text = ObjProductoxCB.Talla.ToString();
                        txt_Codart.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("No Existe el Articulo");
                        txt_Codart.SelectAll();

                    }

                }

            }
        }

        private void Entradafiltros_Load(object sender, EventArgs e)
        {
            cmb_fechainicio.SelectedIndex = 0;
            txt_Codart.SelectAll();

        }

        private void cmb_fechainicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_fechainicio.Text == "Seleccione ---" || cmb_fechainicio.Text == "30 Días")
            {
                TipoFecha = 30;
            }

            else if (cmb_fechainicio.Text == "60 Días")
            {
                TipoFecha = 60;
            }

            else
            {
                TipoFecha = 90;
            }

        }


        private void Txt_CodCliente_KeyPress(object sender, KeyPressEventArgs e)
        {

          if (e.KeyChar == (Char)13)
            {
                if (Txt_CodCliente.Text == "")
                {
                    txtNomCliente.Text = "";
                    CodCLiente = 0;
                }

                else
                {
                    ObjCliente.CodCliente = Int32.Parse(Txt_CodCliente.Text);
                    ObjCliente = ObjProcDB.GetCliente(ObjDaConnexion,ObjCliente.CodCliente);

                    if (ObjCliente.NombreCliente != null)
                    {
                        txtNomCliente.Text = ObjCliente.NombreCliente;
                        txtCif.Text = ObjCliente.CIFCliente;
                        txtTlf1.Text = ObjCliente.Telefono1;
                        txtTlf2.Text = ObjCliente.Telefono2;
                        txtDirec.Text = ObjCliente.Direccion;
                        CodCLiente = ObjCliente.CodCliente;

                        txt_Codart.SelectAll();
                    }
                    else
                    {
                        MessageBox.Show("No Existe el Cliente " + CodCLiente, "Nofificación",MessageBoxButtons.OK,MessageBoxIcon.Warning );
                        txt_Codart.SelectAll();

                    }

                }

            }

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            cmb_fechainicio.SelectedItem = 0;
            Txt_CodCliente.Text = "";
            txtNomCliente.Text = "";
            txtCif.Text = "";
            txtTlf1.Text = "";
            txtTlf2.Text = "";
            TxtDescripcion.Text = "";
            txtDirec.Text = "";
            txt_Codart.Text = "";
            txtTalla.Text = "";
            TxtColor.Text = "";
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            FrmRecibos oFRMRecibos = new FrmRecibos (ObjDaConnexion);
            this.Hide();
            oFRMRecibos.ShowDialog();
            this.Show();
        }
    }
}