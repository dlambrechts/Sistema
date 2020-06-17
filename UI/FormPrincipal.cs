using BLL;
using BE;
using Servicios;
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
    public partial class FormPrincipal : Form,IIdiomaObserver
    {

        UsuarioBLL bllUsuario;
        public FormPrincipal()
        {
            InitializeComponent();
            ValidarFormulario();
            MostrarIdiomas();
            MarcarIdioma();
            Traducir();
            
            bllUsuario = new UsuarioBLL();
        }

        public void UpdateLanguage(IdiomaBE idioma)
        {
            MarcarIdioma();
            Traducir();
        }

        private void Traducir()

        {
            IdiomaBE Idioma = null;

            if (SesionSingleton.Instancia.IsLogged()) Idioma = SesionSingleton.Instancia.Usuario.Idioma;

            var Traducciones = TraductorBLL.ObtenerTraducciones(Idioma);

            if (sesiónToolStripMenuItem.Tag != null && Traducciones.ContainsKey(sesiónToolStripMenuItem.Tag.ToString()))
            this.sesiónToolStripMenuItem.Text = Traducciones[sesiónToolStripMenuItem.Tag.ToString()].Texto;

            if (presupuestosToolStripMenuItem.Tag != null && Traducciones.ContainsKey(presupuestosToolStripMenuItem.Tag.ToString()))
                this.presupuestosToolStripMenuItem.Text = Traducciones[presupuestosToolStripMenuItem.Tag.ToString()].Texto;

            if (pedidosToolStripMenuItem.Tag != null && Traducciones.ContainsKey(pedidosToolStripMenuItem.Tag.ToString()))
                this.pedidosToolStripMenuItem.Text = Traducciones[pedidosToolStripMenuItem.Tag.ToString()].Texto;

            if (clientesToolStripMenuItem.Tag != null && Traducciones.ContainsKey(clientesToolStripMenuItem.Tag.ToString()))
                this.clientesToolStripMenuItem.Text = Traducciones[clientesToolStripMenuItem.Tag.ToString()].Texto;

            if (administradorToolStripMenuItem.Tag != null && Traducciones.ContainsKey(administradorToolStripMenuItem.Tag.ToString()))
                this.administradorToolStripMenuItem.Text = Traducciones[administradorToolStripMenuItem.Tag.ToString()].Texto;

            if (sesiónToolStripMenuItem.Tag != null && Traducciones.ContainsKey(sesiónToolStripMenuItem.Tag.ToString()))
                this.sesiónToolStripMenuItem.Text = Traducciones[sesiónToolStripMenuItem.Tag.ToString()].Texto;

            if (cerrarSesiónToolStripMenuItem.Tag != null && Traducciones.ContainsKey(cerrarSesiónToolStripMenuItem.Tag.ToString()))
                this.cerrarSesiónToolStripMenuItem.Text = Traducciones[cerrarSesiónToolStripMenuItem.Tag.ToString()].Texto;

            if (idiomaToolStripMenuItem.Tag != null && Traducciones.ContainsKey(idiomaToolStripMenuItem.Tag.ToString()))
                this.idiomaToolStripMenuItem.Text = Traducciones[idiomaToolStripMenuItem.Tag.ToString()].Texto;

            if (iniciarSesiónToolStripMenuItem.Tag != null && Traducciones.ContainsKey(iniciarSesiónToolStripMenuItem.Tag.ToString()))
                this.iniciarSesiónToolStripMenuItem.Text = Traducciones[iniciarSesiónToolStripMenuItem.Tag.ToString()].Texto;
           


        }
        private void MostrarIdiomas()

        {
            var idiomas = TraductorBLL.ObtenerIdiomas();

            foreach(var item in idiomas)

            {
                var t = new ToolStripMenuItem();
                t.Text = item.Nombre;
                t.Tag = item;
                this.idiomaToolStripMenuItem.DropDownItems.Add(t);
                t.Click += idioma_Click;

            }

        }
        private void idioma_Click(object sender, EventArgs e)
        {
            SesionSingleton.Instancia.CambiarIdioma((IdiomaBE)((ToolStripMenuItem)sender).Tag);
            
            MarcarIdioma();
        }
        void MarcarIdioma()
        {

            if (!SesionSingleton.Instancia.IsLogged())
            {
                foreach (var item in idiomaToolStripMenuItem.DropDownItems)
                {

                    var i = ((IdiomaBE)((ToolStripMenuItem)item).Tag);

                    ((ToolStripMenuItem)item).Checked = i.Default;
                    ((ToolStripMenuItem)item).Enabled = false;

                }
            }
            else
            {
                foreach (var item in idiomaToolStripMenuItem.DropDownItems)
                {

                    ((ToolStripMenuItem)item).Enabled = true;
                    ((ToolStripMenuItem)item).Checked = SesionSingleton.Instancia.Usuario.Idioma.Id.Equals(((IdiomaBE)((ToolStripMenuItem)item).Tag).Id);
                }
            }

        }


        private void iniciarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLogin frmlogin = new FormLogin();
            frmlogin.MdiParent = this;
            frmlogin.Show();
        }


        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUsuarios frmUsuario = new FormUsuarios();
            frmUsuario.MdiParent = this;
            frmUsuario.Show();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            SesionSingleton.Instancia.SuscribirObs(this);
        }

        public void ValidarFormulario()
        
        {
            this.iniciarSesiónToolStripMenuItem.Enabled = !SesionSingleton.Instancia.IsLogged();
            this.cerrarSesiónToolStripMenuItem.Enabled= SesionSingleton.Instancia.IsLogged();
            this.administradorToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.presupuestosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.pedidosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.clientesToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.idiomaToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            MarcarIdioma();
            Traducir();

            if (SesionSingleton.Instancia.IsLogged())
            {
                this.UsuarioBarraEstado.Text = SesionSingleton.Instancia.Usuario.Nombre + " "+ SesionSingleton.Instancia.Usuario.Apellido;
                ValidarPermisos();
            }
            else { this.UsuarioBarraEstado.Text = "Aún no ha iniciado sesión"; }
         
        }
        public void ValidarPermisos ()
        
        {
            this.usuariosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoA); // ABM Usuarios
            this.permisosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoB); // Perfiles de Acceso
            this.permisoPorUsuarioToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoC); // Asignacion de Perfil a Usuarios
            this.emitirPresupuestoToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoD); // Emitir Presupuestos
            this.aprobarPresupuestoToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoE); // Aprobacion Tecnica
            this.aprobaciónComercialToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoF); // Aprobacion Comercial
            this.visualizarPresupuestoToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoG); // Visualizar Presupuesto
            this.anularToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoH); // Anular Presupuesto
        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la sesión?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bllUsuario.Logut();
                if(ActiveMdiChild!=null)                    
                    ActiveMdiChild.Close();
                ValidarFormulario();
            }
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPerfiles fPerf = new FormPerfiles();
            fPerf.MdiParent = this;
            fPerf.Show();
        }



        private void permisoPorUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPerfilUsuario frmPerfUs = new FormPerfilUsuario();
            frmPerfUs.MdiParent = this;
            frmPerfUs.Show();
        }

        private void aprobaciónComercialToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aprobarPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void sesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void administradorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void etiquetasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIdiomaEtiqueta formEt = new FormIdiomaEtiqueta();
            formEt.MdiParent = this;
            formEt.Show();
        }

        private void traduccionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIdiomaTraducciones formTrad = new FormIdiomaTraducciones();
            formTrad.MdiParent = this;
            formTrad.Show();
        }
    }
}
