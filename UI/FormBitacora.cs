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
    public partial class FormBitacora : Form
    {
        public FormBitacora()
        {
            InitializeComponent();
            CargarUsuarios();
            CargarTipos();
            dateTimeHasta.Value = DateTime.Now;
            MostrarDatos(dateTimeDesde.Value, DateTime.Now, 0,0);
            
        }

        BitacoraBLL bllBit = new BitacoraBLL();
        
        public void CargarUsuarios() 
        
        {
            UsuarioBLL bllus = new UsuarioBLL();
            List<UsuarioBE> Usuarios = new List<UsuarioBE>();
            UsuarioBE defecto = new UsuarioBE(); defecto.Nombre = "Todos"; defecto.Id = 0;
            
            Usuarios=bllus.ListarUsuarios();
            Usuarios.Insert(0,defecto);          
            comboUsuario.DataSource = null;
            comboUsuario.DataSource = Usuarios;
            
        }

        public void CargarTipos() 
        
        {
            List<BitacoraTipoActividad> Tipos = new List<BitacoraTipoActividad>();
            BitacoraTipoActividad defecto = new BitacoraTipoActividad(); defecto.Tipo = "Todos"; defecto.Id = 0;
            
            Tipos = bllBit.ListarTipos();
            Tipos.Insert(0, defecto);
            comboTipo.DataSource = null;
            comboTipo.DataSource = Tipos;
        }

        public void MostrarDatos (DateTime Desde, DateTime Hasta, int IdU, int IdT) 
        
        {
            List<BitacoraActividadBE> Eventos = new List<BitacoraActividadBE>();
            Eventos = bllBit.ListarEventos();

            if (IdU != 0) { Eventos = Eventos.Where(Item => Item.Usuario.Id == IdU).ToList(); }           

            if (IdT != 0) { Eventos = Eventos.Where(Item => Item.Tipo.Id == IdT).ToList(); }

            Eventos = Eventos.Where(Item => Item.Fecha.Date >= Desde && Item.Fecha.Date <= Hasta).ToList();

            dataGridViewEventos.DataSource = null;
            dataGridViewEventos.DataSource = Eventos;
            
        }

        public void Filtrar() 
        
        {
            UsuarioBE sel = new UsuarioBE();
            sel = (UsuarioBE)comboUsuario.SelectedItem;
            BitacoraTipoActividad tipo = new BitacoraTipoActividad();
            tipo = (BitacoraTipoActividad)comboTipo.SelectedItem;
            DateTime desde = dateTimeDesde.Value;
            DateTime hasta = dateTimeHasta.Value;
            
            MostrarDatos(desde, hasta, sel.Id, tipo.Id);
        }
        private void comboUsuario_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void dateTimeDesde_ValueChanged(object sender, EventArgs e)
        {
            Filtrar();
        }

        private void dateTimeHasta_ValueChanged(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void comboTipo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Filtrar();
        }
        private void FormBitacora_Load(object sender, EventArgs e)
        {

        }
        private void buttonMostrar_Click(object sender, EventArgs e)
        {

        }

        private void comboUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboUsuario_SelectedValueChanged(object sender, EventArgs e)
        {

        }


    }
}
