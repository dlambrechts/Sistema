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
using BE.PresupuestoEstado;
using BLL;
using Servicios;

namespace UI
{
    public partial class FormPresupuestoEditar : Form
    {
        public FormPresupuestoEditar()
        {
            InitializeComponent();
        }

        public PresupuestoBE ePresupuesto = new PresupuestoBE();
        public PresupuestoBLL bllPresupuesto = new PresupuestoBLL();
        private void FormPresupuestoEditar_Load(object sender, EventArgs e)
        {
            ePresupuesto = bllPresupuesto.SeleccionarPresupuestoPorId(ePresupuesto.Id);
            ObtenerClientes();
            ObtenerProductos();
            ActualizarGrillaItems();
            CargarDatosCabecera();
            ActualizarTotales();
        }

        decimal subtotal = 0;
        decimal valordesc = 0;
        decimal totalIva = 0;
        decimal total = 0;

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

        public void CargarDatosCabecera()

        {
            this.Text += " " + ePresupuesto.Id.ToString();
            dateTimePicker1.Value = ePresupuesto.FechaEntrega.ToUniversalTime();
            dateTimePickerVal.Value = ePresupuesto.FechaValidez.ToUniversalTime();
            comboCliente.Text = ePresupuesto.Cliente.ToString();
            comboDescuento.Text = ePresupuesto.PorcDescuento.ToString();
            textBoxObs.Text = ePresupuesto.Observaciones;

        }
        public void ActualizarGrillaItems()

        {
            BindingList<PresupuestoItemBE> ListaItems = new BindingList<PresupuestoItemBE>(ePresupuesto.Items);

            this.dataGridViewItems.DataSource = null;
            this.dataGridViewItems.DataSource = ListaItems;
            this.dataGridViewItems.Columns[0].HeaderText = "Item";
            this.dataGridViewItems.Columns[0].Width = 250;
        }
        public void ActualizarTotales()

        {
            subtotal = bllPresupuesto.CalcularSubTotal(ePresupuesto.Items);
            valordesc = bllPresupuesto.CalcularDescuento(subtotal, Convert.ToInt32(comboDescuento.Text));
            totalIva = bllPresupuesto.CalcularTotalIva(ePresupuesto);
            total = bllPresupuesto.CalcularTotal(valordesc, subtotal);
            labelSubt.Text = "$ " + subtotal.ToString("0.##");
            labelTotIva.Text = "$ " + totalIva.ToString("0.##");
            labelDesc.Text = "$ " + valordesc.ToString("0.##");
            labelTot.Text = "$ " + total.ToString("0.##");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PresupuestoItemBE nItem = new PresupuestoItemBE();
            ProductoBE selProd = new ProductoBE();

            selProd = (ProductoBE)comboProducto.SelectedItem;

            if (ePresupuesto.ExisteItem(selProd) == true) { MessageBox.Show("El Item ya fue cargado"); }

            else
            {

                int cantidad = Convert.ToInt32(numericCant.Value);


                if (selProd.Stock < cantidad)
                {
                    DialogResult Respuesta = MessageBox.Show("Actualmente no hay Stock suficiente. ¿Agregar Item de todas formas?", "Advertencia Stock", MessageBoxButtons.YesNo);

                    if (Respuesta == DialogResult.Yes)
                    {
                        ePresupuesto.AgregarItems(selProd, cantidad);
                        ActualizarGrillaItems();
                        ActualizarTotales();
                    }
                }
                else

                {
                    ePresupuesto.AgregarItems(selProd, cantidad);
                    ActualizarGrillaItems();
                    ActualizarTotales();
                }


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            ProductoBE tempProd = new ProductoBE();
            tempProd = (ProductoBE)comboProducto.SelectedItem;
            MessageBox.Show("La cantidad Actual para " + tempProd.Descripcion + " es: " + tempProd.Stock + " " + tempProd.UnidadMedida);
        }

        private void buttonQuitarItem_Click(object sender, EventArgs e)
        {
            if (ePresupuesto.Items.Count > 0)

            {
                PresupuestoItemBE tempItem = new PresupuestoItemBE();
                tempItem = (PresupuestoItemBE)dataGridViewItems.CurrentRow.DataBoundItem;
                ePresupuesto.QuitarItem(tempItem.Producto);
                ActualizarGrillaItems();
                ActualizarTotales();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (ePresupuesto.Items.Count == 0)

            { MessageBox.Show("Debe agregar al menos un Item"); }


            else
            {
                DialogResult Respuesta = MessageBox.Show("Confirma Edición del Presupuesto?", "Editar Presupuesto", MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)
                {

                    ePresupuesto.Cliente = (ClienteBE)comboCliente.SelectedItem;
                    ePresupuesto.Vendedor = SesionSingleton.Instancia.Usuario;
                    ePresupuesto.Estado = new ApTecPend() ;                                 // Al editar vuelve a estar pendiente de Aprobación Técnica
                    ePresupuesto.FechaEntrega = dateTimePicker1.Value;
                    ePresupuesto.FechaValidez = dateTimePickerVal.Value;
                    ePresupuesto.PorcDescuento = Convert.ToInt32(comboDescuento.Text);
                    ePresupuesto.Descuento = valordesc;
                    ePresupuesto.Total = total;
                    ePresupuesto.Observaciones = textBoxObs.Text;
                    ePresupuesto.Iva = totalIva;

                    bllPresupuesto.EditarPresupuesto(ePresupuesto);

                    MessageBox.Show("Presupuesto Editado correctamente");

                    this.Close();
                }
            }
        }

        private void comboDescuento_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActualizarTotales();
        }
    }
}
