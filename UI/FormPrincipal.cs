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
using System.Runtime.CompilerServices;
using Servicios.DigitoVerificador;

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
        #region

        {
            IdiomaBE Idioma = null;

            if (SesionSingleton.Instancia.IsLogged()) Idioma = SesionSingleton.Instancia.Usuario.Idioma;

            var Traducciones = TraductorBLL.ObtenerTraducciones(Idioma);

            if(Traducciones!=null) // Al crear un idioma nuevo y utilizarlo no habrá traducciones, por lo tanto es necesario consultar si es null
            {
                if (this.Tag != null && Traducciones.ContainsKey(this.Tag.ToString()))  // Título del form
                    this.Text = Traducciones[this.Tag.ToString()].Texto;

                foreach (ToolStripItem x in this.menuStrip1.Items) // Todos los menús
                {
                if (x.Tag != null && Traducciones.ContainsKey(x.Tag.ToString()))
                 x.Text = Traducciones[x.Tag.ToString()].Texto;
               }

                foreach (Control x in this.Controls) // Todos los controles

                {
                    if (x.Tag != null && Traducciones.ContainsKey(x.Tag.ToString()))
                        x.Text = Traducciones[x.Tag.ToString()].Texto;

                }

                if (cerrarSesiónToolStripMenuItem.Tag != null && Traducciones.ContainsKey(cerrarSesiónToolStripMenuItem.Tag.ToString()))
                    this.cerrarSesiónToolStripMenuItem.Text = Traducciones[cerrarSesiónToolStripMenuItem.Tag.ToString()].Texto;

                if (idiomaToolStripMenuItem.Tag != null && Traducciones.ContainsKey(idiomaToolStripMenuItem.Tag.ToString()))
                    this.idiomaToolStripMenuItem.Text = Traducciones[idiomaToolStripMenuItem.Tag.ToString()].Texto;

                if (iniciarSesiónToolStripMenuItem.Tag != null && Traducciones.ContainsKey(iniciarSesiónToolStripMenuItem.Tag.ToString()))
                    this.iniciarSesiónToolStripMenuItem.Text = Traducciones[iniciarSesiónToolStripMenuItem.Tag.ToString()].Texto;

                if (emitirPresupuestoToolStripMenuItem.Tag != null && Traducciones.ContainsKey(emitirPresupuestoToolStripMenuItem.Tag.ToString()))
                    this.emitirPresupuestoToolStripMenuItem.Text = Traducciones[emitirPresupuestoToolStripMenuItem.Tag.ToString()].Texto;

                if (aprobarPresupuestoToolStripMenuItem.Tag != null && Traducciones.ContainsKey(aprobarPresupuestoToolStripMenuItem.Tag.ToString()))
                    this.aprobarPresupuestoToolStripMenuItem.Text = Traducciones[aprobarPresupuestoToolStripMenuItem.Tag.ToString()].Texto;

                if (aprobaciónComercialToolStripMenuItem.Tag != null && Traducciones.ContainsKey(aprobaciónComercialToolStripMenuItem.Tag.ToString()))
                    this.aprobaciónComercialToolStripMenuItem.Text = Traducciones[aprobaciónComercialToolStripMenuItem.Tag.ToString()].Texto;


                if (toolStripStatusLabel1.Tag != null && Traducciones.ContainsKey(toolStripStatusLabel1.Tag.ToString()))
                    this.toolStripStatusLabel1.Text = Traducciones[toolStripStatusLabel1.Tag.ToString()].Texto;
                
                if(toolStripStatusLabel2.Tag != null && Traducciones.ContainsKey(toolStripStatusLabel2.Tag.ToString()))
                    this.toolStripStatusLabel2.Text = Traducciones[toolStripStatusLabel2.Tag.ToString()].Texto;

                if(usuariosToolStripMenuItem.Tag != null && Traducciones.ContainsKey(usuariosToolStripMenuItem.Tag.ToString()))
                    this.usuariosToolStripMenuItem.Text = Traducciones[usuariosToolStripMenuItem.Tag.ToString()].Texto;

                if(permisosToolStripMenuItem.Tag != null && Traducciones.ContainsKey(permisosToolStripMenuItem.Tag.ToString()))
                    this.permisosToolStripMenuItem.Text = Traducciones[permisosToolStripMenuItem.Tag.ToString()].Texto;

                if(permisoPorUsuarioToolStripMenuItem.Tag != null && Traducciones.ContainsKey(permisoPorUsuarioToolStripMenuItem.Tag.ToString()))
                    this.permisoPorUsuarioToolStripMenuItem.Text = Traducciones[permisoPorUsuarioToolStripMenuItem.Tag.ToString()].Texto;

                if(idiomaYTraduccionesToolStripMenuItem.Tag != null && Traducciones.ContainsKey(idiomaYTraduccionesToolStripMenuItem.Tag.ToString()))
                    this.idiomaYTraduccionesToolStripMenuItem.Text = Traducciones[idiomaYTraduccionesToolStripMenuItem.Tag.ToString()].Texto;

                if(etiquetasToolStripMenuItem.Tag != null && Traducciones.ContainsKey(etiquetasToolStripMenuItem.Tag.ToString()))
                    this.etiquetasToolStripMenuItem.Text = Traducciones[etiquetasToolStripMenuItem.Tag.ToString()].Texto;

                if(idiomasToolStripMenuItem.Tag != null && Traducciones.ContainsKey(idiomasToolStripMenuItem.Tag.ToString()))
                    this.idiomasToolStripMenuItem.Text = Traducciones[idiomasToolStripMenuItem.Tag.ToString()].Texto;

                if(traduccionesToolStripMenuItem.Tag != null && Traducciones.ContainsKey(traduccionesToolStripMenuItem.Tag.ToString()))
                    this.traduccionesToolStripMenuItem.Text = Traducciones[traduccionesToolStripMenuItem.Tag.ToString()].Texto;

                if (productosToolStripMenuItem.Tag != null && Traducciones.ContainsKey(productosToolStripMenuItem.Tag.ToString()))
                    this.productosToolStripMenuItem.Text = Traducciones[productosToolStripMenuItem.Tag.ToString()].Texto;

                if (metricasToolStripMenuItem.Tag != null && Traducciones.ContainsKey(metricasToolStripMenuItem.Tag.ToString()))
                    this.metricasToolStripMenuItem.Text = Traducciones[metricasToolStripMenuItem.Tag.ToString()].Texto;

                if (gestiónDeClientesToolStripMenuItem.Tag != null && Traducciones.ContainsKey(gestiónDeClientesToolStripMenuItem.Tag.ToString()))
                    this.gestiónDeClientesToolStripMenuItem.Text = Traducciones[gestiónDeClientesToolStripMenuItem.Tag.ToString()].Texto;

                if (gestiónDeProductosToolStripMenuItem.Tag != null && Traducciones.ContainsKey(gestiónDeProductosToolStripMenuItem.Tag.ToString()))
                    this.gestiónDeProductosToolStripMenuItem.Text = Traducciones[gestiónDeProductosToolStripMenuItem.Tag.ToString()].Texto;

                if (ajustesDeStockToolStripMenuItem.Tag != null && Traducciones.ContainsKey(ajustesDeStockToolStripMenuItem.Tag.ToString()))
                    this.ajustesDeStockToolStripMenuItem.Text = Traducciones[ajustesDeStockToolStripMenuItem.Tag.ToString()].Texto;

                if (gestionDePedidosToolStripMenuItem.Tag != null && Traducciones.ContainsKey(gestionDePedidosToolStripMenuItem.Tag.ToString()))
                    this.gestionDePedidosToolStripMenuItem.Text = Traducciones[gestionDePedidosToolStripMenuItem.Tag.ToString()].Texto;

                if (presupuestosToolStripMenuItem1.Tag != null && Traducciones.ContainsKey(presupuestosToolStripMenuItem1.Tag.ToString()))
                    this.presupuestosToolStripMenuItem1.Text = Traducciones[presupuestosToolStripMenuItem1.Tag.ToString()].Texto;

            }

            if (SesionSingleton.Instancia.IsLogged())
            {
                this.toolStripStatusLabel2.Text = SesionSingleton.Instancia.Usuario.Nombre + " " + SesionSingleton.Instancia.Usuario.Apellido;
               ValidarPermisos();
            }

        }
        #endregion
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
            IntegridadDB();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)

        {
            SesionSingleton.Instancia.DesuscribirObs(this);

        }

        public void IntegridadDB() 
        
        {
            DigitoVerificador DV = new DigitoVerificador();

            DV.VerificarIntegridadHorizonal(bllUsuario.ListarUsuarios());
            DV.VerificarIntegridadVertical(bllUsuario.ListarUsuarios());
        
        }

   
        public void ValidarFormulario() // Deshabilitar menu cuando no hay ususarios logueado
        
        {
            this.iniciarSesiónToolStripMenuItem.Enabled = !SesionSingleton.Instancia.IsLogged();
            this.cerrarSesiónToolStripMenuItem.Enabled= SesionSingleton.Instancia.IsLogged();
            this.administradorToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.presupuestosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.pedidosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.clientesToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.idiomaToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.productosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
            this.metricasToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsLogged();
          
            MarcarIdioma();
            Traducir();

         
        }
        public void ValidarPermisos () // Habilitar menu según permisos de usuario logueado
        
        {
            this.usuariosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoA); // ABM Usuarios
            this.permisosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoB); // Perfiles de Acceso
            this.permisoPorUsuarioToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoC); // Asignacion de Perfil a Usuarios
            this.idiomaYTraduccionesToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoJ); // Gestión de Idiomas y Traduciones
            this.emitirPresupuestoToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoD); // Emitir Presupuestos
            this.aprobarPresupuestoToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoE); // Aprobacion Tecnica
            this.aprobaciónComercialToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoF); // Aprobacion Comercial
            this.gestiónDeProductosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoL); // ABM Productos
            this.ajustesDeStockToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoN); // Ajustes de Stock
            this.presupuestosToolStripMenuItem1.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoM); // Ver métricas, indicadores
            this.gestiónDeClientesToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoK); // ABM Clientes
            this.gestionDePedidosToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoO); // Gestión Pedidos
            this.bitácoraToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoP); // Bitacora
            this.backupToolStripMenuItem.Enabled = SesionSingleton.Instancia.IsInRole(PerfilTipoPermisoBE.PermisoQ); // Backup

        }
        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Está seguro que desea cerrar la sesión?", "Confirmar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                bllUsuario.Logut();
                while (ActiveMdiChild != null)
                {
                    ActiveMdiChild.Close();
                }
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
            FormPresupuestoAnalisisComercial frmCom = new FormPresupuestoAnalisisComercial();
            frmCom.MdiParent = this;
            frmCom.Show();
        }

        private void aprobarPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPresupuestoAnalisisTecnico frmApTec = new FormPresupuestoAnalisisTecnico();
            frmApTec.MdiParent = this;
            frmApTec.Show();
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

        private void idiomasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIdioma frmIdio = new FormIdioma();
            frmIdio.MdiParent = this;
            frmIdio.Show();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gestiónDeClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormClienteGestionar frmGesCli = new FormClienteGestionar();
            frmGesCli.MdiParent = this;
            frmGesCli.Show();
        }

        private void emitirPresupuestoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPresupuestoGestion frmPrg = new FormPresupuestoGestion();
            frmPrg.MdiParent = this;
            frmPrg.Show();
        }

        private void gestiónDeProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormProductoGestion frmGesProd = new FormProductoGestion();
            frmGesProd.MdiParent = this;
            frmGesProd.Show();
        }

        private void bitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBitacora fBit = new FormBitacora();
            fBit.MdiParent = this;
            fBit.Show();
        }

        private void backupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBackup fback = new FormBackup();
            fback.MdiParent = this;
            fback.Show();
        }

        private void gestionDePedidosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPedidoGestion Pgest = new FormPedidoGestion();
            Pgest.MdiParent = this;
            Pgest.Show();
        }

        private void presupuestosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormReporte fRep = new FormReporte();
            fRep.MdiParent = this;
            fRep.Show();
        }
    }
}
