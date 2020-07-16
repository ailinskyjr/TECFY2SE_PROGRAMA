using System;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Import2SE.softexpert;
using XML_BD;
using static Import2SE.Form1;




namespace Import2SE
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        private static string logpath = ConfigurationManager.AppSettings["PastaDestinoLog"].ToString();
        String caminho = AppDomain.CurrentDomain.BaseDirectory;
        
        string idt;

        TextBox tb = new TextBox();

        public Form5(string id, string Cliente, string url, string Username, string Password) : this()
        {
            textBox1Client.Text = Cliente;            
            textBox1Link.Text = url;  
            
            textBox1Login.Text = DecryptLogin(Username);         
            textBox2Senha.Text = DecryptLogin(Password); 
            textBox1Senha2.Text = textBox2Senha.Text;
            idt = id;

        }

        public void Form5_Load(object sender, EventArgs e)
        {
      
        }

        public static string CaminhoDadosXML(string caminho)
        {
            if (caminho.IndexOf("\\bin\\Debug") != 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            return caminho;
        }

        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();
        public static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            { // sincroniza
                return getrandom.Next(min, max);
            }
        }

        private void button1_Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2Senha.Text != textBox1Senha2.Text)
                {
                    MessageBox.Show("Senhas não conferem", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string tempL = textBox1Login.Text.Replace(" ", "");
                string cryptLogin = textBox1Login.Text.Replace(" ", "");
                textBox1Login.Text =    EncryptLogin(cryptLogin);

                string tempP = textBox2Senha.Text.Replace(" ", "");
                string cryptPassword = textBox2Senha.Text.Replace(" ", "");
                textBox2Senha.Text = EncryptLogin(cryptPassword);
               
                DataSet ds;
                string sXMLFile = (CaminhoDadosXML(caminho) + @"System.net.b.xml");
                string strID = idt;
                //Criando o DataSet
                ds = new DataSet();
                //Preenche o DataSet com o XML
                ds.ReadXml(sXMLFile);

                //Fazer uma busca no DataSet para encontrar o cliente com o ID da QueryString
                DataRow dRow = ds.Tables["B_dado"].Select(" id = '" + strID + "'")[0];
                //Definindo os valores do DataRow com os valores do formulário.
                dRow["Cliente"] = textBox1Client.Text.Replace(" ", "");
                dRow["url"] = textBox1Link.Text.Replace(" ", "");
                dRow["Username"] = textBox1Login.Text;
                dRow["Password"] = textBox2Senha.Text.Replace(" ", "");

                //Atualizar o XML com os novos valores.
                ds.WriteXml(sXMLFile);                

                Form8 obj = (Form8)Application.OpenForms["Form8"];
                obj.GetDados();

                textBox1Login.Text = tempL;
                textBox2Senha.Text = tempP;
                MessageBox.Show("Salvo com Sucesso!", ".:: Sucesso ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                File.AppendAllText(logpath + @"\" + "log_erro.txt", "\r\n" + DateTime.Now + @" | " + ex.Message);
                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1Link_TextChanged(object sender, EventArgs e)
        {          
            tb.SelectAll();
        }

        private void textBox2Senha_TextChanged(object sender, EventArgs e)
        {
            tb.SelectAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
                SEClient SeachDoc = Conection.GetConnection();

                searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = "" };
                searchDocumentReturn = SeachDoc.searchDocument(searchDocumentFilter, null, null);

                if (searchDocumentReturn.RESULTS.Count() >= 0)
                {
                    MessageBox.Show("Conexão testada com Sucesso!", ".:: Sucesso ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro " + ex.Message, "..:: Erro ::..", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1Senha2_TextChanged(object sender, EventArgs e)
        {
            tb.SelectAll();
        }

        public static string EncryptLogin(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }

        public static string DecryptLogin(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        public void sendText(string msg)
        {
           
        }

        private void textBox1Client_TextChanged(object sender, EventArgs e)
        {
            string text = "Ambiente: " + textBox1Client.Text;
            sendText(text);
            this.Refresh();
        }

        private void textBox1Client_TextChanged_1(object sender, EventArgs e)
        {
            tb.SelectAll();
        }

        private void textBox1Login_TextChanged(object sender, EventArgs e)
        {
            tb.SelectAll();
        }
    }
}


