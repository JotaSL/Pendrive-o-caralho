using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MysqlConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void alunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.MdiParent = this;
            f2.Show();
        }

        private void inserirToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void alunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.MdiParent = this;
            f3.Show();
        }

        private void presençaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.MdiParent = this;
            f4.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void relatóriosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void prenseçaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.MdiParent = this;
            f5.Show();
        }
    }
}
