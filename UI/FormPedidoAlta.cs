using BE;
using BE.PresupuestoEstado;
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
    public partial class FormPedidoAlta : Form
    {
        public FormPedidoAlta()
        {
            InitializeComponent();
        }
        PresupuestoBLL preBLL = new PresupuestoBLL();
        PedidoBLL pedBLL = new PedidoBLL();
        PedidoBE Pedido;
        private void FormPedidoAlta_Load(object sender, EventArgs e)
        {
            ListarPresupuestosAprobados();           
        }
        public void ListarPresupuestosAprobados() 
        
        {
            List<PresupuestoBE> Presup = new List<PresupuestoBE>();
            Presup = preBLL.ListarPresupuestos();
            Presup = Presup.Where(Item => Item.Estado.EmitirPedido() == true).ToList();
            listBoxPresup.DataSource = null;
            listBoxPresup.DataSource = Presup;
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {

            if (Pedido==null)

            { MessageBox.Show("Primero debe cargar un Presupuesto"); }


            else
            {
                DialogResult Respuesta = MessageBox.Show("Confirma Emisión del Pedido?", "Generar Pedido", MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)
                {
                    try { 

                    Pedido.FechaEmision = DateTime.Now;
                    Pedido.FechaEntrega = Convert.ToDateTime(dateTimePicker1.Value);
                    Pedido.Envio = checkBox1.Checked;
                    

                        if (Pedido.Envio == true) 
                        {
                            Pedido.DireccionEnvio = textBoxDir.Text;
                            Pedido.ResponsableEnvio = comboBoxCargo.Text;                           
                        }

                    pedBLL.AltaPedido(Pedido);

                        MessageBox.Show("Pedido Emitito Correctamente");
                        this.Close();
                    }

                    catch (Exception ex)

                    { MessageBox.Show(ex.Message); }
                }

             }

         }
        public void PrecargaPedido() 
        
        {
            labelCli.Text = "";
            labrlPresup.Text = "";

            PresupuestoBE Pres = new PresupuestoBE();
            Pres = (PresupuestoBE)listBoxPresup.SelectedItem;

            Pedido = pedBLL.PresupuestoToPedido(Pres);

            dataGridItemsPedido.DataSource = null;
            dataGridItemsPedido.DataSource = Pedido.Items;

            labelCli.Text = Pedido.Cliente.RazonSocial;
            labrlPresup.Text = Convert.ToString(Pedido.Presupuesto.Id);

            labelImp.Text = "$ " + Convert.ToString(Pres.Iva);
            labelDesc.Text = "$ " + Convert.ToString(Pres.Descuento);
            labelTot.Text = "$ " + Convert.ToString(Pres.Total);

            checkBox1.Enabled = true;
            textBoxDir.Text = Pres.Cliente.Direccion;

        }

        private void buttonCargarPresup_Click(object sender, EventArgs e)
        {
            PrecargaPedido();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
         
                comboBoxCargo.Enabled = checkBox1.Checked;
                textBoxDir.Enabled = checkBox1.Checked;
            
        }

        private void buttonVerPres_Click(object sender, EventArgs e)
        {

            PresupuestoBE Pres = new PresupuestoBE();
            Pres = (PresupuestoBE)listBoxPresup.SelectedItem;

            if (Pres.Id != 0)

            {
                FormPresupuestoVisualizar FormV = new FormPresupuestoVisualizar();
                FormV.vPresup = Pres;
                FormV.MdiParent = this.ParentForm;
                FormV.Show();
            }

            else MessageBox.Show("Por favor, seleccione un Presupuesto de la Grilla");
        }
    
    }
}
