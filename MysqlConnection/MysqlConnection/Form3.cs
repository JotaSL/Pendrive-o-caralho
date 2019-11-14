using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace MysqlConnection
{
    public partial class Form3 : Form
    {
        string conexaoSQL = "server=143.106.241.3;port=3306;UserID=cl18248;database=cl18248;password=cl*21052003";

        byte[] imagem;

        bool grid_click = false;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            refreshList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FileDialog fd = new OpenFileDialog();
            fd.DefaultExt = "PNG(*.png)|JPEG(*.jpeg)|JPG(*.jpg)";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = fd.FileName;
                StreamReader sr = new StreamReader(fd.FileName);
                imagem = Encoding.ASCII.GetBytes(sr.ReadToEnd());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] valores = (textBox1.Text + "," + comboBox1.Text + "," + textBox2.Text + "," + pictureBox1.ImageLocation).Split(',');
            string[] nomes = ("RA,Turma,Nome,Foto").Split(',');
            if (verificarCampos(valores, nomes))
            {
                try
                {
                    MySqlConnection con = new
                    MySqlConnection(conexaoSQL);
                    con.Open();
                    string sql = "INSERT INTO alunos(ra,nome,turma,foto) VALUES ({ra},'{nome}','{turma}','@foto')";
                    sql = sql.Replace("{ra}", textBox1.Text);
                    sql = sql.Replace("{nome}", textBox2.Text);
                    sql = sql.Replace("{turma}", comboBox1.Text);

                    byte[] blobs = imagem;
                    MySqlParameter blob = new MySqlParameter("@foto", MySqlDbType.Blob, blobs.Length);
                    blob.Value = blobs;

                    MySqlCommand insere = new MySqlCommand(sql, con);

                    insere.Parameters.Add(blob);

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

        public byte[] imageToByte(Image img)
        {
            using (var ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
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

        void refreshList()
        {
            try
            {
                MySqlConnection con = new
                MySqlConnection(conexaoSQL);
                con.Open();

                MySqlCommand busca_alunos = new MySqlCommand("SELECT * FROM alunos", con);
                MySqlDataReader ler_aluno = busca_alunos.ExecuteReader();
                listBox1.Items.Clear();
                while (ler_aluno.Read())
                {
                    listBox1.Items.Add(ler_aluno["ra"] + " / " + ler_aluno["nome"] + " / " + ler_aluno["turma"]);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ra = int.Parse(listBox1.Items[listBox1.SelectedIndex].ToString().Split('/')[0]);
            
            try
            {
                MySqlConnection con = new
                MySqlConnection(conexaoSQL);
                con.Open();

                MySqlCommand busca_alunos = new MySqlCommand("SELECT * FROM alunos WHERE ra = "+ ra + " LIMIT 1", con);
                MySqlDataReader ler_aluno = busca_alunos.ExecuteReader();
                while (ler_aluno.Read())
                {
                    textBox1.Text = ler_aluno["ra"].ToString();
                    textBox2.Text = ler_aluno["nome"].ToString();
                    comboBox1.Text = ler_aluno["turma"].ToString();
                    grid_click = true;
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grid_click = false;
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            textBox2.Clear();
            imagem = null;
            pictureBox1.ImageLocation = null;
        }
    }
}
