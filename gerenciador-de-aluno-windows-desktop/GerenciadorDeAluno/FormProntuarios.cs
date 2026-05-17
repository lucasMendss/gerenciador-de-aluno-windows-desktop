using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace GerenciadorDeAluno
{
    public partial class FormProntuarios : Form
    {
        private readonly Form1 _form1;

        public FormProntuarios(Form1 form1)
        {
            InitializeComponent();
            _form1 = form1;
        }

        private void FormProntuarios_Load(object sender, EventArgs e)
        {
            lbProntuarios.Items.Clear();

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

                    using (var command = connection.CreateCommand())
                    {
                        command.CommandType = CommandType.Text;
                        command.CommandText = "select prontuario from public.alunos order by prontuario";

                        using (var dataReader = command.ExecuteReader())
                        {
                            while (dataReader.Read())
                            {
                                lbProntuarios.Items.Add(dataReader["prontuario"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar prontuários: {ex.Message}");
                }
            }
        }

        private void btnSelecionarProntuario_Click(object sender, EventArgs e)
        {
            if (lbProntuarios.SelectedItem is null)
            {
                return;
            }

            _form1.DefinirConsulta(lbProntuarios.SelectedItem.ToString()!);
            Close();
        }
    }
}
