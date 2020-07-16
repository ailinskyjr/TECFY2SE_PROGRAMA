namespace Import2SE
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            this.Pesquisar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RecMatricula = new System.Windows.Forms.TextBox();
            this.Categoria = new System.Windows.Forms.CheckBox();
            this.CheckMatricula = new System.Windows.Forms.CheckBox();
            this.labelList = new System.Windows.Forms.Label();
            this.listBoxLista = new System.Windows.Forms.ListBox();
            this.Limpar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label4Pesq = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.listBox1PSTsemDOC = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1categ = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Pesquisar
            // 
            this.Pesquisar.BackColor = System.Drawing.Color.Teal;
            this.Pesquisar.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pesquisar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Pesquisar.Location = new System.Drawing.Point(124, 103);
            this.Pesquisar.Name = "Pesquisar";
            this.Pesquisar.Size = new System.Drawing.Size(94, 31);
            this.Pesquisar.TabIndex = 0;
            this.Pesquisar.Text = "Pesquisar";
            this.Pesquisar.UseVisualStyleBackColor = false;
            this.Pesquisar.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(283, 395);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "Fechar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Pesquisar por:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID :";
            // 
            // RecMatricula
            // 
            this.RecMatricula.Location = new System.Drawing.Point(124, 63);
            this.RecMatricula.Name = "RecMatricula";
            this.RecMatricula.Size = new System.Drawing.Size(201, 20);
            this.RecMatricula.TabIndex = 4;
            this.RecMatricula.TextChanged += new System.EventHandler(this.RecMatricula_TextChanged);
            // 
            // Categoria
            // 
            this.Categoria.AutoSize = true;
            this.Categoria.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categoria.Location = new System.Drawing.Point(124, 34);
            this.Categoria.Name = "Categoria";
            this.Categoria.Size = new System.Drawing.Size(191, 20);
            this.Categoria.TabIndex = 9;
            this.Categoria.Text = "Documentos da Categoria";
            this.Categoria.UseVisualStyleBackColor = true;
            this.Categoria.CheckedChanged += new System.EventHandler(this.Categoria_CheckedChanged);
            // 
            // CheckMatricula
            // 
            this.CheckMatricula.AutoSize = true;
            this.CheckMatricula.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckMatricula.Location = new System.Drawing.Point(124, 8);
            this.CheckMatricula.Name = "CheckMatricula";
            this.CheckMatricula.Size = new System.Drawing.Size(86, 20);
            this.CheckMatricula.TabIndex = 8;
            this.CheckMatricula.Text = "Matricula";
            this.CheckMatricula.UseVisualStyleBackColor = true;
            this.CheckMatricula.CheckedChanged += new System.EventHandler(this.Matricula_CheckedChanged);
            // 
            // labelList
            // 
            this.labelList.AutoSize = true;
            this.labelList.Location = new System.Drawing.Point(6, 148);
            this.labelList.Name = "labelList";
            this.labelList.Size = new System.Drawing.Size(10, 13);
            this.labelList.TabIndex = 10;
            this.labelList.Text = ".";
            // 
            // listBoxLista
            // 
            this.listBoxLista.FormattingEnabled = true;
            this.listBoxLista.Location = new System.Drawing.Point(9, 213);
            this.listBoxLista.Name = "listBoxLista";
            this.listBoxLista.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxLista.Size = new System.Drawing.Size(353, 108);
            this.listBoxLista.TabIndex = 11;
            this.listBoxLista.Visible = false;
            this.listBoxLista.SelectedIndexChanged += new System.EventHandler(this.listBoxLista_SelectedIndexChanged);
            // 
            // Limpar
            // 
            this.Limpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Limpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Limpar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Limpar.Location = new System.Drawing.Point(281, 327);
            this.Limpar.Name = "Limpar";
            this.Limpar.Size = new System.Drawing.Size(81, 28);
            this.Limpar.TabIndex = 12;
            this.Limpar.Text = "Limpar";
            this.Limpar.UseVisualStyleBackColor = false;
            this.Limpar.Click += new System.EventHandler(this.Limpar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(-2, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(376, 387);
            this.tabControl1.TabIndex = 13;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Categoria);
            this.tabPage1.Controls.Add(this.labelList);
            this.tabPage1.Controls.Add(this.Limpar);
            this.tabPage1.Controls.Add(this.Pesquisar);
            this.tabPage1.Controls.Add(this.listBoxLista);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.RecMatricula);
            this.tabPage1.Controls.Add(this.CheckMatricula);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(368, 361);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Pesquisa Documento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label4Pesq);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.listBox1PSTsemDOC);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.textBox1categ);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(368, 361);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Documento sem arquivo";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label4Pesq
            // 
            this.label4Pesq.AutoSize = true;
            this.label4Pesq.Location = new System.Drawing.Point(28, 145);
            this.label4Pesq.Name = "label4Pesq";
            this.label4Pesq.Size = new System.Drawing.Size(10, 13);
            this.label4Pesq.TabIndex = 15;
            this.label4Pesq.Text = ".";
            this.label4Pesq.Click += new System.EventHandler(this.label4Pesq_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(281, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(81, 28);
            this.button3.TabIndex = 13;
            this.button3.Text = "Limpar";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // listBox1PSTsemDOC
            // 
            this.listBox1PSTsemDOC.FormattingEnabled = true;
            this.listBox1PSTsemDOC.Location = new System.Drawing.Point(6, 172);
            this.listBox1PSTsemDOC.Name = "listBox1PSTsemDOC";
            this.listBox1PSTsemDOC.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1PSTsemDOC.Size = new System.Drawing.Size(353, 134);
            this.listBox1PSTsemDOC.TabIndex = 12;
            this.listBox1PSTsemDOC.SelectedIndexChanged += new System.EventHandler(this.listBox1PSTsemDOC_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(136, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Categoria";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(129, 93);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 31);
            this.button1.TabIndex = 5;
            this.button1.Text = "Pesquisar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // textBox1categ
            // 
            this.textBox1categ.Location = new System.Drawing.Point(107, 67);
            this.textBox1categ.Name = "textBox1categ";
            this.textBox1categ.Size = new System.Drawing.Size(143, 20);
            this.textBox1categ.TabIndex = 6;
            this.textBox1categ.TextChanged += new System.EventHandler(this.textBox1categ_TextChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(386, 434);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form3";
            this.Text = "Pesquisar Documento";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Pesquisar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RecMatricula;
        private System.Windows.Forms.CheckBox Categoria;
        private System.Windows.Forms.CheckBox CheckMatricula;
        private System.Windows.Forms.Label labelList;
        private System.Windows.Forms.ListBox listBoxLista;
        private System.Windows.Forms.Button Limpar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1categ;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListBox listBox1PSTsemDOC;
        private System.Windows.Forms.Label label4Pesq;
    }
}