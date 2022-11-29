using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace trabalho_katia
{
    public partial class Form1 : Form
    {
        Conexao connecta = new Conexao();

        public Form1()
        {
            InitializeComponent();

        }
        public void Limpar()
        {
            txtCnpj.Text = null;
            txtEndereco.Text = null;
            txtEmail.Text = null;
            txtRazao.Text = null;
            txtNomefantasia.Text = null;
            txtInscricao.Text = null;
            txtTTelefone.Text = null;


           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

       

        private void BntPesquisar_Click(object sender, EventArgs e)
        {
            MySqlConnection Conectar = new MySqlConnection("server=localhost;User Id=root;database=bdcadastro;password=cursoads");
            try
            {
                string parametro = $"select * from fornecedor where Cnpj = '{txtCnpj.Text}'";
                MySqlCommand Comm = new MySqlCommand(parametro, Conectar);
                Conectar.Open();
                MySqlDataReader read;
                read = Comm.ExecuteReader();
                while (read.Read())
                {
                    txtCnpj.Text = Convert.ToString(read["Cnpj"]);
                    txtEndereco.Text = Convert.ToString(read["Endereco"]);
                    txtEmail.Text = Convert.ToString(read["Email"]);
                    txtRazao.Text = Convert.ToString(read["Razao"]);
                    txtNomefantasia.Text = Convert.ToString(read["NomeFantasia"]);
                    txtInscricao.Text = Convert.ToString(read["Inscricao"]);
                    txtTTelefone.Text = Convert.ToString(read["Telefone"]) ;
                
                }
            }
            catch
            {
                Conectar.Close();
            }
            
        }

        private void BntInserir_Click(object sender, EventArgs e)
        {
            string parametro = $"insert into fornecedor values('{txtCnpj.Text}' , '{txtEndereco.Text}','{txtEmail.Text}','{txtRazao.Text}','{txtNomefantasia.Text}','{txtInscricao.Text}','{txtTTelefone.Text}')";
            connecta.Cmd(parametro);
            MessageBox.Show("Cadastro feito");
            Limpar();
        }

        private void BntExcluir_Click(object sender, EventArgs e)
        {
            string parametro = $"delete from fornecedor where Cnpj = '{txtCnpj.Text}'";
            connecta.Cmd(parametro);
            MessageBox.Show("Fonecedor excluido");
            Limpar();
        }

        private void BntAlterar_Click(object sender, EventArgs e)
        {
            string parametro = $"update fornecedor set Cnpj = '{txtCnpj.Text}' , Endereco = '{txtEndereco.Text}' , Email = '{txtEmail.Text}' , Razao = '{txtRazao.Text}', NomeFantasia = '{txtNomefantasia.Text}' , Inscricao = '{txtInscricao.Text}' , Telefone = '{txtTTelefone.Text}'";
            connecta.Cmd(parametro);
            MessageBox.Show("O Arquivo foi alterado");
            Limpar();
        }

        private void txtbCadastro_Click(object sender, EventArgs e)
        {
            txtbTipo produto = new txtbTipo();
            produto.Show();
        }
    }
}
