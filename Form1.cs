using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPessoa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            List<Pessoa> pessoas = pessoa.listapessoas();
            dgvPessoa.DataSource = pessoas;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Deseja realmente sair?", "Sair da Aplicação", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            Pessoa pessoa = new Pessoa();
            pessoa.Inserir(txtNome.Text,txtIdade.Text);
            MessageBox.Show("Pessoa cadastrada com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoas();
            dgvPessoa.DataSource = pessoas;
            txtNome.Text = "";
            txtIdade.Text = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Atualizar(Id, txtNome.Text, txtIdade.Text);
            MessageBox.Show("Pessoa atualizada com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoas();
            dgvPessoa.DataSource = pessoas;
            txtNome.Text = "";
            txtIdade.Text = "";
            txtId.Text = "";
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Excluir(Id);
            MessageBox.Show("Pessoa excluída com sucesso!");
            List<Pessoa> pessoas = pessoa.listapessoas();
            dgvPessoa.DataSource = pessoas;
            txtNome.Text = "";
            txtIdade.Text = "";
            txtId.Text = "";
        }

        private void btnLocalizar_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(txtId.Text.Trim());
            Pessoa pessoa = new Pessoa();
            pessoa.Localizar(Id);
            txtNome.Text = pessoa.nome;
            txtIdade.Text = pessoa.idade;
        }

        private void dgvPessoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvPessoa.Rows[e.RowIndex];
                row.Selected = true;
                txtId.Text = row.Cells[0].Value.ToString();
                txtNome.Text = row.Cells[1].Value.ToString();
                txtIdade.Text = row.Cells[2].Value.ToString();
            }
        }
    }
}
