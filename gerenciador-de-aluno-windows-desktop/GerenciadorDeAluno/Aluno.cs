using GerenciadorDeAluno;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeAluno
{
    internal class Aluno
    {
        private string _prontuario;
        private string _nome;
        private string _cpf;
        private string _rg;
        private string _email;
        private string _operacaoSolicitada;
        public string prontuario
        {
            get { return _prontuario; }
            set
            {
                if (!Validacoes.ValidarProntuario(value)) { throw new Exception("O Prontuário deve estar no formato 'RA1234567'."); }
                else if ((operacaoSolicitada == "cadastro" || operacaoSolicitada == "atualizacao") && VerificarSeDadoJaUsado("prontuario", value)) 
                    { throw new Exception("Já existe um registro com este Prontuário."); }
                else { _prontuario = value; }
            }
        }
        public string nome
        {
            get { return _nome; }
            set
            {
                if (!Validacoes.ValidarNome(value)) { throw new Exception("Nome inválido."); }
                else { _nome = value; }
            }
        }
        public string cpf
        {
            get { return _cpf; }
            set
            {
                if (!Validacoes.ValidarCPF(value)) { throw new Exception("CPF deve estar no padrão 'xxxxxxxxxxx'."); }
                else if ((operacaoSolicitada == "cadastro" || operacaoSolicitada == "atualizacao") && VerificarSeDadoJaUsado("cpf", value))
                    { throw new Exception("Já existe um registro com este CPF."); }
                else { _cpf = value; }
            }
        }
        public string rg
        {
            get { return _rg; }
            set
            {
                if (!Validacoes.ValidarRG(value)) { throw new Exception("RG deve estar no padrão 'xxxxxxxxx'."); }
                else if ((operacaoSolicitada == "cadastro" || operacaoSolicitada == "atualizacao") && VerificarSeDadoJaUsado("rg", value))
                    { throw new Exception("Já existe um registro com este RG."); }
                else { _rg = value; }
            }
        }
        public string email
        {
            get { return _email; }
            set
            {
                if (!Validacoes.ValidarEmail(value)) { throw new Exception("E-mail inválido."); }
                else if ((operacaoSolicitada == "cadastro" || operacaoSolicitada == "atualizacao") && VerificarSeDadoJaUsado("email", value))
                    { throw new Exception("Já existe um registro com este E-mail."); }
                else { _email = value; }
            }
        }
        public string operacaoSolicitada
        {
            get { return _operacaoSolicitada; }
            set { _operacaoSolicitada = value; }
        }
        public bool VerificarSeDadoJaUsado(string coluna, string dado)
        {
            //antes de incluir ou atualizar aluno, verificar se cpf, rg ou email já não existem no banco 
            string connectionString = ObterStringConexao();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    NpgsqlCommand selectCommand = connection.CreateCommand();
                    selectCommand.CommandType = CommandType.Text;
                    selectCommand.CommandText = "select " + coluna + " from public.alunos where " + coluna + " = @dado";
                    selectCommand.Parameters.AddWithValue("@dado", dado);

                    connection.Open();
                    NpgsqlDataReader dataReader = selectCommand.ExecuteReader();
                    dataReader.Read();
                    if (!dataReader.HasRows) { return false; }
                    //else { throw new Exception("Já existe registro com este " + coluna.ToUpper() + "."); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return true;
        }
        private string ObterStringConexao()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            IConfiguration config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            return connectionString;
        }
        public bool ConsultarAluno(string colunaEscolhida, string textoConsulta)
        {
            string connectionString = ObterStringConexao();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    string parametro = "";
                    string propriedade = "";
                    switch (colunaEscolhida)
                    {
                        case "Prontuário":
                            parametro = "prontuario";
                            break;
                        case "RG":
                            parametro = "rg";
                            break;
                        case "CPF":
                            parametro = "cpf";
                            break;
                        case "E-mail":
                            parametro = "email";
                            break;
                    }
                    command.CommandText = $"select prontuario, nome, cpf, rg, email from public.alunos where {parametro} = @textoConsulta";
                    command.Parameters.AddWithValue("@textoConsulta", textoConsulta);

                    connection.Open();
                    NpgsqlDataReader dataReader = command.ExecuteReader();
                    if (!dataReader.Read())
                    {
                        return false;
                    }
                    this.prontuario = dataReader["prontuario"].ToString();
                    this.nome = dataReader["nome"].ToString();
                    this.cpf = dataReader["cpf"].ToString();
                    this.rg = dataReader["rg"].ToString();
                    this.email = dataReader["email"].ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
            return true;
        }
        public void CadastrarAluno()
        {
            string connectionString = ObterStringConexao();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    NpgsqlCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandType = CommandType.Text;
                    command.CommandText = "insert into public.alunos (prontuario, nome, cpf, rg, email) values (@prontuario, @nome, @cpf, @rg, @email)";
                    string[] parameters = { "@prontuario", "@nome", "@cpf", "@rg", "@email" };
                    object[] properties = { this.prontuario, this.nome, this.cpf, this.rg, this.email };
                    for (int ii = 0; ii < parameters.Length; ii++)
                    {
                        command.Parameters.AddWithValue(parameters[ii], properties[ii]);
                    }

                    connection.Open();
                    command.ExecuteScalar();
                    MessageBox.Show("O(a) aluno(a) foi cadastrado(a) com sucesso.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        private void AdicionarParametrosAoComandoSql(NpgsqlCommand comando)
        {
            string[] parameters = { "@prontuario", "@nome", "@cpf", "@rg", "@email" };
            object[] properties = { this.prontuario, this.nome, this.cpf, this.rg, this.email };
            for (int ii = 0; ii < parameters.Length; ii++)
            {
                comando.Parameters.AddWithValue(parameters[ii], properties[ii]);
            }
        }
        public void AtualizarAluno()
        {
            string connectionString = ObterStringConexao();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    //pesquisar no banco se há registro correspondente aos dados do form no momento do clique
                    NpgsqlCommand selectCommand = connection.CreateCommand();
                    selectCommand.Connection = connection;
                    selectCommand.CommandType = CommandType.Text;
                    selectCommand.CommandText = "select * from public.alunos where prontuario = @prontuario and nome = @nome and " +
                        "cpf = @cpf and rg = @rg and email = @email;";
                    AdicionarParametrosAoComandoSql(selectCommand);

                    connection.Open();
                    NpgsqlDataReader dataReader = selectCommand.ExecuteReader();
                    dataReader.Read();

                    //se não existir um registro, seguir com a atualização
                    if (!dataReader.HasRows)
                    {
                        connection.Close();
                        selectCommand.Cancel();
                        NpgsqlCommand updateCommand = connection.CreateCommand();
                        updateCommand.Connection = connection;
                        updateCommand.CommandType = CommandType.Text;
                        updateCommand.CommandText = "UPDATE public.alunos SET nome = @nome, cpf = @cpf, rg = @rg, email = @email where prontuario = @prontuario";
                        AdicionarParametrosAoComandoSql(updateCommand);
                        connection.Open();
                        updateCommand.ExecuteNonQuery();
                        MessageBox.Show("Os dados do(a) aluno(a) foram atualizados com sucesso.");
                    }
                    //se existir um registro idêntico, informar que não há nada a atualizar
                    else
                    {
                        throw new Exception("Não foram feitas mudanças a serem cadastradas.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
        public void ExcluirAluno()
        {
            string connectionString = ObterStringConexao();
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                try
                {
                    NpgsqlCommand deleteCommand = new NpgsqlCommand();
                    deleteCommand.Connection = connection;
                    deleteCommand.CommandType = CommandType.Text;
                    deleteCommand.CommandText = "delete from public.alunos where prontuario = @prontuario";
                    deleteCommand.Parameters.AddWithValue("@prontuario", this.prontuario);

                    connection.Open();
                    deleteCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro: {ex.Message}");
                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
