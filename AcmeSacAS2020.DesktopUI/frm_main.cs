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
    public partial class frm_main : Form
    {
        public frm_main()
        {
            InitializeComponent();
        }

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
            
        }

        private void UsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            frm_usuario_mnt f1 = new frm_usuario_mnt();
            f1.ShowDialog();
            this.Cursor = Cursors.Default;
        }

        private void ListasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm_reportes_mnt f1 = new frm_reportes_mnt();
            f1.ShowDialog();
        }

        private void Frm_main_Load(object sender, EventArgs e)
        {
            frm_login f1 = new frm_login();
            f1.ShowDialog();

            toolStripStatusLabel2.Text = frm_login._nombreUsuarioLogin;
        }
    }
}
