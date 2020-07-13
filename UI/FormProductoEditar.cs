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
            comboTipo.DataSource = Enum.GetValues(typeof(TipoProd));
            comboUnMedi.DataSource = Enum.GetValues(typeof(UnidadMedida));

        }

        enum TipoProd : int { Terminado = 1, Repuesto = 2, Insumo = 3, SemiElaborado = 4,Servicio=5 }
        enum UnidadMedida : int { Unidad = 1, Metro = 2, Kg = 3, Litro = 4 }

        public ProductoBE eProd = new ProductoBE();
        
        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (textDescrip.Text == "") { MessageBox.Show("Por favor, ingrese una Descripción"); }

            else 
            
            {
                ProductoBE eProducto = new ProductoBE();

                eProducto.Id = eProd.Id;
                eProducto.Descripcion = textDescrip.Text;
                eProducto.Tipo = comboTipo.Text;
                eProducto.UnidadMedida = comboUnMedi.Text;
                eProducto.Precio = (float)Convert.ToDouble(textPrecio.Text);
                eProducto.Activo = checkBox1.Checked;

                ProductoBLL bllProd = new ProductoBLL();
                bllProd.EditarProducto(eProducto);

                MessageBox.Show("Producto Modificado Correctamente");
                this.Close();

            }
        }

        private void FormProductoEditar_Load(object sender, EventArgs e)
        {
            textDescrip.Text = eProd.Descripcion;
            comboTipo.Text = eProd.Tipo;
            comboUnMedi.Text = eProd.UnidadMedida;
            textPrecio.Text = Convert.ToString(eProd.Precio);
            checkBox1.Checked = eProd.Activo;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
