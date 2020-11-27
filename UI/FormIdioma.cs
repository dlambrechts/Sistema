using BLL;
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

namespace UI
{
    public partial class FormIdioma : Form
    {
        public FormIdioma()
        {
            InitializeComponent();
        }

        public List<IdiomaBE> Idiomas;
        private BE.IdiomaBE Idioma = new IdiomaBE();
        private void FormIdioma_Load(object sender, EventArgs e)
        {
            ObtenerIdiomas();        
        }
        public void ObtenerIdiomas()
        {
            Idiomas = new List<IdiomaBE>();
            Idiomas = TraductorBLL.ObtenerIdiomas();

            foreach (var item in Idiomas)

            {
                if (item.Default == true)
                    LabelDefault.Text = item.Nombre;
            }

            comboIdiomas.DataSource = Idiomas;
        }

        public void VaciarControles()

        {
            textId.Text = "[nuevo]";
            textBoxDescrip.Text = "";
            checkBoxDefault.Checked = false;

        }
        private void buttonEditar_Click(object sender, EventArgs e)
        {
            IdiomaBE Idioma = new IdiomaBE();
            Idioma = (IdiomaBE)comboIdiomas.SelectedItem;

            textId.Text = Convert.ToString(Idioma.Id);
            textBoxDescrip.Text = Idioma.Nombre;
            checkBoxDefault.Checked = Idioma.Default;
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
           
            Idioma.Nombre = textBoxDescrip.Text;

            if (textId.Text =="[nuevo]")
            
            {
                TraductorBLL.Insetaridioma(Idioma, checkBoxDefault.Checked);
            }

            else
            
            {
                Idioma.Id = Convert.ToInt32(textId.Text);
                TraductorBLL.EditarIdioma(Idioma, checkBoxDefault.Checked);
            }

            VaciarControles();
            ObtenerIdiomas();
        }
        private void buttonBorrar_Click(object sender, EventArgs e)
        {
            IdiomaBE Idioma = new IdiomaBE();
            Idioma = (IdiomaBE)comboIdiomas.SelectedItem;

            DialogResult dialogResult = MessageBox.Show("Desea Eliminar el Idioma"+" "+Idioma.Nombre+"? Se borrarán tambien todas las traducciones", "Eliminar", MessageBoxButtons.YesNo);
           
            if (dialogResult == DialogResult.Yes)
            {
                TraductorBLL.EliminarIdioma(Idioma);
                VaciarControles();
                ObtenerIdiomas();
            }
            else if (dialogResult == DialogResult.No)
            {
                // No hago nada
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
