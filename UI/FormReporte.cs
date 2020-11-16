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
using Servicios;

namespace UI
{
    public partial class FormReporte : Form
    {
        public FormReporte()
        {
            InitializeComponent();
        }

        private void FormReporte_Load(object sender, EventArgs e)
        {
            RangoDefecto();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PresupuestoBLL bllPres = new PresupuestoBLL();
            ReporteVentasAtrasadas rep = new ReporteVentasAtrasadas();

            rep.GenerarPresupuestoPdf(bllPres.PresupuestosAtrasados(dateTimePickerDesde.Value, dateTimePickerHasta.Value));
        }

        public void RangoDefecto() 
        
        {
            dateTimePickerDesde.Value = DateTime.Now.AddMonths(-1);
            dateTimePickerHasta.Value = DateTime.Now;
        }
    }
}
