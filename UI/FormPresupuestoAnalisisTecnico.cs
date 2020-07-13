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
    public partial class FormPresupuestoAnalisisTecnico : Form
    {
        public FormPresupuestoAnalisisTecnico()
        {
            InitializeComponent();
        }
        PresupuestoBLL bllPresup = new PresupuestoBLL();
        List<PresupuestoBE> ListaPresupuestos = new List<PresupuestoBE>();
        PresupuestoBE selPres = new PresupuestoBE();
        private void FormPresupuestoAnalisisTecnico_Load(object sender, EventArgs e)
        {
            ObtenerPresupuestos();
            CargarGrilla();
        }

        public void ObtenerPresupuestos() 
        
        {
            ListaPresupuestos = bllPresup.ListarPresupuestos();
            ClienteBLL bllCli = new ClienteBLL();
            UsuarioBLL bllUs = new UsuarioBLL();
            foreach (PresupuestoBE item in ListaPresupuestos)
            {
                item.Cliente = bllCli.SeleccionarPorId(item.Cliente.Id);
                item.Vendedor = bllUs.SeleccionarUsuarioPorId(item.Vendedor.Id);
            }

        }
        public void CargarGrilla()

        {
            dataGridViewPresup.DataSource = null;

            if (radioPendientes.Checked==true)
            {
                List<PresupuestoBE> ListaFiltrada = new List<PresupuestoBE>();
                ListaFiltrada = ListaPresupuestos.Where(x => x.AprobacionTecnica == false).ToList();
                BindingList<PresupuestoBE> bList = new BindingList<PresupuestoBE>(ListaFiltrada);
                dataGridViewPresup.DataSource = bList;
            }

            else 
            
            {
                BindingList<PresupuestoBE> bList = new BindingList<PresupuestoBE>(ListaPresupuestos);
                dataGridViewPresup.DataSource = bList;
            }
            
        }

        private void radioPendientes_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void radioButtonTodos_CheckedChanged(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void buttonAp_Click(object sender, EventArgs e)
        {
            if (selPres.Id == 0) { MessageBox.Show("Por favor, selecciones un Presupuesto"); }
            else 
            { 
            FormPresupuestoAnalisisTecnicoEjecutar frPreAprob = new FormPresupuestoAnalisisTecnicoEjecutar();
            frPreAprob.oPresup = selPres;
            frPreAprob.MdiParent = this.ParentForm;
            frPreAprob.Show();

            }
        }

        private void dataGridViewPresup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            selPres.Id = Convert.ToInt32(dataGridViewPresup.Rows[e.RowIndex].Cells[0].Value);
        }
    }
}
