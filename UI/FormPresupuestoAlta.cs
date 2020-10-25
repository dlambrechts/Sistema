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
using Servicios.Bitacora;

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
        decimal subtotal=0;
        decimal valordesc = 0;
        decimal totalIva = 0;
        decimal total = 0;

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
            totalIva = bllPresupuesto.CalcularTotalIva(nPresupuesto);
            total = bllPresupuesto.CalcularTotal(valordesc,subtotal);
            labelSubt.Text = "$ " + subtotal.ToString("0.##");
            labelTotIva.Text = "$ " + totalIva.ToString("0.##");
            labelDesc.Text = "$ " + valordesc.ToString("0.##");
            labelTot.Text = "$ " + total.ToString("0.##");
            numericCant.Value = 1;
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

            if (nPresupuesto.Items.Count == 0)

            { MessageBox.Show("Debe agregar al menos un Item"); }


            else
            {
                DialogResult Respuesta = MessageBox.Show("Confirma Emisión del Presupuesto?", "Generar Presupuesto", MessageBoxButtons.YesNo);
          

           
                    if (Respuesta == DialogResult.Yes)
                    {

                    try { 
                        nPresupuesto.Cliente = (ClienteBE)comboCliente.SelectedItem;                      
                        nPresupuesto.Vendedor = SesionSingleton.Instancia.Usuario;
                        nPresupuesto.FechaEmision = DateTime.Now;                        
                        nPresupuesto.FechaEntrega = dateTimePicker1.Value;
                        nPresupuesto.FechaValidez = dateTimePickerVal.Value;
                        nPresupuesto.PorcDescuento = Convert.ToInt32(comboDescuento.Text);
                        nPresupuesto.Descuento = valordesc;
                        nPresupuesto.Total = total;
                        nPresupuesto.Observaciones = textBoxObs.Text;
                        nPresupuesto.Iva = totalIva;

                        bllPresupuesto.AltaPresupuesto(nPresupuesto);

                        MessageBox.Show("Presupuesto Emitido correctamente");
                    }

                    catch (Exception Ex) 
                    
                    {
                        BitacoraActividadBE nActividad = new BitacoraActividadBE();
                        BitacoraBLL bllAct = new BitacoraBLL();
                      //  nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Error");
                        nActividad.Detalle = "Error en alta de Presupuesto: " + Ex.Message ;
                        bllAct.NuevaActividad(nActividad);

                        MessageBox.Show(Ex.Message);

                    }
                        

                        this.Close();

                    }

             }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void comboDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
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
