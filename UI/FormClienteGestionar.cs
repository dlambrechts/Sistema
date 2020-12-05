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
using Servicios;

namespace UI
{
    public partial class FormClienteGestionar : Form, IIdiomaObserver
    {
        public FormClienteGestionar()
        {
            InitializeComponent();
            Traducir();
        }
        public void UpdateLanguage(IdiomaBE idioma)
        {
            Traducir();
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

                if (button1.Tag != null && Traducciones.ContainsKey(button1.Tag.ToString()))
                    button1.Text = Traducciones[button1.Tag.ToString()].Texto;

                if (button2.Tag != null && Traducciones.ContainsKey(button2.Tag.ToString()))
                    button2.Text = Traducciones[button2.Tag.ToString()].Texto;

                if (buttonVer.Tag != null && Traducciones.ContainsKey(buttonVer.Tag.ToString()))
                    buttonVer.Text = Traducciones[buttonVer.Tag.ToString()].Texto;

                if (button4.Tag != null && Traducciones.ContainsKey(button4.Tag.ToString()))
                    button4.Text = Traducciones[button4.Tag.ToString()].Texto;

                if (button3.Tag != null && Traducciones.ContainsKey(button3.Tag.ToString()))
                    button3.Text = Traducciones[button3.Tag.ToString()].Texto;

                if (groupBox1.Tag != null && Traducciones.ContainsKey(groupBox1.Tag.ToString()))
                    groupBox1.Text = Traducciones[groupBox1.Tag.ToString()].Texto;

                if (groupBox2.Tag != null && Traducciones.ContainsKey(groupBox2.Tag.ToString()))
                    groupBox2.Text = Traducciones[groupBox2.Tag.ToString()].Texto;

            }

        }

        private BLL.ClienteBLL bllCli = new ClienteBLL();
        public BE.ClienteBE beCli = new ClienteBE();
        List<ClienteBE> LisCLi = new List<ClienteBE>();
        private void button1_Click(object sender, EventArgs e)
        {
            
            FormClienteAlta frmCliAlta = new FormClienteAlta();
            frmCliAlta.MdiParent = this.ParentForm;
            frmCliAlta.FormClosed += new FormClosedEventHandler(frmCliAlta_FormClosed);
            frmCliAlta.Show();
        }

        private void frmCliAlta_FormClosed (object sender, FormClosedEventArgs e)
        {
            LeerClientes();
        }

        private void frmEdit_FormClosed(object sender, FormClosedEventArgs e)
        {
            LeerClientes();
        }

       

        private void FormClienteGestionar_Load(object sender, EventArgs e)
        {
            SesionSingleton.Instancia.SuscribirObs(this);
            LeerClientes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(beCli.RazonSocial==null) { MessageBox.Show("Debe seleccionar un Cliente"); }

            else { 

            FormClienteEditar frmEdit = new FormClienteEditar();
            frmEdit.Cli = beCli;
            frmEdit.MdiParent = this.ParentForm;
            frmEdit.FormClosed += new FormClosedEventHandler(frmEdit_FormClosed);
            frmEdit.Show();

            }
        }
        public void LeerClientes()

        {
            LisCLi.Clear();
            LisCLi = bllCli.ListarClientes();
            dataGridClientes.DataSource = null;
            BindingList<ClienteBE> cList = new BindingList<ClienteBE>(LisCLi);
            dataGridClientes.DataSource =cList;
            dataGridClientes.Columns["_UsuarioCreacion"].Visible = false;
            dataGridClientes.Columns["_UsuarioModificacion"].Visible = false;
            dataGridClientes.Columns["FechaModificacion"].Visible = false;
            dataGridClientes.Columns["FechaCreacion"].Visible = false;
        }

        private void dataGridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            beCli = (ClienteBE)dataGridClientes.CurrentRow.DataBoundItem;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (beCli.Id == 0) { MessageBox.Show("Debe seleccionar un Cliente para Eliminar"); }

            else
            {

                DialogResult Respuesta = MessageBox.Show("¿Eliminar Cliente " + beCli.Id + "?", "Eliminar Cliente", MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)
                {
                    if (bllCli.ExisteClienteEnPresupuesto(beCli) == true) 
                    
                        { MessageBox.Show("No es posible Eliminar. El Cliente tiene Presupuestos asociados "); }

                    else 
                        {
                        bllCli.EliminarCliente(beCli);
                        MessageBox.Show("Cliente Eliminado");
                        LeerClientes();
                    }

                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (beCli.RazonSocial == null) { MessageBox.Show("Debe seleccionar un Cliente"); }

                else
                {

                    FormClienteVersion frmVer = new FormClienteVersion();
                    frmVer.Cli = beCli;

                    if (bllCli.ListarVersionesClientePorId(beCli).Count == 0) { MessageBox.Show("No existen versiones para el cliente " + beCli.Id); }

                    else { 
                    frmVer.MdiParent = this.ParentForm;
                    frmVer.FormClosed += new FormClosedEventHandler(frmEdit_FormClosed);
                    frmVer.Show();
                    }

                }
            }
        }

        private void buttonVer_Click(object sender, EventArgs e)
        {
            if (beCli.RazonSocial == null) { MessageBox.Show("Debe seleccionar un Cliente"); }

            else
            {

                FormClienteVer frmVer = new FormClienteVer();
                frmVer.cliente = beCli;
                frmVer.MdiParent = this.ParentForm;
                frmVer.Show();

            }
        }
    }
}
