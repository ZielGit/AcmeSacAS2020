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
    public partial class frm_rol_mnt : Form
    {
        private ModuloRN moduloRN;
        private BindingSource bindingSourceRol = new BindingSource();
        public frm_rol_mnt()
        {
            InitializeComponent();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Frm_rol_mnt_Load(object sender, EventArgs e)
        {
            moduloRN = new ModuloRN();
            label3.Text = frm_usuario_mnt.UsuarioActualRol;

            bindingSourceRol.DataSource = moduloRN.ListaModulo();
            bindingNavigator1.BindingSource = bindingSourceRol;

            dataGridView1.DataSource = bindingSourceRol;
            dataGridView1.AutoResizeColumns();
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                if (e.ColumnIndex >-1 && e.RowIndex >-1)
                {
                    if (!listBox1.Items.Contains(dataGridView1.CurrentRow.Cells[0].Value.ToString()+" - "+ dataGridView1.CurrentRow.Cells[1].Value.ToString()))
                    {
                        listBox1.Items.Add(dataGridView1.CurrentRow.Cells[0].Value.ToString() + " - " + dataGridView1.CurrentRow.Cells[1].Value.ToString());
                    }
                    else
                    {
                        MessageBox.Show("El Módulo \n"+dataGridView1.CurrentRow.Cells[0].Value.ToString()+" - "+ dataGridView1.CurrentRow.Cells[1].Value.ToString()+" ya esta en la lista...","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }

                }
            }
            tabControl1.SelectedTab = tabPage2;
        }

        private void ListBox1_DoubleClick(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}
