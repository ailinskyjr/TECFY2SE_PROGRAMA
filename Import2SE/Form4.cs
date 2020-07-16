//Lê planilha
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using System.Configuration;
using Import2SE.softexpert;
using System.IO;
using System.Net;
using static Import2SE.Form1;
using System.Xml.Linq;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;

namespace Import2SE
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        string arquivo;
        private static string logpath = ConfigurationManager.AppSettings["PastaDestinoLog"].ToString();
        readonly static string caminho = AppDomain.CurrentDomain.BaseDirectory;
        private static string CriarPastaFuncionario = "Log_CriarPastaFuncionario";
        private static string logCriarPastaFuncionario = logpath + @"\" + CriarPastaFuncionario;        
        private static int id = 0;
        private static int IDSeachDoc, UpdateTit, IDCriaDoc, IDAssoc, UpdateAtr, IDCriate = 1;
     
        

        private void button2_Click(object sender, EventArgs e)
        {
            criarpastas();
            OpenFileDialog AbrirComo = new OpenFileDialog();
            DialogResult Caminho;

            AbrirComo.Title = "Abrir Como";
            AbrirComo.Filter = "Excel Worksheets | *.xlsx";

            Caminho = AbrirComo.ShowDialog();
            arquivo = AbrirComo.FileName;

            if (arquivo != "")
            {
                textBox1.Text = AbrirComo.FileName;
            }
            else
            {
                MessageBox.Show("Arquivo não selecionado!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        #region BOTÂO_ENVIAR
        private void button1_Click(object sender, EventArgs e)
        {

            if (!Directory.Exists(logCriarPastaFuncionario))
            {
                Directory.CreateDirectory(logCriarPastaFuncionario);
            }

            //string nome = "";

            //Process[] runningProcs = Process.GetProcesses(".");
            //StringBuilder builder = new StringBuilder();
            //foreach (Process p in runningProcs)
            //{
            //    if (p.ProcessName == "Import2SE")
            //    {
            //        id = p.Id;
            //        nome = p.ProcessName;


            //    }
            //}


            if (arquivo == null || arquivo == "")
            {
                MessageBox.Show("Sem arquivo para processar!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var texto = "";
            try
            {
                var wb = new XLWorkbook(arquivo);
                var planilha = wb.Worksheet(1);

                #region DadosXML
                var linha = 2;
                while (true)
                {
                    var ColunaA = planilha.Cell("A" + linha.ToString()).Value.ToString();
                    var ColunaB = planilha.Cell("B" + linha.ToString()).Value.ToString();
                    var ColunaC = planilha.Cell("C" + linha.ToString()).Value.ToString();
                    var ColunaD = planilha.Cell("D" + linha.ToString()).Value.ToString().Replace("00:00:00", "");
                    var ColunaE = planilha.Cell("E" + linha.ToString()).Value.ToString().Replace("00:00:00", "");
                    var ColunaF = planilha.Cell("F" + linha.ToString()).Value.ToString();
                    var ColunaG = planilha.Cell("G" + linha.ToString()).Value.ToString();
                    var ColunaH = planilha.Cell("H" + linha.ToString()).Value.ToString();
                    var ColunaI = planilha.Cell("I" + linha.ToString()).Value.ToString();
                    var ColunaJ = planilha.Cell("J" + linha.ToString()).Value.ToString();

                    var ColunaK = planilha.Cell("K" + linha.ToString()).Value.ToString();
                    var ColunaL = planilha.Cell("L" + linha.ToString()).Value.ToString();
                    var ColunaM = planilha.Cell("M" + linha.ToString()).Value.ToString();
                    var ColunaN = planilha.Cell("N" + linha.ToString()).Value.ToString();
                    var ColunaO = planilha.Cell("O" + linha.ToString()).Value.ToString();
                    var ColunaP = planilha.Cell("P" + linha.ToString()).Value.ToString();


                    string Indice = "";
                    XDocument doc = XDocument.Load((CaminhoDadosXML(caminho) + @"System.net.cnfg.xml"));
                    var prods = from p in doc.Descendants("Config")
                                select new
                                {
                                    Indice = p.Element("IndiceID").Value,
                                };

                    foreach (var p in prods)
                    {
                        Indice = p.Indice;
                    }
                    #endregion
                    string temp = Indice.Substring(Indice.Length - 1);
                    Indice = planilha.Cell(temp + linha.ToString()).Value.ToString();

                    if (string.IsNullOrEmpty(ColunaA)) break;
                    linha++;

                    texto = @" Processando... " + ColunaA + @" - " + ColunaB;

                    sendText(texto);

                    Executar(ColunaA, ColunaB, ColunaC, ColunaD, ColunaE, ColunaF, ColunaG, ColunaH, ColunaI, ColunaJ, ColunaK, ColunaL, ColunaM, ColunaN, ColunaO, ColunaP, Indice);

                    //texto = "";
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_CriarPastaFuncionario.txt", "\r\n" + "- - - -");


                    wb.Dispose();

                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("O processo não pode acessar o arquivo"))
                {
                    MessageBox.Show("O Arquivo esta aberto! É necessario Fecha-lo", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return;
            }


            MessageBox.Show("Processado com Sucesso!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            textBox1.Text = "";
            arquivo = "";
            sendText("");
        }
        #endregion

        public void sendText(string msg)
        {
            labelNome.Text = msg;
            labelNome.Refresh();

        }



        #region Executar
        public static string Executar(string matricula, string nome, string ColunaC_Empresa, string ColunaD, string ColunaE_Dtdesligamento, string ColunaF, string ColunaG, string ColunaH, string ColunaI, string ColunaJ, string ColunaK, string ColunaL, string ColunaM, string ColunaN, string ColunaO, string ColunaP, string Indice)
        {
            try
            {
                var RetornCreateFolder = CreateFolder(matricula, nome, ColunaC_Empresa, ColunaD, ColunaE_Dtdesligamento, ColunaF, ColunaG, ColunaH, ColunaI, ColunaJ, ColunaK, ColunaL, ColunaM, ColunaN, ColunaO, ColunaP, Indice);

                if (ColunaE_Dtdesligamento == "")
                {
                    if (RetornCreateFolder != "false")
                    {
                        var resposta = searchDoc(matricula, ColunaC_Empresa, RetornCreateFolder, Indice, nome, ColunaD, ColunaE_Dtdesligamento, ColunaF, ColunaG, ColunaH, ColunaI, ColunaJ, ColunaK, ColunaL, ColunaM, ColunaN, ColunaO, ColunaP);
                    }
                }

            }
            catch (Exception ex)
            {
                File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | " + ex.Message);
                MessageBox.Show(ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return ("");

        }
        #endregion

        public static string CaminhoDadosXML(string caminho)
        {
            if (caminho.IndexOf("\\bin\\Debug") != 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            return caminho;
        }


        #region CreateFolder
        public static string CreateFolder(string matricula, string nome, string ColunaC_Empresa, string ColunaD, string ColunaE_Dtdesligamento, string ColunaF, string ColunaG, string ColunaH, string ColunaI, string ColunaJ, string ColunaK, string ColunaL, string ColunaM, string ColunaN, string ColunaO, string ColunaP, string Indice)
        {
            try
            {
                #region DadosXML
                var ColunaA_MatriculaPasta = "";
                var AttributeNome = "";
                var AttributeEmpresa = "";
                var vColunaD = "";
                var AttributeDtdesligamento = "";
                var vColunaF = "";
                var vColunaG = "";
                var vColunaH = "";
                var vColunaI = "";
                var vColunaJ = "";

                var vColunaK = "";
                var vColunaL = "";
                var vColunaM = "";
                var vColunaN = "";
                var vColunaO = "";
                var vColunaP = "";

                string IDCATEGORY = "";
                string IDUSER = "";
                string FormatoData = "";
                string EditAtrib = "";


                XDocument doc = XDocument.Load((CaminhoDadosXML(caminho) + @"System.net.cnfg.xml"));
                var prods = from p in doc.Descendants("Config")
                            select new
                            {
                                ColunaA_MatriculaPasta = p.Element("ColunaA_MatriculaPasta").Value,
                                ColunaB_Nome = p.Element("ColunaB_Nome").Value,
                                ColunaC_Empresa = p.Element("ColunaC_Empresa").Value,
                                ColunaD_Dtadmissao = p.Element("ColunaD_Dtadmissao").Value,
                                ColunaE_Dtdesligamento = p.Element("ColunaE_Dtdesligamento").Value,
                                ColunaF = p.Element("ColunaF").Value,
                                ColunaG = p.Element("ColunaG").Value,
                                ColunaH = p.Element("ColunaH").Value,
                                ColunaI = p.Element("ColunaI").Value,
                                ColunaJ = p.Element("ColunaJ").Value,
                                ColunaK = p.Element("ColunaK").Value,
                                ColunaL = p.Element("ColunaL").Value,
                                ColunaM = p.Element("ColunaM").Value,
                                ColunaN = p.Element("ColunaN").Value,
                                ColunaO = p.Element("ColunaO").Value,
                                ColunaP = p.Element("ColunaP").Value,

                                IDCategoriaPasta = p.Element("IDCategoriaPasta").Value,
                                Categorychecklist = p.Element("Categorychecklist").Value,

                                StructPendenteID = p.Element("StructPendenteID").Value,
                                DigitosStructID = p.Element("DigitosStructID").Value,

                                IdUsuario = p.Element("IdUsuario").Value,
                                EditarCadastro = p.Element("EditarCadastro").Value,
                                FormatoData = p.Element("FormatoData").Value,

                            };

                foreach (var p in prods)
                {
                    ColunaA_MatriculaPasta = p.ColunaA_MatriculaPasta;
                    AttributeNome = p.ColunaB_Nome;
                    AttributeEmpresa = p.ColunaC_Empresa;
                    vColunaD = p.ColunaD_Dtadmissao;
                    AttributeDtdesligamento = p.ColunaE_Dtdesligamento;
                    vColunaF = p.ColunaF;
                    vColunaG = p.ColunaG;
                    vColunaH = p.ColunaH;
                    vColunaI = p.ColunaI;
                    vColunaJ = p.ColunaJ;
                    vColunaK = p.ColunaK;
                    vColunaL = p.ColunaL;
                    vColunaM = p.ColunaM;
                    vColunaN = p.ColunaN;
                    vColunaO = p.ColunaO;
                    vColunaP = p.ColunaP;
                    IDCATEGORY = p.IDCategoriaPasta;
                    IDUSER = p.IdUsuario;
                    FormatoData = p.FormatoData;
                    EditAtrib = p.EditarCadastro;

                }
                #endregion

                string DTDOCUMENT = Convert.ToString(System.DateTime.Now.ToString(FormatoData));

                string StrAtribut = (ColunaA_MatriculaPasta + "=" + matricula + ";"
                                     + AttributeNome + "=" + nome + ";"
                                     + AttributeEmpresa + "=" + ColunaC_Empresa + ";"
                                     + vColunaD + "=" + ColunaD + ";"
                                     + AttributeDtdesligamento + "=" + ColunaE_Dtdesligamento + ";"
                                     + vColunaF + "=" + ColunaF + ";"
                                     + vColunaG + "=" + ColunaG + ";"
                                     + vColunaH + "=" + ColunaH + ";"
                                     + vColunaI + "=" + ColunaI + ";"
                                     + vColunaJ + "=" + ColunaJ + ";"
                                     + vColunaK + "=" + ColunaK + ";"
                                     + vColunaL + "=" + ColunaL + ";"
                                     + vColunaM + "=" + ColunaM + ";"
                                     + vColunaN + "=" + ColunaN + ";"
                                     + vColunaO + "=" + ColunaO + ";"
                                     + vColunaP + "=" + ColunaP);

                string ATTRIBUTTES = StrAtribut.Replace("=;=;=;=;=", "").Replace(";=", "").Replace("=;=", "").Replace("=;=;=", "").Replace("=;=;=;=", "");


                int FGMODEL = 1;

                string Cat_Indice = IDCATEGORY + "-" + Indice;

                SEClient newFolder = Conection.GetConnection();
                string resultadoNewDoc = newFolder.newDocument(IDCATEGORY, Cat_Indice, "", "", DTDOCUMENT, ATTRIBUTTES, IDUSER, null, FGMODEL, null);

                IDCriate = 1;
                string strID = "";

                if (resultadoNewDoc.ToString().Substring(0, 2).Contains("0:"))
                {
                    //File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | " + matricula + @" | " + nome + @" | " + resultadoNewDoc.Substring(3).ToString() + @";");
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | " + matricula + @" | " + nome + @" | " + resultadoNewDoc.Substring(3).ToString() + @";");
                    //
                    if (EditAtrib == "Sim")
                    {

                        if (resultadoNewDoc.ToString().Contains("0: Identificador já existente.."))
                        {
                            string[] edd = resultadoNewDoc.ToString().Split(new char[] { Convert.ToChar("[") });
                            string idmatricula = edd[1].Replace("]", "");

                            foreach (var item in (ATTRIBUTTES.ToString().Split(new char[] { Convert.ToChar(";") })))
                            {
                                if (item == "")
                                {
                                    break;
                                }

                                string[] strNome = item.ToString().Split(new char[] { Convert.ToChar("=") });

                                string idattribute = strNome[0];
                                string vlattribute = strNome[1];
                                UpdateAtributos(idmatricula, idattribute, vlattribute);

                            }
                            UpdateTitulo(IDCATEGORY, idmatricula, nome);
                            File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | Atualizado dados no cadastro da Matricula " + idmatricula + @";");

                            return ("false");
                        }
                    }

                    //File.AppendAllText(logpath + @"\" + "log.txt", "\r\n" + DateTime.Now + @" | " + matricula + @" | " + nome + @" | " + resultadoNewDoc.Substring(3).ToString() + @";");
                    MessageBox.Show(matricula + @" | " + nome + @" | " + resultadoNewDoc.Substring(3).ToString(), ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return ("false");
                }
                else
                {
                    strID = resultadoNewDoc.Substring(3).Replace(": Documento criado com sucesso", "");
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | " + matricula + @" | " + nome + @" | " + resultadoNewDoc.Substring(3).ToString().Replace("Documento", "Pasta") + @";");
                }


                return (strID);


            }
            catch (Exception ex)
            {
                while (IDCriate <= 2)
                {
                    IDCriate++;
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | CriarPastaDoc | " + ex.Message.ToString() + @";");
                    Thread.Sleep(Convert.ToInt32(7000));
                    return CreateFolder(matricula, nome, ColunaC_Empresa, ColunaD, ColunaE_Dtdesligamento, ColunaF, ColunaG, ColunaH, ColunaI, ColunaJ, ColunaK, ColunaL, ColunaM, ColunaN, ColunaO, ColunaP, Indice);
                }
                return ("false");
            }
            #endregion

        }
        #region searchDoc
        public static string searchDoc(string Identificador, string empresa, string RetornCreateFolder, string Indice, string nome, string ColunaD, string ColunaE_Dtdesligamento, string ColunaF, string ColunaG, string ColunaH, string ColunaI, string ColunaJ, string ColunaK, string ColunaL, string ColunaM, string ColunaN, string ColunaO, string ColunaP)
        {
            try
            {
                #region DadosXML
                string Categorychecklist = "";
                string Chklist_empresa = "";
                string Chklist_evento = "";

                var separator = ConfigurationManager.AppSettings["separator"];

                XDocument doc = XDocument.Load((CaminhoDadosXML(caminho) + @"System.net.cnfg.xml"));
                var prods = from p in doc.Descendants("Config")
                            select new
                            {
                                Categorychecklist = p.Element("Categorychecklist").Value,
                                Chklist_empresa = p.Element("Chklist_empresa").Value,
                                Chklist_evento = p.Element("Chklist_evento").Value,

                            };

                foreach (var p in prods)
                {
                    Categorychecklist = p.Categorychecklist;
                    Chklist_empresa = p.Chklist_empresa;
                    Chklist_evento = p.Chklist_evento;

                }
                #endregion
                //
                attributeData[] attributeDatas = new attributeData[2];
                attributeDatas[0] = new attributeData
                {

                    IDATTRIBUTE = Chklist_empresa,
                    VLATTRIBUTE = empresa
                };

                attributeDatas[1] = new attributeData
                {

                    IDATTRIBUTE = Chklist_evento,
                    VLATTRIBUTE = "admissão"
                };

                searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = Categorychecklist };
                SEClient seClient = Conection.GetConnection();
                searchDocumentReturn searchDocumentReturn = seClient.searchDocument(searchDocumentFilter, "", attributeDatas);


                if (searchDocumentReturn.RESULTS.Count() > 0)
                {
                    foreach (var item in (searchDocumentReturn.RESULTS))
                    {
                        string[] strNome = Path.GetFileName(item.IDDOCUMENT).ToString().Split(new char[] { Convert.ToChar(separator) });

                        string IdCat = strNome[3];
                        //Identificador
                        var RetCriarDoc = CriarDoc(IdCat, RetornCreateFolder, Indice, Identificador, nome, empresa, ColunaD, ColunaE_Dtdesligamento, ColunaF, ColunaG, ColunaH, ColunaI, ColunaJ, ColunaK, ColunaL, ColunaM, ColunaN, ColunaO, ColunaP);
                        if (RetCriarDoc != "false")
                        {
                            var RetDocAssocia = CriaDocContainerAssocia(IdCat, RetCriarDoc, RetornCreateFolder);
                        }
                    }
                }
                IDSeachDoc = 1;
                return Identificador;
            }
            catch (Exception ex)
            {///here
                while (IDSeachDoc <= 2)
                {
                    IDSeachDoc++;
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | CriarPastaDoc | " + ex.Message.ToString() + @";");
                    Thread.Sleep(Convert.ToInt32(5000));
                    return searchDoc(Identificador, empresa, RetornCreateFolder, Indice, nome, ColunaD, ColunaE_Dtdesligamento, ColunaF, ColunaG, ColunaH, ColunaI, ColunaJ, ColunaK, ColunaL, ColunaM, ColunaN, ColunaO, ColunaP);
                }
                return ("false");
            }

        }
        #endregion

        #region CriarDoc
        public static string CriarDoc(string CategoryID, string matricula, string Indice, string ColunaA, string ColunaB, string ColunaC_Empresa, string ColunaD, string ColunaE_Dtdesligamento, string ColunaF, string ColunaG, string ColunaH, string ColunaI, string ColunaJ, string ColunaK, string ColunaL, string ColunaM, string ColunaN, string ColunaO, string ColunaP)
        {
            try
            {

                var AttributeSituacaodoc = "";
                var Valor_AttributeSituacaodoc = "";

                var AttributeMatriculaDoc = "";
                var V_Atributo2 = matricula;

                var user = "";
                string FormatoData = "";

                #region DadosXML

                string AtribDocColunaA = "";
                string AtribDocColunaB = "";
                string AtribDocColunaC = "";
                string AtribDocColunaD = "";
                string AtribDocColunaE = "";
                string AtribDocColunaF = "";
                string AtribDocColunaG = "";
                string AtribDocColunaH = "";
                string AtribDocColunaI = "";
                string AtribDocColunaJ = "";
                string AtribDocColunaK = "";
                string AtribDocColunaL = "";
                string AtribDocColunaM = "";
                string AtribDocColunaN = "";
                string AtribDocColunaO = "";
                string AtribDocColunaP = "";

                XDocument doc = XDocument.Load((CaminhoDadosXML(caminho) + @"System.net.cnfg.xml"));
                var prods = from p in doc.Descendants("Config")
                            select new
                            {
                                AttributeMatriculaDoc = p.Element("AttributeMatriculaDoc").Value,
                                AttributeSituacaodoc = p.Element("AttributeSituacaodoc").Value,
                                Valor_AttributeSituacaodoc = p.Element("Valor_AttributeSituacaodoc").Value,
                                IdUsuario = p.Element("IdUsuario").Value,
                                FormatoData = p.Element("FormatoData").Value,
                                AtribDocColunaA = p.Element("AtribDocColunaA").Value,
                                AtribDocColunaB = p.Element("AtribDocColunaB").Value,
                                AtribDocColunaC = p.Element("AtribDocColunaC").Value,
                                AtribDocColunaD = p.Element("AtribDocColunaD").Value,
                                AtribDocColunaE = p.Element("AtribDocColunaE").Value,
                                AtribDocColunaF = p.Element("AtribDocColunaF").Value,
                                AtribDocColunaG = p.Element("AtribDocColunaG").Value,
                                AtribDocColunaH = p.Element("AtribDocColunaH").Value,
                                AtribDocColunaI = p.Element("AtribDocColunaI").Value,
                                AtribDocColunaJ = p.Element("AtribDocColunaJ").Value,
                                AtribDocColunaK = p.Element("AtribDocColunaK").Value,
                                AtribDocColunaL = p.Element("AtribDocColunaL").Value,
                                AtribDocColunaM = p.Element("AtribDocColunaM").Value,
                                AtribDocColunaN = p.Element("AtribDocColunaN").Value,
                                AtribDocColunaO = p.Element("AtribDocColunaO").Value,
                                AtribDocColunaP = p.Element("AtribDocColunaP").Value,
                            };

                foreach (var p in prods)
                {
                    AttributeSituacaodoc = p.AttributeSituacaodoc;
                    Valor_AttributeSituacaodoc = p.Valor_AttributeSituacaodoc;
                    AttributeMatriculaDoc = p.AttributeMatriculaDoc;
                    user = p.IdUsuario;
                    FormatoData = p.FormatoData;
                    AtribDocColunaA = p.AtribDocColunaA;
                    AtribDocColunaB = p.AtribDocColunaB;
                    AtribDocColunaC = p.AtribDocColunaC;
                    AtribDocColunaD = p.AtribDocColunaD;
                    AtribDocColunaE = p.AtribDocColunaE;
                    AtribDocColunaF = p.AtribDocColunaF;
                    AtribDocColunaG = p.AtribDocColunaG;
                    AtribDocColunaH = p.AtribDocColunaH;
                    AtribDocColunaI = p.AtribDocColunaI;
                    AtribDocColunaJ = p.AtribDocColunaJ;
                    AtribDocColunaK = p.AtribDocColunaK;
                    AtribDocColunaL = p.AtribDocColunaL;
                    AtribDocColunaM = p.AtribDocColunaM;
                    AtribDocColunaN = p.AtribDocColunaN;
                    AtribDocColunaO = p.AtribDocColunaO;
                    AtribDocColunaP = p.AtribDocColunaP;

                    if (AtribDocColunaA == "") { ColunaA = ""; }
                    if (AtribDocColunaB == "") { ColunaB = ""; }
                    if (AtribDocColunaC == "") { ColunaC_Empresa = ""; }
                    if (AtribDocColunaD == "") { ColunaD = ""; }
                    if (AtribDocColunaE == "") { ColunaE_Dtdesligamento = ""; }
                    if (AtribDocColunaF == "") { ColunaF = ""; }
                    if (AtribDocColunaG == "") { ColunaG = ""; }
                    if (AtribDocColunaH == "") { ColunaH = ""; }
                    if (AtribDocColunaI == "") { ColunaI = ""; }
                    if (AtribDocColunaJ == "") { ColunaJ = ""; }
                    if (AtribDocColunaK == "") { ColunaK = ""; }
                    if (AtribDocColunaL == "") { ColunaL = ""; }
                    if (AtribDocColunaM == "") { ColunaM = ""; }
                    if (AtribDocColunaN == "") { ColunaN = ""; }
                    if (AtribDocColunaO == "") { ColunaO = ""; }
                    if (AtribDocColunaP == "") { ColunaP = ""; }

                }

                #endregion

                string StrAtribut = (AttributeSituacaodoc + "=" + Valor_AttributeSituacaodoc + ";"
                                    + AttributeMatriculaDoc + "=" + V_Atributo2 + ";"
                                    + AtribDocColunaA + "=" + ColunaA + ";"
                                    + AtribDocColunaB + "=" + ColunaB + ";"
                                    + AtribDocColunaC + "=" + ColunaC_Empresa + ";"
                                    + AtribDocColunaD + "=" + ColunaD + ";"
                                    + AtribDocColunaE + "=" + ColunaE_Dtdesligamento + ";"
                                    + AtribDocColunaF + "=" + ColunaF + ";"
                                    + AtribDocColunaG + "=" + ColunaG + ";"
                                    + AtribDocColunaH + "=" + ColunaH + ";"
                                    + AtribDocColunaI + "=" + ColunaI + ";"
                                    + AtribDocColunaJ + "=" + ColunaJ + ";"
                                    + AtribDocColunaK + "=" + ColunaK + ";"
                                    + AtribDocColunaL + "=" + ColunaL + ";"
                                    + AtribDocColunaM + "=" + ColunaM + ";"
                                    + AtribDocColunaM + "=" + ColunaN + ";"
                                    + AtribDocColunaN + "=" + ColunaO + ";"
                                    + AtribDocColunaP + "=" + ColunaP);

                string ATTRIBUTTES = StrAtribut.Replace("=;=;=;=;=", "").Replace("=;", "").Replace("=;=", "").Replace("=;=;=", "").Replace("=;=;=;=", "").Replace(";=", "");

                string DTDOCUMENT = Convert.ToString(System.DateTime.Now.ToString(FormatoData));

                //string StrAtribut = (AttributeSituacaodoc + "=" + Valor_AttributeSituacaodoc + ";" + AttributeMatriculaDoc + "=" + V_Atributo2);

                int FGMODEL = 1;

                string CategIndice = CategoryID + @"-" + Indice;

                SEClient newDoc = Conection.GetConnection();
                var resultadoNewDoc = newDoc.newDocument(CategoryID, CategIndice, "", "", DTDOCUMENT, ATTRIBUTTES, user, null, FGMODEL, null);

                string Identific = "";

                if (resultadoNewDoc.ToString().Substring(0, 2).Contains("0:"))
                {
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | " + matricula + @" | " + resultadoNewDoc.Substring(3).ToString() + @";");
                    return ("false");
                }
                else
                {
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | " + matricula + @" | " + resultadoNewDoc.Substring(3).ToString() + @";");
                    Identific = resultadoNewDoc.Substring(3).Replace(": Documento criado com sucesso", "");

                }
                IDCriaDoc = 1;
                return (Identific);
            }
            catch (Exception ex)
            {
                while (IDCriaDoc <= 2)
                {
                    IDCriaDoc++;
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | CriarPastaDoc | " + ex.Message.ToString() + @";");
                    Thread.Sleep(Convert.ToInt32(5000));
                    return CriarDoc(CategoryID, matricula, Indice, ColunaA, ColunaB, ColunaC_Empresa, ColunaD, ColunaE_Dtdesligamento, ColunaF, ColunaG, ColunaH, ColunaI, ColunaJ, ColunaK, ColunaL, ColunaM, ColunaN, ColunaO, ColunaP);
                }
                return ("false");
            }
        }
        #endregion

        #region CREATEDOCCONTAINER
        public static string CriaDocContainerAssocia(string IDCATEGORY, string Retornocriar, string RetornCreateFolder)
        {
            try
            {
                string IDPASTA = "";
                string StructID = "";
                var digitosparaStructID = "";

                #region DadosXML

                XDocument doc = XDocument.Load((CaminhoDadosXML(caminho) + @"System.net.cnfg.xml"));
                var prods = from p in doc.Descendants("Config")
                            select new
                            {
                                IDCategoriaPasta = p.Element("IDCategoriaPasta").Value,
                                StructPendenteID = p.Element("StructPendenteID").Value,
                                DigitosStructID = p.Element("DigitosStructID").Value,
                            };

                foreach (var p in prods)
                {
                    IDPASTA = p.IDCategoriaPasta;
                    StructID = p.StructPendenteID;
                    digitosparaStructID = p.DigitosStructID;

                }
                #endregion

                if (StructID == "")
                {
                    string strID = IDCATEGORY.Substring(0, Convert.ToInt32(digitosparaStructID));
                    StructID = strID;
                }


                SEClient newDocContainerAss = Conection.GetConnection();
                string resultContainerAss = newDocContainerAss.newDocumentContainerAssociation(IDPASTA, RetornCreateFolder, "", StructID, IDCATEGORY, Retornocriar, out long codeAssociation, out string detailAssociation);
                if (resultContainerAss.ToString().Substring(0, 2).Contains("0:"))
                {
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | VINCULADO DOCUMENTO: " + Retornocriar + @" A PASTA " + RetornCreateFolder + @" COM " + resultContainerAss + @";");
                }
                else
                {
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | VINCULADO DOCUMENTO: " + Retornocriar + @" A PASTA " + RetornCreateFolder + @" COM " + resultContainerAss + @";");
                }
                IDAssoc = 1;
                return resultContainerAss;
            }
            catch (Exception ex)
            {
                while (IDAssoc <= 2)
                {
                    IDAssoc++;
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | CriarPastaDoc | " + ex.Message.ToString() + @";");
                    Thread.Sleep(Convert.ToInt32(5000));
                    return CriaDocContainerAssocia(IDCATEGORY, Retornocriar, RetornCreateFolder);
                }
                return ("false");
            }
        }
        #endregion

        #region UpdateAtributo
        public static void UpdateAtributos(string IDDoc, string idattribute, string vlattribute)
        {
            try
            {
                SEClient UpdateAtrib = Conection.GetConnection();
                string resUpdateAtrib = UpdateAtrib.setAttributeValue(IDDoc, "", idattribute, vlattribute);

                UpdateAtr = 1;
            }
            catch (Exception ex)
            {
                while (UpdateAtr <= 2)
                {
                    UpdateAtr++;
                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" |  UpdateAtributos " + ex.Message);
                    MessageBox.Show("UpdateAtributos" + ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        }
        #endregion

        #region UpdateTitulo
        public static void UpdateTitulo(string IDCATEGORY, string IdDocumento, string titulo)
        {
            try
            {
                SEClient EditDoc = Conection.GetConnection();
                string resEditDoc = EditDoc.editDocument(IDCATEGORY, IdDocumento, "", "", titulo, "");
                UpdateTit = 1;
            }
            catch (Exception ex)
            {
                while (UpdateTit <= 2)
                {
                    UpdateTit++;

                    File.AppendAllText(logCriarPastaFuncionario + @"\" + "log_erro_CriarPastaFuncionario.txt", "\r\n" + DateTime.Now + @" | " + ex.Message);
                }
                MessageBox.Show(ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }

        }
        #endregion



        #region Pastas
        private void criarpastas()
        {
            var PastaDestinoLog = ConfigurationManager.AppSettings["PastaDestinoLog"].ToString();
            if (!Directory.Exists(PastaDestinoLog))
            {
                Directory.CreateDirectory(PastaDestinoLog);
            }
        }

        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

            //Form4 menuadminform = new Form4();
            //menuadminform.Show();
            //this.Close();
            if (id != 0)
            {
                Int32 pID = Convert.ToInt32(id);
                Process p = Process.GetProcessById(pID);
                p.Kill();
            }


        }

        private void labelNome_Click(object sender, EventArgs e)
        {

        }
    }
}
