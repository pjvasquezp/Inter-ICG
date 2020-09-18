namespace ICG_Inter
{
    partial class Entradafiltros
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_CodCliente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.BtnReportes = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_fechainicio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Codart = new System.Windows.Forms.TextBox();
            this.LBLRefer = new System.Windows.Forms.Label();
            this.lblTalla = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.txtTalla = new System.Windows.Forms.TextBox();
            this.TxtColor = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCodArticulo = new System.Windows.Forms.TextBox();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.LblCodArticulo = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtTlf2 = new System.Windows.Forms.TextBox();
            this.txtTlf1 = new System.Windows.Forms.TextBox();
            this.lblTelef = new System.Windows.Forms.Label();
            this.txtDirec = new System.Windows.Forms.TextBox();
            this.lblDirec = new System.Windows.Forms.Label();
            this.txtCif = new System.Windows.Forms.TextBox();
            this.lblCif = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNomCliente = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Dias de Factura:";
            // 
            // Txt_CodCliente
            // 
            this.Txt_CodCliente.Location = new System.Drawing.Point(113, 52);
            this.Txt_CodCliente.Name = "Txt_CodCliente";
            this.Txt_CodCliente.Size = new System.Drawing.Size(100, 20);
            this.Txt_CodCliente.TabIndex = 10;
            this.Txt_CodCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txt_CodCliente_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Cod. Cliente:";
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(207, 14);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(72, 27);
            this.button10.TabIndex = 41;
            this.button10.Text = "Quitar filtros";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // BtnReportes
            // 
            this.BtnReportes.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BtnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnReportes.Location = new System.Drawing.Point(285, 14);
            this.BtnReportes.Name = "BtnReportes";
            this.BtnReportes.Size = new System.Drawing.Size(103, 27);
            this.BtnReportes.TabIndex = 42;
            this.BtnReportes.Text = "Consultar Recibos";
            this.BtnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnReportes.UseVisualStyleBackColor = false;
            this.BtnReportes.Click += new System.EventHandler(this.BtnReportes_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_aceptar);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.BtnReportes);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 54);
            this.panel1.TabIndex = 45;
            // 
            // cmb_fechainicio
            // 
            this.cmb_fechainicio.FormattingEnabled = true;
            this.cmb_fechainicio.Items.AddRange(new object[] {
            "Seleccione ---",
            "30 Días",
            "60 Días",
            "90 Días"});
            this.cmb_fechainicio.Location = new System.Drawing.Point(113, 26);
            this.cmb_fechainicio.Name = "cmb_fechainicio";
            this.cmb_fechainicio.Size = new System.Drawing.Size(143, 21);
            this.cmb_fechainicio.TabIndex = 46;
            this.cmb_fechainicio.SelectedIndexChanged += new System.EventHandler(this.cmb_fechainicio_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Cod. Articulo:";
            // 
            // txt_Codart
            // 
            this.txt_Codart.Location = new System.Drawing.Point(97, 19);
            this.txt_Codart.Name = "txt_Codart";
            this.txt_Codart.Size = new System.Drawing.Size(211, 20);
            this.txt_Codart.TabIndex = 48;
            this.txt_Codart.TextChanged += new System.EventHandler(this.Txt_Codart_TextChanged);
            this.txt_Codart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Codart_KeyPress);
            // 
            // LBLRefer
            // 
            this.LBLRefer.AutoSize = true;
            this.LBLRefer.Location = new System.Drawing.Point(196, 56);
            this.LBLRefer.Name = "LBLRefer";
            this.LBLRefer.Size = new System.Drawing.Size(62, 13);
            this.LBLRefer.TabIndex = 50;
            this.LBLRefer.Text = "Referencia:";
            // 
            // lblTalla
            // 
            this.lblTalla.AutoSize = true;
            this.lblTalla.Location = new System.Drawing.Point(8, 114);
            this.lblTalla.Name = "lblTalla";
            this.lblTalla.Size = new System.Drawing.Size(33, 13);
            this.lblTalla.TabIndex = 51;
            this.lblTalla.Text = "Talla:";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(202, 112);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(34, 13);
            this.lblColor.TabIndex = 52;
            this.lblColor.Text = "Color:";
            // 
            // txtTalla
            // 
            this.txtTalla.Location = new System.Drawing.Point(96, 109);
            this.txtTalla.Name = "txtTalla";
            this.txtTalla.Size = new System.Drawing.Size(100, 20);
            this.txtTalla.TabIndex = 53;
            // 
            // TxtColor
            // 
            this.TxtColor.Location = new System.Drawing.Point(261, 109);
            this.TxtColor.Name = "TxtColor";
            this.TxtColor.Size = new System.Drawing.Size(95, 20);
            this.TxtColor.TabIndex = 54;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtCodArticulo);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtReferencia);
            this.groupBox1.Controls.Add(this.TxtDescripcion);
            this.groupBox1.Controls.Add(this.LblCodArticulo);
            this.groupBox1.Controls.Add(this.txt_Codart);
            this.groupBox1.Controls.Add(this.txtTalla);
            this.groupBox1.Controls.Add(this.LBLRefer);
            this.groupBox1.Controls.Add(this.TxtColor);
            this.groupBox1.Controls.Add(this.lblTalla);
            this.groupBox1.Controls.Add(this.lblColor);
            this.groupBox1.Location = new System.Drawing.Point(15, 305);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 162);
            this.groupBox1.TabIndex = 55;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos del Artículo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 59;
            this.label3.Text = "Descripción:";
            // 
            // TxtCodArticulo
            // 
            this.TxtCodArticulo.Location = new System.Drawing.Point(96, 53);
            this.TxtCodArticulo.Name = "TxtCodArticulo";
            this.TxtCodArticulo.Size = new System.Drawing.Size(96, 20);
            this.TxtCodArticulo.TabIndex = 58;
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(261, 53);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(95, 20);
            this.txtReferencia.TabIndex = 57;
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Location = new System.Drawing.Point(95, 82);
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(262, 20);
            this.TxtDescripcion.TabIndex = 56;
            // 
            // LblCodArticulo
            // 
            this.LblCodArticulo.AutoSize = true;
            this.LblCodArticulo.Location = new System.Drawing.Point(8, 56);
            this.LblCodArticulo.Name = "LblCodArticulo";
            this.LblCodArticulo.Size = new System.Drawing.Size(72, 13);
            this.LblCodArticulo.TabIndex = 55;
            this.LblCodArticulo.Text = "Cod. Artículo:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTlf2);
            this.groupBox2.Controls.Add(this.txtTlf1);
            this.groupBox2.Controls.Add(this.lblTelef);
            this.groupBox2.Controls.Add(this.txtDirec);
            this.groupBox2.Controls.Add(this.lblDirec);
            this.groupBox2.Controls.Add(this.txtCif);
            this.groupBox2.Controls.Add(this.lblCif);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNomCliente);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.Txt_CodCliente);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmb_fechainicio);
            this.groupBox2.Location = new System.Drawing.Point(15, 65);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 234);
            this.groupBox2.TabIndex = 56;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parametros de Busqueda";
            // 
            // txtTlf2
            // 
            this.txtTlf2.Location = new System.Drawing.Point(245, 140);
            this.txtTlf2.Name = "txtTlf2";
            this.txtTlf2.Size = new System.Drawing.Size(109, 20);
            this.txtTlf2.TabIndex = 55;
            // 
            // txtTlf1
            // 
            this.txtTlf1.Location = new System.Drawing.Point(112, 140);
            this.txtTlf1.Name = "txtTlf1";
            this.txtTlf1.Size = new System.Drawing.Size(100, 20);
            this.txtTlf1.TabIndex = 54;
            // 
            // lblTelef
            // 
            this.lblTelef.AutoSize = true;
            this.lblTelef.Location = new System.Drawing.Point(23, 140);
            this.lblTelef.Name = "lblTelef";
            this.lblTelef.Size = new System.Drawing.Size(57, 13);
            this.lblTelef.TabIndex = 53;
            this.lblTelef.Text = "Telefonos:";
            // 
            // txtDirec
            // 
            this.txtDirec.Location = new System.Drawing.Point(113, 169);
            this.txtDirec.Multiline = true;
            this.txtDirec.Name = "txtDirec";
            this.txtDirec.Size = new System.Drawing.Size(242, 49);
            this.txtDirec.TabIndex = 52;
            // 
            // lblDirec
            // 
            this.lblDirec.AutoSize = true;
            this.lblDirec.Location = new System.Drawing.Point(24, 172);
            this.lblDirec.Name = "lblDirec";
            this.lblDirec.Size = new System.Drawing.Size(55, 13);
            this.lblDirec.TabIndex = 51;
            this.lblDirec.Text = "Dirección:";
            // 
            // txtCif
            // 
            this.txtCif.Location = new System.Drawing.Point(113, 110);
            this.txtCif.Name = "txtCif";
            this.txtCif.Size = new System.Drawing.Size(100, 20);
            this.txtCif.TabIndex = 50;
            // 
            // lblCif
            // 
            this.lblCif.AutoSize = true;
            this.lblCif.Location = new System.Drawing.Point(24, 110);
            this.lblCif.Name = "lblCif";
            this.lblCif.Size = new System.Drawing.Size(26, 13);
            this.lblCif.TabIndex = 49;
            this.lblCif.Text = "CIF:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 48;
            this.label5.Text = "Nombre Cliente:";
            // 
            // txtNomCliente
            // 
            this.txtNomCliente.Location = new System.Drawing.Point(113, 79);
            this.txtNomCliente.Name = "txtNomCliente";
            this.txtNomCliente.Size = new System.Drawing.Size(242, 20);
            this.txtNomCliente.TabIndex = 47;
            // 
            // button4
            // 
            this.button4.Image = global::ICG_Inter.Properties.Resources.b_search;
            this.button4.Location = new System.Drawing.Point(216, 52);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 23);
            this.button4.TabIndex = 29;
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Image = global::ICG_Inter.Properties.Resources.b_search;
            this.button1.Location = new System.Drawing.Point(314, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 49;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_aceptar.Image = global::ICG_Inter.Properties.Resources.s_success;
            this.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(13, 14);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(65, 27);
            this.btn_aceptar.TabIndex = 39;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aceptar.UseVisualStyleBackColor = false;
            this.btn_aceptar.Click += new System.EventHandler(this.Btn_aceptar_Click);
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button9.Image = global::ICG_Inter.Properties.Resources.s_cancel;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(106, 14);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(73, 27);
            this.button9.TabIndex = 40;
            this.button9.Text = "Cancelar";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Entradafiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 479);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Entradafiltros";
            this.Text = "Entrada de filtros";
            this.Load += new System.EventHandler(this.Entradafiltros_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_CodCliente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button BtnReportes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_fechainicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Codart;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label LBLRefer;
        private System.Windows.Forms.Label lblTalla;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TextBox txtTalla;
        private System.Windows.Forms.TextBox TxtColor;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.Label LblCodArticulo;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCodArticulo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNomCliente;
        private System.Windows.Forms.TextBox txtTlf2;
        private System.Windows.Forms.TextBox txtTlf1;
        private System.Windows.Forms.Label lblTelef;
        private System.Windows.Forms.TextBox txtDirec;
        private System.Windows.Forms.Label lblDirec;
        private System.Windows.Forms.TextBox txtCif;
        private System.Windows.Forms.Label lblCif;
    }
}

