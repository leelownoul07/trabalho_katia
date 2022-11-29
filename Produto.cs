using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalho_katia
{
    public partial class txtbTipo : Form // Jaime egidio da silva junior RA: 6322100
    {
        Conexao connecta = new Conexao();
        public txtbTipo()
        {
            InitializeComponent();
        }
        public void Limpar()
        {
            txtbCodigo.Text = null;
            txtbDescricao.Text = null;
            txtbDatadevalidade.Text = null;
            txtbPreco.Text = null;
            txtbQuantidade.Text = null;
            txtTipo.Text = null;
            txtMedida.Text = null;
            
          
        }

        private void BntPesquisar_Click(object sender, EventArgs e)
        {
            MySqlConnection Conectar = new MySqlConnection("server=localhost;User Id=root;database=bdcadastro;password=cursoads");
            try
            {
                string parametro = $"select * from produto where Codigo = '{txtbCodigo.Text}'";
                MySqlCommand Comm = new MySqlCommand(parametro, Conectar);
                Conectar.Open();
                MySqlDataReader read;
                read = Comm.ExecuteReader();
                while (read.Read())
                {
                    txtbCodigo.Text = Convert.ToString(read["Codigo"]);
                    txtbDescricao.Text = Convert.ToString(read["Descricao"]);
                    txtbDatadevalidade.Text = Convert.ToString(read["DatadeValidade"]);
                    txtbPreco.Text = Convert.ToString(read["Preco"]);
                    txtbQuantidade.Text = Convert.ToString(read["Quantidade"]);
                    txtTipo.Text = Convert.ToString(read["Tipo"]);
                    txtMedida.Text = Convert.ToString(read["Medida"]);
                }
            }
            catch
            {
                Conectar.Close();
            }
        }

        private void BntInserir_Click(object sender, EventArgs e)
        {
            string parametro = $"insert into produto values('{txtbCodigo.Text}','{txtbDescricao.Text}','{txtbDatadevalidade.Text}','{txtbPreco.Text}','{txtbQuantidade.Text}','{txtTipo.Text}','{txtMedida.Text}')";
            connecta.Cmd(parametro);
            MessageBox.Show("Cadastro feito");
            Limpar();
        }

        private void BntExcluir_Click(object sender, EventArgs e)
        {
            string parametro = $"delete from produto where Codigo = '{txtbCodigo.Text}'";
            connecta.Cmd(parametro);
            MessageBox.Show("produto excluido");
            Limpar();
        }

        private void BntAlterar_Click(object sender, EventArgs e)
        {
            string parametro = $"update produto set Codigo = '{txtbCodigo.Text}' , Descricao = '{txtbDescricao.Text}' , DatadeValidade = '{txtbDatadevalidade.Text}' , Preco = '{txtbPreco.Text}', QuantidadenoEstoque = '{txtbQuantidade.Text}', Tipo = '{txtTipo.Text}', Medida = '{txtMedida.Text}' ";

            connecta.Cmd(parametro);
            MessageBox.Show("produto alterado");
            Limpar();
        }

       
    }
}
