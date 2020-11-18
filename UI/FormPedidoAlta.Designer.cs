namespace UI
{
    partial class FormPedidoAlta
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
            this.buttonVerPres = new System.Windows.Forms.Button();
            this.listBoxPresup = new System.Windows.Forms.ListBox();
            this.buttonCargarPresup = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxCargo = new System.Windows.Forms.ComboBox();
            this.textBoxDir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridItemsPedido = new System.Windows.Forms.DataGridView();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labrlPresup = new System.Windows.Forms.Label();
            this.labelCli = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConfirmar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItemsPedido)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonVerPres);
            this.groupBox1.Controls.Add(this.listBoxPresup);
            this.groupBox1.Controls.Add(this.buttonCargarPresup);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 410);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Presupuestos Aprobados";
            // 
            // buttonVerPres
            // 
            this.buttonVerPres.Location = new System.Drawing.Point(141, 372);
            this.buttonVerPres.Name = "buttonVerPres";
            this.buttonVerPres.Size = new System.Drawing.Size(76, 32);
            this.buttonVerPres.TabIndex = 2;
            this.buttonVerPres.Text = "Ver";
            this.buttonVerPres.UseVisualStyleBackColor = true;
            this.buttonVerPres.Click += new System.EventHandler(this.buttonVerPres_Click);
            // 
            // listBoxPresup
            // 
            this.listBoxPresup.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.listBoxPresup.FormattingEnabled = true;
            this.listBoxPresup.ItemHeight = 16;
            this.listBoxPresup.Location = new System.Drawing.Point(6, 24);
            this.listBoxPresup.Name = "listBoxPresup";
            this.listBoxPresup.Size = new System.Drawing.Size(316, 324);
            this.listBoxPresup.TabIndex = 1;
            // 
            // buttonCargarPresup
            // 
            this.buttonCargarPresup.Location = new System.Drawing.Point(247, 372);
            this.buttonCargarPresup.Name = "buttonCargarPresup";
            this.buttonCargarPresup.Size = new System.Drawing.Size(75, 32);
            this.buttonCargarPresup.TabIndex = 0;
            this.buttonCargarPresup.Text = "Cargar";
            this.buttonCargarPresup.UseVisualStyleBackColor = true;
            this.buttonCargarPresup.Click += new System.EventHandler(this.buttonCargarPresup_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.dataGridItemsPedido);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.labrlPresup);
            this.groupBox2.Controls.Add(this.labelCli);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonConfirmar);
            this.groupBox2.Location = new System.Drawing.Point(365, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(411, 410);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pedido";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.comboBoxCargo);
            this.groupBox3.Controls.Add(this.textBoxDir);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(6, 252);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(370, 114);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Entrega";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(8, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(55, 17);
            this.checkBox1.TabIndex = 14;
            this.checkBox1.Text = "Envío";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Dirección de Entrega";
            // 
            // comboBoxCargo
            // 
            this.comboBoxCargo.Enabled = false;
            this.comboBoxCargo.FormattingEnabled = true;
            this.comboBoxCargo.Items.AddRange(new object[] {
            "Cliente",
            "Vendedor"});
            this.comboBoxCargo.Location = new System.Drawing.Point(237, 77);
            this.comboBoxCargo.Name = "comboBoxCargo";
            this.comboBoxCargo.Size = new System.Drawing.Size(127, 21);
            this.comboBoxCargo.TabIndex = 13;
            this.comboBoxCargo.Text = "Cliente";
            // 
            // textBoxDir
            // 
            this.textBoxDir.Enabled = false;
            this.textBoxDir.Location = new System.Drawing.Point(141, 51);
            this.textBoxDir.Name = "textBoxDir";
            this.textBoxDir.Size = new System.Drawing.Size(223, 20);
            this.textBoxDir.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Envío a Cargo de";
            // 
            // dataGridItemsPedido
            // 
            this.dataGridItemsPedido.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridItemsPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridItemsPedido.Location = new System.Drawing.Point(9, 63);
            this.dataGridItemsPedido.Name = "dataGridItemsPedido";
            this.dataGridItemsPedido.Size = new System.Drawing.Size(371, 183);
            this.dataGridItemsPedido.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(294, 19);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(92, 20);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // labrlPresup
            // 
            this.labrlPresup.AutoSize = true;
            this.labrlPresup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labrlPresup.Location = new System.Drawing.Point(101, 47);
            this.labrlPresup.Name = "labrlPresup";
            this.labrlPresup.Size = new System.Drawing.Size(0, 13);
            this.labrlPresup.TabIndex = 6;
            // 
            // labelCli
            // 
            this.labelCli.AutoSize = true;
            this.labelCli.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCli.Location = new System.Drawing.Point(101, 24);
            this.labelCli.Name = "labelCli";
            this.labelCli.Size = new System.Drawing.Size(0, 13);
            this.labelCli.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Fecha Entrega";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Presupuesto";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Cliente";
            // 
            // buttonConfirmar
            // 
            this.buttonConfirmar.Location = new System.Drawing.Point(316, 372);
            this.buttonConfirmar.Name = "buttonConfirmar";
            this.buttonConfirmar.Size = new System.Drawing.Size(75, 32);
            this.buttonConfirmar.TabIndex = 0;
            this.buttonConfirmar.Text = "Confirmar";
            this.buttonConfirmar.UseVisualStyleBackColor = true;
            this.buttonConfirmar.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // FormPedidoAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 439);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPedidoAlta";
            this.Text = "Nuevo Pedido";
            this.Load += new System.EventHandler(this.FormPedidoAlta_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridItemsPedido)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxPresup;
        private System.Windows.Forms.Button buttonCargarPresup;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonConfirmar;
        private System.Windows.Forms.DataGridView dataGridItemsPedido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label labrlPresup;
        private System.Windows.Forms.Label labelCli;
        private System.Windows.Forms.ComboBox comboBoxCargo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDir;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonVerPres;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}