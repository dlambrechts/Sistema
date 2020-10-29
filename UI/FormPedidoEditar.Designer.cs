namespace UI
{
    partial class FormPedidoEditar
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
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelEmision = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelPRes = new System.Windows.Forms.Label();
            this.labelCli = new System.Windows.Forms.Label();
            this.labelNum = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerEntrega = new System.Windows.Forms.DateTimePicker();
            this.buttonAct = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridViewItems);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 284);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Items";
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Location = new System.Drawing.Point(9, 20);
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.Size = new System.Drawing.Size(348, 253);
            this.dataGridViewItems.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePickerEntrega);
            this.groupBox1.Controls.Add(this.labelEmision);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.labelPRes);
            this.groupBox1.Controls.Add(this.labelCli);
            this.groupBox1.Controls.Add(this.labelNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 92);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cabecera";
            // 
            // labelEmision
            // 
            this.labelEmision.AutoSize = true;
            this.labelEmision.Location = new System.Drawing.Point(277, 25);
            this.labelEmision.Name = "labelEmision";
            this.labelEmision.Size = new System.Drawing.Size(32, 13);
            this.labelEmision.TabIndex = 9;
            this.labelEmision.Text = "fEmis";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(175, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fecha de Emisión";
            // 
            // labelPRes
            // 
            this.labelPRes.AutoSize = true;
            this.labelPRes.Location = new System.Drawing.Point(94, 69);
            this.labelPRes.Name = "labelPRes";
            this.labelPRes.Size = new System.Drawing.Size(35, 13);
            this.labelPRes.TabIndex = 7;
            this.labelPRes.Text = "label5";
            // 
            // labelCli
            // 
            this.labelCli.AutoSize = true;
            this.labelCli.Location = new System.Drawing.Point(58, 48);
            this.labelCli.Name = "labelCli";
            this.labelCli.Size = new System.Drawing.Size(18, 13);
            this.labelCli.TabIndex = 5;
            this.labelCli.Text = "Cli";
            // 
            // labelNum
            // 
            this.labelNum.AutoSize = true;
            this.labelNum.Location = new System.Drawing.Point(58, 25);
            this.labelNum.Name = "labelNum";
            this.labelNum.Size = new System.Drawing.Size(46, 13);
            this.labelNum.TabIndex = 4;
            this.labelNum.Text = "numPed";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(174, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha de Entrega";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Presupuesto N°";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Pedido N°";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cliente";
            // 
            // dateTimePickerEntrega
            // 
            this.dateTimePickerEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEntrega.Location = new System.Drawing.Point(272, 48);
            this.dateTimePickerEntrega.Name = "dateTimePickerEntrega";
            this.dateTimePickerEntrega.Size = new System.Drawing.Size(89, 20);
            this.dateTimePickerEntrega.TabIndex = 10;
            // 
            // buttonAct
            // 
            this.buttonAct.Location = new System.Drawing.Point(294, 400);
            this.buttonAct.Name = "buttonAct";
            this.buttonAct.Size = new System.Drawing.Size(75, 30);
            this.buttonAct.TabIndex = 4;
            this.buttonAct.Text = "Actualizar";
            this.buttonAct.UseVisualStyleBackColor = true;
            this.buttonAct.Click += new System.EventHandler(this.buttonAct_Click);
            // 
            // FormPedidoEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 434);
            this.Controls.Add(this.buttonAct);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormPedidoEditar";
            this.Text = "Editar Pedido";
            this.Load += new System.EventHandler(this.FormPedidoEditar_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePickerEntrega;
        private System.Windows.Forms.Label labelEmision;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelPRes;
        private System.Windows.Forms.Label labelCli;
        private System.Windows.Forms.Label labelNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAct;
    }
}