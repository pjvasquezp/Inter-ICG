using CrystalDecisions.CrystalReports.Engine;
using ICG_Inter.Datos;
using ICG_Inter.Objetos;
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
        public UserSistemas oUserSistemasLog = new UserSistemas();

        public FrmRecibos()
        {
            InitializeComponent();
        }

        public FrmRecibos(DAConnectionSQL ObjDAConnecion, UserSistemas oUserSistemas)
        {
            oUserSistemasLog = oUserSistemas;
            ObjDaConnexion = ObjDAConnecion;
            InitializeComponent();
            this.Text = this.Text + " USER .: " + oUserSistemasLog.NOMVENDEDOR + " :.";
        }

        private void FrmRecibos_Load(object sender, EventArgs e)
        {
            RDBAll.Checked = true;
            TipoSrie = "A";
        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            ReportDocument crystalReport = new ReportDocument();
            //MessageBox.Show(Settings.Default.PathReportes + "ReciboNcrAll.rpt");
            if (System.IO.File.Exists(Settings.Default.PathReportes + "ReciboNcrAll.rpt"))
            {
                try
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
                        crystalReport.Load(Settings.Default.PathReportes + "ReciboNcrAll.rpt");
                        //MessageBox.Show(Application.StartupPath.ToString());

                        //Creo mi Repositorio de Datos y le agrego la info
                        //*****************************************************
                        DataTable DTNotasCred = new DataTable();
                        DTNotasCred = ObjProcDB.GetDataNCRAll(DTPFechaDesde.Value, DTPFechaHasta.Value, TipoSrie, ObjDaConnexion);

                        crystalReport.SetDataSource(DTNotasCred);

                        crystalReportViewer1.ReportSource = crystalReport;

                            //crystalReport.PrintToPrinter(ps, pg, false);


                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error " + ex.Message, "Información", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
