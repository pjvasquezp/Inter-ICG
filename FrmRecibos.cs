using CrystalDecisions.CrystalReports.Engine;
using ICG_Inter.Datos;
using ICG_Inter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICG_Inter
{
    public partial class FrmRecibos : Form
    {
        string PrinterName = Settings.Default.PrinterName;
        public DAConnectionSQL ObjDaConnexion;
        public ProcesosDB ObjProcDB = new ProcesosDB();
        public String  TipoSrie = "A";
        public string SereDocumento;

        public FrmRecibos()
        {
            InitializeComponent();
        }

        public FrmRecibos(DAConnectionSQL ObjDAConnecion)
        {
            ObjDaConnexion = ObjDAConnecion;
            InitializeComponent();
        }

        private void FrmRecibos_Load(object sender, EventArgs e)
        {
            RDBAll.Checked = true;
            TipoSrie = "A";
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            ReportDocument crystalReport = new ReportDocument();
            if (System.IO.File.Exists(Application.StartupPath.Replace("bin\\Debug", "\\Reportes\\ReciboNcrAll.rpt")))
            {
                //Uso de la Impresora
                //*****************************************************
                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = PrinterName;
                bool ImpresoraValida = ps.IsValid;
                ps.Copies = 1;
                PageSettings pg = new PageSettings();
                pg.PrinterSettings = ps;
                //*****************************************************

                //Carga el Reporte en el Visor
                //*****************************************************
                crystalReport.Load(Application.StartupPath.Replace("bin\\Debug", "\\Reportes\\ReciboNcrAll.rpt"));

                //Creo mi Repositorio de Datos y le agrego la info
                //*****************************************************
                DataTable DTNotasCred = new DataTable();
                DTNotasCred = ObjProcDB.GetDataNCRAll(DTPFechaDesde.Value, DTPFechaHasta.Value, TipoSrie, ObjDaConnexion);

                crystalReport.SetDataSource(DTNotasCred);

                crystalReportViewer1.ReportSource = crystalReport;

                //crystalReport.PrintToPrinter(ps, pg, false);
            }

        }

        private void RDBX_CheckedChanged(object sender, EventArgs e)
        {
            TipoSrie = "X";
        }

        private void RDBY_CheckedChanged(object sender, EventArgs e)
        {
            TipoSrie = "Y";
        }
    }
}
