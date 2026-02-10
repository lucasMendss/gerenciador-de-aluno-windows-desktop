using GerenciadorDeAluno;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Data;

namespace GerenciadorDeAluno
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private bool _consultaFeita;
        public bool consultaFeita
        {
            get
            {
                return _consultaFeita;
            }
            set
            {
                _consultaFeita = value;
                if (_consultaFeita)
                {
                    rbAlterar.Enabled = true;
                    rbExcluir.Enabled = true;
                }
                else
                {
                    rbAlterar.Enabled = false;
                    rbExcluir.Enabled = false;
                }
            }
        }
        public void LimparCampos()
        {
            foreach (TextBox textbox in gbCampos.Controls.OfType<System.Windows.Forms.TextBox>())
            {
                textbox.Clear();
            }
            txtConsulta.Clear();
            consultaFeita = false;
        }
        private void DesabilitarControles(Control container)
        {
            foreach (Control c in container.Controls)
            {
                c.Enabled = false;

                // Desabilitar componentes filhos se existir
                if (c.HasChildren)
                {
                    DesabilitarControles(c);
                }
            }
        }
        private void AlterarPermissaoDeApenasLeituraTextBoxes(bool valor)
        {
            foreach (TextBox textbox in gbCampos.Controls.OfType<System.Windows.Forms.TextBox>())
            {
                textbox.ReadOnly = valor;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            consultaFeita = false;
            lbOpcoesConsulta.SelectedIndex = 0;
            gbCamposConsulta.Enabled = false;
            rbConsultar.Checked = true;

            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            using (var connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    lblStatus.Text = lblStatus.Text + " Conectado";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Não foi possível se conectar ao banco de dados: {ex.Message}");
                    DesabilitarControles(this);
                    lblStatus.Text = lblStatus.Text + " Desconectado";
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            Aluno a = new Aluno();
            a.operacaoSolicitada = "consulta";
            try
            {
                string textoConsulta = txtConsulta.Text.ToUpper();
                string colunaEscolhida = lbOpcoesConsulta.Text;

                if (a.ConsultarAluno(colunaEscolhida, textoConsulta))
                {
                    txtProntuario.Text = a.prontuario;
                    txtNome.Text = a.nome;
                    txtCPF.Text = a.cpf;
                    txtRG.Text = a.rg;
                    txtEmail.Text = a.email;
                    consultaFeita = true;
                }
                else
                {
                    MessageBox.Show("Aluno não encontrado.");
                }
            }
            catch (Exception ex)
            {
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void btnGerarProntuario_Click(object sender, EventArgs e)
        {
            var random = new Random();              
            string prontuario = "RA" + (random.Next(1000000, 9999999)).ToString();
            txtProntuario.Clear();
            txtProntuario.Text = prontuario;
        }
        private void btnAcao_Click(object sender, EventArgs e)
        {
            if (rbIncluir.Checked)
            {
                Aluno a = new Aluno();
                a.operacaoSolicitada = "cadastro";
                try
                {
                    a.prontuario = txtProntuario.Text;
                    a.nome = txtNome.Text;
                    a.cpf = txtCPF.Text;
                    a.rg = txtRG.Text;
                    a.email = txtEmail.Text;
                    a.CadastrarAluno();
                    consultaFeita = true;
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (rbAlterar.Checked)
            {
                Aluno a = new Aluno();
                a.operacaoSolicitada = "atualizar";
                try
                {
                    a.prontuario = txtProntuario.Text;
                    a.nome = txtNome.Text;
                    a.cpf = txtCPF.Text;
                    a.rg = txtRG.Text;
                    a.email = txtEmail.Text;
                    a.AtualizarAluno();
                    consultaFeita = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (rbExcluir.Checked)
            {
                Aluno a = new Aluno();
                try
                {
                    a.prontuario = txtProntuario.Text;
                    DialogResult resposta = MessageBox.Show($"Certeza que deseja excluir o(a) aluno(a) com prontuário {a.prontuario}?", "Confirmar exclusão",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (resposta == DialogResult.Yes)
                    {
                        a.ExcluirAluno();
                        LimparCampos();
                        MessageBox.Show("Aluno(a) excluído do sistema com sucesso.");
                        consultaFeita = false;
                    }
                    else
                    {
                        MessageBox.Show("Exclusão cancelada.");
                    }
                }
                catch (Exception ex)
                {
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }
        private void rbConsultar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConsultar.Checked == true)
            {
                btnAcao.Visible = false;
                gbCamposConsulta.Enabled = true;
                btnGerarProntuario.Enabled = false;
                AlterarPermissaoDeApenasLeituraTextBoxes(true);
                txtConsulta.Focus();
            }
            else
            {
                gbCamposConsulta.Enabled = false;
                txtConsulta.Text = string.Empty;
            }
        }
        private void rbAlterar_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAlterar.Checked == true)
            {
                btnAcao.Visible = true;
                btnAcao.Text = "Alterar Aluno";
                btnGerarProntuario.Enabled = true;
                AlterarPermissaoDeApenasLeituraTextBoxes(false);
                if (txtProntuario.Text.Length == 9)
                {
                    btnAcao.Enabled = true;
                }
                else
                {
                    btnAcao.Enabled = false;
                }
            }
            txtProntuario.ReadOnly = true;
            txtNome.Focus();
        }
        private void rbIncluir_CheckedChanged(object sender, EventArgs e)
        {
            if (rbIncluir.Checked == true)
            {
                btnAcao.Visible = true;
                btnAcao.Text = "Incluir Aluno";
                btnGerarProntuario.Enabled = true;
                AlterarPermissaoDeApenasLeituraTextBoxes(false);
                if (txtProntuario.Text.Length == 9)
                {
                    btnAcao.Enabled = true;
                }
                else
                {
                    btnAcao.Enabled = false;
                }
            }
            txtProntuario.Focus();
        }
        private void rbExcluir_CheckedChanged(object sender, EventArgs e)
        {
            if (rbExcluir.Checked == true)
            {
                btnAcao.Visible = true;
                btnAcao.Text = "Excluir Aluno";
                btnGerarProntuario.Enabled = false;
                AlterarPermissaoDeApenasLeituraTextBoxes(true);
            }
        }
        private void txtProntuario_TextChanged(object sender, EventArgs e)
        {
            if ((rbConsultar.Checked || rbIncluir.Checked) && txtProntuario.Text.Length == 9)
            {
                btnAcao.Enabled = true;
            }
            else
            {
                btnAcao.Enabled = false;
            }

            if (consultaFeita)
            {
                consultaFeita = false;
            }
        }

        private void txtCPF_TextChanged(object sender, EventArgs e)
        {

        }
        private void lbOpcoesConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (lbOpcoesConsulta.Text)
            {
                case "Prontuário":
                    txtConsulta.MaxLength = 9;
                    break;
                case "RG":
                    txtConsulta.MaxLength = 9;
                    break;
                case "CPF":
                    txtConsulta.MaxLength = 11;
                    break;
                case "E-mail":
                    txtConsulta.MaxLength = 50;
                    break;
            }

            if (lbOpcoesConsulta.Text != "E-mail")
            {
                txtConsulta.CharacterCasing = CharacterCasing.Upper;
                if (txtConsulta.Text.Length == txtConsulta.MaxLength)
                {
                    btnConsultar.Enabled = true;
                }
                else
                {
                    btnConsultar.Enabled = false;
                }
            }
            else
            {
                txtConsulta.CharacterCasing = CharacterCasing.Lower;
                btnConsultar.Enabled = true;
            }
        }
        private void txtConsulta_TextChanged(object sender, EventArgs e)
        {
            if (lbOpcoesConsulta.Text != "E-mail")
            {
                if (txtConsulta.Text.Length == txtConsulta.MaxLength)
                {
                    btnConsultar.Enabled = true;
                }
                else
                {
                    btnConsultar.Enabled = false;
                }
            }
            else
            {
                btnConsultar.Enabled = true;
            }
        }
    }
}
