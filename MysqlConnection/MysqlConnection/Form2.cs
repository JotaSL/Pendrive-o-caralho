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
    public partial class Form2 : Form
    {
        string conexaoSQL = "server=143.106.241.3;port=3306;UserID=cl18248;database=cl18248;password=cl*21052003";

        public Form2()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int min = 0,
                hora = 0,
                intervalo = 30;

            while (hora < 24)
            {
                comboBox1.Items.Add(ZeroAEsquerda(hora) + ":" + ZeroAEsquerda(min));

                min += intervalo;
                while (min >= 60)
                {
                    hora++;
                    min -= 60;
                }
            }

            refreshList();
        }

        string ZeroAEsquerda(int valor)
        {
            return (valor < 10) ? "0" + valor.ToString() : valor.ToString();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            textBox1.Text = monthCalendar1.SelectionStart.ToShortDateString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] valores = (textBox1.Text + "," + comboBox1.Text + "," + textBox2.Text + "," + textBox4.Text).Split(',');
            string[] nomes = ("Data,Hora,Titulo,Professor").Split(',');

            if (verificarCampos(valores, nomes))
            {
                if(palestra_id == -1)
                {
                    try
                    {
                        MySqlConnection con = new
                    MySqlConnection(conexaoSQL);
                    con.Open();
                    string sqlCom = "SELECT * FROM palestras WHERE diaPalestra = '" + textBox1.Text + "' AND horaPalestra = '" + comboBox1.Text + "'";

                    MySqlCommand busca_palestras = new MySqlCommand(sqlCom, con);
                    MySqlDataReader ler_palestra = busca_palestras.ExecuteReader();
                    int c = 0;
                    while (ler_palestra.Read())
                    {
                        c++;
                    }

                    if(c > 0)
                    {
                        MessageBox.Show("Tem palestra nesse mesmo dia e horario", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                try
                {
                    MySqlConnection con = new
                    MySqlConnection(conexaoSQL);
                    con.Open();
                    string sql = "";

                    if (palestra_id == -1)
                        sql = "INSERT INTO palestras(tituloPalestra,nomePalestrante,diaPalestra,horaPalestra) VALUES ('{titulo}','{nome}','{diaPalestra}','{horaPalestra}')";
                    else
                        sql = "UPDATE palestras SET                 tituloPalestra='{titulo}',nomePalestrante='{nome}',diaPalestra='{diaPalestra}',horaPalestra='{horaPalestra}' WHERE idPalestras = "+palestra_id;

                    sql = sql.Replace("{titulo}", textBox2.Text);
                    sql = sql.Replace("{nome}", textBox4.Text);
                    sql = sql.Replace("{diaPalestra}", textBox1.Text);
                    sql = sql.Replace("{horaPalestra}", comboBox1.Text);
                    MySqlCommand insere = new MySqlCommand(sql, con);

                    insere.ExecuteNonQuery();


                    MessageBox.Show("Gravação realizada com sucesso");
                    con.Close();
                    refreshList();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        void refreshList()
        {
            try
            {
                MySqlConnection con = new
                MySqlConnection(conexaoSQL);
                con.Open();

                MySqlCommand busca_palestras = new MySqlCommand("SELECT * FROM palestras", con);
                MySqlDataReader ler_palestra = busca_palestras.ExecuteReader();
                listBox1.Items.Clear();
                while (ler_palestra.Read())
                {
                    listBox1.Items.Add(ler_palestra["idPalestras"] + " | " + ler_palestra["tituloPalestra"] + " | " + ler_palestra["nomePalestrante"] + " | " + ler_palestra["diaPalestra"] + " | " + ler_palestra["horaPalestra"]);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        int palestra_id = -1;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                int id = int.Parse(listBox1.Items[listBox1.SelectedIndex].ToString().Split('|')[0]);
                palestra_id = id;
                monthCalendar1.SelectionStart = DateTime.Parse(listBox1.Items[listBox1.SelectedIndex].ToString().Split('|')[3]);
                textBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString().Split('|')[3].Trim();
                comboBox1.Text = listBox1.Items[listBox1.SelectedIndex].ToString().Split('|')[4].Trim();
                textBox2.Text = listBox1.Items[listBox1.SelectedIndex].ToString().Split('|')[1].Trim();
                textBox4.Text = listBox1.Items[listBox1.SelectedIndex].ToString().Split('|')[2].Trim();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart = DateTime.Now;
            listBox1.SelectedIndex = -1;
            palestra_id = -1;
            textBox1.Text = DateTime.Now.ToShortDateString();
            comboBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }

        private void removerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (palestra_id != -1)
            {
                try
                {
                    MySqlConnection con = new
                    MySqlConnection(conexaoSQL);
                    con.Open();
                    string sql = "DELETE FROM palestras WHERE idPalestras = " + palestra_id;
                    
                    MySqlCommand insere = new MySqlCommand(sql, con);

                    insere.ExecuteNonQuery();
                    
                    MessageBox.Show("Registro removido com sucesso");
                    con.Close();
                    refreshList();

                    monthCalendar1.SelectionStart = DateTime.Now;
                    listBox1.SelectedIndex = -1;
                    palestra_id = -1;
                    textBox1.Text = DateTime.Now.ToShortDateString();
                    comboBox1.Text = "";
                    textBox2.Text = "";
                    textBox4.Text = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
