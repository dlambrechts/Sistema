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
    public partial class FormBitacora : Form
    {
        public FormBitacora()
        {
            InitializeComponent();
            CargarUsuarios();
            CargarTipos();
        }

        private void buttonMostrar_Click(object sender, EventArgs e)
        {
            BitacoraBLL bllBit = new BitacoraBLL();
            List<BitacoraActividadBE> Lista = new List<BitacoraActividadBE>();
            Lista = bllBit.ListarEventos();
            dataGridViewEventos.DataSource = null;
            dataGridViewEventos.DataSource = Lista;

            if (CheckFecha.Checked==true) 
            
            {
                Lista = Lista.Where(Item => Item.Fecha.Date >= Convert.ToDateTime(dateTimeDesde.Text) && Item.Fecha.Date <= Convert.ToDateTime(dateTimeHasta.Text)).ToList();
            
            }

            if (checkBoxUsuario.Checked == true) 
            
            {
                UsuarioBE Usel = new UsuarioBE();
                Usel = (UsuarioBE)comboUsuario.SelectedItem;
                Lista = Lista.Where(Item => Item.Usuario.Id == Usel.Id).ToList();
            }

            if (checkBoxTipo.Checked==true)

            {
                BitacoraClasifActividad Tipo = (BitacoraClasifActividad)comboTipo.SelectedItem;

                Lista = Lista.Where(Item => Item.Clasificacion == Tipo).ToList();

            }

            
            dataGridViewEventos.DataSource = null;
            dataGridViewEventos.DataSource = Lista;

        }

        public void CargarUsuarios() 
        
        {
            UsuarioBLL bllus = new UsuarioBLL();
            comboUsuario.DataSource = null;
            comboUsuario.DataSource = bllus.ListarUsuarios();
        
        }

        public void CargarTipos() 
        
        {
            comboTipo.DataSource = null;
            comboTipo.DataSource= Enum.GetValues(typeof(BitacoraClasifActividad));
        }
    }
}
