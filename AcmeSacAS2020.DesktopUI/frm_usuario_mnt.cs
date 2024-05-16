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
    public partial class frm_usuario_mnt : Form
    {
        public static string UsuarioActualRol;
        private UsuarioRN usuarioRN;
        private BindingSource bindingSource_usuario = new BindingSource();
        public bool estado;
        public frm_usuario_mnt()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            estado = true;
            panel2.Enabled = true;
            textBox1.Focus();
            textBox1.ResetText();
            textBox2.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            #region Bloque que valida los objetos de entrada
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                panel2.BackColor = Color.FromArgb(219,81,69);
                MessageBox.Show("Completa los Datos","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Error);
                errorProvider1.SetError(panel2, "Completa los Datos");
                return;
            }
            else
            {
                errorProvider1.SetError(panel2, string.Empty);
                panel2.BackColor = Color.FromArgb(255,255,255);
            }
            #endregion

            #region Haciendo datos persistentes en el contexto (BD)
            if (estado)
            {
                Usuario usuario = new Usuario { nom_usuario = textBox1.Text, ape_usuario = textBox2.Text };
                usuarioRN.Agregar(usuario);
                MessageBox.Show("Datos Guardados");
            }
            else
            {
                Usuario usuario = usuarioRN.Buscar(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                usuario.nom_usuario = textBox1.Text;
                usuario.ape_usuario = textBox2.Text;

                usuarioRN.Modificar(usuario);
                MessageBox.Show("Datos actualizados con éxito...");
            }
            #endregion
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            UsuarioActualRol = dataGridView1.CurrentRow.Cells[0].Value.ToString() + " - " + dataGridView1.CurrentRow.Cells[1].Value.ToString();

            frm_rol_mnt from_Rol = new frm_rol_mnt();
            from_Rol.ShowDialog();
        }

        private void Frm_usuario_mnt_Load(object sender, EventArgs e)
        {
            usuarioRN = new UsuarioRN();
            bindingSource_usuario.DataSource = usuarioRN.ListarUsuarioCampos();
            bindingNavigator1.BindingSource = bindingSource_usuario;

            dataGridView1.DataSource = bindingSource_usuario;
            dataGridView1.AutoResizeColumns();
        }

        private void ToolStripButton1_Click(object sender, EventArgs e)
        {
            Frm_usuario_mnt_Load(sender, e);
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (e.ColumnIndex > -1 && e.RowIndex > -1)
                {
                    estado = false;
                    Usuario usuario = usuarioRN.Buscar(int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString()));

                    textBox1.Text = usuario.nom_usuario;
                    textBox2.Text = usuario.ape_usuario;

                    tabControl1.SelectedTab = tabPage2;
                }
            }
        }
    }
}
