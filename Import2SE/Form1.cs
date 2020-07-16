using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Import2SE.softexpert;
using System.Data.OleDb;
using ClosedXML.Excel;
using System.Threading;
using System.Xml.Linq;
using static Import2SE.Form5;
using System.Diagnostics;

namespace Import2SE
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        #region .: Variables :.
       
        private static string logpath = ConfigurationManager.AppSettings["PastaDestinoLog"].ToString();

        #endregion


        //


        #region SEClient

        public class SEClient : Documento
        {
            private string m_HeaderName;
            private string m_HeaderValue;

            protected override WebRequest GetWebRequest(Uri uri)
            {
                HttpWebRequest request = (HttpWebRequest)base.GetWebRequest(uri);

                if (null != this.m_HeaderName)
                    request.Headers.Add(this.m_HeaderName, this.m_HeaderValue);
                return (WebRequest)request;
            }

            public void SetRequestHeader(string headerName, string headerValue)
            {
                this.m_HeaderName = headerName;
                this.m_HeaderValue = headerValue;
            }

            public void SetAuthentication(string userName, string password)
            {
                string usernamePassword = userName + ":" + password;

                this.SetRequestHeader("Authorization", "Basic " + Convert.ToBase64String(new ASCIIEncoding().GetBytes(usernamePassword)));
            }

        }
        #endregion

        #region Conection
        public class Conection
        {
            readonly static string caminho = AppDomain.CurrentDomain.BaseDirectory;

            public static SEClient GetConnection()
            {
                string URL = "";
                string Username = "";
                string Password = "";

                XDocument doc = XDocument.Load((CaminhoDadosXML(caminho) + @"System.net.sess.xml"));
                var prods = from p in doc.Descendants("B_ses")
                            select new
                            {
                                url = p.Element("url").Value,
                                Username = p.Element("Username").Value,
                                Password = p.Element("Password").Value,
                            };
                foreach (var p in prods)
                {
                    URL = p.url;
                    Username = p.Username;
                    Password = p.Password;
                }
                 
                #region autentication

                string DcryptLogin = Username;
                Username = DecryptLogin(DcryptLogin);

                string DcryptPassword = Password;
                Password = DecryptLogin(DcryptPassword);

                #endregion


                SEClient seClient = new SEClient { Url = URL };
                seClient.SetAuthentication(Username, Password);

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Ssl3;
                ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                return seClient;
            }
        }
        #endregion



        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void excluirPorCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 ExcluirCategoria = new Form2();
            ExcluirCategoria.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string x = Process.GetCurrentProcess().ProcessName;
            if (Process.GetProcessesByName(x).Length > 1)

            {
                Form1 Form1 = new Form1();
                Form1.Refresh();
                Application.Exit();
            }

        }

        private void pesquisarMatriculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 PesquisarPorCategoria = new Form3();
            PesquisarPorCategoria.Show();
        }

        private void criarPastaFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 CriarPastaFuncionario = new Form4();
            CriarPastaFuncionario.Show(); ;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form4 CriarPastaFuncionario = new Form4();
            CriarPastaFuncionario.Show(); ;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Form3 PesquisarPorCategoria = new Form3();
            PesquisarPorCategoria.Show();

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Form2 ExcluirCategoria = new Form2();
            ExcluirCategoria.Show();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }


        public class DeleteDocument
        {
            public static string DeletDocument(string IDCATEGORY, string IdDocumento)
            {
                try
                {
                    //string caminho = "C:\Tecfy2SE-RH";
                    SEClient SeachDoc = Conection.GetConnection();
                    var strijjj = SeachDoc.downloadEletronicFile(IdDocumento, "", "", "", "", "", "", "");
                    return "false";

                }
                catch (Exception ex)
                {
                    var logpath = ConfigurationManager.AppSettings["PastaDestinoLog"].ToString();
                    File.AppendAllText(logpath + @"\" + "log_Excluir_Documentos.txt", "\r\n" + DateTime.Now + @" | DeletDoc " + ex.Message.ToString() + @";");
                    return "";
                }
            }
        }



        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 Configuracoes = new Form5();
            Configuracoes.Show();

        }

        private void configuraçõesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form6 ConfiguracoesAjustes = new Form6();
            ConfiguracoesAjustes.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void associarPastaXDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 associarPastaXDocumento = new Form7();
            associarPastaXDocumento.Show();

        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
