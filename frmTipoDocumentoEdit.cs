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
    public partial class frmTipoDocumentoEdit : Form
    {
        private int? id;
        public frmTipoDocumentoEdit(int? id=null)
        {
            InitializeComponent();
            this.id = id;
        }

       

        private void frmTipoDocumentoEdit_Load(object sender, EventArgs e)
        {
            if (this.id != null)
            {
                this.Text = "Editar";
                var adaptador = new DataSet1TableAdapters.TipoDocumentoTableAdapter();
                var tabla = adaptador.GetDataById((int)this.id);
                var fila = (DataSet1.TipoDocumentoRow)tabla.Rows[0];
                txtName.Text = fila.Nombre;
                chkchkestado.Checked = fila.Estado == 1 ? true : false;
            }
            else
            {
                this.Text = "Nuevo";
            }
        }

        private void frmTipoDocumentoEdit_Load_1(object sender, EventArgs e)
        {
            if (this.id != null)
            {
                this.Text = "Editar";
                var adaptador = new DataSet1TableAdapters.TipoDocumentoTableAdapter();
                var tabla = adaptador.GetDataById((int)this.id);
                var fila = (DataSet1.TipoDocumentoRow)tabla.Rows[0];
                txtName.Text = fila.Nombre;
                chkchkestado.Checked = fila.Estado == 1 ? true : false;
            }
            else
            {
                this.Text = "Nuevo";
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int estado = chkchkestado.Checked ? 1 : 0;
            string nombre = txtName.Text;
            var adaptador = new DataSet1TableAdapters.TipoDocumentoTableAdapter();
            if (this.id == null)
            {
                adaptador.Add(nombre, (byte)estado);
            }
            else
            {
                adaptador.Edit(nombre, (byte)estado, (int)this.id);
            }

            this.Close();
        }
    }
}
