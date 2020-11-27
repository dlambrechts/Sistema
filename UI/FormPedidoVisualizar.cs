using BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    public partial class FormPedidoVisualizar : Form
    {
        public FormPedidoVisualizar()
        {
            InitializeComponent();
        }

        public BE.PedidoBE Pedido;
        private BLL.PedidoBLL bllP = new PedidoBLL();
        private void FormPedidoVisualizar_Load(object sender, EventArgs e)
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
            labelEntrega.Text = Pedido.FechaEntrega.ToShortDateString();
            labelEmision.Text = Pedido.FechaEmision.ToShortDateString();
            labelPRes.Text = Convert.ToString(Pedido.Presupuesto.Id);
            labelDesc.Text = "$ "+Convert.ToString(Pedido.Descuento);
            labelImp.Text = "$ " + Convert.ToString(Pedido.Impuestos);
            labelTot.Text = "$ " + Convert.ToString(Pedido.Total);
            checkBox1.Checked = Pedido.Envio;
            if (Pedido.Envio == true)

            {
                labelDir.Text = Pedido.DireccionEnvio;
                labelResp.Text = Pedido.ResponsableEnvio;

            }
            else

            {
                labelDir.Text = "n/a";
                labelResp.Text = "n/a";
            }
        
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
