namespace MysqlConnection
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.inserirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alunoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alunosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.presençaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relatóriosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prenseçaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inserirToolStripMenuItem,
            this.relatóriosToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(807, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // inserirToolStripMenuItem
            // 
            this.inserirToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.alunoToolStripMenuItem,
            this.alunosToolStripMenuItem,
            this.presençaToolStripMenuItem});
            this.inserirToolStripMenuItem.Name = "inserirToolStripMenuItem";
            this.inserirToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.inserirToolStripMenuItem.Text = "Gerenciar";
            this.inserirToolStripMenuItem.Click += new System.EventHandler(this.inserirToolStripMenuItem_Click);
            // 
            // alunoToolStripMenuItem
            // 
            this.alunoToolStripMenuItem.Name = "alunoToolStripMenuItem";
            this.alunoToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.alunoToolStripMenuItem.Text = "Palestras";
            this.alunoToolStripMenuItem.Click += new System.EventHandler(this.alunoToolStripMenuItem_Click);
            // 
            // alunosToolStripMenuItem
            // 
            this.alunosToolStripMenuItem.Name = "alunosToolStripMenuItem";
            this.alunosToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.alunosToolStripMenuItem.Text = "Alunos";
            this.alunosToolStripMenuItem.Click += new System.EventHandler(this.alunosToolStripMenuItem_Click);
            // 
            // presençaToolStripMenuItem
            // 
            this.presençaToolStripMenuItem.Name = "presençaToolStripMenuItem";
            this.presençaToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.presençaToolStripMenuItem.Text = "Presença";
            this.presençaToolStripMenuItem.Click += new System.EventHandler(this.presençaToolStripMenuItem_Click);
            // 
            // relatóriosToolStripMenuItem
            // 
            this.relatóriosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prenseçaToolStripMenuItem});
            this.relatóriosToolStripMenuItem.Name = "relatóriosToolStripMenuItem";
            this.relatóriosToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.relatóriosToolStripMenuItem.Text = "Relatórios";
            this.relatóriosToolStripMenuItem.Click += new System.EventHandler(this.relatóriosToolStripMenuItem_Click);
            // 
            // prenseçaToolStripMenuItem
            // 
            this.prenseçaToolStripMenuItem.Name = "prenseçaToolStripMenuItem";
            this.prenseçaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.prenseçaToolStripMenuItem.Text = "Presença";
            this.prenseçaToolStripMenuItem.Click += new System.EventHandler(this.prenseçaToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 499);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Conexão Banco De Dados";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem inserirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alunoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alunosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem presençaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relatóriosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prenseçaToolStripMenuItem;
    }
}

