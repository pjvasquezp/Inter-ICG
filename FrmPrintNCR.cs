using CrystalDecisions.CrystalReports.Engine;
using ICG_Inter.DataSet;
using ICG_Inter.Datos;
using ICG_Inter.Objetos;
using ICG_Inter.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using static System.Resources.ResXFileRef;

namespace ICG_Inter
{
    public partial class FrmPrintNCR : Form
    {
        string PrinterName = Settings.Default.PrinterName;
        public DAConnectionSQL ObjDaConnexion;
        public ProcesosDB ObjProcDB = new ProcesosDB();
        public NotasCredito oProcNotaCredito = new NotasCredito();

        public ListaNCReporteData ListaNCRRPT = new ListaNCReporteData();
                
        public FrmPrintNCR()
        {
            InitializeComponent();
        }

        public FrmPrintNCR(DAConnectionSQL ObjDAConnecion, NotasCredito oNotaCredito)
        {
            oProcNotaCredito = oNotaCredito;
            ObjDaConnexion = ObjDAConnecion;
            InitializeComponent();
        }

        private void FrmPrintNCR_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            DataSet.DSNotasCredito MyDataset = new DSNotasCredito();
            ReportDocument crystalReport = new ReportDocument();
            if (System.IO.File.Exists(Application.StartupPath.Replace("bin\\Debug", "\\Reportes\\ReciboNcr.rpt")))
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
                crystalReport.Load(Application.StartupPath.Replace("bin\\Debug", "\\Reportes\\ReciboNcrVF.rpt"));

                //Creo mi Repositorio de Datos y le agrego la info
                //*****************************************************
                DataTable DTNotasCred = new DataTable();                
                DTNotasCred = ObjProcDB.GetDataNCR(oProcNotaCredito, ObjDaConnexion);
               
                
                crystalReport.SetDataSource(DTNotasCred);
                crystalReport.PrintToPrinter(ps, pg, false);
             }

            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Close();
        }



    }
}
