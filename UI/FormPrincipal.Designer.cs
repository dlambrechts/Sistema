namespace UI
{
    public partial class FormPrincipal
    {
        /// <summary>
        /// Variable del dise�ador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se est�n usando.
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

        #region C�digo generado por el Dise�ador de Windows Forms

        /// <summary>
        /// M�todo necesario para admitir el Dise�ador. No se puede modificar
        /// el contenido de este m�todo con el editor de c�digo.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.sesi�nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesi�nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesi�nToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.idiomaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presupuestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emitirPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aprobarPresupuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aprobaci�nComercialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gesti�nDeClientesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionDePedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gesti�nDeProductosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.bit�coraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.sesi�nToolStripMenuItem,
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
            // sesi�nToolStripMenuItem
            // 
            this.sesi�nToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarSesi�nToolStripMenuItem,
            this.cerrarSesi�nToolStripMenuItem,
            this.idiomaToolStripMenuItem});
            this.sesi�nToolStripMenuItem.Name = "sesi�nToolStripMenuItem";
            this.sesi�nToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.sesi�nToolStripMenuItem.Tag = "Sesion";
            this.sesi�nToolStripMenuItem.Text = "Sesion";
            this.sesi�nToolStripMenuItem.Click += new System.EventHandler(this.sesi�nToolStripMenuItem_Click);
            // 
            // iniciarSesi�nToolStripMenuItem
            // 
            this.iniciarSesi�nToolStripMenuItem.Name = "iniciarSesi�nToolStripMenuItem";
            this.iniciarSesi�nToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.iniciarSesi�nToolStripMenuItem.Tag = "Login";
            this.iniciarSesi�nToolStripMenuItem.Text = "Iniciar Sesi�n";
            this.iniciarSesi�nToolStripMenuItem.Click += new System.EventHandler(this.iniciarSesi�nToolStripMenuItem_Click);
            // 
            // cerrarSesi�nToolStripMenuItem
            // 
            this.cerrarSesi�nToolStripMenuItem.Name = "cerrarSesi�nToolStripMenuItem";
            this.cerrarSesi�nToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cerrarSesi�nToolStripMenuItem.Tag = "Logout";
            this.cerrarSesi�nToolStripMenuItem.Text = "Cerrar Sesi�n";
            this.cerrarSesi�nToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesi�nToolStripMenuItem_Click);
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
            this.aprobaci�nComercialToolStripMenuItem});
            this.presupuestosToolStripMenuItem.Name = "presupuestosToolStripMenuItem";
            this.presupuestosToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.presupuestosToolStripMenuItem.Tag = "Presupuestos";
            this.presupuestosToolStripMenuItem.Text = "Presupuestos";
            // 
            // emitirPresupuestoToolStripMenuItem
            // 
            this.emitirPresupuestoToolStripMenuItem.Name = "emitirPresupuestoToolStripMenuItem";
            this.emitirPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.emitirPresupuestoToolStripMenuItem.Tag = "Gesti�n de presupuestos";
            this.emitirPresupuestoToolStripMenuItem.Text = "Gesti�n de Presupuestos";
            this.emitirPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.emitirPresupuestoToolStripMenuItem_Click);
            // 
            // aprobarPresupuestoToolStripMenuItem
            // 
            this.aprobarPresupuestoToolStripMenuItem.Name = "aprobarPresupuestoToolStripMenuItem";
            this.aprobarPresupuestoToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.aprobarPresupuestoToolStripMenuItem.Tag = "Aprobaci�n T�cnica";
            this.aprobarPresupuestoToolStripMenuItem.Text = "Aprobaci�n T�cnica";
            this.aprobarPresupuestoToolStripMenuItem.Click += new System.EventHandler(this.aprobarPresupuestoToolStripMenuItem_Click);
            // 
            // aprobaci�nComercialToolStripMenuItem
            // 
            this.aprobaci�nComercialToolStripMenuItem.Name = "aprobaci�nComercialToolStripMenuItem";
            this.aprobaci�nComercialToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.aprobaci�nComercialToolStripMenuItem.Tag = "Aprobaci�n Comercial";
            this.aprobaci�nComercialToolStripMenuItem.Text = "Aprobaci�n Comercial";
            this.aprobaci�nComercialToolStripMenuItem.Click += new System.EventHandler(this.aprobaci�nComercialToolStripMenuItem_Click);
            // 
            // clientesToolStripMenuItem
            // 
            this.clientesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gesti�nDeClientesToolStripMenuItem});
            this.clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            this.clientesToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.clientesToolStripMenuItem.Tag = "Clientes";
            this.clientesToolStripMenuItem.Text = "Clientes";
            // 
            // gesti�nDeClientesToolStripMenuItem
            // 
            this.gesti�nDeClientesToolStripMenuItem.Name = "gesti�nDeClientesToolStripMenuItem";
            this.gesti�nDeClientesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gesti�nDeClientesToolStripMenuItem.Tag = "Gestion de Clientes";
            this.gesti�nDeClientesToolStripMenuItem.Text = "Gesti�n de Clientes";
            this.gesti�nDeClientesToolStripMenuItem.Click += new System.EventHandler(this.gesti�nDeClientesToolStripMenuItem_Click);
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
            this.gesti�nDeProductosToolStripMenuItem,
            this.ajustesDeStockToolStripMenuItem});
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.productosToolStripMenuItem.Tag = "Productos";
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // gesti�nDeProductosToolStripMenuItem
            // 
            this.gesti�nDeProductosToolStripMenuItem.Name = "gesti�nDeProductosToolStripMenuItem";
            this.gesti�nDeProductosToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.gesti�nDeProductosToolStripMenuItem.Tag = "Gestion de Productos";
            this.gesti�nDeProductosToolStripMenuItem.Text = "Gestion de Productos";
            this.gesti�nDeProductosToolStripMenuItem.Click += new System.EventHandler(this.gesti�nDeProductosToolStripMenuItem_Click);
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
            this.bit�coraToolStripMenuItem,
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
            // bit�coraToolStripMenuItem
            // 
            this.bit�coraToolStripMenuItem.Name = "bit�coraToolStripMenuItem";
            this.bit�coraToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.bit�coraToolStripMenuItem.Text = "Bit�cora";
            this.bit�coraToolStripMenuItem.Click += new System.EventHandler(this.bit�coraToolStripMenuItem_Click);
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
            this.toolStripStatusLabel2.Tag = "Sesi�n no iniciada";
            this.toolStripStatusLabel2.Text = "A�n no ha iniciado sesi�n";
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
            this.Text = "Sistema de Gesti�n y Seguimiento de Ventas";
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
        private System.Windows.Forms.ToolStripMenuItem sesi�nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iniciarSesi�nToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesi�nToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripMenuItem aprobaci�nComercialToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pedidosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomaYTraduccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem etiquetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem idiomasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem traduccionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripMenuItem gesti�nDeClientesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gesti�nDeProductosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajustesDeStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem metricasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presupuestosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bit�coraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionDePedidosToolStripMenuItem;
    }
}

