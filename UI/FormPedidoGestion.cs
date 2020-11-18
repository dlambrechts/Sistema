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
using Servicios;

namespace UI
{
    public partial class FormPedidoGestion : Form, IIdiomaObserver
    {
        public FormPedidoGestion()
        {
            InitializeComponent();
            Traducir();
        }

        public void UpdateLanguage(IdiomaBE idioma)
        {
            Traducir();
        }

        PedidoBLL pBLL = new PedidoBLL();
        PedidoBE selPed;
        private void buttonNuevo_Click(object sender, EventArgs e)
        {
            FormPedidoAlta Alta = new FormPedidoAlta();
            Alta.MdiParent = this.ParentForm;
            Alta.FormClosed += new FormClosedEventHandler(Alta_FormClosed);
            Alta.Show();
        }

        private void FormPedidoGestion_Load(object sender, EventArgs e)
        {
            CargarPedidos();
            SesionSingleton.Instancia.SuscribirObs(this);
        }

        private void Alta_FormClosed(object sender, FormClosedEventArgs e)
        {
            CargarPedidos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            selPed = (PedidoBE)dataGridViewPedidos.CurrentRow.DataBoundItem;
        }

        public void CargarPedidos()

        {
            dataGridViewPedidos.DataSource = null;
            dataGridViewPedidos.DataSource = pBLL.ListarPedidos();

        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            if (selPed == null) { MessageBox.Show("Debe seleccionar un Pedido"); }

            else 
            
            { 
            FormPedidoVisualizar fVer = new FormPedidoVisualizar();
            fVer.Pedido = selPed;
            fVer.MdiParent = this.ParentForm;
            fVer.Show();
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            if (selPed == null) { MessageBox.Show("Debe seleccionar un Pedido"); }

            else

            {
                FormPedidoEditar fEdit = new FormPedidoEditar();
                fEdit.Pedido = selPed;
                fEdit.MdiParent = this.ParentForm;
                fEdit.FormClosed += new FormClosedEventHandler(Alta_FormClosed);
                fEdit.Show();
            }
        }

        private void buttonEliminar_Click(object sender, EventArgs e)
        {

            if (selPed.Id != 0) 
            
            { 
                DialogResult Respuesta = MessageBox.Show("Confirma Eliminar el Pedido "+selPed.Id+"?", "Eliminar", MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)

                {
                    pBLL.Eliminar(selPed);
                    MessageBox.Show("Pedido Eliminado");
                    CargarPedidos();
                }

            }

            else { MessageBox.Show("Debe seleccionar un Pedido"); }

        }

        private void Traducir()

        {
            IdiomaBE Idioma = null;

            if (SesionSingleton.Instancia.IsLogged()) Idioma = SesionSingleton.Instancia.Usuario.Idioma;

            var Traducciones = TraductorBLL.ObtenerTraducciones(Idioma);

            if (Traducciones != null) // Al crear un idioma nuevo y utilizarlo no habrá traducciones, por lo tanto es necesario consultar si es null
            {

                if (this.Tag != null && Traducciones.ContainsKey(this.Tag.ToString()))  // Título del form
                    this.Text = Traducciones[this.Tag.ToString()].Texto;

                if (groupBox1.Tag != null && Traducciones.ContainsKey(groupBox1.Tag.ToString()))
                    groupBox1.Text = Traducciones[groupBox1.Tag.ToString()].Texto;

                if (buttonNuevo.Tag != null && Traducciones.ContainsKey(buttonNuevo.Tag.ToString()))
                    buttonNuevo.Text = Traducciones[buttonNuevo.Tag.ToString()].Texto;

                if (buttonVer.Tag != null && Traducciones.ContainsKey(buttonVer.Tag.ToString()))
                    buttonVer.Text = Traducciones[buttonVer.Tag.ToString()].Texto;

                if (buttonEditar.Tag != null && Traducciones.ContainsKey(buttonEditar.Tag.ToString()))
                    buttonEditar.Text = Traducciones[buttonEditar.Tag.ToString()].Texto;

                if (buttonEliminar.Tag != null && Traducciones.ContainsKey(buttonEliminar.Tag.ToString()))
                    buttonEliminar.Text = Traducciones[buttonEliminar.Tag.ToString()].Texto;

                if (groupBox2.Tag != null && Traducciones.ContainsKey(groupBox2.Tag.ToString()))
                    groupBox2.Text = Traducciones[groupBox2.Tag.ToString()].Texto;

            }

        }
    }
}
