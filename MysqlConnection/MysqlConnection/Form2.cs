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

            while(hora < 24)
            {
                comboBox1.Items.Add(ZeroAEsquerda(hora) + ":" + ZeroAEsquerda(min));

                min += intervalo;
                while(min >= 60)
                {
                    hora++;
                    min -= 60;
                }
            }
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

            if (verificarCampos(valores,nomes))
            {
                try
                {
                    MySqlConnection con = new
                    MySqlConnection(conexaoSQL);
                    con.Open();
                    string sql = "INSERT INTO palestras(tituloPalestra,nomePalestrante,diaPalestra,horaPalestra) VALUES ('{titulo}','{nome}','{diaPalestra}','{horaPalestra}')";
                    sql = sql.Replace( "{titulo}", textBox2.Text);
                    sql = sql.Replace("{nome}", textBox4.Text);
                    sql = sql.Replace("{diaPalestra}", textBox1.Text);
                    sql = sql.Replace("{horaPalestra}", comboBox1.Text);
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

        bool verificarCampos(string[] txts,string[] nome)
        {
            for(int i= 0; i < txts.Length; i++)
            {
                if(txts[i] == string.Empty)
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
    }
}
