namespace GerenciadorDeAluno
{
    partial class FormProntuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProntuarios));
            lbProntuarios = new ListBox();
            btnSelecionarProntuario = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // lbProntuarios
            // 
            lbProntuarios.FormattingEnabled = true;
            lbProntuarios.ItemHeight = 15;
            lbProntuarios.Location = new Point(12, 28);
            lbProntuarios.Name = "lbProntuarios";
            lbProntuarios.Size = new Size(211, 94);
            lbProntuarios.TabIndex = 0;
            // 
            // btnSelecionarProntuario
            // 
            btnSelecionarProntuario.Location = new Point(12, 131);
            btnSelecionarProntuario.Name = "btnSelecionarProntuario";
            btnSelecionarProntuario.Size = new Size(211, 23);
            btnSelecionarProntuario.TabIndex = 1;
            btnSelecionarProntuario.Text = "Usar este RA na consulta";
            btnSelecionarProntuario.UseVisualStyleBackColor = true;
            btnSelecionarProntuario.Click += btnSelecionarProntuario_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(137, 15);
            label1.TabIndex = 2;
            label1.Text = "Prontuários cadastrados:";
            // 
            // FormProntuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(240, 160);
            Controls.Add(label1);
            Controls.Add(btnSelecionarProntuario);
            Controls.Add(lbProntuarios);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "FormProntuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Prontuarios";
            Load += FormProntuarios_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lbProntuarios;
        private Button btnSelecionarProntuario;
        private Label label1;
    }
}