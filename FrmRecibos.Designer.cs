namespace ICG_Inter
{
    partial class FrmRecibos
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.GRPBoxParam = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RDBX = new System.Windows.Forms.RadioButton();
            this.RDBAll = new System.Windows.Forms.RadioButton();
            this.RDBY = new System.Windows.Forms.RadioButton();
            this.BtnGenerar = new System.Windows.Forms.Button();
            this.DTPFechaHasta = new System.Windows.Forms.DateTimePicker();
            this.DTPFechaDesde = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.GRPBoxParam.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.GRPBoxParam);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.crystalReportViewer1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 69;
            this.splitContainer1.TabIndex = 0;
            // 
            // GRPBoxParam
            // 
            this.GRPBoxParam.Controls.Add(this.groupBox1);
            this.GRPBoxParam.Controls.Add(this.BtnGenerar);
            this.GRPBoxParam.Controls.Add(this.DTPFechaHasta);
            this.GRPBoxParam.Controls.Add(this.DTPFechaDesde);
            this.GRPBoxParam.Controls.Add(this.label2);
            this.GRPBoxParam.Controls.Add(this.label1);
            this.GRPBoxParam.Location = new System.Drawing.Point(3, 0);
            this.GRPBoxParam.Name = "GRPBoxParam";
            this.GRPBoxParam.Size = new System.Drawing.Size(794, 66);
            this.GRPBoxParam.TabIndex = 0;
            this.GRPBoxParam.TabStop = false;
            this.GRPBoxParam.Text = "Parametros de Consulta";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RDBX);
            this.groupBox1.Controls.Add(this.RDBAll);
            this.groupBox1.Controls.Add(this.RDBY);
            this.groupBox1.Location = new System.Drawing.Point(211, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 47);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // RDBX
            // 
            this.RDBX.AutoSize = true;
            this.RDBX.Location = new System.Drawing.Point(136, 19);
            this.RDBX.Name = "RDBX";
            this.RDBX.Size = new System.Drawing.Size(104, 17);
            this.RDBX.TabIndex = 6;
            this.RDBX.TabStop = true;
            this.RDBX.Text = "Notas de Crédito";
            this.RDBX.UseVisualStyleBackColor = true;
            this.RDBX.CheckedChanged += new System.EventHandler(this.RDBX_CheckedChanged);
            // 
            // RDBAll
            // 
            this.RDBAll.AutoSize = true;
            this.RDBAll.Location = new System.Drawing.Point(16, 19);
            this.RDBAll.Name = "RDBAll";
            this.RDBAll.Size = new System.Drawing.Size(55, 17);
            this.RDBAll.TabIndex = 4;
            this.RDBAll.TabStop = true;
            this.RDBAll.Text = "Todos";
            this.RDBAll.UseVisualStyleBackColor = true;
            // 
            // RDBY
            // 
            this.RDBY.AutoSize = true;
            this.RDBY.Location = new System.Drawing.Point(322, 19);
            this.RDBY.Name = "RDBY";
            this.RDBY.Size = new System.Drawing.Size(102, 17);
            this.RDBY.TabIndex = 5;
            this.RDBY.TabStop = true;
            this.RDBY.Text = "Notas de Abono";
            this.RDBY.UseVisualStyleBackColor = true;
            this.RDBY.CheckedChanged += new System.EventHandler(this.RDBY_CheckedChanged);
            // 
            // BtnGenerar
            // 
            this.BtnGenerar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.BtnGenerar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGenerar.ForeColor = System.Drawing.Color.White;
            this.BtnGenerar.Location = new System.Drawing.Point(678, 18);
            this.BtnGenerar.Name = "BtnGenerar";
            this.BtnGenerar.Size = new System.Drawing.Size(88, 23);
            this.BtnGenerar.TabIndex = 6;
            this.BtnGenerar.Text = "Generar Recibos";
            this.BtnGenerar.UseVisualStyleBackColor = false;
            this.BtnGenerar.Click += new System.EventHandler(this.BtnGenerar_Click);
            // 
            // DTPFechaHasta
            // 
            this.DTPFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaHasta.Location = new System.Drawing.Point(85, 39);
            this.DTPFechaHasta.Name = "DTPFechaHasta";
            this.DTPFechaHasta.Size = new System.Drawing.Size(104, 20);
            this.DTPFechaHasta.TabIndex = 3;
            // 
            // DTPFechaDesde
            // 
            this.DTPFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DTPFechaDesde.Location = new System.Drawing.Point(85, 14);
            this.DTPFechaDesde.Name = "DTPFechaDesde";
            this.DTPFechaDesde.Size = new System.Drawing.Size(104, 20);
            this.DTPFechaDesde.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fecha Hasta :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha Desde :";
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.ShowLogo = false;
            this.crystalReportViewer1.Size = new System.Drawing.Size(800, 377);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // FrmRecibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmRecibos";
            this.Text = "Consultar Recibos";
            this.Load += new System.EventHandler(this.FrmRecibos_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.GRPBoxParam.ResumeLayout(false);
            this.GRPBoxParam.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox GRPBoxParam;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGenerar;
        private System.Windows.Forms.RadioButton RDBY;
        private System.Windows.Forms.RadioButton RDBAll;
        private System.Windows.Forms.DateTimePicker DTPFechaHasta;
        private System.Windows.Forms.DateTimePicker DTPFechaDesde;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RDBX;
    }
}