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
    public partial class FormPresupuestoVisualizar : Form
    {
        public FormPresupuestoVisualizar()
        {
            InitializeComponent();
        }

        public PresupuestoBE vPresup = new PresupuestoBE();
       

        private void FormPresupuestoVisualizar_Load(object sender, EventArgs e)
        {
            CompletarDatosPresupuesto();
            groupBoxCabecera.Text += " " +Convert.ToString(vPresup.Id);
            labelCli.Text = Convert.ToString(vPresup.Cliente.RazonSocial) + " (" + vPresup.Cliente.Id + ")";
            labelVen.Text = vPresup.Vendedor.ToString();
            labelDesc.Text = "$ "+ Convert.ToString(vPresup.Descuento);
            labelTot.Text = "$ " +Convert.ToString(vPresup.Total);
            labelEmis.Text = Convert.ToString(vPresup.FechaEmision.Date.ToShortDateString()) ;
            labelVal.Text = Convert.ToString(vPresup.FechaValidez.Date.ToShortDateString());
            labelEnt.Text = Convert.ToString(vPresup.FechaEntrega.Date.ToShortDateString());
            labelEst.Text = vPresup.Estado;
            checkBoxApTec.Checked = vPresup.AprobacionTecnica;
            checkBoxApCom.Checked = vPresup.AprobacionComercial;
            textBoxObs.Text = vPresup.Observaciones;

            CargarItemsEnGrilla();
            CargarHitorial();
        }


        public void CompletarDatosPresupuesto() 
        {
            PresupuestoBLL bllPresup = new PresupuestoBLL();
            ClienteBLL bllCli = new ClienteBLL();
            UsuarioBLL bllUs = new UsuarioBLL();

            vPresup = bllPresup.SeleccionarPresupuestoPorId(vPresup.Id);
            vPresup.Cliente = bllCli.SeleccionarPorId(vPresup.Cliente.Id);
            vPresup.Vendedor = bllUs.SeleccionarUsuarioPorId(vPresup.Vendedor.Id);           
        }

        public void CargarItemsEnGrilla() 
        {
       
            BindingList<PresupuestoItemBE> Items = new BindingList<PresupuestoItemBE>(vPresup.Items);
            dataGridViewItems.DataSource = null;
            dataGridViewItems.DataSource = Items;
            this.dataGridViewItems.Columns[0].HeaderText = "Item";
            this.dataGridViewItems.Columns[0].Width = 250;
        }

        public void CargarHitorial() 
        
        {
            PresupuestoBLL bllPresup = new PresupuestoBLL();
            List<PresupuestoAprobacionBE> Historial = new List<PresupuestoAprobacionBE>();
            Historial = bllPresup.HistorialAnalisis(vPresup);
            BindingList<PresupuestoAprobacionBE> hist = new BindingList<PresupuestoAprobacionBE>(Historial);
            this.dataGridViewAprob.DataSource = null;
            this.dataGridViewAprob.DataSource = hist;

            this.dataGridViewAprob.Columns[0].Visible = false;
            this.dataGridViewAprob.Columns[2].HeaderText = "Aprobador";
            this.dataGridViewAprob.Columns[5].Width = 250;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
