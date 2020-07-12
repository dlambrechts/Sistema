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
    public partial class FormClienteGestionar : Form
    {
        public FormClienteGestionar()
        {
            InitializeComponent();
        }

        ClienteBLL bllCli = new ClienteBLL();
        public ClienteBE beCli = new ClienteBE();

        private void button1_Click(object sender, EventArgs e)
        {
            
            FormClienteAlta frmCliAlta = new FormClienteAlta();
            frmCliAlta.MdiParent = this.ParentForm;
            frmCliAlta.FormClosed += new FormClosedEventHandler(frmCliAlta_FormClosed);
            frmCliAlta.Show();
        }

        private void frmCliAlta_FormClosed (object sender, FormClosedEventArgs e)
        {
            LeerClientes();
        }

        private void frmEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            LeerClientes();
        }

        private void FormClienteGestionar_Load(object sender, EventArgs e)
        {
            LeerClientes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(beCli.RazonSocial==null) { MessageBox.Show("Debe seleccionar un Cliente"); }

            else { 

            FormClienteEditar frmEdit = new FormClienteEditar();
            frmEdit.Cli = beCli;
            frmEdit.MdiParent = this.ParentForm;
            frmEdit.FormClosed += new FormClosedEventHandler(frmEdit_FormClosed);
            frmEdit.Show();

            }
        }
        public void LeerClientes()

        {
            dataGridClientes.DataSource = null;
            dataGridClientes.DataSource = bllCli.ListarClientes();

        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            beCli.Id = Convert.ToInt32(dataGridClientes.Rows[e.RowIndex].Cells[0].Value);
            beCli.RazonSocial = Convert.ToString(dataGridClientes.Rows[e.RowIndex].Cells[1].Value);
            beCli.Direccion = Convert.ToString(dataGridClientes.Rows[e.RowIndex].Cells[2].Value);
            beCli.CodigoPostal = Convert.ToInt32(dataGridClientes.Rows[e.RowIndex].Cells[3].Value);
            beCli.Telefono = Convert.ToString(dataGridClientes.Rows[e.RowIndex].Cells[4].Value);
            beCli.Mail = Convert.ToString(dataGridClientes.Rows[e.RowIndex].Cells[5].Value);
            beCli.Tipo= Convert.ToString(dataGridClientes.Rows[e.RowIndex].Cells[6].Value);
            beCli.Cuit = Convert.ToString(dataGridClientes.Rows[e.RowIndex].Cells[7].Value);
            beCli.Contacto= Convert.ToString(dataGridClientes.Rows[e.RowIndex].Cells[8].Value);
            beCli.CondicionPago = Convert.ToString(dataGridClientes.Rows[e.RowIndex].Cells[9].Value);
            beCli.Activo = Convert.ToBoolean(dataGridClientes.Rows[e.RowIndex].Cells[10].Value);
        }
    }
}
