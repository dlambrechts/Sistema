namespace UI
{
    partial class FormPerfiles
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
            this.buttonPermisoQuitar = new System.Windows.Forms.Button();
            this.buttonAgregarPermiso = new System.Windows.Forms.Button();
            this.comboPermisos = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.buttonGuardarPermiso = new System.Windows.Forms.Button();
            this.comboPermAtom = new System.Windows.Forms.ComboBox();
            this.textDescripcionPerm = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonQuitarGrupo = new System.Windows.Forms.Button();
            this.buttonAgrgarGrupo = new System.Windows.Forms.Button();
            this.buttonConfig = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.buttonGuardarGrupo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNombreGrupo = new System.Windows.Forms.TextBox();
            this.comboGrupos = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.treeFam = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonPermisoQuitar);
            this.groupBox1.Controls.Add(this.buttonAgregarPermiso);
            this.groupBox1.Controls.Add(this.comboPermisos);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(11, 247);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 226);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Tag = "Permisos";
            this.groupBox1.Text = "Permisos";
            // 
            // buttonPermisoQuitar
            // 
            this.buttonPermisoQuitar.Location = new System.Drawing.Point(220, 75);
            this.buttonPermisoQuitar.Name = "buttonPermisoQuitar";
            this.buttonPermisoQuitar.Size = new System.Drawing.Size(105, 23);
            this.buttonPermisoQuitar.TabIndex = 3;
            this.buttonPermisoQuitar.Tag = "Quitar";
            this.buttonPermisoQuitar.Text = "Quitar <<<";
            this.buttonPermisoQuitar.UseVisualStyleBackColor = true;
            this.buttonPermisoQuitar.Click += new System.EventHandler(this.buttonPermisoQuitar_Click);
            // 
            // buttonAgregarPermiso
            // 
            this.buttonAgregarPermiso.Location = new System.Drawing.Point(219, 46);
            this.buttonAgregarPermiso.Name = "buttonAgregarPermiso";
            this.buttonAgregarPermiso.Size = new System.Drawing.Size(106, 23);
            this.buttonAgregarPermiso.TabIndex = 2;
            this.buttonAgregarPermiso.Tag = "Agregar";
            this.buttonAgregarPermiso.Text = "Agregar >>>";
            this.buttonAgregarPermiso.UseVisualStyleBackColor = true;
            this.buttonAgregarPermiso.Click += new System.EventHandler(this.buttonAgregarPermiso_Click);
            // 
            // comboPermisos
            // 
            this.comboPermisos.FormattingEnabled = true;
            this.comboPermisos.Location = new System.Drawing.Point(68, 19);
            this.comboPermisos.Name = "comboPermisos";
            this.comboPermisos.Size = new System.Drawing.Size(257, 21);
            this.comboPermisos.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.buttonGuardarPermiso);
            this.groupBox4.Controls.Add(this.comboPermAtom);
            this.groupBox4.Controls.Add(this.textDescripcionPerm);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(6, 96);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(325, 115);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Tag = "Nuevo";
            this.groupBox4.Text = "Nuevo Permiso";
            // 
            // buttonGuardarPermiso
            // 
            this.buttonGuardarPermiso.Location = new System.Drawing.Point(244, 75);
            this.buttonGuardarPermiso.Name = "buttonGuardarPermiso";
            this.buttonGuardarPermiso.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardarPermiso.TabIndex = 4;
            this.buttonGuardarPermiso.Tag = "Guardar";
            this.buttonGuardarPermiso.Text = "Guardar";
            this.buttonGuardarPermiso.UseVisualStyleBackColor = true;
            this.buttonGuardarPermiso.Click += new System.EventHandler(this.buttonGuardarPermiso_Click);
            // 
            // comboPermAtom
            // 
            this.comboPermAtom.FormattingEnabled = true;
            this.comboPermAtom.Location = new System.Drawing.Point(98, 16);
            this.comboPermAtom.Name = "comboPermAtom";
            this.comboPermAtom.Size = new System.Drawing.Size(221, 21);
            this.comboPermAtom.TabIndex = 3;
            // 
            // textDescripcionPerm
            // 
            this.textDescripcionPerm.Location = new System.Drawing.Point(98, 49);
            this.textDescripcionPerm.Name = "textDescripcionPerm";
            this.textDescripcionPerm.Size = new System.Drawing.Size(221, 20);
            this.textDescripcionPerm.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Tag = "Descripción";
            this.label2.Text = "Descripción";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Tag = "Permiso atómico";
            this.label1.Text = "Permiso Atómico";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonQuitarGrupo);
            this.groupBox2.Controls.Add(this.buttonAgrgarGrupo);
            this.groupBox2.Controls.Add(this.buttonConfig);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.comboGrupos);
            this.groupBox2.Location = new System.Drawing.Point(11, 24);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 224);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "Grupos";
            this.groupBox2.Text = "Grupos";
            // 
            // buttonQuitarGrupo
            // 
            this.buttonQuitarGrupo.Location = new System.Drawing.Point(220, 75);
            this.buttonQuitarGrupo.Name = "buttonQuitarGrupo";
            this.buttonQuitarGrupo.Size = new System.Drawing.Size(105, 23);
            this.buttonQuitarGrupo.TabIndex = 4;
            this.buttonQuitarGrupo.Tag = "Quitar";
            this.buttonQuitarGrupo.Text = "Quitar <<<";
            this.buttonQuitarGrupo.UseVisualStyleBackColor = true;
            this.buttonQuitarGrupo.Click += new System.EventHandler(this.buttonQuitarGrupo_Click);
            // 
            // buttonAgrgarGrupo
            // 
            this.buttonAgrgarGrupo.Location = new System.Drawing.Point(220, 46);
            this.buttonAgrgarGrupo.Name = "buttonAgrgarGrupo";
            this.buttonAgrgarGrupo.Size = new System.Drawing.Size(106, 23);
            this.buttonAgrgarGrupo.TabIndex = 3;
            this.buttonAgrgarGrupo.Tag = "Agregar";
            this.buttonAgrgarGrupo.Text = "Agregar >>>";
            this.buttonAgrgarGrupo.UseVisualStyleBackColor = true;
            this.buttonAgrgarGrupo.Click += new System.EventHandler(this.buttonAgrgarGrupo_Click);
            // 
            // buttonConfig
            // 
            this.buttonConfig.Location = new System.Drawing.Point(79, 46);
            this.buttonConfig.Name = "buttonConfig";
            this.buttonConfig.Size = new System.Drawing.Size(75, 23);
            this.buttonConfig.TabIndex = 2;
            this.buttonConfig.Tag = "Configurar";
            this.buttonConfig.Text = "Configurar";
            this.buttonConfig.UseVisualStyleBackColor = true;
            this.buttonConfig.Click += new System.EventHandler(this.buttonConfig_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.buttonGuardarGrupo);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.textBoxNombreGrupo);
            this.groupBox5.Location = new System.Drawing.Point(7, 104);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(325, 103);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Tag = "Nuevo";
            this.groupBox5.Text = "Nuevo";
            // 
            // buttonGuardarGrupo
            // 
            this.buttonGuardarGrupo.Location = new System.Drawing.Point(244, 69);
            this.buttonGuardarGrupo.Name = "buttonGuardarGrupo";
            this.buttonGuardarGrupo.Size = new System.Drawing.Size(75, 23);
            this.buttonGuardarGrupo.TabIndex = 2;
            this.buttonGuardarGrupo.Tag = "Guardar";
            this.buttonGuardarGrupo.Text = "Guardar";
            this.buttonGuardarGrupo.UseVisualStyleBackColor = true;
            this.buttonGuardarGrupo.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Tag = "Descripción";
            this.label3.Text = "Descripción";
            // 
            // textBoxNombreGrupo
            // 
            this.textBoxNombreGrupo.Location = new System.Drawing.Point(98, 43);
            this.textBoxNombreGrupo.Name = "textBoxNombreGrupo";
            this.textBoxNombreGrupo.Size = new System.Drawing.Size(221, 20);
            this.textBoxNombreGrupo.TabIndex = 0;
            // 
            // comboGrupos
            // 
            this.comboGrupos.FormattingEnabled = true;
            this.comboGrupos.Location = new System.Drawing.Point(69, 19);
            this.comboGrupos.Name = "comboGrupos";
            this.comboGrupos.Size = new System.Drawing.Size(257, 21);
            this.comboGrupos.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.treeFam);
            this.groupBox3.Location = new System.Drawing.Point(368, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(301, 423);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Tag = "Configuración del grupo";
            this.groupBox3.Text = "Configuración del Grupo";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Tag = "Guardar";
            this.button1.Text = "Guardar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // treeFam
            // 
            this.treeFam.Location = new System.Drawing.Point(6, 19);
            this.treeFam.Name = "treeFam";
            this.treeFam.Size = new System.Drawing.Size(289, 360);
            this.treeFam.TabIndex = 0;
            // 
            // FormPerfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 485);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPerfiles";
            this.Tag = "Perfiles";
            this.Text = "Perfiles de Acceso";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPerfiles_FormClosing);
            this.Load += new System.EventHandler(this.FormPerfiles_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboPermAtom;
        private System.Windows.Forms.TextBox textDescripcionPerm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGuardarPermiso;
        private System.Windows.Forms.Button buttonAgregarPermiso;
        private System.Windows.Forms.ComboBox comboPermisos;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboGrupos;
        private System.Windows.Forms.Button buttonAgrgarGrupo;
        private System.Windows.Forms.Button buttonConfig;
        private System.Windows.Forms.Button buttonGuardarGrupo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNombreGrupo;
        private System.Windows.Forms.TreeView treeFam;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonQuitarGrupo;
        private System.Windows.Forms.Button buttonPermisoQuitar;
    }
}