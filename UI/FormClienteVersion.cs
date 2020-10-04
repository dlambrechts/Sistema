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
    public partial class FormClienteVersion : Form
    {
        public FormClienteVersion()
        {
            InitializeComponent();
        }

        public ClienteBE Cli = new ClienteBE();
        ClienteBLL bllCli = new ClienteBLL();
        ClienteVersionBE selVer = new ClienteVersionBE();
        private void FormClienteVersion_Load(object sender, EventArgs e)
        {
            CargarGrillaVersiones();
        }




        private void dataGridViewVersiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            {
                
                selVer=(ClienteVersionBE)dataGridViewVersiones.CurrentRow.DataBoundItem;
                
                selVer=bllCli.ObtenerVersionPorIdVersion(selVer);
                MostrarContenidoVersion(selVer);
                selVer.Cambios = bllCli.ObtenerCamposAfectadorEnVersion(selVer);
                MostrarCamposAfectados(selVer.Cambios);
            }
        }

        private void dataGridViewContenido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;{}
        }
        public void CargarGrillaVersiones()

        {
            labelCli.Text = Convert.ToString(Cli.Id);
            dataGridViewVersiones.DataSource = null;
            dataGridViewVersiones.DataSource = bllCli.ListarVersionesClientePorId(Cli);
            if (dataGridViewVersiones.Columns.Count > 0)
            { dataGridViewVersiones.Columns["IdVersion"].Visible = false; }

        }
        public void MostrarContenidoVersion(ClienteVersionBE Version)

        {
            List<ClienteBE> Vers = new List<ClienteBE>();

            Vers.Add(Version.Cliente);
            dataGridViewContenido.DataSource = null;
            dataGridViewContenido.DataSource = Vers;
            dataGridViewContenido.Columns["Id"].Visible = false;
            dataGridViewContenido.Columns["FechaCreacion"].Visible = false;
        }

        public void MostrarCamposAfectados(ClienteVersionCambiosBE Cambios)

        {
            List<ClienteVersionCambiosBE> lCambios = new List<ClienteVersionCambiosBE>();

            lCambios.Add(Cambios);
            dataGridViewCampos.DataSource = null;
            dataGridViewCampos.DataSource = lCambios;

        }
        private void buttonrest_Click(object sender, EventArgs e)
        {
            if (selVer.IdVersion != 0)

            {

                DialogResult Respuesta = MessageBox.Show("Desea restaurar el Cliente a la version " + selVer.Fecha + "?", Convert.ToString(Cli.Id), MessageBoxButtons.YesNo);

                if (Respuesta == DialogResult.Yes)

                {
                    bllCli.NuevaVersion(Cli, selVer.Cliente);
                    MessageBox.Show("Versión Restaurada");
                    this.Close();
                }

            }

            else { MessageBox.Show("Debe seleccionar una versión"); }
        }
    }
    
}
