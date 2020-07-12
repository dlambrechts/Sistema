using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace UI
{
    public partial class FormPresupuestoGestion : Form
    {
        public FormPresupuestoGestion()
        {
            InitializeComponent();
            CargarGrilla();
        }

        PresupuestoBLL bllPresup = new PresupuestoBLL();
        List<PresupuestoBE> ListaPresupuestos = new List<PresupuestoBE>();
        
        private void button1_Click(object sender, EventArgs e)
        {
            FormPresupuestoAlta fNuevo = new FormPresupuestoAlta();
            fNuevo.MdiParent = this.ParentForm;
            fNuevo.Show();
        }

        private void FormPresupuestoGestion_Load(object sender, EventArgs e)
        {

        }

        public void CargarGrilla() 
        
        {
            ListaPresupuestos = bllPresup.ListarPresupuestos();
            ClienteBLL bllCli = new ClienteBLL();
            UsuarioBLL bllUs = new UsuarioBLL();
            foreach (PresupuestoBE item in ListaPresupuestos)
            {
                item.Cliente = bllCli.SeleccionarPorId(item.Cliente.Id);
                item.Vendedor = bllUs.SeleccionarUsuarioPorId(item.Vendedor.Id);
            }

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ListaPresupuestos;
        }

    


        
    }
}
