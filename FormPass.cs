using ICG_Inter.Datos;
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
    public partial class FormPass : Form
    {
        public DAConnectionSQL ObjDaConnexion; //= new DAConnectionSQL();
        public ProcesosDB ObjProcDB = new ProcesosDB();
        public bool PasswordValido = false; 
        public FormPass()
        {
            InitializeComponent();
        }

        public FormPass(DAConnectionSQL ObjDAConnecion)
        {            
            ObjDaConnexion = ObjDAConnecion;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                MessageBox.Show("Ingrese Password ", "Nofificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                PasswordValido = false;
            }

            else
            {
                PasswordValido = ObjProcDB.GetPasswordSupervisor(ObjDaConnexion, txtPassword.Text);

                if (!PasswordValido)
                {
                    MessageBox.Show("Password Invalido ", "Nofificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPassword.SelectAll();
                }
                else
                {
                    this.Close();
                }
                
            }

        }


        private void button2_Click(object sender, EventArgs e)
        {
            // txtPassword.Text = txtPassword.Text + "2";
            this.Close();
        }

        
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            if (e.KeyChar == (Char)13)
            {
                if (txtPassword.Text == "")
                {
                    PasswordValido = false;
                    MessageBox.Show("Ingrese Password ", "Nofificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                else
                {
                    PasswordValido = ObjProcDB.GetPasswordSupervisor(ObjDaConnexion, txtPassword.Text);

                    if (!PasswordValido)
                    {
                        MessageBox.Show("Password Invalido ", "Nofificación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtPassword.SelectAll();
                    }

                    else
                    {
                        this.Close();
                    }

                }

                
            }

        }

        private void FormPass_Load(object sender, EventArgs e)
        {

        }

    }
}
