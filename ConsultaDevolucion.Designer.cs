namespace ICG_Inter
{
    partial class ConsultaDevolucion
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_aceptar = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.DGV_NotasCredito = new System.Windows.Forms.DataGridView();
            this.BSNotasCredito = new System.Windows.Forms.BindingSource(this.components);
            this.FechaNC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unidadesDevueltasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.razonDevolucionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tallaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.almacenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numLineaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descuentoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaFactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precioSinivaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codBarraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_NotasCredito)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSNotasCredito)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DGV_NotasCredito);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(568, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Devoluciones del Cliente";
            // 
            // btn_aceptar
            // 
            this.btn_aceptar.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_aceptar.Image = global::ICG_Inter.Properties.Resources.s_success;
            this.btn_aceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_aceptar.Location = new System.Drawing.Point(12, -1);
            this.btn_aceptar.Name = "btn_aceptar";
            this.btn_aceptar.Size = new System.Drawing.Size(65, 27);
            this.btn_aceptar.TabIndex = 41;
            this.btn_aceptar.Text = "Aceptar";
            this.btn_aceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_aceptar.UseVisualStyleBackColor = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button9.Image = global::ICG_Inter.Properties.Resources.s_cancel;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.Location = new System.Drawing.Point(92, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(73, 27);
            this.button9.TabIndex = 42;
            this.button9.Text = "Cancelar";
            this.button9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button9.UseVisualStyleBackColor = false;
            // 
            // DGV_NotasCredito
            // 
            this.DGV_NotasCredito.AutoGenerateColumns = false;
            this.DGV_NotasCredito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_NotasCredito.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaNC,
            this.serieDataGridViewTextBoxColumn,
            this.numeroDataGridViewTextBoxColumn,
            this.referenciaDataGridViewTextBoxColumn,
            this.descripcionDataGridViewTextBoxColumn,
            this.unidadesDataGridViewTextBoxColumn,
            this.unidadesDevueltasDataGridViewTextBoxColumn,
            this.razonDevolucionDataGridViewTextBoxColumn,
            this.precioDataGridViewTextBoxColumn,
            this.tallaDataGridViewTextBoxColumn,
            this.colorDataGridViewTextBoxColumn,
            this.almacenDataGridViewTextBoxColumn,
            this.numLineaDataGridViewTextBoxColumn,
            this.descuentoDataGridViewTextBoxColumn,
            this.codArticuloDataGridViewTextBoxColumn,
            this.fechaFactDataGridViewTextBoxColumn,
            this.precioSinivaDataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.codBarraDataGridViewTextBoxColumn});
            this.DGV_NotasCredito.DataSource = this.BSNotasCredito;
            this.DGV_NotasCredito.Location = new System.Drawing.Point(6, 19);
            this.DGV_NotasCredito.Name = "DGV_NotasCredito";
            this.DGV_NotasCredito.Size = new System.Drawing.Size(556, 150);
            this.DGV_NotasCredito.TabIndex = 0;
            // 
            // BSNotasCredito
            // 
            this.BSNotasCredito.DataSource = typeof(ICG_Inter.Objetos.NotasCredito);
            // 
            // FechaNC
            // 
            this.FechaNC.DataPropertyName = "FechaNC";
            this.FechaNC.HeaderText = "Fecha NCR";
            this.FechaNC.Name = "FechaNC";
            // 
            // serieDataGridViewTextBoxColumn
            // 
            this.serieDataGridViewTextBoxColumn.DataPropertyName = "Serie";
            this.serieDataGridViewTextBoxColumn.HeaderText = "Serie";
            this.serieDataGridViewTextBoxColumn.Name = "serieDataGridViewTextBoxColumn";
            // 
            // numeroDataGridViewTextBoxColumn
            // 
            this.numeroDataGridViewTextBoxColumn.DataPropertyName = "Numero";
            this.numeroDataGridViewTextBoxColumn.HeaderText = "Numero";
            this.numeroDataGridViewTextBoxColumn.Name = "numeroDataGridViewTextBoxColumn";
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
            // unidadesDataGridViewTextBoxColumn
            // 
            this.unidadesDataGridViewTextBoxColumn.DataPropertyName = "Unidades";
            this.unidadesDataGridViewTextBoxColumn.HeaderText = "Unidades";
            this.unidadesDataGridViewTextBoxColumn.Name = "unidadesDataGridViewTextBoxColumn";
            // 
            // unidadesDevueltasDataGridViewTextBoxColumn
            // 
            this.unidadesDevueltasDataGridViewTextBoxColumn.DataPropertyName = "UnidadesDevueltas";
            this.unidadesDevueltasDataGridViewTextBoxColumn.HeaderText = "UnidadesDevueltas";
            this.unidadesDevueltasDataGridViewTextBoxColumn.Name = "unidadesDevueltasDataGridViewTextBoxColumn";
            // 
            // razonDevolucionDataGridViewTextBoxColumn
            // 
            this.razonDevolucionDataGridViewTextBoxColumn.DataPropertyName = "RazonDevolucion";
            this.razonDevolucionDataGridViewTextBoxColumn.HeaderText = "RazonDevolucion";
            this.razonDevolucionDataGridViewTextBoxColumn.Name = "razonDevolucionDataGridViewTextBoxColumn";
            // 
            // precioDataGridViewTextBoxColumn
            // 
            this.precioDataGridViewTextBoxColumn.DataPropertyName = "Precio";
            this.precioDataGridViewTextBoxColumn.HeaderText = "Precio";
            this.precioDataGridViewTextBoxColumn.Name = "precioDataGridViewTextBoxColumn";
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
            // almacenDataGridViewTextBoxColumn
            // 
            this.almacenDataGridViewTextBoxColumn.DataPropertyName = "Almacen";
            this.almacenDataGridViewTextBoxColumn.HeaderText = "Almacen";
            this.almacenDataGridViewTextBoxColumn.Name = "almacenDataGridViewTextBoxColumn";
            // 
            // numLineaDataGridViewTextBoxColumn
            // 
            this.numLineaDataGridViewTextBoxColumn.DataPropertyName = "NumLinea";
            this.numLineaDataGridViewTextBoxColumn.HeaderText = "NumLinea";
            this.numLineaDataGridViewTextBoxColumn.Name = "numLineaDataGridViewTextBoxColumn";
            // 
            // descuentoDataGridViewTextBoxColumn
            // 
            this.descuentoDataGridViewTextBoxColumn.DataPropertyName = "Descuento";
            this.descuentoDataGridViewTextBoxColumn.HeaderText = "Descuento";
            this.descuentoDataGridViewTextBoxColumn.Name = "descuentoDataGridViewTextBoxColumn";
            // 
            // codArticuloDataGridViewTextBoxColumn
            // 
            this.codArticuloDataGridViewTextBoxColumn.DataPropertyName = "CodArticulo";
            this.codArticuloDataGridViewTextBoxColumn.HeaderText = "CodArticulo";
            this.codArticuloDataGridViewTextBoxColumn.Name = "codArticuloDataGridViewTextBoxColumn";
            // 
            // fechaFactDataGridViewTextBoxColumn
            // 
            this.fechaFactDataGridViewTextBoxColumn.DataPropertyName = "Fecha_Fact";
            this.fechaFactDataGridViewTextBoxColumn.HeaderText = "Fecha_Fact";
            this.fechaFactDataGridViewTextBoxColumn.Name = "fechaFactDataGridViewTextBoxColumn";
            // 
            // precioSinivaDataGridViewTextBoxColumn
            // 
            this.precioSinivaDataGridViewTextBoxColumn.DataPropertyName = "Precio_Sin_iva";
            this.precioSinivaDataGridViewTextBoxColumn.HeaderText = "Precio_Sin_iva";
            this.precioSinivaDataGridViewTextBoxColumn.Name = "precioSinivaDataGridViewTextBoxColumn";
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            // 
            // codBarraDataGridViewTextBoxColumn
            // 
            this.codBarraDataGridViewTextBoxColumn.DataPropertyName = "CodBarra";
            this.codBarraDataGridViewTextBoxColumn.HeaderText = "CodBarra";
            this.codBarraDataGridViewTextBoxColumn.Name = "codBarraDataGridViewTextBoxColumn";
            // 
            // ConsultaDevolucion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 222);
            this.Controls.Add(this.btn_aceptar);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultaDevolucion";
            this.Text = "ConsultaDevolucion";
            this.Load += new System.EventHandler(this.ConsultaDevolucion_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_NotasCredito)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BSNotasCredito)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView DGV_NotasCredito;
        private System.Windows.Forms.Button btn_aceptar;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.BindingSource BSNotasCredito;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaNC;
        private System.Windows.Forms.DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn unidadesDevueltasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn razonDevolucionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tallaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn colorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn almacenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numLineaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descuentoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaFactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn precioSinivaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn codBarraDataGridViewTextBoxColumn;
    }
}