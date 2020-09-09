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
    public partial class FormProductoEditar : Form
    {
        public FormProductoEditar()
        {
            InitializeComponent();
            CompletarTipos();
            CompletarUnidades();

        }

        public ProductoBE eProd = new ProductoBE();
        ProductoBLL bllProd = new ProductoBLL();

        public void CompletarTipos()

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
            if (textDescrip.Text == "") { MessageBox.Show("Por favor, ingrese una Descripción"); }

            else 
            
            {
                ProductoBE eProducto = new ProductoBE();

                eProducto.Id = eProd.Id;
                eProducto.Descripcion = textDescrip.Text;
                eProducto.tipo = (ProductoTipoBE)comboTipo.SelectedItem;
                eProducto.um = (ProductoUnidadMedidaBE)comboUnMedi.SelectedItem;
                eProducto.Precio = Convert.ToDecimal(textPrecio.Text);
                eProducto.Iva = Convert.ToDecimal(comboIva.Text);
                eProducto.Activo = checkBox1.Checked;
          
                bllProd.EditarProducto(eProducto);

                MessageBox.Show("Producto Modificado Correctamente");
                this.Close();

            }
        }

        private void FormProductoEditar_Load(object sender, EventArgs e)
        {
            textDescrip.Text = eProd.Descripcion;
            comboTipo.SelectedIndex = comboTipo.FindStringExact(eProd.tipo.Tipo);
            comboUnMedi.SelectedIndex = comboUnMedi.FindStringExact(eProd.UnidadMedida.Descripcion);
            textPrecio.Text = Convert.ToString(eProd.Precio);
            checkBox1.Checked = eProd.Activo;
            comboIva.Text = eProd.Iva.ToString(); ;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
