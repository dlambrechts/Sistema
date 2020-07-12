namespace UI
{
    partial class FormUsuarios
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
            this.comboIdioma = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonUPD = new System.Windows.Forms.Button();
            this.buttonDEL = new System.Windows.Forms.Button();
            this.buttonCRE = new System.Windows.Forms.Button();
            this.textPass2 = new System.Windows.Forms.TextBox();
            this.textPass1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textMail = new System.Windows.Forms.TextBox();
            this.textApellido = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboIdioma);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.buttonUPD);
            this.groupBox1.Controls.Add(this.buttonDEL);
            this.groupBox1.Controls.Add(this.buttonCRE);
            this.groupBox1.Controls.Add(this.textPass2);
            this.groupBox1.Controls.Add(this.textPass1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textMail);
            this.groupBox1.Controls.Add(this.textApellido);
            this.groupBox1.Controls.Add(this.textNombre);
            this.groupBox1.Controls.Add(this.textId);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 266);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Usuario";
            // 
            // comboIdioma
            // 
            this.comboIdioma.FormattingEnabled = true;
            this.comboIdioma.Location = new System.Drawing.Point(144, 184);
            this.comboIdioma.Name = "comboIdioma";
            this.comboIdioma.Size = new System.Drawing.Size(134, 21);
            this.comboIdioma.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 192);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Idioma";
            // 
            // buttonUPD
            // 
            this.buttonUPD.Location = new System.Drawing.Point(87, 227);
            this.buttonUPD.Name = "buttonUPD";
            this.buttonUPD.Size = new System.Drawing.Size(75, 23);
            this.buttonUPD.TabIndex = 14;
            this.buttonUPD.Text = "Modificar";
            this.buttonUPD.UseVisualStyleBackColor = true;
            // 
            // buttonDEL
            // 
            this.buttonDEL.Location = new System.Drawing.Point(6, 227);
            this.buttonDEL.Name = "buttonDEL";
            this.buttonDEL.Size = new System.Drawing.Size(75, 23);
            this.buttonDEL.TabIndex = 13;
            this.buttonDEL.Text = "Eliminar";
            this.buttonDEL.UseVisualStyleBackColor = true;
            this.buttonDEL.Click += new System.EventHandler(this.buttonDEL_Click);
            // 
            // buttonCRE
            // 
            this.buttonCRE.Location = new System.Drawing.Point(203, 227);
            this.buttonCRE.Name = "buttonCRE";
            this.buttonCRE.Size = new System.Drawing.Size(75, 23);
            this.buttonCRE.TabIndex = 12;
            this.buttonCRE.Text = "Crear";
            this.buttonCRE.UseVisualStyleBackColor = true;
            this.buttonCRE.Click += new System.EventHandler(this.buttonCRE_Click);
            // 
            // textPass2
            // 
            this.textPass2.Location = new System.Drawing.Point(144, 158);
            this.textPass2.Name = "textPass2";
            this.textPass2.Size = new System.Drawing.Size(134, 20);
            this.textPass2.TabIndex = 11;
            // 
            // textPass1
            // 
            this.textPass1.Location = new System.Drawing.Point(144, 132);
            this.textPass1.Name = "textPass1";
            this.textPass1.Size = new System.Drawing.Size(134, 20);
            this.textPass1.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Confirmar Contraseña";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Contraseña";
            // 
            // textMail
            // 
            this.textMail.Location = new System.Drawing.Point(144, 106);
            this.textMail.Name = "textMail";
            this.textMail.Size = new System.Drawing.Size(134, 20);
            this.textMail.TabIndex = 7;
            // 
            // textApellido
            // 
            this.textApellido.Location = new System.Drawing.Point(144, 80);
            this.textApellido.Name = "textApellido";
            this.textApellido.Size = new System.Drawing.Size(134, 20);
            this.textApellido.TabIndex = 6;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(144, 54);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(134, 20);
            this.textNombre.TabIndex = 5;
            // 
            // textId
            // 
            this.textId.Enabled = false;
            this.textId.Location = new System.Drawing.Point(178, 27);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(100, 20);
            this.textId.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(336, 28);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(547, 349);
            this.dataGridView1.TabIndex = 1;
            // 
            // FormUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(895, 395);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormUsuarios";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.FormUsuarios_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textPass2;
        private System.Windows.Forms.TextBox textPass1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textMail;
        private System.Windows.Forms.TextBox textApellido;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonUPD;
        private System.Windows.Forms.Button buttonDEL;
        private System.Windows.Forms.Button buttonCRE;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comboIdioma;
        private System.Windows.Forms.Label label7;
    }
}