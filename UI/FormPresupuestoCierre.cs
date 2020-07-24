using BE;
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
using Servicios;

namespace UI
{
    public partial class FormPresupuestoCierre : Form
    {
        public FormPresupuestoCierre()
        {
            InitializeComponent();
        }
        enum Accion : int { Aprobar = 1, Rechazar = 2 }

        public PresupuestoBE cPresup = new PresupuestoBE();
       
        PresupuestoAprobacionBE nAprob = new PresupuestoAprobacionBE();
        private void FormPresupuestoCierre_Load(object sender, EventArgs e)
        {
            textBoxPre.Text = Convert.ToString(cPresup.Id);
            comboBoxTipo.DataSource = Enum.GetValues(typeof(Accion));
        }

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {
            if (cPresup.Estado.AprobacionCliente()==true) { MessageBox.Show("No es posible Realizar el Cierre en ele Estado Actual"); }

            else
            {
                DialogResult Respuesta = MessageBox.Show("Confirma Cierre del Presupuesto?", comboBoxTipo.Text, MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)

                {
                    nAprob.Presupuesto = cPresup;
                    nAprob.Aprobador = SesionSingleton.Instancia.Usuario;
                    nAprob.Fecha = DateTime.Now;
                    //nAprob.TipoAprobacion = "Cliente";
                    nAprob.Accion = comboBoxTipo.Text;
                    nAprob.Observaciones = textBoxObs.Text;
                    PresupuestoBLL bllAp = new PresupuestoBLL();
                    bllAp.Cierre(nAprob);

                    MessageBox.Show("Operación realizada correctamente");

                    this.Close();

                }
            }
        }
    }
}
