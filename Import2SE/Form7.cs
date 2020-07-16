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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private static string logpath = ConfigurationManager.AppSettings["PastaDestinoLog"].ToString();
        private static string AssociaçaoDocumento = "Log_AssociaçaoDocumento";
        private static string logAssociaçaoDocumento = logpath + @"\" + AssociaçaoDocumento;
        private static string texto = "";
        private static int IDAssoc = 1;
        private static string travaAssocCategMatric = ConfigurationManager.AppSettings["travaAssocCategMatric"].ToString();
        TextBox tb = new TextBox();

        private void button1_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(logAssociaçaoDocumento))
            {
                Directory.CreateDirectory(logAssociaçaoDocumento);
            }

            //string AssociaçaoDocumento = "";
            //string CategPast = textBox1CategPast.Text;
            //string CategDoc = textBox3CategDoc.Text;
            //string AtribDoc = textBox2AtribDoc.Text;

            //string ReturnBusc = ValidMatricExistt(CategDoc, AtribDoc, CategPast);
            try
            {
                string CategPast = textBox1CategPast.Text;
                string CategDoc = textBox3CategDoc.Text;
                string AtribDoc = textBox2AtribDoc.Text;

                SEClient SeachDoc1 = Conection.GetConnection();

                searchDocumentReturn searchDocumentReturnT1 = new searchDocumentReturn();
                searchDocumentFilter searchDocumentFilterT1 = new searchDocumentFilter { IDCATEGORY = CategDoc };
                searchDocumentReturnT1 = SeachDoc1.searchDocument(searchDocumentFilterT1, "", null);

                if (searchDocumentReturnT1.RESULTS.Count() > 0)
                {
                    foreach (var item in (searchDocumentReturnT1.RESULTS))
                    {

                        documentDataReturn documentDataReturn = new documentDataReturn();
                        SEClient SeachDoc = Conection.GetConnection();
                        documentDataReturn = SeachDoc.viewDocumentData(item.IDDOCUMENT, "", "", "");

                        foreach (var item1 in (documentDataReturn.ATTRIBUTTES.Where(p => p.ATTRIBUTTENAME == AtribDoc)))
                        {
                            var AtribuValue = item1.ATTRIBUTTEVALUE[0];
                            
                            if (AtribuValue != null && AtribuValue != "")
                            {
                                string IDPasta = "";

                                if (travaAssocCategMatric == "yes")
                                {
                                    IDPasta =  AtribuValue;
                                }
                                else
                                {
                                    IDPasta = CategPast + "-" + AtribuValue;
                                }

                                texto = @"Verificando associação... Documento: " + item.IDDOCUMENT + @"  Pasta: " + IDPasta;
                                sendText(texto);

                                AssociarDOCxPASTA(CategPast, IDPasta, CategDoc, item.IDDOCUMENT);
                            }
                            else
                            {
                                File.AppendAllText(logAssociaçaoDocumento + @"\" + "log_Associação_erro.txt", "\r\n" + DateTime.Now + @" | ASSOCIAR DOCUMENTO: " + item.IDDOCUMENT + @" DOCUMENTO SEM VALOR NO ATRIBUTO: " + AtribDoc);
                            }
                        }
                        //MessageBox.Show("Atributo Documento: " + AtribDoc + " não confere", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //break;
                    }
                }
                MessageBox.Show("Verificação concluida!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sendText("");

            }
            catch (Exception ex)
            {
                File.AppendAllText(logAssociaçaoDocumento + @"\" + "log_Associação_erro.txt", "\r\n" + DateTime.Now + @" | AssociaçãoDoc " + ex.Message.ToString() + @";");
                MessageBox.Show("Erro " + ex.Message.ToString(), ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }


        //#region BuscaMatricula
        //public static string ValidMatricExistt(string CategDoc, string VlAtribut, string CategPast)
        //{

        //    try
        //    {
        //        SEClient SeachDoc1 = Conection.GetConnection();

        //        searchDocumentReturn searchDocumentReturnT1 = new searchDocumentReturn();
        //        searchDocumentFilter searchDocumentFilterT1 = new searchDocumentFilter { IDCATEGORY = CategDoc };
        //        searchDocumentReturnT1 = SeachDoc1.searchDocument(searchDocumentFilterT1, "", null);

        //        if (searchDocumentReturnT1.RESULTS.Count() > 0)
        //        {
        //            foreach (var item in (searchDocumentReturnT1.RESULTS))
        //            {

        //                documentDataReturn documentDataReturn = new documentDataReturn();
        //                SEClient SeachDoc = Conection.GetConnection();
        //                documentDataReturn = SeachDoc.viewDocumentData(item.IDDOCUMENT, "", "", "");

        //                foreach (var item1 in (documentDataReturn.ATTRIBUTTES.Where(p => p.ATTRIBUTTENAME == VlAtribut)))
        //                {

        //                    var AtribuValue = item1.ATTRIBUTTEVALUE[0];

        //                    if (AtribuValue != null && AtribuValue != "")
        //                    {
        //                        var IDPasta = CategPast + "-" + AtribuValue;
        //                        AssociarDOCxPASTA(CategPast, IDPasta, CategDoc, item.IDDOCUMENT);
        //                    }
        //                    else
        //                    {
        //                        File.AppendAllText(logpath + @"\" + "log_Associação_erro.txt", "\r\n" + DateTime.Now + @" | ASSOCIAR DOCUMENTO: " + item.IDDOCUMENT + @" DOCUMENTO SEM VALOR NO ATRIBUTO: " + VlAtribut);
        //                    }

        //                }

        //            }
        //        }

        //        //Pesq2 = 1;

        //        //if (searchDocumentReturnT1.RESULTS.Count() > 0)
        //        //{
        //        //    return ("yes");
        //        //}
        //        //else
        //        //{
        //        return ("NoExist");
        //        //}

        //    }
        //    catch (Exception ex)
        //    {
        //        //while (Pesq2 <= 2)
        //        //{
        //        //    Pesq2++;
        //        //    File.AppendAllText(logpath + @"\" + "log_erro.txt", "\r\n" + DateTime.Now + @" | ValidMatricExistt | " + @" Valida Matricula: " + IdentificadorDOC + @" - " + ex.Message.ToString() + @";");
        //        //    Thread.Sleep(Convert.ToInt32());
        //        //    return ValidMatricExistt(IdentificadorDOC);
        //        //}
        //        ////File.AppendAllText(logpath + @"\" + "log_erro.txt", "\r\n" + DateTime.Now + @" | SeachDoc " + ex.Message.ToString() + @";");
        //        return ("NoConect");
        //    }

        //}
        //#endregion


        #region CREATEDOCCONTAINER
        public static string AssociarDOCxPASTA(string CategPast, string IDPasta, string CategDoc, string IDDocument)
        {
            try
            {

                var fileNameArray = Path.GetFileName(CategDoc).ToString().Split(new char[] { Convert.ToChar("-") });

                string StructID = fileNameArray[0];

                SEClient newDocContainerAss = Conection.GetConnection();
                string resultadoAssocDoc = newDocContainerAss.newDocumentContainerAssociation(CategPast, IDPasta, "", StructID, CategDoc, IDDocument, out long codeAssociation, out string detailAssociation);

                string RespAssoc = resultadoAssocDoc + "-" + detailAssociation;

                if (resultadoAssocDoc == "SUCCESS")
                {
                    File.AppendAllText(logAssociaçaoDocumento + @"\" + "log_Associação.txt", "\r\n" + DateTime.Now + @" | ASSOCIAR DOCUMENTO: " + IDDocument + @" A PASTA " + IDPasta + @" - " + RespAssoc + @";");
                }
                else if (RespAssoc.Contains("Documento já associado"))
                {
                    File.AppendAllText(logAssociaçaoDocumento + @"\" + "log_Documento já associado.txt", "\r\n" + DateTime.Now + @" | ASSOCIAR DOCUMENTO: " + IDDocument + @" A PASTA " + IDPasta + @" - " + detailAssociation + @";");
                }
                else if (RespAssoc.Contains("FAILURE"))
                {
                    File.AppendAllText(logAssociaçaoDocumento + @"\" + "log_Associação_erro.txt", "\r\n" + DateTime.Now + @" | ASSOCIAR DOCUMENTO: " + IDDocument + @" A PASTA " + IDPasta + @" - " + RespAssoc + @";");
                }
                IDAssoc = 1;

                return ("");
            }
            catch (Exception ex)
            {
                while (IDAssoc <= 2)
                {
                    IDAssoc++;
                    File.AppendAllText(logAssociaçaoDocumento + @"\" + "log_Associação_erro.txt", "\r\n" + DateTime.Now + @" | AssociaDOC | " + ex.Message.ToString() + @";");
                    Thread.Sleep(5000);
                    return AssociarDOCxPASTA(CategPast, IDPasta, CategDoc, IDDocument);
                }
                return ("");
            }
        }
        #endregion

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

                XDocument doc = XDocument.Load((CaminhoDadosXML(caminho) + @"System.net.b.xml"));
                var prods = from p in doc.Descendants("B_dado")
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

        #region  sendText       
        public void sendText(string msg)
        {
            labelNome.Text = msg;
            labelNome.Refresh();

        }
        #endregion

        public void labelNome_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1CategPast_TextChanged(object sender, EventArgs e)
        {
          
            tb.SelectAll();
        }

        private void textBox3CategDoc_TextChanged(object sender, EventArgs e)
        {
         
            tb.SelectAll();
        }

        private void textBox2AtribDoc_TextChanged(object sender, EventArgs e)
        {
        
            tb.SelectAll();
        }
    }
}
