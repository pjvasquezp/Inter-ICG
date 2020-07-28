namespace ICG_Inter
{
    partial class FacturasVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dgv_q = new System.Windows.Forms.DataGridView();
            this.dgv_Doc = new System.Windows.Forms.DataGridView();
            this.serieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tallaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DSDetalleDoc = new System.Windows.Forms.BindingSource(this.components);
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.txt_poblacion2 = new System.Windows.Forms.TextBox();
            this.txt_vendedor2 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_direccion = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_cliente2 = new System.Windows.Forms.TextBox();
            this.txtcliente = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_hora = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_fecha = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_num = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_serie = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.Dgv_ProductosDev = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BSDocVentas = new System.Windows.Forms.BindingSource(this.components);
            this.serieDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDocumentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_q)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Doc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDetalleDoc)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ProductosDev)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSDocVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_q
            // 
            this.dgv_q.AutoGenerateColumns = false;
            this.dgv_q.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_q.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serieDataGridViewTextBoxColumn1,
            this.numeroDataGridViewTextBoxColumn1,
            this.totalDocumentoDataGridViewTextBoxColumn,
            this.fechaDocDataGridViewTextBoxColumn});
            this.dgv_q.DataSource = this.BSDocVentas;
            this.dgv_q.Location = new System.Drawing.Point(0, 47);
            this.dgv_q.Name = "dgv_q";
            this.dgv_q.Size = new System.Drawing.Size(324, 630);
            this.dgv_q.TabIndex = 46;
            this.dgv_q.DoubleClick += new System.EventHandler(this.Dgv_q_DoubleClick);
            // 
            // dgv_Doc
            // 
            this.dgv_Doc.AutoGenerateColumns = false;
            this.dgv_Doc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Doc.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serieDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.referenciaDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.tallaDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.unidadesDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.descuentoDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.almacenDataGridViewTextBoxColumn});
            this.dgv_Doc.DataSource = this.DSDetalleDoc;
            this.dgv_Doc.Location = new System.Drawing.Point(344, 185);
            this.dgv_Doc.Name = "dgv_Doc";
            this.dgv_Doc.Size = new System.Drawing.Size(810, 257);
            this.dgv_Doc.TabIndex = 47;
            this.dgv_Doc.DoubleClick += new System.EventHandler(this.dgv_Doc_DoubleClick);
            // 
            // serieDataGridViewTextBoxColumn
            // 
            this.serieDataGridViewTextBoxColumn.DataPropertyName = "Serie";
            this.serieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.serieDataGridViewTextBoxColumn.Name = "serieDataGridViewTextBoxColumn";
            this.serieDataGridViewTextBoxColumn.Visible = false;
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "Numero";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
            this.numeroDataGridViewTextBoxColumn.Visible = false;
            // 
            // referenciaDataGridViewTextBoxColumn
            // 
            this.referenciaDataGridViewTextBoxColumn.DataPropertyName = "Referencia";
            this.referenciaDataGridViewTextBoxColumn.HeaderText = "Referencia";
            this.referenciaDataGridViewTextBoxColumn.Name = "referenciaDataGridViewTextBoxColumn";
            // 
            // descripcionDataGridViewTextBoxColumn
            // 
            this.descripcionDataGridViewTextBoxColumn.DataPropertyName = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.HeaderText = "Descripcion";
            this.descripcionDataGridViewTextBoxColumn.Name = "descripcionDataGridViewTextBoxColumn";
            // 
            // tallaDataGridViewTextBoxColumn
            // 
            this.tallaDataGridViewTextBoxColumn.DataPropertyName = "Talla";
            this.tallaDataGridViewTextBoxColumn.HeaderText = "Talla";
            this.tallaDataGridViewTextBoxColumn.Name = "tallaDataGridViewTextBoxColumn";
            // 
            // colorDataGridViewTextBoxColumn
            // 
            this.colorDataGridViewTextBoxColumn.DataPropertyName = "Color";
            this.colorDataGridViewTextBoxColumn.HeaderText = "Color";
            this.colorDataGridViewTextBoxColumn.Name = "colorDataGridViewTextBoxColumn";
            // 
            // unidadesDataGridViewTextBoxColumn
            // 
            this.unidadesDataGridViewTextBoxColumn.DataPropertyName = "Unidades";
            this.unidadesDataGridViewTextBoxColumn.HeaderText = "Unidades";
            this.unidadesDataGridViewTextBoxColumn.Name = "unidadesDataGridViewTextBoxColumn";
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
            // 
            // descuentoDataGridViewTextBoxColumn
            // 
            this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
            this.descuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
            this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // almacenDataGridViewTextBoxColumn
            // 
            this.almacenDataGridViewTextBoxColumn.DataPropertyName = "Almacen";
            this.almacenDataGridViewTextBoxColumn.HeaderText = "Almacen";
            this.almacenDataGridViewTextBoxColumn.Name = "almacenDataGridViewTextBoxColumn";
            // 
            // DSDetalleDoc
            // 
            this.DSDetalleDoc.DataSource = typeof(ICG_Inter.Documento_Detalle);
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_aceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_aceptar.Image = global::ICG_Inter.Properties.Resources.s_success;
            this.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(3, 3);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(65, 27);
            this.btn_aceptar.TabIndex = 48;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aceptar.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.btn_aceptar);
            this.panel1.Location = new System.Drawing.Point(0, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1163, 39);
            this.panel1.TabIndex = 49;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(153, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 51;
            this.button1.Text = "Filtro";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button9.Image = global::ICG_Inter.Properties.Resources.s_cancel;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(74, 3);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(73, 27);
            this.button9.TabIndex = 50;
            this.button9.Text = "Cancelar";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.txt_poblacion2);
            this.panel6.Controls.Add(this.txt_vendedor2);
            this.panel6.Controls.Add(this.label11);
            this.panel6.Controls.Add(this.label10);
            this.panel6.Controls.Add(this.txt_direccion);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.txt_cliente2);
            this.panel6.Controls.Add(this.txtcliente);
            this.panel6.Controls.Add(this.label8);
            this.panel6.Controls.Add(this.txt_hora);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.txt_fecha);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.txt_num);
            this.panel6.Controls.Add(this.label4);
            this.panel6.Controls.Add(this.txt_serie);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Location = new System.Drawing.Point(344, 47);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(810, 132);
            this.panel6.TabIndex = 51;
            // 
            // txt_poblacion2
            // 
            this.txt_poblacion2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_poblacion2.Location = new System.Drawing.Point(552, 77);
            this.txt_poblacion2.Name = "txt_poblacion2";
            this.txt_poblacion2.Size = new System.Drawing.Size(171, 20);
            this.txt_poblacion2.TabIndex = 23;
            // 
            // txt_vendedor2
            // 
            this.txt_vendedor2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_vendedor2.Location = new System.Drawing.Point(552, 105);
            this.txt_vendedor2.Name = "txt_vendedor2";
            this.txt_vendedor2.Size = new System.Drawing.Size(171, 20);
            this.txt_vendedor2.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(500, 108);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Vendedor:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(500, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Ciudad:";
            // 
            // txt_direccion
            // 
            this.txt_direccion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_direccion.Location = new System.Drawing.Point(551, 51);
            this.txt_direccion.Name = "txt_direccion";
            this.txt_direccion.Size = new System.Drawing.Size(250, 20);
            this.txt_direccion.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(500, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Dirección:";
            // 
            // txt_cliente2
            // 
            this.txt_cliente2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txt_cliente2.Location = new System.Drawing.Point(551, 25);
            this.txt_cliente2.Name = "txt_cliente2";
            this.txt_cliente2.Size = new System.Drawing.Size(250, 20);
            this.txt_cliente2.TabIndex = 15;
            // 
            // txtcliente
            // 
            this.txtcliente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtcliente.Location = new System.Drawing.Point(551, 3);
            this.txtcliente.Name = "txtcliente";
            this.txtcliente.Size = new System.Drawing.Size(250, 20);
            this.txtcliente.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(500, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Cliente:";
            // 
            // txt_hora
            // 
            this.txt_hora.Location = new System.Drawing.Point(156, 96);
            this.txt_hora.Name = "txt_hora";
            this.txt_hora.Size = new System.Drawing.Size(57, 20);
            this.txt_hora.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(153, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Hora:";
            // 
            // txt_fecha
            // 
            this.txt_fecha.Location = new System.Drawing.Point(78, 96);
            this.txt_fecha.Name = "txt_fecha";
            this.txt_fecha.Size = new System.Drawing.Size(72, 20);
            this.txt_fecha.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha:";
            // 
            // txt_num
            // 
            this.txt_num.Location = new System.Drawing.Point(156, 25);
            this.txt_num.Name = "txt_num";
            this.txt_num.Size = new System.Drawing.Size(57, 20);
            this.txt_num.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(163, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Num:";
            // 
            // txt_serie
            // 
            this.txt_serie.Location = new System.Drawing.Point(78, 25);
            this.txt_serie.Name = "txt_serie";
            this.txt_serie.Size = new System.Drawing.Size(72, 20);
            this.txt_serie.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(75, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Serie:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(341, 445);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Devoluciones";
            // 
            // Dgv_ProductosDev
            // 
            this.Dgv_ProductosDev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Dgv_ProductosDev.Location = new System.Drawing.Point(344, 461);
            this.Dgv_ProductosDev.Name = "Dgv_ProductosDev";
            this.Dgv_ProductosDev.Size = new System.Drawing.Size(592, 150);
            this.Dgv_ProductosDev.TabIndex = 54;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(942, 461);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(212, 150);
            this.pictureBox1.TabIndex = 57;
            this.pictureBox1.TabStop = false;
            // 
            // BSDocVentas
            // 
            this.BSDocVentas.DataSource = typeof(ICG_Inter.Objetos.DocVentas);
            // 
            // serieDataGridViewTextBoxColumn1
            // 
            this.serieDataGridViewTextBoxColumn1.DataPropertyName = "Serie";
            this.serieDataGridViewTextBoxColumn1.HeaderText = "Serie";
            this.serieDataGridViewTextBoxColumn1.Name = "serieDataGridViewTextBoxColumn1";
            this.serieDataGridViewTextBoxColumn1.Width = 50;
            // 
            // numeroDataGridViewTextBoxColumn1
            // 
            this.numeroDataGridViewTextBoxColumn1.DataPropertyName = "Numero";
            this.numeroDataGridViewTextBoxColumn1.HeaderText = "Numero";
            this.numeroDataGridViewTextBoxColumn1.Name = "numeroDataGridViewTextBoxColumn1";
            this.numeroDataGridViewTextBoxColumn1.Width = 50;
            // 
            // totalDocumentoDataGridViewTextBoxColumn
            // 
            this.totalDocumentoDataGridViewTextBoxColumn.DataPropertyName = "TotalDocumento";
            this.totalDocumentoDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDocumentoDataGridViewTextBoxColumn.Name = "totalDocumentoDataGridViewTextBoxColumn";
            this.totalDocumentoDataGridViewTextBoxColumn.Width = 50;
            // 
            // fechaDocDataGridViewTextBoxColumn
            // 
            this.fechaDocDataGridViewTextBoxColumn.DataPropertyName = "FechaDoc";
            this.fechaDocDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDocDataGridViewTextBoxColumn.Name = "fechaDocDataGridViewTextBoxColumn";
            this.fechaDocDataGridViewTextBoxColumn.Width = 70;
            // 
            // FacturasVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 705);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Dgv_ProductosDev);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgv_Doc);
            this.Controls.Add(this.dgv_q);
            this.Name = "FacturasVenta";
            this.Text = "FACTURAS DE VENTA";
            this.Load += new System.EventHandler(this.FacturasVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_q)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Doc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSDetalleDoc)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_ProductosDev)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSDocVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_q;
        private System.Windows.Forms.DataGridView dgv_Doc;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_hora;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_fecha;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_num;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_serie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_poblacion2;
        private System.Windows.Forms.TextBox txt_vendedor2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_direccion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_cliente2;
        private System.Windows.Forms.TextBox txtcliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView Dgv_ProductosDev;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tallaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource DSDetalleDoc;
        private System.Windows.Forms.BindingSource BSDocVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDocumentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDocDataGridViewTextBoxColumn;
    }
}