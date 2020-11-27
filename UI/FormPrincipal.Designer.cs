namespace UI
{
    public partial class FormPrincipal
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
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aprobarPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aprobaciónComercialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDePedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestiónDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajustesDeStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.metricasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.administradorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.permisoPorUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaYTraduccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.etiquetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.traduccionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitácoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BarraDeEstado = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dots = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.BarraDeEstado.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sesiónToolStripMenuItem,
            this.presupuestosToolStripMenuItem,
            this.clientesToolStripMenuItem,
            this.pedidosToolStripMenuItem,
            this.productosToolStripMenuItem,
            this.metricasToolStripMenuItem,
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
            this.iniciarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.iniciarSesiónToolStripMenuItem.Tag = "Login";
            this.iniciarSesiónToolStripMenuItem.Text = "Iniciar Sesión";
            this.iniciarSesiónToolStripMenuItem.Click += new System.EventHandler(this.iniciarSesiónToolStripMenuItem_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesiónToolStripMenuItem.Tag = "Logout";
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesiónToolStripMenuItem_Click);
            // 
            // idiomaToolStripMenuItem
            // 
            this.idiomaToolStripMenuItem.Name = "idiomaToolStripMenuItem";
            this.idiomaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.idiomaToolStripMenuItem.Tag = "Idioma";
            this.idiomaToolStripMenuItem.Text = "Idioma";
            // 
            // presupuestosToolStripMenuItem
            // 
            this.presupuestosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emitirPresupuestoToolStripMenuItem,
            this.aprobarPresupuestoToolStripMenuItem,
            this.aprobaciónComercialToolStripMenuItem});
            this.presupuestosToolStripMenuItem.Name = "presupuestosToolStripMenuItem";
            this.presupuestosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.presupuestosToolStripMenuItem.Tag = "Presupuestos";
            this.presupuestosToolStripMenuItem.Text = "Presupuestos";
            // 
            // emitirPresupuestoToolStripMenuItem
            // 
            this.emitirPresupuestoToolStripMenuItem.Name = "emitirPresupuestoToolStripMenuItem";
            this.emitirPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.emitirPresupuestoToolStripMenuItem.Tag = "Gestión de presupuestos";
            this.emitirPresupuestoToolStripMenuItem.Text = "Gestión de Presupuestos";
            this.emitirPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.emitirPresupuestoToolStripMenuItem_Click);
            // 
            // aprobarPresupuestoToolStripMenuItem
            // 
            this.aprobarPresupuestoToolStripMenuItem.Name = "aprobarPresupuestoToolStripMenuItem";
            this.aprobarPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.aprobarPresupuestoToolStripMenuItem.Tag = "Aprobación Técnica";
            this.aprobarPresupuestoToolStripMenuItem.Text = "Aprobación Técnica";
            this.aprobarPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.aprobarPresupuestoToolStripMenuItem_Click);
            // 
            // aprobaciónComercialToolStripMenuItem
            // 
            this.aprobaciónComercialToolStripMenuItem.Name = "aprobaciónComercialToolStripMenuItem";
            this.aprobaciónComercialToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.aprobaciónComercialToolStripMenuItem.Tag = "Aprobación Comercial";
            this.aprobaciónComercialToolStripMenuItem.Text = "Aprobación Comercial";
            this.aprobaciónComercialToolStripMenuItem.Click += new System.EventHandler(this.aprobaciónComercialToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDeClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Tag = "Clientes";
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // gestiónDeClientesToolStripMenuItem
            // 
            this.gestiónDeClientesToolStripMenuItem.Name = "gestiónDeClientesToolStripMenuItem";
            this.gestiónDeClientesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gestiónDeClientesToolStripMenuItem.Tag = "Gestion de Clientes";
            this.gestiónDeClientesToolStripMenuItem.Text = "Gestión de Clientes";
            this.gestiónDeClientesToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeClientesToolStripMenuItem_Click);
            // 
            // pedidosToolStripMenuItem
            // 
            this.pedidosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestionDePedidosToolStripMenuItem});
            this.pedidosToolStripMenuItem.Name = "pedidosToolStripMenuItem";
            this.pedidosToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pedidosToolStripMenuItem.Tag = "Pedidos";
            this.pedidosToolStripMenuItem.Text = "Pedidos";
            // 
            // gestionDePedidosToolStripMenuItem
            // 
            this.gestionDePedidosToolStripMenuItem.Name = "gestionDePedidosToolStripMenuItem";
            this.gestionDePedidosToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gestionDePedidosToolStripMenuItem.Tag = "Pedidos";
            this.gestionDePedidosToolStripMenuItem.Text = "Gestion de Pedidos";
            this.gestionDePedidosToolStripMenuItem.Click += new System.EventHandler(this.gestionDePedidosToolStripMenuItem_Click);
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gestiónDeProductosToolStripMenuItem,
            this.ajustesDeStockToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Tag = "Productos";
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // gestiónDeProductosToolStripMenuItem
            // 
            this.gestiónDeProductosToolStripMenuItem.Name = "gestiónDeProductosToolStripMenuItem";
            this.gestiónDeProductosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.gestiónDeProductosToolStripMenuItem.Tag = "Gestion de Productos";
            this.gestiónDeProductosToolStripMenuItem.Text = "Gestion de Productos";
            this.gestiónDeProductosToolStripMenuItem.Click += new System.EventHandler(this.gestiónDeProductosToolStripMenuItem_Click);
            // 
            // ajustesDeStockToolStripMenuItem
            // 
            this.ajustesDeStockToolStripMenuItem.Name = "ajustesDeStockToolStripMenuItem";
            this.ajustesDeStockToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.ajustesDeStockToolStripMenuItem.Tag = "Ajustes de Stock";
            this.ajustesDeStockToolStripMenuItem.Text = "Ajustes de Stock";
            // 
            // metricasToolStripMenuItem
            // 
            this.metricasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.presupuestosToolStripMenuItem1});
            this.metricasToolStripMenuItem.Name = "metricasToolStripMenuItem";
            this.metricasToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.metricasToolStripMenuItem.Tag = "Indicadores";
            this.metricasToolStripMenuItem.Text = "Reportes";
            // 
            // presupuestosToolStripMenuItem1
            // 
            this.presupuestosToolStripMenuItem1.Name = "presupuestosToolStripMenuItem1";
            this.presupuestosToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.presupuestosToolStripMenuItem1.Tag = "Ventas Perdidas";
            this.presupuestosToolStripMenuItem1.Text = "Ventas Perdidas";
            this.presupuestosToolStripMenuItem1.Click += new System.EventHandler(this.presupuestosToolStripMenuItem1_Click);
            // 
            // administradorToolStripMenuItem
            // 
            this.administradorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItem,
            this.permisosToolStripMenuItem,
            this.permisoPorUsuarioToolStripMenuItem,
            this.idiomaYTraduccionesToolStripMenuItem,
            this.bitácoraToolStripMenuItem,
            this.backupToolStripMenuItem});
            this.administradorToolStripMenuItem.Name = "administradorToolStripMenuItem";
            this.administradorToolStripMenuItem.Size = new System.Drawing.Size(95, 20);
            this.administradorToolStripMenuItem.Tag = "Administrador";
            this.administradorToolStripMenuItem.Text = "Administrador";
            this.administradorToolStripMenuItem.Click += new System.EventHandler(this.administradorToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.usuariosToolStripMenuItem.Tag = "Usuarios";
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            this.usuariosToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // permisosToolStripMenuItem
            // 
            this.permisosToolStripMenuItem.Name = "permisosToolStripMenuItem";
            this.permisosToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.permisosToolStripMenuItem.Tag = "Perfiles";
            this.permisosToolStripMenuItem.Text = "Perfiles";
            this.permisosToolStripMenuItem.Click += new System.EventHandler(this.permisosToolStripMenuItem_Click);
            // 
            // permisoPorUsuarioToolStripMenuItem
            // 
            this.permisoPorUsuarioToolStripMenuItem.Name = "permisoPorUsuarioToolStripMenuItem";
            this.permisoPorUsuarioToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.permisoPorUsuarioToolStripMenuItem.Tag = "Perfil por Usuario";
            this.permisoPorUsuarioToolStripMenuItem.Text = "Perfil por Usuario";
            this.permisoPorUsuarioToolStripMenuItem.Click += new System.EventHandler(this.permisoPorUsuarioToolStripMenuItem_Click);
            // 
            // idiomaYTraduccionesToolStripMenuItem
            // 
            this.idiomaYTraduccionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.etiquetasToolStripMenuItem,
            this.idiomasToolStripMenuItem,
            this.traduccionesToolStripMenuItem});
            this.idiomaYTraduccionesToolStripMenuItem.Name = "idiomaYTraduccionesToolStripMenuItem";
            this.idiomaYTraduccionesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.idiomaYTraduccionesToolStripMenuItem.Tag = "Idioma";
            this.idiomaYTraduccionesToolStripMenuItem.Text = "Idioma y Traducciones";
            // 
            // etiquetasToolStripMenuItem
            // 
            this.etiquetasToolStripMenuItem.Name = "etiquetasToolStripMenuItem";
            this.etiquetasToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.etiquetasToolStripMenuItem.Tag = "Etiquetas";
            this.etiquetasToolStripMenuItem.Text = "Etiquetas";
            this.etiquetasToolStripMenuItem.Click += new System.EventHandler(this.etiquetasToolStripMenuItem_Click);
            // 
            // idiomasToolStripMenuItem
            // 
            this.idiomasToolStripMenuItem.Name = "idiomasToolStripMenuItem";
            this.idiomasToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.idiomasToolStripMenuItem.Tag = "Idiomas";
            this.idiomasToolStripMenuItem.Text = "Idiomas";
            this.idiomasToolStripMenuItem.Click += new System.EventHandler(this.idiomasToolStripMenuItem_Click);
            // 
            // traduccionesToolStripMenuItem
            // 
            this.traduccionesToolStripMenuItem.Name = "traduccionesToolStripMenuItem";
            this.traduccionesToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.traduccionesToolStripMenuItem.Tag = "Traducciones";
            this.traduccionesToolStripMenuItem.Text = "Traducciones";
            this.traduccionesToolStripMenuItem.Click += new System.EventHandler(this.traduccionesToolStripMenuItem_Click);
            // 
            // bitácoraToolStripMenuItem
            // 
            this.bitácoraToolStripMenuItem.Name = "bitácoraToolStripMenuItem";
            this.bitácoraToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.bitácoraToolStripMenuItem.Text = "Bitácora";
            this.bitácoraToolStripMenuItem.Click += new System.EventHandler(this.bitácoraToolStripMenuItem_Click);
            // 
            // backupToolStripMenuItem
            // 
            this.backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            this.backupToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.backupToolStripMenuItem.Text = "Backup";
            this.backupToolStripMenuItem.Click += new System.EventHandler(this.backupToolStripMenuItem_Click);
            // 
            // BarraDeEstado
            // 
            this.BarraDeEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.dots,
            this.toolStripStatusLabel2});
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
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(47, 17);
            this.toolStripStatusLabel1.Tag = "Usuario";
            this.toolStripStatusLabel1.Text = "Usuario";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // dots
            // 
            this.dots.Name = "dots";
            this.dots.Size = new System.Drawing.Size(10, 17);
            this.dots.Tag = "";
            this.dots.Text = ":";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(143, 17);
            this.toolStripStatusLabel2.Tag = "Sesión no iniciada";
            this.toolStripStatusLabel2.Text = "Aún no ha iniciado sesión";
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
            this.Tag = "Nombre del sistema";
            this.Text = "Sistema de Gestión y Seguimiento de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPrincipal_FormClosing);
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
        private System.Windows.Forms.ToolStripStatusLabel dots;
        private System.Windows.Forms.ToolStripMenuItem permisoPorUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emitirPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aprobarPresupuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aprobaciónComercialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaYTraduccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traduccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestiónDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajustesDeStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metricasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bitácoraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDePedidosToolStripMenuItem;
    }
}

