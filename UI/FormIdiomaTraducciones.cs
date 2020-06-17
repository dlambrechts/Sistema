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

        IdiomaEtiquetaBLL bllEt = new IdiomaEtiquetaBLL();
       
        IdiomaBE beIdioma = new IdiomaBE();
        IdiomaEtiquetaBE beEt = new IdiomaEtiquetaBE();
       
        private void FormIdiomaTraducciones_Load(object sender, EventArgs e)
        {
            comboEtiqueta.DataSource = bllEt.ObtenerEtiquetas();
            comboIdioma.DataSource = TraductorBLL.ObtenerIdiomas();
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            beEt = (IdiomaEtiquetaBE)comboEtiqueta.SelectedItem;
            beIdioma = (IdiomaBE)comboIdioma.SelectedItem;
        }
    }
}
