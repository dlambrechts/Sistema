using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Servicios;

namespace UI
{
    public partial class FormPresupuestoAlta : Form
    {
        public FormPresupuestoAlta()
        {
            InitializeComponent();
            ActualizarGrillaItems();
            comboDescuento.SelectedItem = 0;
            dateTimePicker1.Value = DateTime.Now.AddDays(15);
            dateTimePickerVal.Value = DateTime.Now.AddDays(30);
        }
 
        PresupuestoBE nPresupuesto = new PresupuestoBE();
        PresupuestoBLL bllPresupuesto = new PresupuestoBLL();     
        float subtotal=0;
        float valordesc = 0;
        float total = 0;

        public void ActualizarGrillaItems() 
        
        {
            BindingList<PresupuestoItemBE> ListaItems = new BindingList<PresupuestoItemBE>(nPresupuesto.Items);

            this.dataGridViewItems.DataSource = null;
            this.dataGridViewItems.DataSource = ListaItems;
            this.dataGridViewItems.Columns[0].HeaderText = "Item";
            this.dataGridViewItems.Columns[0].Width = 250;       
        }
        public void ActualizarTotales() 
        
        {
            subtotal = bllPresupuesto.CalcularSubTotal(nPresupuesto.Items);
            valordesc = bllPresupuesto.CalcularDescuento(subtotal, Convert.ToInt32(comboDescuento.Text));
            total = bllPresupuesto.CalcularTotal(valordesc,subtotal);
            labelSubt.Text = "$ " + Convert.ToString(subtotal);
            labelDesc.Text = "$ " + Convert.ToString(valordesc);
            labelTot.Text = "$ " + Convert.ToString(total);
        }

        private void FormPresupuestoAlta_Load(object sender, EventArgs e)
        {
            ObtenerClientes();
            ObtenerProductos();
        }

        public void ObtenerClientes() 
        {
            ClienteBLL bllCli = new ClienteBLL();
            comboCliente.DataSource = null;
            comboCliente.DataSource = bllCli.ListarClientes();
        }

        public void ObtenerProductos()        
        {
            ProductoBLL bllProd = new ProductoBLL();
            comboProducto.DataSource = null;
            comboProducto.DataSource = bllProd.ListarProductos();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PresupuestoItemBE nItem = new PresupuestoItemBE();
            ProductoBE selProd = new ProductoBE();
            
            selProd = (ProductoBE)comboProducto.SelectedItem;

            if (nPresupuesto.ExisteItem(selProd) == true) { MessageBox.Show("El Item ya fue cargado");}

            else
            {

                int cantidad = Convert.ToInt32(numericCant.Value);


                if (selProd.Stock < cantidad)
                {
                    DialogResult Respuesta = MessageBox.Show("Actualmente no hay Stock suficiente. ¿Agregar Item de todas formas?", "Advertencia Stock", MessageBoxButtons.YesNo);

                    if (Respuesta == DialogResult.Yes)
                    {
                        nPresupuesto.AgregarItems(selProd, cantidad);
                        ActualizarGrillaItems();
                        ActualizarTotales();
                    }
                }
                else

                {
                    nPresupuesto.AgregarItems(selProd, cantidad);
                    ActualizarGrillaItems();
                    ActualizarTotales();
                }


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta = MessageBox.Show("Confirma Emisión del Presupuesto?", "Generar Presupuesto", MessageBoxButtons.YesNo);
            
            if (Respuesta == DialogResult.Yes)
            {
                nPresupuesto.Cliente = (ClienteBE)comboCliente.SelectedItem;                      
                nPresupuesto.Vendedor = SesionSingleton.Instancia.Usuario;
                nPresupuesto.FechaEmision = DateTime.Now;
                nPresupuesto.Estado = "Emitido";
                nPresupuesto.FechaEntrega = dateTimePicker1.Value;
                nPresupuesto.FechaValidez = dateTimePickerVal.Value;
                nPresupuesto.Descuento = valordesc;
                nPresupuesto.Total = total;
                nPresupuesto.Observaciones = textBoxObs.Text;

                bllPresupuesto.AltaPresupuesto(nPresupuesto);

                ReiniciarValores();
                MessageBox.Show("Presupuesto emitido correctamente");

            }                     
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }

        public void ReiniciarValores() 
        
        {
            nPresupuesto.Items.Clear();
            comboDescuento.SelectedItem = 0;
            dateTimePicker1.Value = DateTime.Now.AddDays(15);           
            dateTimePickerVal.Value = DateTime.Now.AddDays(30);
            textBoxObs.Text = "";
            ObtenerProductos();
            ObtenerClientes();
            ActualizarGrillaItems();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProductoBE tempProd = new ProductoBE();
            tempProd =(ProductoBE)comboProducto.SelectedItem;
            MessageBox.Show("La cantidad Actual para " + tempProd.Descripcion + " es: " + tempProd.Stock + " " + tempProd.UnidadMedida);
        }

        private void buttonQuitarItem_Click(object sender, EventArgs e)
        {

            if (nPresupuesto.Items.Count > 0) 
            
            { 
                PresupuestoItemBE tempItem = new PresupuestoItemBE();
                tempItem = (PresupuestoItemBE)dataGridViewItems.CurrentRow.DataBoundItem;
                nPresupuesto.QuitarItem(tempItem.Producto);
                ActualizarGrillaItems();
                ActualizarTotales();

            }
        }

        private void dataGridViewItems_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
