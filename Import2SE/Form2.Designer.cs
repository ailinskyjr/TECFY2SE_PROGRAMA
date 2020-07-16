namespace Import2SE
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCateg = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Matricula = new System.Windows.Forms.CheckBox();
            this.Categoria = new System.Windows.Forms.CheckBox();
            this.labelBoxmatr = new System.Windows.Forms.Label();
            this.listBox1DelDoc = new System.Windows.Forms.ListBox();
            this.Limpar = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label5Exclui = new System.Windows.Forms.Label();
            this.label4Pesq = new System.Windows.Forms.Label();
            this.listBox1PSTsemDOC = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1categ = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1CategDate = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker2Fim = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1Inicio = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(265, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 26);
            this.button1.TabIndex = 0;
            this.button1.Text = "Excluir";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Registro: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Excluir Documentos por:";
            // 
            // textBoxCateg
            // 
            this.textBoxCateg.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCateg.ForeColor = System.Drawing.SystemColors.MenuText;
            this.textBoxCateg.Location = new System.Drawing.Point(64, 79);
            this.textBoxCateg.Multiline = true;
            this.textBoxCateg.Name = "textBoxCateg";
            this.textBoxCateg.Size = new System.Drawing.Size(309, 43);
            this.textBoxCateg.TabIndex = 3;
            this.textBoxCateg.Tag = "";
            this.textBoxCateg.TextChanged += new System.EventHandler(this.textBoxCateg_TextChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.button2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(313, 367);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 26);
            this.button2.TabIndex = 4;
            this.button2.Text = "Fechar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 249);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = ".";
            // 
            // Matricula
            // 
            this.Matricula.AutoSize = true;
            this.Matricula.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Matricula.Location = new System.Drawing.Point(182, 12);
            this.Matricula.Name = "Matricula";
            this.Matricula.Size = new System.Drawing.Size(75, 20);
            this.Matricula.TabIndex = 6;
            this.Matricula.Text = "Matricula";
            this.Matricula.UseVisualStyleBackColor = true;
            this.Matricula.CheckedChanged += new System.EventHandler(this.Matricula_CheckedChanged);
            // 
            // Categoria
            // 
            this.Categoria.AutoSize = true;
            this.Categoria.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Categoria.Location = new System.Drawing.Point(182, 38);
            this.Categoria.Name = "Categoria";
            this.Categoria.Size = new System.Drawing.Size(78, 20);
            this.Categoria.TabIndex = 7;
            this.Categoria.Text = "Categoria";
            this.Categoria.UseVisualStyleBackColor = true;
            this.Categoria.CheckedChanged += new System.EventHandler(this.Categoria_CheckedChanged);
            // 
            // labelBoxmatr
            // 
            this.labelBoxmatr.AutoSize = true;
            this.labelBoxmatr.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBoxmatr.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelBoxmatr.Location = new System.Drawing.Point(263, 16);
            this.labelBoxmatr.Name = "labelBoxmatr";
            this.labelBoxmatr.Size = new System.Drawing.Size(8, 12);
            this.labelBoxmatr.TabIndex = 8;
            this.labelBoxmatr.Text = ".";
            // 
            // listBox1DelDoc
            // 
            this.listBox1DelDoc.FormattingEnabled = true;
            this.listBox1DelDoc.Location = new System.Drawing.Point(64, 170);
            this.listBox1DelDoc.Name = "listBox1DelDoc";
            this.listBox1DelDoc.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1DelDoc.Size = new System.Drawing.Size(309, 69);
            this.listBox1DelDoc.TabIndex = 9;
            this.listBox1DelDoc.Visible = false;
            this.listBox1DelDoc.SelectedIndexChanged += new System.EventHandler(this.listBox1DelDoc_SelectedIndexChanged);
            // 
            // Limpar
            // 
            this.Limpar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Limpar.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Limpar.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Limpar.Location = new System.Drawing.Point(282, 249);
            this.Limpar.Name = "Limpar";
            this.Limpar.Size = new System.Drawing.Size(91, 28);
            this.Limpar.TabIndex = 13;
            this.Limpar.Text = "Limpar";
            this.Limpar.UseVisualStyleBackColor = false;
            this.Limpar.Click += new System.EventHandler(this.Limpar_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(2, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(405, 350);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxCateg);
            this.tabPage1.Controls.Add(this.Limpar);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.listBox1DelDoc);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.labelBoxmatr);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.Categoria);
            this.tabPage1.Controls.Add(this.Matricula);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(397, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Excluir Documento";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label5Exclui);
            this.tabPage2.Controls.Add(this.label4Pesq);
            this.tabPage2.Controls.Add(this.listBox1PSTsemDOC);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.textBox1categ);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(397, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Excluir pasta sem arquivos";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label5Exclui
            // 
            this.label5Exclui.AutoSize = true;
            this.label5Exclui.Location = new System.Drawing.Point(20, 289);
            this.label5Exclui.Name = "label5Exclui";
            this.label5Exclui.Size = new System.Drawing.Size(10, 13);
            this.label5Exclui.TabIndex = 21;
            this.label5Exclui.Text = ".";
            // 
            // label4Pesq
            // 
            this.label4Pesq.AutoSize = true;
            this.label4Pesq.Location = new System.Drawing.Point(20, 107);
            this.label4Pesq.Name = "label4Pesq";
            this.label4Pesq.Size = new System.Drawing.Size(10, 13);
            this.label4Pesq.TabIndex = 20;
            this.label4Pesq.Text = ".";
            this.label4Pesq.Click += new System.EventHandler(this.label4Pesq_Click);
            // 
            // listBox1PSTsemDOC
            // 
            this.listBox1PSTsemDOC.FormattingEnabled = true;
            this.listBox1PSTsemDOC.Location = new System.Drawing.Point(23, 134);
            this.listBox1PSTsemDOC.Name = "listBox1PSTsemDOC";
            this.listBox1PSTsemDOC.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1PSTsemDOC.Size = new System.Drawing.Size(353, 134);
            this.listBox1PSTsemDOC.TabIndex = 19;
            this.listBox1PSTsemDOC.SelectedIndexChanged += new System.EventHandler(this.listBox1PSTsemDOC_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(153, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 18;
            this.label4.Text = "Categoria";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Teal;
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button3.Location = new System.Drawing.Point(147, 63);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 31);
            this.button3.TabIndex = 16;
            this.button3.Text = "Excluir";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1categ
            // 
            this.textBox1categ.Location = new System.Drawing.Point(125, 37);
            this.textBox1categ.Name = "textBox1categ";
            this.textBox1categ.Size = new System.Drawing.Size(143, 20);
            this.textBox1categ.TabIndex = 17;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.textBox1CategDate);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.label5);
            this.tabPage3.Controls.Add(this.dateTimePicker2Fim);
            this.tabPage3.Controls.Add(this.dateTimePicker1Inicio);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(397, 324);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Excluir Documento por data";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(153, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 18);
            this.label8.TabIndex = 20;
            this.label8.Text = "Categoria";
            // 
            // textBox1CategDate
            // 
            this.textBox1CategDate.Location = new System.Drawing.Point(125, 57);
            this.textBox1CategDate.Name = "textBox1CategDate";
            this.textBox1CategDate.Size = new System.Drawing.Size(143, 20);
            this.textBox1CategDate.TabIndex = 19;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Teal;
            this.button4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button4.Location = new System.Drawing.Point(125, 118);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(136, 31);
            this.button4.TabIndex = 17;
            this.button4.Text = "Listar Documentos";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(91, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(207, 15);
            this.label7.TabIndex = 6;
            this.label7.Text = "Periodo de cadastro do Documento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(198, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 15);
            this.label6.TabIndex = 4;
            this.label6.Text = "Fim:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Inicio:";
            // 
            // dateTimePicker2Fim
            // 
            this.dateTimePicker2Fim.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker2Fim.Location = new System.Drawing.Point(234, 92);
            this.dateTimePicker2Fim.Name = "dateTimePicker2Fim";
            this.dateTimePicker2Fim.Size = new System.Drawing.Size(96, 20);
            this.dateTimePicker2Fim.TabIndex = 1;
            // 
            // dateTimePicker1Inicio
            // 
            this.dateTimePicker1Inicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1Inicio.Location = new System.Drawing.Point(63, 92);
            this.dateTimePicker1Inicio.Name = "dateTimePicker1Inicio";
            this.dateTimePicker1Inicio.Size = new System.Drawing.Size(93, 20);
            this.dateTimePicker1Inicio.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(404, 406);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.Text = "Excluir Documentos";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCateg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox Matricula;
        private System.Windows.Forms.CheckBox Categoria;
        private System.Windows.Forms.Label labelBoxmatr;
        private System.Windows.Forms.ListBox listBox1DelDoc;
        private System.Windows.Forms.Button Limpar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label4Pesq;
        private System.Windows.Forms.ListBox listBox1PSTsemDOC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1categ;
        private System.Windows.Forms.Label label5Exclui;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker2Fim;
        private System.Windows.Forms.DateTimePicker dateTimePicker1Inicio;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1CategDate;
        private System.Windows.Forms.Button button4;
    }
}