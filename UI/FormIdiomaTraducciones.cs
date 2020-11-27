using BE;
using BLL;
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
    public partial class FormIdiomaTraducciones : Form
    {
        public FormIdiomaTraducciones()
        {
            InitializeComponent();
        }

        private BLL.IdiomaEtiquetaBLL bllEt = new IdiomaEtiquetaBLL();
       
        private BE.IdiomaBE beIdioma = new IdiomaBE();
        private BE.IdiomaEtiquetaBE beEt = new IdiomaEtiquetaBE();
       


        private void FormIdiomaTraducciones_Load(object sender, EventArgs e)
        {
            comboEtiqueta.DataSource = bllEt.ObtenerEtiquetas();
            comboIdioma.DataSource = TraductorBLL.ObtenerIdiomas();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {

            LeerCombos();
            var Traducciones=TraductorBLL.ObtenerTraducciones(beIdioma);

            if(Traducciones==null)  // Traducciones va a ser null cuando se cree un idioma nuevo y no tenga traducciones cargadas para las etiquetas
            {
                MessageBox.Show("A�n no existen la traducci�n para el Idioma seleccionado");
                textTraduccion.Text = "";
            }

            else
            { 
                 if (Traducciones.ContainsKey(beEt.Nombre) )

                   {
                         textTraduccion.Text = Traducciones[beEt.Nombre].Texto;
                   }

                   else 
            
                   {
                         MessageBox.Show("A�n no existen la traducci�n para el Idioma seleccionado");
                         textTraduccion.Text = "";
                   }

                Traducciones.Clear();
                Traducciones = TraductorBLL.ObtenerTraducciones(beIdioma);
            }

        }

        private void buttonGuardar_Click(object sender, EventArgs e)
        {
            LeerCombos();
            var Traducciones = TraductorBLL.ObtenerTraducciones(beIdioma);
            IdiomaTraduccionBE nTraduc = new IdiomaTraduccionBE();
            nTraduc.Etiqueta = beEt;
            nTraduc.Texto = textTraduccion.Text;

            if (Traducciones!=null && Traducciones.ContainsKey(beEt.Nombre)) // Si existe entonces la modifico

            {
                TraductorBLL.InsertarEditarTraduccion(beIdioma, nTraduc, 2);
                MessageBox.Show("La traducci�n se Modifico correctamente");
            }

            else

            {
                TraductorBLL.InsertarEditarTraduccion(beIdioma, nTraduc, 1); // Si no existe entonces la creo
                MessageBox.Show("La Traducci�n se Cre� correctamente");
            }

            textTraduccion.Text = "";
        }

        public void LeerCombos()
        {
            beEt = (IdiomaEtiquetaBE)comboEtiqueta.SelectedItem;
            beIdioma = (IdiomaBE)comboIdioma.SelectedItem;
        }


    }
}
