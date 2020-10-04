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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonNuevo = new System.Windows.Forms.Button();
            this.buttonRestaurar = new System.Windows.Forms.Button();
            this.labelResp = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelResp);
            this.groupBox2.Controls.Add(this.buttonRestaurar);
            this.groupBox2.Controls.Add(this.buttonNuevo);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(388, 192);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Respaldos Disponibles";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 19);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(235, 121);
            this.listBox1.TabIndex = 0;
            // 
            // buttonNuevo
            // 
            this.buttonNuevo.Location = new System.Drawing.Point(262, 48);
            this.buttonNuevo.Name = "buttonNuevo";
            this.buttonNuevo.Size = new System.Drawing.Size(75, 23);
            this.buttonNuevo.TabIndex = 0;
            this.buttonNuevo.Text = "Nuevo";
            this.buttonNuevo.UseVisualStyleBackColor = true;
            this.buttonNuevo.Click += new System.EventHandler(this.buttonNuevo_Click);
            // 
            // buttonRestaurar
            // 
            this.buttonRestaurar.Location = new System.Drawing.Point(262, 19);
            this.buttonRestaurar.Name = "buttonRestaurar";
            this.buttonRestaurar.Size = new System.Drawing.Size(75, 23);
            this.buttonRestaurar.TabIndex = 1;
            this.buttonRestaurar.Text = "Restaurar";
            this.buttonRestaurar.UseVisualStyleBackColor = true;
            this.buttonRestaurar.Click += new System.EventHandler(this.buttonRestaurar_Click);
            // 
            // labelResp
            // 
            this.labelResp.AutoSize = true;
            this.labelResp.Location = new System.Drawing.Point(6, 155);
            this.labelResp.Name = "labelResp";
            this.labelResp.Size = new System.Drawing.Size(188, 13);
            this.labelResp.TabIndex = 1;
            this.labelResp.Text = "La ruta predeterminada de Backup es ";
            // 
            // FormBackup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 217);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormBackup";
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
    }
}