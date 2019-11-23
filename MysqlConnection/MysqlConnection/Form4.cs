using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MysqlConnection
{
    public partial class Form4 : Form
    {
        string conexaoSQL = "server=143.106.241.3;port=3306;UserID=cl18248;database=cl18248;password=cl*21052003";

        public Form4()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] valores = (comboBox1.Text + "," + textBox2.Text).Split(',');
            string[] nomes = ("Palestra,Ra").Split(',');
            if (verificarCampos(valores, nomes))
            {
                try
                {
                    MySqlConnection con = new
                    MySqlConnection(conexaoSQL);
                    con.Open();
                    string sqlCom = "SELECT * FROM alunos WHERE ra = " + textBox2.Text;

                    MySqlCommand busca_palestras = new MySqlCommand(sqlCom, con);
                    MySqlDataReader ler_palestra = busca_palestras.ExecuteReader();
                    int c = 0;
                    while (ler_palestra.Read())
                    {
                        c++;
                    }

                    if (c < 1)
                    {
                        if (MessageBox.Show("Não existe aluno com esse RA, deseja cadastrar?", "Erro!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                        {
                            Form3 f3 = new Form3();
                            f3.MdiParent = this.MdiParent;
                            f3.Show();
                        }
                        return;
                    }
                    
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    MySqlConnection con = new
                    MySqlConnection(conexaoSQL);
                    con.Open();

                    string sqlCom2 = "SELECT * FROM presenca WHERE ra = " + textBox2.Text + " AND id_palestra = " + comboBox1.Text.Split('|')[0];
                    MySqlCommand busca_palestras2 = new MySqlCommand(sqlCom2, con);
                    MySqlDataReader ler_palestra2 = busca_palestras2.ExecuteReader();
                    int c = 0;
                    while (ler_palestra2.Read())
                    {
                        c++;
                    }

                    if (c > 0)
                    {
                        MessageBox.Show("Esse aluno já tem presença nessa palestra!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    MySqlConnection con = new
                    MySqlConnection(conexaoSQL);
                    con.Open();
                    string sql = "INSERT INTO presenca(id_palestra, ra, data_hora) VALUES({palestra},{ra},'{data}'); ";

                    sql = sql.Replace("{palestra}", comboBox1.Text.Split('|')[0]);
                    sql = sql.Replace("{ra}", textBox2.Text);
                    sql = sql.Replace("{data}", textBox1.Text);

                    MySqlCommand insere = new MySqlCommand(sql, con);
                    
                    insere.ExecuteNonQuery();

                    MessageBox.Show("Gravação realizada com sucesso");
                    con.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
            
        bool verificarCampos(string[] txts, string[] nome)
        {
            for (int i = 0; i < txts.Length; i++)
            {
                if (txts[i] == string.Empty)
                {
                    MessageBox.Show("Você precisa preencher o " + nome[i], "ERRO!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new
                MySqlConnection(conexaoSQL);
                con.Open();

                MySqlCommand busca_alunos = new MySqlCommand("SELECT * fROM palestras", con);
                MySqlDataReader ler_aluno = busca_alunos.ExecuteReader();
                while (ler_aluno.Read())
                {
                    comboBox1.Items.Add(ler_aluno["idPalestras"] + " | " + ler_aluno["nomePalestrante"]);
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
            textBox1.Text = DateTime.Now.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.ToString();
        }
    }
}
