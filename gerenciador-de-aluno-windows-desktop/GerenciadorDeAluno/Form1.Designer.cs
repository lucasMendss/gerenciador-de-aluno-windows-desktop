namespace GerenciadorDeAluno
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            rbConsultar = new RadioButton();
            label1 = new Label();
            txtProntuario = new TextBox();
            btnLimpar = new Button();
            gbCampos = new GroupBox();
            btnGerarProntuario = new Button();
            txtEmail = new TextBox();
            label5 = new Label();
            txtRG = new TextBox();
            label3 = new Label();
            txtCPF = new TextBox();
            label4 = new Label();
            txtNome = new TextBox();
            label2 = new Label();
            rbAlterar = new RadioButton();
            rbExcluir = new RadioButton();
            rbIncluir = new RadioButton();
            btnAcao = new Button();
            lblStatus = new Label();
            label6 = new Label();
            lbOpcoesConsulta = new ListBox();
            label7 = new Label();
            txtConsulta = new TextBox();
            btnConsultar = new Button();
            gbCamposConsulta = new GroupBox();
            gbCampos.SuspendLayout();
            gbCamposConsulta.SuspendLayout();
            SuspendLayout();
            // 
            // rbConsultar
            // 
            rbConsultar.AutoSize = true;
            rbConsultar.Location = new Point(18, 12);
            rbConsultar.Name = "rbConsultar";
            rbConsultar.Size = new Size(109, 19);
            rbConsultar.TabIndex = 0;
            rbConsultar.TabStop = true;
            rbConsultar.Text = "Consultar aluno";
            rbConsultar.UseVisualStyleBackColor = true;
            rbConsultar.CheckedChanged += rbConsultar_CheckedChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 33);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 1;
            label1.Text = "Prontuário:";
            // 
            // txtProntuario
            // 
            txtProntuario.CharacterCasing = CharacterCasing.Upper;
            txtProntuario.Location = new Point(82, 30);
            txtProntuario.MaxLength = 9;
            txtProntuario.Name = "txtProntuario";
            txtProntuario.ReadOnly = true;
            txtProntuario.Size = new Size(383, 23);
            txtProntuario.TabIndex = 2;
            txtProntuario.TextChanged += txtProntuario_TextChanged;
            // 
            // btnLimpar
            // 
            btnLimpar.Location = new Point(18, 326);
            btnLimpar.Name = "btnLimpar";
            btnLimpar.Size = new Size(235, 23);
            btnLimpar.TabIndex = 3;
            btnLimpar.Text = "Limpar";
            btnLimpar.UseVisualStyleBackColor = true;
            btnLimpar.Click += btnLimpar_Click;
            // 
            // gbCampos
            // 
            gbCampos.Controls.Add(btnGerarProntuario);
            gbCampos.Controls.Add(txtEmail);
            gbCampos.Controls.Add(label5);
            gbCampos.Controls.Add(txtRG);
            gbCampos.Controls.Add(label1);
            gbCampos.Controls.Add(label3);
            gbCampos.Controls.Add(txtProntuario);
            gbCampos.Controls.Add(txtCPF);
            gbCampos.Controls.Add(label4);
            gbCampos.Controls.Add(txtNome);
            gbCampos.Controls.Add(label2);
            gbCampos.Location = new Point(18, 87);
            gbCampos.Name = "gbCampos";
            gbCampos.Size = new Size(585, 233);
            gbCampos.TabIndex = 4;
            gbCampos.TabStop = false;
            gbCampos.Text = "Campos (informe dados fictícios, e não seus dados reais):";
            // 
            // btnGerarProntuario
            // 
            btnGerarProntuario.Enabled = false;
            btnGerarProntuario.Location = new Point(471, 30);
            btnGerarProntuario.Name = "btnGerarProntuario";
            btnGerarProntuario.Size = new Size(100, 23);
            btnGerarProntuario.TabIndex = 17;
            btnGerarProntuario.Text = "Gerar aleatório";
            btnGerarProntuario.UseVisualStyleBackColor = true;
            btnGerarProntuario.Click += btnGerarProntuario_Click;
            // 
            // txtEmail
            // 
            txtEmail.CharacterCasing = CharacterCasing.Lower;
            txtEmail.Location = new Point(82, 187);
            txtEmail.MaxLength = 100;
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(489, 23);
            txtEmail.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 190);
            label5.Name = "label5";
            label5.Size = new Size(44, 15);
            label5.TabIndex = 15;
            label5.Text = "E-mail:";
            // 
            // txtRG
            // 
            txtRG.Location = new Point(82, 147);
            txtRG.MaxLength = 9;
            txtRG.Name = "txtRG";
            txtRG.ReadOnly = true;
            txtRG.Size = new Size(489, 23);
            txtRG.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(55, 150);
            label3.Name = "label3";
            label3.Size = new Size(25, 15);
            label3.TabIndex = 13;
            label3.Text = "RG:";
            // 
            // txtCPF
            // 
            txtCPF.Location = new Point(82, 107);
            txtCPF.MaxLength = 11;
            txtCPF.Name = "txtCPF";
            txtCPF.ReadOnly = true;
            txtCPF.Size = new Size(489, 23);
            txtCPF.TabIndex = 12;
            txtCPF.TextChanged += txtCPF_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(48, 110);
            label4.Name = "label4";
            label4.Size = new Size(31, 15);
            label4.TabIndex = 11;
            label4.Text = "CPF:";
            // 
            // txtNome
            // 
            txtNome.CharacterCasing = CharacterCasing.Upper;
            txtNome.Location = new Point(82, 69);
            txtNome.Name = "txtNome";
            txtNome.ReadOnly = true;
            txtNome.Size = new Size(489, 23);
            txtNome.TabIndex = 10;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 72);
            label2.Name = "label2";
            label2.Size = new Size(43, 15);
            label2.TabIndex = 9;
            label2.Text = "Nome:";
            // 
            // rbAlterar
            // 
            rbAlterar.AutoSize = true;
            rbAlterar.Enabled = false;
            rbAlterar.Location = new Point(133, 12);
            rbAlterar.Name = "rbAlterar";
            rbAlterar.Size = new Size(93, 19);
            rbAlterar.TabIndex = 5;
            rbAlterar.TabStop = true;
            rbAlterar.Text = "Alterar aluno";
            rbAlterar.UseVisualStyleBackColor = true;
            rbAlterar.CheckedChanged += rbAlterar_CheckedChanged;
            // 
            // rbExcluir
            // 
            rbExcluir.AutoSize = true;
            rbExcluir.Enabled = false;
            rbExcluir.Location = new Point(333, 12);
            rbExcluir.Name = "rbExcluir";
            rbExcluir.Size = new Size(92, 19);
            rbExcluir.TabIndex = 7;
            rbExcluir.TabStop = true;
            rbExcluir.Text = "Excluir aluno";
            rbExcluir.UseVisualStyleBackColor = true;
            rbExcluir.CheckedChanged += rbExcluir_CheckedChanged;
            // 
            // rbIncluir
            // 
            rbIncluir.AutoSize = true;
            rbIncluir.Location = new Point(232, 12);
            rbIncluir.Name = "rbIncluir";
            rbIncluir.Size = new Size(91, 19);
            rbIncluir.TabIndex = 6;
            rbIncluir.TabStop = true;
            rbIncluir.Text = "Incluir aluno";
            rbIncluir.UseVisualStyleBackColor = true;
            rbIncluir.CheckedChanged += rbIncluir_CheckedChanged;
            // 
            // btnAcao
            // 
            btnAcao.Enabled = false;
            btnAcao.Location = new Point(369, 326);
            btnAcao.Name = "btnAcao";
            btnAcao.Size = new Size(234, 23);
            btnAcao.TabIndex = 8;
            btnAcao.Text = "Aguardando ação";
            btnAcao.UseVisualStyleBackColor = true;
            btnAcao.Visible = false;
            btnAcao.Click += btnAcao_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(18, 357);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(169, 12);
            lblStatus.TabIndex = 17;
            lblStatus.Text = "Status da conexão com o banco de dados:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(0, 19);
            label6.Name = "label6";
            label6.Size = new Size(82, 15);
            label6.TabIndex = 17;
            label6.Text = "Consultar por:";
            // 
            // lbOpcoesConsulta
            // 
            lbOpcoesConsulta.FormattingEnabled = true;
            lbOpcoesConsulta.ItemHeight = 15;
            lbOpcoesConsulta.Items.AddRange(new object[] { "Prontuário", "CPF", "RG", "E-mail" });
            lbOpcoesConsulta.Location = new Point(88, 19);
            lbOpcoesConsulta.Name = "lbOpcoesConsulta";
            lbOpcoesConsulta.ScrollAlwaysVisible = true;
            lbOpcoesConsulta.Size = new Size(94, 19);
            lbOpcoesConsulta.TabIndex = 18;
            lbOpcoesConsulta.SelectedIndexChanged += lbOpcoesConsulta_SelectedIndexChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(198, 19);
            label7.Name = "label7";
            label7.Size = new Size(96, 15);
            label7.TabIndex = 17;
            label7.Text = "Digite sua busca:";
            // 
            // txtConsulta
            // 
            txtConsulta.CharacterCasing = CharacterCasing.Upper;
            txtConsulta.Location = new Point(300, 15);
            txtConsulta.MaxLength = 9;
            txtConsulta.Name = "txtConsulta";
            txtConsulta.Size = new Size(238, 23);
            txtConsulta.TabIndex = 18;
            txtConsulta.TextChanged += txtConsulta_TextChanged;
            // 
            // btnConsultar
            // 
            btnConsultar.BackgroundImage = Properties.Resources.search_icon_icons_com_74128;
            btnConsultar.BackgroundImageLayout = ImageLayout.Stretch;
            btnConsultar.Enabled = false;
            btnConsultar.ImageAlign = ContentAlignment.BottomCenter;
            btnConsultar.Location = new Point(544, 14);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(25, 23);
            btnConsultar.TabIndex = 19;
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // gbCamposConsulta
            // 
            gbCamposConsulta.Controls.Add(label7);
            gbCamposConsulta.Controls.Add(btnConsultar);
            gbCamposConsulta.Controls.Add(label6);
            gbCamposConsulta.Controls.Add(txtConsulta);
            gbCamposConsulta.Controls.Add(lbOpcoesConsulta);
            gbCamposConsulta.Location = new Point(32, 37);
            gbCamposConsulta.Name = "gbCamposConsulta";
            gbCamposConsulta.Size = new Size(571, 44);
            gbCamposConsulta.TabIndex = 20;
            gbCamposConsulta.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(610, 379);
            Controls.Add(gbCamposConsulta);
            Controls.Add(lblStatus);
            Controls.Add(btnAcao);
            Controls.Add(rbExcluir);
            Controls.Add(rbIncluir);
            Controls.Add(rbAlterar);
            Controls.Add(gbCampos);
            Controls.Add(btnLimpar);
            Controls.Add(rbConsultar);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gerenciador de Aluno";
            Load += Form1_Load;
            gbCampos.ResumeLayout(false);
            gbCampos.PerformLayout();
            gbCamposConsulta.ResumeLayout(false);
            gbCamposConsulta.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton rbConsultar;
        private Label label1;
        private TextBox txtProntuario;
        private Button btnLimpar;
        private GroupBox gbCampos;
        private RadioButton rbAlterar;
        private RadioButton rbExcluir;
        private RadioButton rbIncluir;
        private TextBox txtRG;
        private Label label3;
        private TextBox txtCPF;
        private Label label4;
        private TextBox txtNome;
        private Label label2;
        private Button btnAcao;
        private TextBox txtEmail;
        private Label label5;
        private Label lblStatus;
        private Label label6;
        private ListBox lbOpcoesConsulta;
        private Label label7;
        private TextBox txtConsulta;
        private Button btnConsultar;
        private GroupBox gbCamposConsulta;
        private Button btnGerarProntuario;
    }
}
