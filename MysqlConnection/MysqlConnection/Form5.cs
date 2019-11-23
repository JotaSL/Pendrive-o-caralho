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
    public partial class Form5 : Form
    {
        string conexaoSQL = "server=143.106.241.3;port=3306;UserID=cl18248;database=cl18248;password=cl*21052003";

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(conexaoSQL);
                con.Open();
                var sql = "SELECT (SELECT nome FROM alunos WHERE ra = p.ra) AS aluno,(SELECT tituloPalestra FROM palestras where idPalestras = p.id_palestra) AS palestra,(SELECT nomePalestrante FROM palestras where idPalestras = p.id_palestra) AS palestrante,data_hora FROM presenca p";

                MySqlCommand command = new MySqlCommand(sql);
                MySqlDataAdapter da = new MySqlDataAdapter(command);

                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }
    }
}
