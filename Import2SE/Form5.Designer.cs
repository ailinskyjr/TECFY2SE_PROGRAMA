namespace Import2SE
{
    partial class Form5
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.textBox1Link = new System.Windows.Forms.TextBox();
            this.textBox2Senha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1_Salvar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1Login = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1Senha2 = new System.Windows.Forms.TextBox();
            this.textBox1Client = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1Link
            // 
            this.textBox1Link.Location = new System.Drawing.Point(135, 52);
            this.textBox1Link.Name = "textBox1Link";
            this.textBox1Link.Size = new System.Drawing.Size(352, 20);
            this.textBox1Link.TabIndex = 0;
            this.textBox1Link.TextChanged += new System.EventHandler(this.textBox1Link_TextChanged);
            // 
            // textBox2Senha
            // 
            this.textBox2Senha.Location = new System.Drawing.Point(135, 129);
            this.textBox2Senha.Name = "textBox2Senha";
            this.textBox2Senha.PasswordChar = '*';
            this.textBox2Senha.Size = new System.Drawing.Size(162, 20);
            this.textBox2Senha.TabIndex = 1;
            this.textBox2Senha.TextChanged += new System.EventHandler(this.textBox2Senha_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Servidor WebService:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Senha:";
            // 
            // button1_Salvar
            // 
            this.button1_Salvar.BackColor = System.Drawing.Color.Teal;
            this.button1_Salvar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1_Salvar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1_Salvar.Location = new System.Drawing.Point(135, 201);
            this.button1_Salvar.Name = "button1_Salvar";
            this.button1_Salvar.Size = new System.Drawing.Size(97, 29);
            this.button1_Salvar.TabIndex = 5;
            this.button1_Salvar.Text = "Salvar";
            this.button1_Salvar.UseVisualStyleBackColor = false;
            this.button1_Salvar.Click += new System.EventHandler(this.button1_Salvar_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Teal;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button2.Location = new System.Drawing.Point(396, 201);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "Fechar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Usuario:";
            // 
            // textBox1Login
            // 
            this.textBox1Login.Location = new System.Drawing.Point(135, 87);
            this.textBox1Login.Name = "textBox1Login";
            this.textBox1Login.Size = new System.Drawing.Size(162, 20);
            this.textBox1Login.TabIndex = 8;
            this.textBox1Login.TextChanged += new System.EventHandler(this.textBox1Login_TextChanged);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Teal;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Location = new System.Drawing.Point(252, 200);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 31);
            this.button1.TabIndex = 9;
            this.button1.Text = "Testar Conexão";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Senha(Confirmar):";
            // 
            // textBox1Senha2
            // 
            this.textBox1Senha2.Location = new System.Drawing.Point(135, 162);
            this.textBox1Senha2.Name = "textBox1Senha2";
            this.textBox1Senha2.PasswordChar = '*';
            this.textBox1Senha2.Size = new System.Drawing.Size(162, 20);
            this.textBox1Senha2.TabIndex = 11;
            this.textBox1Senha2.TextChanged += new System.EventHandler(this.textBox1Senha2_TextChanged);
            // 
            // textBox1Client
            // 
            this.textBox1Client.Location = new System.Drawing.Point(135, 13);
            this.textBox1Client.Name = "textBox1Client";
            this.textBox1Client.Size = new System.Drawing.Size(100, 20);
            this.textBox1Client.TabIndex = 12;
            this.textBox1Client.TextChanged += new System.EventHandler(this.textBox1Client_TextChanged_1);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(510, 245);
            this.Controls.Add(this.textBox1Client);
            this.Controls.Add(this.textBox1Senha2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1Login);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1_Salvar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox2Senha);
            this.Controls.Add(this.textBox1Link);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form5";
            this.Text = " Configuração - Integração - SE";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1_Salvar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox textBox1Link;
        public System.Windows.Forms.TextBox textBox2Senha;
        public System.Windows.Forms.TextBox textBox1Login;
        public System.Windows.Forms.TextBox textBox1Senha2;
        public System.Windows.Forms.TextBox textBox1Client;
    }
}