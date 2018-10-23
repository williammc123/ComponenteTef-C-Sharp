namespace ComponenteTef
{
	partial class ComponenteTef
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
			this.textBoxresultado = new System.Windows.Forms.TextBox();
			this.labelValor = new System.Windows.Forms.Label();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.comboBoxPagamento = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.comboBoxParcelas = new System.Windows.Forms.ComboBox();
			this.panelTopo = new System.Windows.Forms.Panel();
			this.labelLogo = new System.Windows.Forms.Label();
			this.comboBoxAdm = new System.Windows.Forms.ComboBox();
			this.labelAdm = new System.Windows.Forms.Label();
			this.textBoxNumeroControle = new System.Windows.Forms.TextBox();
			this.labelNumeroControle = new System.Windows.Forms.Label();
			this.comboBoxTipoVia = new System.Windows.Forms.ComboBox();
			this.labelTipoVia = new System.Windows.Forms.Label();
			this.comboBoxTipoParcelamento = new System.Windows.Forms.ComboBox();
			this.panelTopo.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxresultado
			// 
			this.textBoxresultado.BackColor = System.Drawing.Color.DarkSlateGray;
			this.textBoxresultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBoxresultado.ForeColor = System.Drawing.SystemColors.Window;
			this.textBoxresultado.Location = new System.Drawing.Point(2, 199);
			this.textBoxresultado.Multiline = true;
			this.textBoxresultado.Name = "textBoxresultado";
			this.textBoxresultado.Size = new System.Drawing.Size(602, 98);
			this.textBoxresultado.TabIndex = 0;
			this.textBoxresultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// labelValor
			// 
			this.labelValor.AutoSize = true;
			this.labelValor.BackColor = System.Drawing.SystemColors.Menu;
			this.labelValor.Location = new System.Drawing.Point(12, 72);
			this.labelValor.Name = "labelValor";
			this.labelValor.Size = new System.Drawing.Size(31, 13);
			this.labelValor.TabIndex = 2;
			this.labelValor.Text = "Valor";
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(12, 90);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(110, 30);
			this.textBox1.TabIndex = 3;
			// 
			// comboBoxPagamento
			// 
			this.comboBoxPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxPagamento.FormattingEnabled = true;
			this.comboBoxPagamento.Items.AddRange(new object[] {
            "Debito",
            "Credito"});
			this.comboBoxPagamento.Location = new System.Drawing.Point(142, 91);
			this.comboBoxPagamento.Name = "comboBoxPagamento";
			this.comboBoxPagamento.Size = new System.Drawing.Size(150, 28);
			this.comboBoxPagamento.TabIndex = 4;
			this.comboBoxPagamento.Text = "Débito";
			this.comboBoxPagamento.SelectedIndexChanged += new System.EventHandler(this.Pagamento_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.SystemColors.Menu;
			this.label1.Location = new System.Drawing.Point(139, 72);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Tipo de Pagamento";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.Menu;
			this.label2.Location = new System.Drawing.Point(308, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(111, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Tipo de Parcelamento";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.SystemColors.Menu;
			this.label3.Location = new System.Drawing.Point(472, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "Parcelas";
			// 
			// comboBoxParcelas
			// 
			this.comboBoxParcelas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxParcelas.FormattingEnabled = true;
			this.comboBoxParcelas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
			this.comboBoxParcelas.Location = new System.Drawing.Point(475, 91);
			this.comboBoxParcelas.Name = "comboBoxParcelas";
			this.comboBoxParcelas.Size = new System.Drawing.Size(104, 28);
			this.comboBoxParcelas.TabIndex = 9;
			this.comboBoxParcelas.Text = "1";
			// 
			// panelTopo
			// 
			this.panelTopo.BackColor = System.Drawing.Color.DarkSlateGray;
			this.panelTopo.Controls.Add(this.labelLogo);
			this.panelTopo.Location = new System.Drawing.Point(2, 3);
			this.panelTopo.Name = "panelTopo";
			this.panelTopo.Size = new System.Drawing.Size(602, 49);
			this.panelTopo.TabIndex = 10;
			// 
			// labelLogo
			// 
			this.labelLogo.AutoSize = true;
			this.labelLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.labelLogo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.labelLogo.Location = new System.Drawing.Point(7, 6);
			this.labelLogo.Name = "labelLogo";
			this.labelLogo.Size = new System.Drawing.Size(82, 33);
			this.labelLogo.TabIndex = 0;
			this.labelLogo.Text = " PDV";
			// 
			// comboBoxAdm
			// 
			this.comboBoxAdm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxAdm.FormattingEnabled = true;
			this.comboBoxAdm.Items.AddRange(new object[] {
            "Reimpressão",
            "Cancelamento"});
			this.comboBoxAdm.Location = new System.Drawing.Point(12, 161);
			this.comboBoxAdm.Name = "comboBoxAdm";
			this.comboBoxAdm.Size = new System.Drawing.Size(150, 28);
			this.comboBoxAdm.TabIndex = 11;
			this.comboBoxAdm.Text = "Reimpressão";
			this.comboBoxAdm.SelectedIndexChanged += new System.EventHandler(this.OpcaoAdmcomboBoxAdm_SelectedIndexChanged);
			// 
			// labelAdm
			// 
			this.labelAdm.AutoSize = true;
			this.labelAdm.BackColor = System.Drawing.SystemColors.Menu;
			this.labelAdm.Location = new System.Drawing.Point(12, 140);
			this.labelAdm.Name = "labelAdm";
			this.labelAdm.Size = new System.Drawing.Size(102, 13);
			this.labelAdm.TabIndex = 12;
			this.labelAdm.Text = "Escolha a operação";
			// 
			// textBoxNumeroControle
			// 
			this.textBoxNumeroControle.Location = new System.Drawing.Point(419, 161);
			this.textBoxNumeroControle.Multiline = true;
			this.textBoxNumeroControle.Name = "textBoxNumeroControle";
			this.textBoxNumeroControle.Size = new System.Drawing.Size(160, 30);
			this.textBoxNumeroControle.TabIndex = 13;
			// 
			// labelNumeroControle
			// 
			this.labelNumeroControle.AutoSize = true;
			this.labelNumeroControle.BackColor = System.Drawing.SystemColors.Menu;
			this.labelNumeroControle.Location = new System.Drawing.Point(416, 140);
			this.labelNumeroControle.Name = "labelNumeroControle";
			this.labelNumeroControle.Size = new System.Drawing.Size(101, 13);
			this.labelNumeroControle.TabIndex = 14;
			this.labelNumeroControle.Text = "Número de Controle";
			// 
			// comboBoxTipoVia
			// 
			this.comboBoxTipoVia.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxTipoVia.FormattingEnabled = true;
			this.comboBoxTipoVia.Items.AddRange(new object[] {
            "",
            "Completa",
            "Via Cliente",
            "Via Loja",
            ""});
			this.comboBoxTipoVia.Location = new System.Drawing.Point(213, 161);
			this.comboBoxTipoVia.Name = "comboBoxTipoVia";
			this.comboBoxTipoVia.Size = new System.Drawing.Size(150, 28);
			this.comboBoxTipoVia.TabIndex = 15;
			this.comboBoxTipoVia.Text = "Via Cliente";
			this.comboBoxTipoVia.Visible = false;
			this.comboBoxTipoVia.SelectedIndexChanged += new System.EventHandler(this.EscolherViacomboBoxTipoVia_SelectedIndexChanged);
			// 
			// labelTipoVia
			// 
			this.labelTipoVia.AutoSize = true;
			this.labelTipoVia.BackColor = System.Drawing.SystemColors.Menu;
			this.labelTipoVia.Location = new System.Drawing.Point(210, 140);
			this.labelTipoVia.Name = "labelTipoVia";
			this.labelTipoVia.Size = new System.Drawing.Size(72, 13);
			this.labelTipoVia.TabIndex = 16;
			this.labelTipoVia.Text = "Escolha a Via";
			this.labelTipoVia.Visible = false;
			// 
			// comboBoxTipoParcelamento
			// 
			this.comboBoxTipoParcelamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.comboBoxTipoParcelamento.FormattingEnabled = true;
			this.comboBoxTipoParcelamento.Items.AddRange(new object[] {
            "Administradora",
            "Loja"});
			this.comboBoxTipoParcelamento.Location = new System.Drawing.Point(311, 92);
			this.comboBoxTipoParcelamento.Name = "comboBoxTipoParcelamento";
			this.comboBoxTipoParcelamento.Size = new System.Drawing.Size(150, 28);
			this.comboBoxTipoParcelamento.TabIndex = 17;
			this.comboBoxTipoParcelamento.Text = "Loja";
			// 
			// ComponenteTef
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(605, 297);
			this.Controls.Add(this.comboBoxTipoParcelamento);
			this.Controls.Add(this.labelTipoVia);
			this.Controls.Add(this.comboBoxTipoVia);
			this.Controls.Add(this.labelNumeroControle);
			this.Controls.Add(this.textBoxNumeroControle);
			this.Controls.Add(this.labelAdm);
			this.Controls.Add(this.comboBoxAdm);
			this.Controls.Add(this.panelTopo);
			this.Controls.Add(this.comboBoxParcelas);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.comboBoxPagamento);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.labelValor);
			this.Controls.Add(this.textBoxresultado);
			this.Name = "ComponenteTef";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Componente Tef";
			this.Load += new System.EventHandler(this.ComponenteTef_Load);
			this.panelTopo.ResumeLayout(false);
			this.panelTopo.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxresultado;
		private System.Windows.Forms.Label labelValor;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox comboBoxPagamento;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox comboBoxParcelas;
		private System.Windows.Forms.Panel panelTopo;
		private System.Windows.Forms.Label labelLogo;
		private System.Windows.Forms.ComboBox comboBoxAdm;
		private System.Windows.Forms.Label labelAdm;
		private System.Windows.Forms.TextBox textBoxNumeroControle;
		private System.Windows.Forms.Label labelNumeroControle;
		private System.Windows.Forms.ComboBox comboBoxTipoVia;
		private System.Windows.Forms.Label labelTipoVia;
		private System.Windows.Forms.ComboBox comboBoxTipoParcelamento;
	}
}

