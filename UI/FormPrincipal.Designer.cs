namespace UI
{
    partial class FormPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aprobarPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aprobaciónComercialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizarPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anularToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisoPorUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraDeEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.UsuarioBarraEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaYTraduccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traduccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.BarraDeEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesiónToolStripMenuItem,
            this.presupuestosToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.administradorToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // sesiónToolStripMenuItem
            // 
            this.sesiónToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarSesiónToolStripMenuItem,
            this.cerrarSesiónToolStripMenuItem,
            this.idiomaToolStripMenuItem});
            this.sesiónToolStripMenuItem.Name = "sesiónToolStripMenuItem";
            this.sesiónToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.sesiónToolStripMenuItem.Tag = "Sesion";
            this.sesiónToolStripMenuItem.Text = "Sesion";
            this.sesiónToolStripMenuItem.Click += new System.EventHandler(this.sesiónToolStripMenuItem_Click);
            // 
            // iniciarSesiónToolStripMenuItem
            // 
            this.iniciarSesiónToolStripMenuItem.Name = "iniciarSesiónToolStripMenuItem";
            this.iniciarSesiónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.iniciarSesiónToolStripMenuItem.Tag = "Login";
            this.iniciarSesiónToolStripMenuItem.Text = "Iniciar Sesión";
            this.iniciarSesiónToolStripMenuItem.Click += new System.EventHandler(this.iniciarSesiónToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cerrarSesiónToolStripMenuItem.Tag = "Logout";
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // presupuestosToolStripMenuItem
            // 
            this.presupuestosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emitirPresupuestoToolStripMenuItem,
            this.aprobarPresupuestoToolStripMenuItem,
            this.aprobaciónComercialToolStripMenuItem,
            this.visualizarPresupuestoToolStripMenuItem,
            this.anularToolStripMenuItem});
            this.presupuestosToolStripMenuItem.Name = "presupuestosToolStripMenuItem";
            this.presupuestosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.presupuestosToolStripMenuItem.Tag = "Presupuestos";
            this.presupuestosToolStripMenuItem.Text = "Presupuestos";
            // 
            // emitirPresupuestoToolStripMenuItem
            // 
            this.emitirPresupuestoToolStripMenuItem.Name = "emitirPresupuestoToolStripMenuItem";
            this.emitirPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.emitirPresupuestoToolStripMenuItem.Text = "Nuevo";
            // 
            // aprobarPresupuestoToolStripMenuItem
            // 
            this.aprobarPresupuestoToolStripMenuItem.Name = "aprobarPresupuestoToolStripMenuItem";
            this.aprobarPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aprobarPresupuestoToolStripMenuItem.Text = "Aprobación Técnica";
            this.aprobarPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.aprobarPresupuestoToolStripMenuItem_Click);
            // 
            // aprobaciónComercialToolStripMenuItem
            // 
            this.aprobaciónComercialToolStripMenuItem.Name = "aprobaciónComercialToolStripMenuItem";
            this.aprobaciónComercialToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.aprobaciónComercialToolStripMenuItem.Text = "Aprobación Comercial";
            this.aprobaciónComercialToolStripMenuItem.Click += new System.EventHandler(this.aprobaciónComercialToolStripMenuItem_Click);
            // 
            // visualizarPresupuestoToolStripMenuItem
            // 
            this.visualizarPresupuestoToolStripMenuItem.Name = "visualizarPresupuestoToolStripMenuItem";
            this.visualizarPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.visualizarPresupuestoToolStripMenuItem.Text = "Visualizar";
            // 
            // anularToolStripMenuItem
            // 
            this.anularToolStripMenuItem.Name = "anularToolStripMenuItem";
            this.anularToolStripMenuItem.Size = new System.Drawing.Size(193, 22);
            this.anularToolStripMenuItem.Text = "Anular";
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pedidosToolStripMenuItem.Tag = "Pedidos";
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Tag = "Clientes";
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // administradorToolStripMenuItem
            // 
            this.administradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.permisosToolStripMenuItem,
            this.permisoPorUsuarioToolStripMenuItem,
            this.idiomaYTraduccionesToolStripMenuItem});
            this.administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            this.administradorToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.administradorToolStripMenuItem.Tag = "Administrador";
            this.administradorToolStripMenuItem.Text = "Administrador";
            this.administradorToolStripMenuItem.Click += new System.EventHandler(this.administradorToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.permisosToolStripMenuItem.Text = "Perfiles";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // permisoPorUsuarioToolStripMenuItem
            // 
            this.permisoPorUsuarioToolStripMenuItem.Name = "permisoPorUsuarioToolStripMenuItem";
            this.permisoPorUsuarioToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.permisoPorUsuarioToolStripMenuItem.Text = "Perfil por Usuario";
            this.permisoPorUsuarioToolStripMenuItem.Click += new System.EventHandler(this.permisoPorUsuarioToolStripMenuItem_Click);
            // 
            // BarraDeEstado
            // 
            this.BarraDeEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.UsuarioBarraEstado});
            this.BarraDeEstado.Location = new System.Drawing.Point(0, 428);
            this.BarraDeEstado.Name = "BarraDeEstado";
            this.BarraDeEstado.Size = new System.Drawing.Size(800, 22);
            this.BarraDeEstado.TabIndex = 2;
            this.BarraDeEstado.Text = "statusStrip1";
            this.BarraDeEstado.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusStrip1_ItemClicked);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel1.Text = "Usuario: ";
            // 
            // UsuarioBarraEstado
            // 
            this.UsuarioBarraEstado.Name = "UsuarioBarraEstado";
            this.UsuarioBarraEstado.Size = new System.Drawing.Size(143, 17);
            this.UsuarioBarraEstado.Text = "Aún no ha iniciado sesión";
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            this.idiomaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.idiomaToolStripMenuItem.Tag = "Idioma";
            this.idiomaToolStripMenuItem.Text = "Idioma";
            // 
            // idiomaYTraduccionesToolStripMenuItem
            // 
            this.idiomaYTraduccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.etiquetasToolStripMenuItem,
            this.idiomasToolStripMenuItem,
            this.traduccionesToolStripMenuItem});
            this.idiomaYTraduccionesToolStripMenuItem.Name = "idiomaYTraduccionesToolStripMenuItem";
            this.idiomaYTraduccionesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.idiomaYTraduccionesToolStripMenuItem.Text = "Idioma y Traducciones";
            // 
            // etiquetasToolStripMenuItem
            // 
            this.etiquetasToolStripMenuItem.Name = "etiquetasToolStripMenuItem";
            this.etiquetasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.etiquetasToolStripMenuItem.Text = "Etiquetas";
            this.etiquetasToolStripMenuItem.Click += new System.EventHandler(this.etiquetasToolStripMenuItem_Click);
            // 
            // idiomasToolStripMenuItem
            // 
            this.idiomasToolStripMenuItem.Name = "idiomasToolStripMenuItem";
            this.idiomasToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.idiomasToolStripMenuItem.Text = "Idiomas";
            // 
            // traduccionesToolStripMenuItem
            // 
            this.traduccionesToolStripMenuItem.Name = "traduccionesToolStripMenuItem";
            this.traduccionesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.traduccionesToolStripMenuItem.Text = "Traducciones";
            this.traduccionesToolStripMenuItem.Click += new System.EventHandler(this.traduccionesToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BarraDeEstado);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormPrincipal";
            this.Text = "Sistema de Gestión y Seguimiento de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.BarraDeEstado.ResumeLayout(false);
            this.BarraDeEstado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem sesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.StatusStrip BarraDeEstado;
        private System.Windows.Forms.ToolStripMenuItem administradorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem permisosToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel UsuarioBarraEstado;
        private System.Windows.Forms.ToolStripMenuItem permisoPorUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitirPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aprobarPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aprobaciónComercialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizarPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anularToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaYTraduccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traduccionesToolStripMenuItem;
    }
}

