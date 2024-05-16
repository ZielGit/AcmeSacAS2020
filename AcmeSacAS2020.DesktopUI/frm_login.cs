using AcmeSacAS2020.Core.Entidades;
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
    public partial class frm_login : Form
    {
        private UsuarioRN usuarioRN = new UsuarioRN();
        public static string _nombreUsuarioLogin, _coddigoUsuarioLogin;
        public frm_login()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            #region Validamos los objetos
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Complete los datos, porfavor...","Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Error);
                label4.ForeColor = Color.FromArgb(230, 0, 18);
                label4.Text = "Complete los datos, porfavor";

                errorProvider1.SetError(label4, "Complete los datos, porfavor...");
                return;
            }
            else
            {
                label4.ForeColor = Color.White;
                errorProvider1.SetError(label4, string.Empty);

            }
            #endregion

            #region Consulta al contexto
            Usuario usuarioLogin = usuarioRN.Buscar(int.Parse(textBox1.Text));

            if (usuarioLogin != null)
            {
                _nombreUsuarioLogin = usuarioLogin.ape_usuario + " " + usuarioLogin.nom_usuario;
                _coddigoUsuarioLogin = usuarioLogin.Id.ToString();

                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario no registrado...");
            }
            #endregion
        }
    }
}
