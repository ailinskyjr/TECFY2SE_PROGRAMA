namespace Import2SE
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.excluirPorCategoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarMatriculaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.criarPastaFuncionarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.associarPastaXDocumentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configuraçõesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Black;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opçõesToolStripMenuItem,
            this.sistemaToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(444, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // opçõesToolStripMenuItem
            // 
            this.opçõesToolStripMenuItem.BackColor = System.Drawing.Color.Black;
            this.opçõesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.excluirPorCategoriaToolStripMenuItem,
            this.pesquisarMatriculaToolStripMenuItem,
            this.criarPastaFuncionarioToolStripMenuItem,
            this.associarPastaXDocumentoToolStripMenuItem});
            this.opçõesToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opçõesToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.opçõesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Silver;
            this.opçõesToolStripMenuItem.Name = "opçõesToolStripMenuItem";
            this.opçõesToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.opçõesToolStripMenuItem.Text = "Menu";
            this.opçõesToolStripMenuItem.Click += new System.EventHandler(this.opçõesToolStripMenuItem_Click);
            // 
            // excluirPorCategoriaToolStripMenuItem
            // 
            this.excluirPorCategoriaToolStripMenuItem.Name = "excluirPorCategoriaToolStripMenuItem";
            this.excluirPorCategoriaToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.excluirPorCategoriaToolStripMenuItem.Text = "Excluir Documentos";
            this.excluirPorCategoriaToolStripMenuItem.Click += new System.EventHandler(this.excluirPorCategoriaToolStripMenuItem_Click);
            // 
            // pesquisarMatriculaToolStripMenuItem
            // 
            this.pesquisarMatriculaToolStripMenuItem.Name = "pesquisarMatriculaToolStripMenuItem";
            this.pesquisarMatriculaToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.pesquisarMatriculaToolStripMenuItem.Text = "Pesquisar Documento";
            this.pesquisarMatriculaToolStripMenuItem.Click += new System.EventHandler(this.pesquisarMatriculaToolStripMenuItem_Click);
            // 
            // criarPastaFuncionarioToolStripMenuItem
            // 
            this.criarPastaFuncionarioToolStripMenuItem.Name = "criarPastaFuncionarioToolStripMenuItem";
            this.criarPastaFuncionarioToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.criarPastaFuncionarioToolStripMenuItem.Text = "Criar Pasta Funcionario";
            this.criarPastaFuncionarioToolStripMenuItem.Click += new System.EventHandler(this.criarPastaFuncionarioToolStripMenuItem_Click);
            // 
            // associarPastaXDocumentoToolStripMenuItem
            // 
            this.associarPastaXDocumentoToolStripMenuItem.Name = "associarPastaXDocumentoToolStripMenuItem";
            this.associarPastaXDocumentoToolStripMenuItem.Size = new System.Drawing.Size(256, 22);
            this.associarPastaXDocumentoToolStripMenuItem.Text = "Associar Pasta x Documento";
            this.associarPastaXDocumentoToolStripMenuItem.Click += new System.EventHandler(this.associarPastaXDocumentoToolStripMenuItem_Click);
            // 
            // sistemaToolStripMenuItem
            // 
            this.sistemaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configuraçõesToolStripMenuItem,
            this.configuraçõesToolStripMenuItem1});
            this.sistemaToolStripMenuItem.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sistemaToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.sistemaToolStripMenuItem.Name = "sistemaToolStripMenuItem";
            this.sistemaToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.sistemaToolStripMenuItem.Text = "Sistema";
            // 
            // configuraçõesToolStripMenuItem
            // 
            this.configuraçõesToolStripMenuItem.Name = "configuraçõesToolStripMenuItem";
            this.configuraçõesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.configuraçõesToolStripMenuItem.Text = "Integração SE";
            this.configuraçõesToolStripMenuItem.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem_Click);
            // 
            // configuraçõesToolStripMenuItem1
            // 
            this.configuraçõesToolStripMenuItem1.Name = "configuraçõesToolStripMenuItem1";
            this.configuraçõesToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.configuraçõesToolStripMenuItem1.Text = "Configurações ";
            this.configuraçõesToolStripMenuItem1.Click += new System.EventHandler(this.configuraçõesToolStripMenuItem1_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(444, 42);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Enabled = false;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0, 2, 0, 6);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(26, 34);
            this.toolStripButton1.Text = "Criar Pasta Funcionario";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(32, 39);
            this.toolStripButton2.Text = "Pesquisar";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(33, 39);
            this.toolStripButton3.Text = "Excluir Documentos";
            this.toolStripButton3.Click += new System.EventHandler(this.toolStripButton3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::Import2SE.Properties.Resources.IconeNovo2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(444, 244);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "  Tecfy2SE-RH v1.8";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem excluirPorCategoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisarMatriculaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem criarPastaFuncionarioToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripMenuItem sistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configuraçõesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem associarPastaXDocumentoToolStripMenuItem;
    }
}

