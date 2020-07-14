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
using Servicios;
using BLL;

namespace UI
{
    public partial class FormPresupuestoAnalisisComercialEjecutar : Form
    {
        public FormPresupuestoAnalisisComercialEjecutar()
        {
            InitializeComponent();
            comboBoxAccion.DataSource = Enum.GetValues(typeof(Accion));
            textBoxPresup.Text = Convert.ToString(oPresup.Id);
        }

        enum Accion : int { Aprobar = 1, Rechazar = 2 }
        public PresupuestoBE oPresup = new PresupuestoBE();
        PresupuestoAprobacionBE nAprob = new PresupuestoAprobacionBE();

        private void buttonConfirmar_Click(object sender, EventArgs e)
        {

            if (oPresup.AprobacionComercial == true && comboBoxAccion.Text == "Aprobar") { MessageBox.Show("El Presupuesto ya está Aprobado"); }

            else
            {
                DialogResult Respuesta = MessageBox.Show("Confirma " + comboBoxAccion.Text + "Presupuesto?", comboBoxAccion.Text, MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)

                {
                    nAprob.Presupuesto = oPresup;
                    nAprob.Aprobador = SesionSingleton.Instancia.Usuario;
                    nAprob.Fecha = DateTime.Now;
                    nAprob.TipoAprobacion = "Comercial";
                    nAprob.Accion = comboBoxAccion.Text;
                    nAprob.Observaciones = textBoxObs.Text;
                    PresupuestoBLL bllAp = new PresupuestoBLL();
                    bllAp.AnalisisComercial(nAprob);

                    MessageBox.Show("Operación realizada correctamente");

                    this.Close();

                }

            }
        }

        private void FormPresupuestoAnalisisComercialEjecutar_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void FormPresupuestoAnalisisComercialEjecutar_Load(object sender, EventArgs e)
        {
            textBoxPresup.Text = Convert.ToString(oPresup.Id);
        }
    }
}
