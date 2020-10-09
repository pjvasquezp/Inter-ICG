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
    public partial class LoginFrm : Form
    {
        public DAConnectionSQL ObjDaConnexion = new DAConnectionSQL();
      
        public UserSistemas  oUserSistemas = new UserSistemas();
        int CodCLiente = 0;
        public string Cod_Art = "";
        public string Des_Articulo = "";
        bool UserLogued = false;

        public ProcesosDB ObjProcDB = new ProcesosDB();
        public LoginFrm(DAConnectionSQL ObjDAConnecion)
        {
            ObjDaConnexion = ObjDAConnecion;
            InitializeComponent();
        }

        public LoginFrm()
        {
            InitializeComponent();
        }

        private UserSistemas BuscarUsuario()
        {
            UserSistemas OUserSistemas = ObjProcDB.GetUserSistema(ObjDaConnexion, oUserSistemas);

            return OUserSistemas;
        }
        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (txtUser.Text != null && txtPassword.Text != null)
            {
                oUserSistemas.PASSWORDWEB = txtPassword.Text;
                oUserSistemas.NOMVENDEDOR = txtUser.Text;

                UserSistemas OUserLogueado = BuscarUsuario();
                if (OUserLogueado.NOMVENDEDOR != null && OUserLogueado.PASSWORDWEB != null)
                {
                    oUserSistemas.PASSWORDWEB = txtPassword.Text;
                    UserLogued = true;
                    Entradafiltros FormFiltros = new Entradafiltros(ObjDaConnexion, OUserLogueado);
                    this.Hide();
                    FormFiltros.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Error en la Validación del Usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Ingrese Datos Validos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.SelectAll();
            }

                               
        }            

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUser.Text))
            {
                MessageBox.Show("Debe ingresar un Nombre de Usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUser.Select();
            }
            else
            {
                oUserSistemas.NOMVENDEDOR = txtUser.Text;
            }
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Debe ingresar un Nombre de Usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Select();
            }
            else
            {
                oUserSistemas.NOMVENDEDOR = txtUser.Text;
            }
        }

        private void txtUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
            {
                if (txtUser.Text == "")
                {
                    MessageBox.Show("Debe ingresar un Nombre de Usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.Select();
                }               

            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)13)
            {
                if (txtPassword.Text == "")
                {
                    txtUser.Text = "";
                }

                else
                {
                    oUserSistemas.PASSWORDWEB = txtPassword.Text;
                    UserSistemas OUserLogueado = BuscarUsuario();
                    if (OUserLogueado.NOMVENDEDOR != null && OUserLogueado.PASSWORDWEB != null)
                    {
                        UserLogued = true;
                        Entradafiltros FormFiltros = new Entradafiltros(ObjDaConnexion, OUserLogueado);
                        this.Hide();
                        FormFiltros.ShowDialog();
                        this.Show();
                    }
                    else
                    {
                        MessageBox.Show("Error en la Validación del Usuario", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.SelectAll();
                    }

                }

            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
