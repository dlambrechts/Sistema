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
        }

        

        PresupuestoBE nPresupuesto = new PresupuestoBE();
        PresupuestoBLL bllPresupuesto = new PresupuestoBLL();
        BindingList<PresupuestoItemBE> Items = new BindingList<PresupuestoItemBE>();
        float subtotal=0;
        float valordesc = 0;
        float total = 0;

        public void ActualizarGrillaItems() 
        
        {
           
            this.dataGridViewItems.DataSource = null;
            this.dataGridViewItems.DataSource = Items;
            this.dataGridViewItems.Columns[0].HeaderText = "Item";
            this.dataGridViewItems.Columns[0].Width = 250;
          
        }
        

        public void ActualizarTotales() 
        
        {
            subtotal = bllPresupuesto.CalcularSubTotal(Items);
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

            int cantidad = Convert.ToInt32(numericCant.Value);

            if  (selProd.Stock < cantidad)
                {
                    MessageBox.Show("No hay Stock suficiente");
                }

                else 
                
                {
                    nItem.Cantidad = cantidad;
                    nItem.Producto = selProd;
                    nItem.PrecioUnitario = selProd.Precio;
                    nItem.TotalItem = selProd.Precio*nItem.Cantidad;

                    Items.Add(nItem);
                    
                    
                    ActualizarGrillaItems();
                    ActualizarTotales();                   
                }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult Respuesta = MessageBox.Show("Confirma Emisión del Presupuesto?", "Generar Presupuesto", MessageBoxButtons.YesNo);
            
            if (Respuesta == DialogResult.Yes)
            {
                nPresupuesto.Cliente = (ClienteBE)comboCliente.SelectedItem;
                nPresupuesto.Items = new List<PresupuestoItemBE>();
                nPresupuesto.Items = Items.ToList();
                nPresupuesto.Vendedor = SesionSingleton.Instancia.Usuario;
                nPresupuesto.FechaEmision = DateTime.Now;
                nPresupuesto.Estado = "Emitido";
                nPresupuesto.FechaEntrega = dateTimePicker1.Value;
                nPresupuesto.Descuento = valordesc;
                nPresupuesto.Total = total;

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
            Items.Clear();
            comboDescuento.SelectedItem = 0;
            dateTimePicker1.Value = DateTime.Now.AddDays(15);
            ObtenerProductos();
            ObtenerClientes();
        }
    }
}
