namespace UI
{
    partial class FormBackup
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.buttonCambiar = new System.Windows.Forms.Button();
            this.buttonElim = new System.Windows.Forms.Button();
            this.labelResp = new System.Windows.Forms.Label();
            this.buttonRestaurar = new System.Windows.Forms.Button();
            this.buttonNuevo = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonCambiar);
            this.groupBox2.Controls.Add(this.buttonElim);
            this.groupBox2.Controls.Add(this.labelResp);
            this.groupBox2.Controls.Add(this.buttonRestaurar);
            this.groupBox2.Controls.Add(this.buttonNuevo);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(363, 204);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Tag = "Respaldos";
            this.groupBox2.Text = "Respaldos Disponibles";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // buttonCambiar
            // 
            this.buttonCambiar.Location = new System.Drawing.Point(9, 172);
            this.buttonCambiar.Name = "buttonCambiar";
            this.buttonCambiar.Size = new System.Drawing.Size(75, 23);
            this.buttonCambiar.TabIndex = 3;
            this.buttonCambiar.Tag = "Cambiar";
            this.buttonCambiar.Text = "Cambiar";
            this.buttonCambiar.UseVisualStyleBackColor = true;
            // 
            // buttonElim
            // 
            this.buttonElim.Location = new System.Drawing.Point(260, 78);
            this.buttonElim.Name = "buttonElim";
            this.buttonElim.Size = new System.Drawing.Size(75, 23);
            this.buttonElim.TabIndex = 2;
            this.buttonElim.Tag = "Eliminar";
            this.buttonElim.Text = "Eliminar";
            this.buttonElim.UseVisualStyleBackColor = true;
            // 
            // labelResp
            // 
            this.labelResp.AutoSize = true;
            this.labelResp.Location = new System.Drawing.Point(9, 155);
            this.labelResp.Name = "labelResp";
            this.labelResp.Size = new System.Drawing.Size(35, 13);
            this.labelResp.TabIndex = 1;
            this.labelResp.Text = "Path: ";
            // 
            // buttonRestaurar
            // 
            this.buttonRestaurar.Location = new System.Drawing.Point(260, 48);
            this.buttonRestaurar.Name = "buttonRestaurar";
            this.buttonRestaurar.Size = new System.Drawing.Size(75, 23);
            this.buttonRestaurar.TabIndex = 1;
            this.buttonRestaurar.Tag = "Restaurar";
            this.buttonRestaurar.Text = "Restaurar";
            this.buttonRestaurar.UseVisualStyleBackColor = true;
            this.buttonRestaurar.Click += new System.EventHandler(this.buttonRestaurar_Click);
            // 
            // buttonNuevo
            // 
            this.buttonNuevo.Location = new System.Drawing.Point(260, 19);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(75, 23);
            this.buttonNuevo.TabIndex = 0;
            this.buttonNuevo.Tag = "Nuevo";
            this.buttonNuevo.Text = "Nuevo";
            this.buttonNuevo.UseVisualStyleBackColor = true;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(248, 121);
            this.listBox1.TabIndex = 0;
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 228);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormBackup";
            this.Tag = "Backup";
            this.Text = "Backup";
            this.Load += new System.EventHandler(this.FormBackup_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonNuevo;
        private System.Windows.Forms.Button buttonRestaurar;
        private System.Windows.Forms.Label labelResp;
        private System.Windows.Forms.Button buttonCambiar;
        private System.Windows.Forms.Button buttonElim;
    }
}