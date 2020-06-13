namespace UI
{
    partial class FormPerfilUsuario
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboUsuario = new System.Windows.Forms.ComboBox();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboGrupos = new System.Windows.Forms.ComboBox();
            this.buttonAddGrupo = new System.Windows.Forms.Button();
            this.comboPermisos = new System.Windows.Forms.ComboBox();
            this.buttonAddPerm = new System.Windows.Forms.Button();
            this.treeArbolPermisos = new System.Windows.Forms.TreeView();
            this.buttonGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonAddPerm);
            this.groupBox1.Controls.Add(this.comboPermisos);
            this.groupBox1.Controls.Add(this.buttonAddGrupo);
            this.groupBox1.Controls.Add(this.comboGrupos);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.buttonConfig);
            this.groupBox1.Controls.Add(this.comboUsuario);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(342, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configurar Perfil";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonGuardar);
            this.groupBox2.Controls.Add(this.treeArbolPermisos);
            this.groupBox2.Location = new System.Drawing.Point(374, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(285, 297);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Conjunto de Permisos";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // comboUsuario
            // 
            this.comboUsuario.FormattingEnabled = true;
            this.comboUsuario.Location = new System.Drawing.Point(58, 25);
            this.comboUsuario.Name = "comboUsuario";
            this.comboUsuario.Size = new System.Drawing.Size(278, 21);
            this.comboUsuario.TabIndex = 1;
            // 
            // buttonConfig
            // 
            this.buttonConfig.Location = new System.Drawing.Point(261, 52);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonConfig.TabIndex = 2;
            this.buttonConfig.Text = "Configurar";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Permiso:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Grupo:";
            // 
            // comboGrupos
            // 
            this.comboGrupos.FormattingEnabled = true;
            this.comboGrupos.Location = new System.Drawing.Point(60, 101);
            this.comboGrupos.Name = "comboGrupos";
            this.comboGrupos.Size = new System.Drawing.Size(276, 21);
            this.comboGrupos.TabIndex = 5;
            // 
            // buttonAddGrupo
            // 
            this.buttonAddGrupo.Location = new System.Drawing.Point(261, 128);
            this.buttonAddGrupo.Name = "buttonAddGrupo";
            this.buttonAddGrupo.Size = new System.Drawing.Size(75, 23);
            this.buttonAddGrupo.TabIndex = 6;
            this.buttonAddGrupo.Text = "Agregar >>";
            this.buttonAddGrupo.UseVisualStyleBackColor = true;
            this.buttonAddGrupo.Click += new System.EventHandler(this.buttonAddGrupo_Click);
            // 
            // comboPermisos
            // 
            this.comboPermisos.FormattingEnabled = true;
            this.comboPermisos.Location = new System.Drawing.Point(60, 182);
            this.comboPermisos.Name = "comboPermisos";
            this.comboPermisos.Size = new System.Drawing.Size(276, 21);
            this.comboPermisos.TabIndex = 7;
            // 
            // buttonAddPerm
            // 
            this.buttonAddPerm.Location = new System.Drawing.Point(261, 209);
            this.buttonAddPerm.Name = "buttonAddPerm";
            this.buttonAddPerm.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPerm.TabIndex = 8;
            this.buttonAddPerm.Text = "Agregar >>";
            this.buttonAddPerm.UseVisualStyleBackColor = true;
            this.buttonAddPerm.Click += new System.EventHandler(this.buttonAddPerm_Click);
            // 
            // treeArbolPermisos
            // 
            this.treeArbolPermisos.Location = new System.Drawing.Point(6, 25);
            this.treeArbolPermisos.Name = "treeArbolPermisos";
            this.treeArbolPermisos.Size = new System.Drawing.Size(261, 237);
            this.treeArbolPermisos.TabIndex = 0;
            // 
            // buttonGuardar
            // 
            this.buttonGuardar.Location = new System.Drawing.Point(192, 268);
            this.buttonGuardar.Name = "buttonGuardar";
            this.buttonGuardar.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardar.TabIndex = 1;
            this.buttonGuardar.Text = "Guardar";
            this.buttonGuardar.UseVisualStyleBackColor = true;
            this.buttonGuardar.Click += new System.EventHandler(this.buttonGuardar_Click);
            // 
            // FormPerfilUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 332);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPerfilUsuario";
            this.Text = "Perfil de los Usuarios";
            this.Load += new System.EventHandler(this.FormPerfilUsuario_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddPerm;
        private System.Windows.Forms.ComboBox comboPermisos;
        private System.Windows.Forms.Button buttonAddGrupo;
        private System.Windows.Forms.ComboBox comboGrupos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.ComboBox comboUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonGuardar;
        private System.Windows.Forms.TreeView treeArbolPermisos;
    }
}