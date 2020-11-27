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
    public partial class FormProductoAlta : Form
    {
        public FormProductoAlta()
        {
            InitializeComponent();
            CompletarTipos();
            CompletarUnidades();
        }

        private BLL.ProductoBLL bllProd = new ProductoBLL();

        public void CompletarTipos ()
        
        {
            comboTipo.DataSource = null;
            comboTipo.DataSource = bllProd.ListarTipoProducto();
        }

        public void CompletarUnidades() 
        
        {
            comboUnMedi.DataSource = null;
            comboUnMedi.DataSource = bllProd.ListarUnidadesMedida();
        }
        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (textDescrip.Text=="") { MessageBox.Show("Por favor, ingrese una Descripción"); }

            else 
            
            {
                try { 
                ProductoBE nProducto = new ProductoBE();

                nProducto.Descripcion = textDescrip.Text;
                nProducto.tipo = (ProductoTipoBE)comboTipo.SelectedItem;
                nProducto.um = (ProductoUnidadMedidaBE)comboUnMedi.SelectedItem;
                nProducto.Stock = Convert.ToInt32(numericStock.Value);
                nProducto.Precio = Convert.ToDecimal(textPrecio.Text);
                nProducto.Iva = Convert.ToDecimal(comboIva.Text);

                
                bllProd.AltaProducto(nProducto);

                MessageBox.Show("Producto Creado Correctamente");
                this.Close();
                }

                catch (Exception ex)

                {
                    MessageBox.Show(ex.Message);

                }
            }
        }

        private void FormProductoAlta_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
