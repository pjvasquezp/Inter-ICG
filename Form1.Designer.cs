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
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Codiente = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmb_fechainicio = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Codart = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
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
            this.label4.Location = new System.Drawing.Point(15, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Fecha Inicio:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(140, 91);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 20);
            this.textBox4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Fecha Fin:";
            // 
            // txt_Codiente
            // 
            this.txt_Codiente.Location = new System.Drawing.Point(140, 117);
            this.txt_Codiente.Name = "txt_Codiente";
            this.txt_Codiente.Size = new System.Drawing.Size(100, 20);
            this.txt_Codiente.TabIndex = 10;
            this.txt_Codiente.TextChanged += new System.EventHandler(this.Txt_Codiente_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 120);
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
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button11.Location = new System.Drawing.Point(307, 14);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(81, 27);
            this.button11.TabIndex = 42;
            this.button11.Text = "Campos libres";
            this.button11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button11.UseVisualStyleBackColor = false;
            // 
            // button13
            // 
            this.button13.Image = global::ICG_Inter.Properties.Resources.b_calendar;
            this.button13.Location = new System.Drawing.Point(246, 91);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(29, 23);
            this.button13.TabIndex = 44;
            this.button13.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button13.UseVisualStyleBackColor = true;
            // 
            // button12
            // 
            this.button12.Image = global::ICG_Inter.Properties.Resources.b_calendar;
            this.button12.Location = new System.Drawing.Point(246, 62);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(29, 23);
            this.button12.TabIndex = 43;
            this.button12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button12.UseVisualStyleBackColor = true;
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
            // button4
            // 
            this.button4.Image = global::ICG_Inter.Properties.Resources.b_search;
            this.button4.Location = new System.Drawing.Point(246, 117);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(41, 23);
            this.button4.TabIndex = 29;
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btn_aceptar);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.button10);
            this.panel1.Controls.Add(this.button11);
            this.panel1.Location = new System.Drawing.Point(-1, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(528, 54);
            this.panel1.TabIndex = 45;
            // 
            // cmb_fechainicio
            // 
            this.cmb_fechainicio.FormattingEnabled = true;
            this.cmb_fechainicio.Items.AddRange(new object[] {
            "30 Días",
            "90 Días",
            "60 Días"});
            this.cmb_fechainicio.Location = new System.Drawing.Point(140, 64);
            this.cmb_fechainicio.Name = "cmb_fechainicio";
            this.cmb_fechainicio.Size = new System.Drawing.Size(100, 21);
            this.cmb_fechainicio.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 47;
            this.label2.Text = "Cod. Articulo:";
            // 
            // txt_Codart
            // 
            this.txt_Codart.Location = new System.Drawing.Point(140, 145);
            this.txt_Codart.Name = "txt_Codart";
            this.txt_Codart.Size = new System.Drawing.Size(100, 20);
            this.txt_Codart.TabIndex = 48;
            this.txt_Codart.TextChanged += new System.EventHandler(this.Txt_Codart_TextChanged);
            // 
            // button1
            // 
            this.button1.Image = global::ICG_Inter.Properties.Resources.b_search;
            this.button1.Location = new System.Drawing.Point(246, 145);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(41, 23);
            this.button1.TabIndex = 49;
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Entradafiltros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 354);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_Codart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_fechainicio);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button13);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.txt_Codiente);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Entradafiltros";
            this.Text = "Entrada de filtros";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_Codiente;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cmb_fechainicio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Codart;
        private System.Windows.Forms.Button button1;
    }
}

