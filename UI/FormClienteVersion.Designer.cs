namespace UI
{
    partial class FormClienteVersion
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.buttonrest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCli = new System.Windows.Forms.Label();
            this.dataGridViewVersiones = new System.Windows.Forms.DataGridView();
            this.dataGridViewContenido = new System.Windows.Forms.DataGridView();
            this.dataGridViewCampos = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersiones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContenido)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCampos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridViewVersiones);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 240);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Versiones";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewCampos);
            this.groupBox2.Location = new System.Drawing.Point(311, 141);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(578, 88);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Datos Afectados";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridViewContenido);
            this.groupBox3.Location = new System.Drawing.Point(311, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(578, 97);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Contenido";
            // 
            // buttonrest
            // 
            this.buttonrest.Location = new System.Drawing.Point(780, 235);
            this.buttonrest.Name = "buttonrest";
            this.buttonrest.Size = new System.Drawing.Size(107, 42);
            this.buttonrest.TabIndex = 3;
            this.buttonrest.Text = "Restaurar Versión";
            this.buttonrest.UseVisualStyleBackColor = true;
            this.buttonrest.Click += new System.EventHandler(this.buttonrest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cliente";
            // 
            // labelCli
            // 
            this.labelCli.AutoSize = true;
            this.labelCli.Location = new System.Drawing.Point(58, 13);
            this.labelCli.Name = "labelCli";
            this.labelCli.Size = new System.Drawing.Size(35, 13);
            this.labelCli.TabIndex = 5;
            this.labelCli.Text = "label2";
            // 
            // dataGridViewVersiones
            // 
            this.dataGridViewVersiones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewVersiones.Location = new System.Drawing.Point(6, 20);
            this.dataGridViewVersiones.MultiSelect = false;
            this.dataGridViewVersiones.Name = "dataGridViewVersiones";
            this.dataGridViewVersiones.ReadOnly = true;
            this.dataGridViewVersiones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewVersiones.Size = new System.Drawing.Size(269, 209);
            this.dataGridViewVersiones.TabIndex = 0;
            this.dataGridViewVersiones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewVersiones_CellContentClick);
            // 
            // dataGridViewContenido
            // 
            this.dataGridViewContenido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewContenido.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewContenido.Name = "dataGridViewContenido";
            this.dataGridViewContenido.ReadOnly = true;
            this.dataGridViewContenido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewContenido.Size = new System.Drawing.Size(563, 72);
            this.dataGridViewContenido.TabIndex = 1;
            this.dataGridViewContenido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewContenido_CellContentClick);
            // 
            // dataGridViewCampos
            // 
            this.dataGridViewCampos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCampos.Location = new System.Drawing.Point(9, 19);
            this.dataGridViewCampos.Name = "dataGridViewCampos";
            this.dataGridViewCampos.Size = new System.Drawing.Size(563, 63);
            this.dataGridViewCampos.TabIndex = 2;
            // 
            // FormClienteVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 286);
            this.Controls.Add(this.labelCli);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonrest);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormClienteVersion";
            this.Text = "Versiones Anteriores";
            this.Load += new System.EventHandler(this.FormClienteVersion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewVersiones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewContenido)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCampos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonrest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCli;
        private System.Windows.Forms.DataGridView dataGridViewVersiones;
        private System.Windows.Forms.DataGridView dataGridViewCampos;
        private System.Windows.Forms.DataGridView dataGridViewContenido;
    }
}