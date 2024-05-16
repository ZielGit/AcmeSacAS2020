using AcmeSacAS2020.Infraestructura.ReglasNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcmeSacAS2020.DesktopUI
{
    public partial class frm_reportes_mnt : Form
    {
        Reportes reportes;
        public frm_reportes_mnt()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_reportes_mnt_Load(object sender, EventArgs e)
        {

            //this.reportViewer1.RefreshReport();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            #region Validando objetos de entrada
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Selecione un reporte...", "Advertencia", MessageBoxButtons.OK,MessageBoxIcon.Error);
                errorProvider1.SetError(comboBox1, "Seleccione un reporte...");
                return;
            }
            else
            
                errorProvider1.SetError(comboBox1,string.Empty);

            #endregion

            #region Consulta al contexto
            switch (comboBox1.Text.Substring(0,2))
            {
                case "01":
                    reportes = new Reportes();
                    oReporteUsuarioBindingSource.DataSource = reportes.oReporteUsuariosLista().ToList();

                    this.reportViewer1.RefreshReport();

                    break;
            }
            #endregion
        }
    }
}
