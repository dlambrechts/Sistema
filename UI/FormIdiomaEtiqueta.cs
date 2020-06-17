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
    public partial class FormIdiomaEtiqueta : Form
    {
        public FormIdiomaEtiqueta()
        {
            InitializeComponent();
        }

        IdiomaEtiquetaBLL bllEt = new IdiomaEtiquetaBLL();
        IdiomaEtiquetaBE beEt = new IdiomaEtiquetaBE();
        private void FormIdiomaEtiqueta_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void buttonAgregar_Click(object sender, EventArgs e)
        {
            beEt.Id = 0;
            beEt.Nombre = NombreEtiqueta.Text;
            bllEt.abmEtiqueta(beEt, 1);
            CargarGrilla();
            VaciarControles();
        }
        private void Modificar_Click(object sender, EventArgs e)
        {
            beEt.Id = Convert.ToInt32(IdEtiqueta.Text);
            beEt.Nombre = NombreEtiqueta.Text;
            bllEt.abmEtiqueta(beEt, 2);
            CargarGrilla();
            VaciarControles();
        }

        private void Eliminar_Click(object sender, EventArgs e)
        {
   

            DialogResult dialogResult = MessageBox.Show("Desea Eliminar la Etiqueta seleccionada?", "Eliminar", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                beEt.Id = Convert.ToInt32(IdEtiqueta.Text);
                bllEt.abmEtiqueta(beEt, 3);
                CargarGrilla();
                VaciarControles();
            }
            else if (dialogResult == DialogResult.No)
            {
                // No hago nada
            }
        }

        public void VaciarControles()
        {
            IdEtiqueta.Text = "0";
            NombreEtiqueta.Text = "";

        }

        public void CargarGrilla()

        {
            dataGridViewEtiquetas.DataSource = null;
            dataGridViewEtiquetas.DataSource = bllEt.ObtenerEtiquetas();
        }

        private void dataGridViewEtiquetas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            IdEtiqueta.Text = Convert.ToString(dataGridViewEtiquetas.Rows[e.RowIndex].Cells[0].Value);
            NombreEtiqueta.Text= Convert.ToString(dataGridViewEtiquetas.Rows[e.RowIndex].Cells[1].Value);
        }


    }
}
