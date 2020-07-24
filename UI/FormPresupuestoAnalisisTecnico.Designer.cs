namespace UI
{
    partial class FormPresupuestoAnalisisTecnico
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
            this.buttonVis = new System.Windows.Forms.Button();
            this.buttonAp = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioPendientes = new System.Windows.Forms.RadioButton();
            this.radioButtonTodos = new System.Windows.Forms.RadioButton();
            this.dataGridViewPresup = new System.Windows.Forms.DataGridView();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresup)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.buttonVis);
            this.groupBox2.Controls.Add(this.buttonAp);
            this.groupBox2.Location = new System.Drawing.Point(7, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(233, 54);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Acciones";
            // 
            // buttonVis
            // 
            this.buttonVis.Location = new System.Drawing.Point(144, 20);
            this.buttonVis.Name = "buttonVis";
            this.buttonVis.Size = new System.Drawing.Size(75, 23);
            this.buttonVis.TabIndex = 2;
            this.buttonVis.Text = "Visualizar";
            this.buttonVis.UseVisualStyleBackColor = true;
            this.buttonVis.Click += new System.EventHandler(this.buttonVis_Click);
            // 
            // buttonAp
            // 
            this.buttonAp.Location = new System.Drawing.Point(26, 20);
            this.buttonAp.Name = "buttonAp";
            this.buttonAp.Size = new System.Drawing.Size(112, 23);
            this.buttonAp.TabIndex = 0;
            this.buttonAp.Text = "Aprobar/Rechazar";
            this.buttonAp.UseVisualStyleBackColor = true;
            this.buttonAp.Click += new System.EventHandler(this.buttonAp_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.dataGridViewPresup);
            this.groupBox1.Location = new System.Drawing.Point(7, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(859, 393);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presupuestos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioPendientes);
            this.groupBox3.Controls.Add(this.radioButtonTodos);
            this.groupBox3.Location = new System.Drawing.Point(20, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(335, 40);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar";
            // 
            // radioPendientes
            // 
            this.radioPendientes.AutoSize = true;
            this.radioPendientes.Checked = true;
            this.radioPendientes.Location = new System.Drawing.Point(17, 16);
            this.radioPendientes.Name = "radioPendientes";
            this.radioPendientes.Size = new System.Drawing.Size(150, 17);
            this.radioPendientes.TabIndex = 1;
            this.radioPendientes.TabStop = true;
            this.radioPendientes.Text = "Pendientes de Aprobación";
            this.radioPendientes.UseVisualStyleBackColor = true;
            this.radioPendientes.CheckedChanged += new System.EventHandler(this.radioPendientes_CheckedChanged);
            // 
            // radioButtonTodos
            // 
            this.radioButtonTodos.AutoSize = true;
            this.radioButtonTodos.Location = new System.Drawing.Point(184, 16);
            this.radioButtonTodos.Name = "radioButtonTodos";
            this.radioButtonTodos.Size = new System.Drawing.Size(55, 17);
            this.radioButtonTodos.TabIndex = 0;
            this.radioButtonTodos.Text = "Todos";
            this.radioButtonTodos.UseVisualStyleBackColor = true;
            this.radioButtonTodos.CheckedChanged += new System.EventHandler(this.radioButtonTodos_CheckedChanged);
            // 
            // dataGridViewPresup
            // 
            this.dataGridViewPresup.AllowUserToAddRows = false;
            this.dataGridViewPresup.AllowUserToDeleteRows = false;
            this.dataGridViewPresup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPresup.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2;
            this.dataGridViewPresup.Location = new System.Drawing.Point(18, 65);
            this.dataGridViewPresup.Name = "dataGridViewPresup";
            this.dataGridViewPresup.ReadOnly = true;
            this.dataGridViewPresup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPresup.Size = new System.Drawing.Size(835, 322);
            this.dataGridViewPresup.TabIndex = 0;
            this.dataGridViewPresup.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewPresup_CellContentClick);
            // 
            // FormPresupuestoAnalisisTecnico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 474);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPresupuestoAnalisisTecnico";
            this.Text = "Análisis Técnico de Presupuestos";
            this.Load += new System.EventHandler(this.FormPresupuestoAnalisisTecnico_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPresup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonVis;
        private System.Windows.Forms.Button buttonAp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioPendientes;
        private System.Windows.Forms.RadioButton radioButtonTodos;
        private System.Windows.Forms.DataGridView dataGridViewPresup;
    }
}