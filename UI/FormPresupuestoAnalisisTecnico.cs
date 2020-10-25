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
using Servicios.Bitacora;

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
                ListaFiltrada = ListaPresupuestos.Where(x => x.Estado.GetType().Name =="ApTecPend").ToList();
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
            if (selPres.Id == 0) { MessageBox.Show("Por favor, seleccione un Presupuesto"); }

           
            else {

                
                if (selPres.Estado.AprobacionTecnica() == true || selPres.Estado.RechazoTecnico() == true)

                {

                    FormPresupuestoAnalisisTecnicoEjecutar frPreAprob = new FormPresupuestoAnalisisTecnicoEjecutar();
                    frPreAprob.oPresup = selPres;
                    frPreAprob.MdiParent = this.ParentForm;
                    frPreAprob.FormClosed += new FormClosedEventHandler(frPrepAprob_FormClosed);

                    frPreAprob.Show();
                }
                else
                {

                    MessageBox.Show("No es posible realizar el Análisis Técnico en el Estado actual");

                    BitacoraActividadBE nActividad = new BitacoraActividadBE();
                    BitacoraBLL bllAct = new BitacoraBLL();
                //    nActividad.Clasificacion = (BitacoraClasifActividad)System.Enum.Parse(typeof(BitacoraClasifActividad), "Advertencia");
                    nActividad.Detalle = "Análisis Técnico no es posible para el Presupuesto N° " + selPres.Id + " en el estado actual";
                    bllAct.NuevaActividad(nActividad);
                }

                
            }
        }

        private void frPrepAprob_FormClosed(object sende, EventArgs e)
        
        {
            ObtenerPresupuestos();
            CargarGrilla();
        }

        private void dataGridViewPresup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            
            selPres = (PresupuestoBE)dataGridViewPresup.CurrentRow.DataBoundItem;
           
        }

        private void buttonVis_Click(object sender, EventArgs e)
        {

            if (selPres.Id != 0)

            {
                FormPresupuestoVisualizar FormV = new FormPresupuestoVisualizar();
                FormV.vPresup = selPres;
                FormV.MdiParent = this.ParentForm;
                FormV.Show();
            }

            else MessageBox.Show("Por favor, seleccione un Presupuesto de la Grilla");
        }
    }
}
