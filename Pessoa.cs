using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppPessoa3
{
    class Pessoa
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string cidade { get; set; }
        public string endereco { get; set; }
        public string data_nascimento { get; set; }
        public string celular { get; set; }
        public string email { get; set; }

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Pessoa\DbPessoa.mdf;Integrated Security=True");

        public List<Pessoa> listapessoas()
        {
            List<Pessoa> li = new List<Pessoa>();
            string sql = "SELECT * FROM Pessoa";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Pessoa p = new Pessoa();
                p.Id = (int)dr["Id"];
                p.nome = dr["nome"].ToString();
                p.cidade = dr["cidade"].ToString();
                p.endereco = dr["endereco"].ToString();
                p.data_nascimento = dr["data_nascimento"].ToString();
                p.celular = dr["celular"].ToString();
                p.email = dr["email"].ToString();
                li.Add(p);
            }
            dr.Close();
            con.Close();
            return li;
        }

        public void Inserir(string nome, string cidade, string endereco, string data_nascimento, string celular, string email)
        {
            string sql = "INSERT INTO pessoa(nome,cidade,endereco,data_nascimento,celular,email) VALUES('" + nome + "','" + cidade + "','" + endereco + "','" + data_nascimento + "','" + celular + "','" + email + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        
        public void Atualizar(int id, string nome, string cidade, string endereco, string data_nascimento, string celular, string email)
        {
            string sql = "INSERT INTO pessoa(nome,cidade,endereco,data_nascimento,celular,email) VALUES('" + nome + "','" + cidade + "','" + endereco + "','" + data_nascimento + "','" + celular + "','" + email + "')";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Excluir(int id)
        {
            string sql = "DELETE FROM pessoa WERE Id=(nome,cidade,endereco,data_nascimento,celular,email) VALUES('" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void Localizar(int id)
        {
            string sql = "DELETE FROM pessoa WERE Id=VALUES '" + id + "'";
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                nome = dr["nome"].ToString();
                cidade = dr["cidade"].ToString();
                endereco = dr["endereco"].ToString();
                data_nascimento= dr["Data_nascimento"].ToString();
                celular = dr["celular"].ToString();
                email = dr["email"].ToString();
            }
            dr.Close();
            con.Close();
        }
    }
}
