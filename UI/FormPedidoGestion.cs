using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FormPedidoGestion : Form
    {
        public FormPedidoGestion()
        {
            InitializeComponent();
        }

        PedidoBLL pBLL = new PedidoBLL();
        PedidoBE selPed;
        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            FormPedidoAlta Alta = new FormPedidoAlta();
            Alta.MdiParent = this.ParentForm;
            Alta.FormClosed += new FormClosedEventHandler(Alta_FormClosed);
            Alta.Show();
        }

        private void FormPedidoGestion_Load(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void Alta_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarPedidos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            selPed = (PedidoBE)dataGridViewPedidos.CurrentRow.DataBoundItem;
        }

        public void CargarPedidos()

        {
            dataGridViewPedidos.DataSource = null;
            dataGridViewPedidos.DataSource = pBLL.ListarPedidos();

        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            if (selPed == null) { MessageBox.Show("Debe seleccionar un Pedido"); }

            else 
            
            { 
            FormPedidoVisualizar fVer = new FormPedidoVisualizar();
            fVer.Pedido = selPed;
            fVer.MdiParent = this.ParentForm;
            fVer.Show();
            }
        }
    }
}
