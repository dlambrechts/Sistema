using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class FormPedidoEditar : Form
    {
        public FormPedidoEditar()
        {
            InitializeComponent();
        }

        public PedidoBE Pedido;
        PedidoBLL bllP = new PedidoBLL();

        private void FormPedidoEditar_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }
        public void CargarDatos()
        {
            dataGridViewItems.DataSource = null;
            bllP.CargarItems(Pedido);
            dataGridViewItems.DataSource = Pedido.Items;
            labelCli.Text = Pedido.Cliente.RazonSocial;
            labelNum.Text = Convert.ToString(Pedido.Id);
            dateTimePickerEntrega.Value = Pedido.FechaEntrega;
            labelEmision.Text = Pedido.FechaEmision.ToShortDateString();
            labelPRes.Text = Convert.ToString(Pedido.Presupuesto.Id);
        
        }

        private void buttonAct_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta = MessageBox.Show("Confirma Edición del Pedido?", "Editar Pedido", MessageBoxButtons.YesNo);

            if (Respuesta == DialogResult.Yes)
            {
                try
                {
                    Pedido.FechaEntrega = Convert.ToDateTime(dateTimePickerEntrega.Value);
                    bllP.CambiarFechaEntrega(Pedido);
                    MessageBox.Show("Pedido Actualizado Correctamente");
                    this.Close();
                }

                catch (Exception ex)

                { MessageBox.Show(ex.Message); }
            }

        }
    }
}
