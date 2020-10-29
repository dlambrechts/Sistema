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
        List<ClienteBE> LisCLi = new List<ClienteBE>();
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
            LisCLi.Clear();
            LisCLi = bllCli.ListarClientes();
            dataGridClientes.DataSource = null;
            BindingList<ClienteBE> cList = new BindingList<ClienteBE>(LisCLi);
            dataGridClientes.DataSource =cList;
            dataGridClientes.Columns["_UsuarioCreacion"].Visible = false;
            dataGridClientes.Columns["_UsuarioModificacion"].Visible = false;
            dataGridClientes.Columns["FechaModificacion"].Visible = false;
            dataGridClientes.Columns["FechaCreacion"].Visible = false;
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            beCli = (ClienteBE)dataGridClientes.CurrentRow.DataBoundItem;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (beCli.Id == 0) { MessageBox.Show("Debe seleccionar un Cliente para Eliminar"); }

            else
            {

                DialogResult Respuesta = MessageBox.Show("¿Eliminar Cliente " + beCli.Id + "?", "Eliminar Cliente", MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)
                {
                    if (bllCli.ExisteClienteEnPresupuesto(beCli) == true) 
                    
                        { MessageBox.Show("No es posible Eliminar. El Cliente tiene Presupuestos asociados "); }

                    else 
                        {
                        bllCli.EliminarCliente(beCli);
                        MessageBox.Show("Cliente Eliminado");
                        LeerClientes();
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (beCli.RazonSocial == null) { MessageBox.Show("Debe seleccionar un Cliente"); }

                else
                {

                    FormClienteVersion frmVer = new FormClienteVersion();
                    frmVer.Cli = beCli;

                    if (bllCli.ListarVersionesClientePorId(beCli).Count == 0) { MessageBox.Show("No existen versiones para el cliente " + beCli.Id); }

                    else { 
                    frmVer.MdiParent = this.ParentForm;
                    frmVer.FormClosed += new FormClosedEventHandler(frmEdit_FormClosed);
                    frmVer.Show();
                    }

                }
            }
        }   
    }
}
