using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EVA1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }
        private void cargarDatos()
        {
            var adaptador = new DataSet1TableAdapters.TipoDocumentoTableAdapter();
            var tabla = adaptador.GetData();
            dgvDatos.DataSource = tabla;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            var frm = new frmTipoDocumentoEdit();
            frm.ShowDialog();
            cargarDatos();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                var frm = new frmTipoDocumentoEdit(id);
                frm.ShowDialog();
                cargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un id valido", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private int getId()
        {
            try
            {
                DataGridViewRow filaActual = dgvDatos.CurrentRow;
                if (filaActual == null)
                {
                    return 0;
                }
                return int.Parse(dgvDatos.Rows[filaActual.Index].Cells[0].Value.ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = getId();
            if (id > 0)
            {
                DialogResult respuesta = MessageBox.Show("Realmente desea eliminar el registro?", "Sistema",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (respuesta == DialogResult.Yes)
                {
                    var adaptador = new DataSet1TableAdapters.TipoDocumentoTableAdapter();
                    adaptador.Remove(id);
                    MessageBox.Show("Registro eliminado", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cargarDatos();
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un id valido", "Sistemas", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}