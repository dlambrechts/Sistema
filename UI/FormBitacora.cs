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
using Servicios;

namespace UI
{
    public partial class FormBitacora : Form,IIdiomaObserver
    {
        public FormBitacora()
        {
            InitializeComponent();
            Traducir();
            CargarUsuarios();
            CargarTipos();
            dateTimeHasta.Value = DateTime.Now;
            MostrarDatos(dateTimeDesde.Value, DateTime.Now, 0,0);
            
        }

        public void UpdateLanguage(IdiomaBE idioma)
        {
            Traducir();
        }

        BitacoraBLL bllBit = new BitacoraBLL();

        private void Traducir()

        {
            IdiomaBE Idioma = null;

            if (SesionSingleton.Instancia.IsLogged()) Idioma = SesionSingleton.Instancia.Usuario.Idioma;

            var Traducciones = TraductorBLL.ObtenerTraducciones(Idioma);

            if (Traducciones != null) // Al crear un idioma nuevo y utilizarlo no habrá traducciones, por lo tanto es necesario consultar si es null
            {

                if (this.Tag != null && Traducciones.ContainsKey(this.Tag.ToString()))  // Título del form
                    this.Text = Traducciones[this.Tag.ToString()].Texto;

                if (groupBox1.Tag != null && Traducciones.ContainsKey(groupBox1.Tag.ToString()))
                    groupBox1.Text = Traducciones[groupBox1.Tag.ToString()].Texto;

                if (label1.Tag != null && Traducciones.ContainsKey(label1.Tag.ToString()))
                    label1.Text = Traducciones[label1.Tag.ToString()].Texto;

                if (label2.Tag != null && Traducciones.ContainsKey(label2.Tag.ToString()))
                    label2.Text = Traducciones[label2.Tag.ToString()].Texto;

                if (label3.Tag != null && Traducciones.ContainsKey(label3.Tag.ToString()))
                    label3.Text = Traducciones[label3.Tag.ToString()].Texto;

                if (label4.Tag != null && Traducciones.ContainsKey(label4.Tag.ToString()))
                    label4.Text = Traducciones[label4.Tag.ToString()].Texto;

            }

        }
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
            SesionSingleton.Instancia.SuscribirObs(this);
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
