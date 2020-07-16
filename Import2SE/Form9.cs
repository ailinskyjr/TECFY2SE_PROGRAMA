using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Import2SE.Dados;
using Import2SE.softexpert;
using XML_BD;
using static Import2SE.Form1;



namespace Import2SE
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }
        private static string logpath = ConfigurationManager.AppSettings["PastaDestinoLog"].ToString();
        String caminho = AppDomain.CurrentDomain.BaseDirectory;
        string id;

        public void Form9_Load(object sender, EventArgs e)
        {

        }
        TextBox tb = new TextBox();

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

                id = Convert.ToString(GetRandomNumber(1, 9999));

                string tempL = textBox1Login.Text.Replace(" ", "");
                string cryptLogin = textBox1Login.Text.Replace(" ", "");
                textBox1Login.Text =    EncryptLogin(cryptLogin);

                string tempP = textBox2Senha.Text.Replace(" ", "");
                string cryptPassword = textBox2Senha.Text.Replace(" ", "");
                textBox2Senha.Text = EncryptLogin(cryptPassword);


                using (DataSet dsResultado = new DataSet())
                {
                    dsResultado.ReadXml(CaminhoDadosXML(caminho) + @"System.net.b.xml");
                    if (dsResultado.Tables.Count != 0)
                    {                        
                        dsResultado.Tables[0].Rows.Add(dsResultado.Tables[0].NewRow());
                        dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["id"] = id;
                        dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Cliente"] = textBox1Client.Text;
                        dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["url"] = textBox1Link.Text;
                        dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Username"] = textBox1Login.Text;
                        dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Password"] = textBox2Senha.Text;

                        dsResultado.AcceptChanges();
                        //--  Escreve para o arquivo XML final usando o método Write
                        dsResultado.WriteXml(CaminhoDadosXML(caminho) + @"System.net.b.xml", XmlWriteMode.IgnoreSchema);
                    }
                }

                //using (DataSet dsRess = new DataSet())
                //{

                //    sessao sessao = new sessao();
                //    sessao.idSessao = Convert.ToInt32(id);
                //    sessao.ClienteSessao = textBox1Client.Text;

                //    XmlTextWriter writer = new XmlTextWriter(CaminhoDadosXML(caminho) + @"System.net.b.xml", System.Text.Encoding.UTF8);
                //    writer.WriteStartDocument(true);

                //    writer.Formatting = Formatting.Indented;
                //    writer.Indentation = 2;
                //    writer.WriteStartElement("B_dados");

                //    writer.WriteStartElement("sessao");
                //    writer.WriteStartElement("idsessao");
                //    writer.WriteString(Convert.ToString(sessao.idSessao));
                //    writer.WriteEndElement();

                //    writer.WriteStartElement("Cliente");
                //    writer.WriteString(sessao.ClienteSessao);
                //    writer.WriteEndElement();

                //    writer.WriteEndElement();
                //    writer.WriteEndDocument();
                //    writer.Close();
                //    dsRess.ReadXml(CaminhoDadosXML(caminho) + @"System.net.b.xml");

                //}
                // Salva na sessao
                //XElement x = new XElement("sessao");
                //x.Add(new XAttribute("id", id));
                //x.Add(new XAttribute("Cliente", textBox1Client.Text));
                //XElement xml = XElement.Load(CaminhoDadosXML(caminho) + @"System.net.b.xml");
                //xml.Add(x);
                //xml.Save(CaminhoDadosXML(caminho) + @"System.net.b.xml");





                textBox1Login.Text = tempL;
                textBox2Senha.Text = tempP;

                Form8 obj = (Form8)Application.OpenForms["Form8"];
                obj.GetDados();


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

                searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = "123" };
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


