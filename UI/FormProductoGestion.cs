using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class FormProductoGestion : Form
    {
        public FormProductoGestion()
        {
            InitializeComponent();
        }

        ProductoBLL bllProd = new ProductoBLL();
        ProductoBE beProd = new ProductoBE();
        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            FormProductoAlta frmProdAlta = new FormProductoAlta();
            frmProdAlta.MdiParent = ParentForm;
            frmProdAlta.FormClosed += new FormClosedEventHandler(frmProdAlta_FormClosed);
            frmProdAlta.Show();
        }
        private void frmProdAlta_FormClosed(object sender, FormClosedEventArgs e)
        {
            LeerProductos();
        }
        private void FormProductoGestion_Load(object sender, EventArgs e)
        {
            LeerProductos();
        }

        public void LeerProductos()

        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bllProd.ListarProductos();
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (beProd.Descripcion == null) { MessageBox.Show("Debe seleccionar un Producto para Editar"); }

            else { 

            FormProductoEditar frmProdEd = new FormProductoEditar();
            frmProdEd.eProd = beProd;
            frmProdEd.MdiParent = this.ParentForm;
            frmProdEd.FormClosed += new FormClosedEventHandler(frmProdEd_FormClosed);
            frmProdEd.Show();

            }
        }

        private void frmProdEd_FormClosed(object sender, FormClosedEventArgs e)
        {
            LeerProductos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            beProd.Id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            beProd.Descripcion = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
            beProd.Tipo = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value);
            beProd.UnidadMedida = Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value);
            beProd.Precio = (float)Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells[5].Value);
            beProd.Activo=Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[6].Value);
        }

    }
}
