using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Import2SE.Dados;
using Import2SE.softexpert;
using static Import2SE.Form1;

namespace Import2SE
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private static string logpath = ConfigurationManager.AppSettings["PastaDestinoLog"].ToString();
        String caminho = AppDomain.CurrentDomain.BaseDirectory;

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
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


        private void button1Salvar_Click(object sender, EventArgs e)
        {
            try
            {
                using (DataSet dsResultado = new DataSet())
                {
                    dsResultado.ReadXml(CaminhoDadosXML(caminho) + @"System.net.cnfg.xml");
                    if (dsResultado.Tables.Count != 0)
                    {
                        Config Config = new Config();
                        Config.ColunaA_MatriculaPasta = textBox8ColunaA.Text.Replace(" ", "");
                        Config.ColunaB_Nome = textBox9ColunaB.Text.Replace(" ", "");
                        Config.ColunaC_Empresa = textBox10ColunaC.Text.Replace(" ", "");
                        Config.ColunaD_Dtadmissao = textBox11ColunaD.Text.Replace(" ", "");
                        Config.ColunaE_Dtdesligamento = textBox12ColunaE.Text.Replace(" ", "");
                        Config.ColunaF = textBox13ColunaF.Text.Replace(" ", "");
                        Config.ColunaG = textBox14ColunaG.Text.Replace(" ", "");
                        Config.ColunaH = textBox15ColunaH.Text.Replace(" ", "");
                        Config.ColunaI = textBox16ColunaI.Text.Replace(" ", "");
                        Config.ColunaJ = textBox17ColunaJ.Text.Replace(" ", "");
                        Config.ColunaK = textBox18ColunaK.Text.Replace(" ", "");
                        Config.ColunaL = textBox19ColunaL.Text.Replace(" ", "");
                        Config.ColunaM = textBox20ColunaM.Text.Replace(" ", "");
                        Config.ColunaN = textBox21ColunaN.Text.Replace(" ", "");
                        Config.ColunaO = textBox22ColunaO.Text.Replace(" ", "");
                        Config.ColunaP = textBox23ColunaP.Text.Replace(" ", "");

                        Config.AttributeMatriculaDoc = textBox5AtributoMatrDoc.Text.Replace(" ", "");
                        Config.AttributeSituacaodoc = textBox6AtribSitDoc.Text.Replace(" ", "");
                        Config.Valor_AttributeSituacaodoc = textBox7VLAtribSitDoc.Text.Replace(" ", "");

                        Config.IDCategoriaPasta = textBox1IDCatPasta.Text.Replace(" ", "");
                        Config.Categorychecklist = textBox2CategChecklist.Text.Replace(" ", "");
                        Config.Chklist_empresa = textBox1ChklistEmpresa.Text.Replace(" ", "");
                        Config.Chklist_evento = textBox2ChklistEvento.Text.Replace(" ", "");


                        Config.StructPendenteID = textBox3StructPendID.Text.Replace(" ", "");
                        Config.DigitosStructID = textBox4DigStructID.Text.Replace(" ", "");

                        Config.IdUsuario = textBox1IDusuario.Text.Replace(" ", "");
                        Config.EditarCadastro = comboBox1.Text.Replace(" ", "");
                        Config.FormatoData = textBox25FormData.Text.Replace(" ", "");
                        Config.IndiceID = textBox1AtribIndice.Text.Replace(" ", "");

                        Config.AtribDocColunaA = textBox1AtribDocColunaA.Text.Replace(" ", "");
                        Config.AtribDocColunaB = textBox2AtribDocColunaB.Text.Replace(" ", "");
                        Config.AtribDocColunaC = textBox3AtribDocColunaC.Text.Replace(" ", "");
                        Config.AtribDocColunaD = textBox4AtribDocColunaD.Text.Replace(" ", "");
                        Config.AtribDocColunaE = textBox5AtribDocColunaE.Text.Replace(" ", "");
                        Config.AtribDocColunaF = textBox6AtribDocColunaF.Text.Replace(" ", "");
                        Config.AtribDocColunaG = textBox7AtribDocColunaG.Text.Replace(" ", "");
                        Config.AtribDocColunaH = textBox8AtribDocColunaH.Text.Replace(" ", "");
                        Config.AtribDocColunaI = textBox9AtribDocColunaI.Text.Replace(" ", "");
                        Config.AtribDocColunaJ = textBox10AtribDocColunaJ.Text.Replace(" ", "");
                        Config.AtribDocColunaK = textBox11AtribDocColunaK.Text.Replace(" ", "");
                        Config.AtribDocColunaL = textBox12AtribDocColunaL.Text.Replace(" ", "");
                        Config.AtribDocColunaM = textBox13AtribDocColunaM.Text.Replace(" ", "");
                        Config.AtribDocColunaN = textBox14AtribDocColunaN.Text.Replace(" ", "");
                        Config.AtribDocColunaO = textBox15AtribDocColunaO.Text.Replace(" ", "");
                        Config.AtribDocColunaP = textBox16AtribDocColunaP.Text.Replace(" ", "");
                                                                     

                        XmlTextWriter writer = new XmlTextWriter(CaminhoDadosXML(caminho) + @"System.net.cnfg.xml", System.Text.Encoding.UTF8);

                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;
                        writer.WriteStartElement("B_dados");

                        writer.WriteStartElement("Config");

                        writer.WriteStartElement("ColunaA_MatriculaPasta");
                        writer.WriteString(Config.ColunaA_MatriculaPasta);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaB_Nome");
                        writer.WriteString(Config.ColunaB_Nome);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaC_Empresa");
                        writer.WriteString(Config.ColunaC_Empresa);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaD_Dtadmissao");
                        writer.WriteString(Config.ColunaD_Dtadmissao);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaE_Dtdesligamento");
                        writer.WriteString(Config.ColunaE_Dtdesligamento);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaF");
                        writer.WriteString(Config.ColunaF);
                        writer.WriteEndElement();
                        //
                        writer.WriteStartElement("ColunaG");
                        writer.WriteString(Config.ColunaG);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaH");
                        writer.WriteString(Config.ColunaH);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaI");
                        writer.WriteString(Config.ColunaI);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaJ");
                        writer.WriteString(Config.ColunaJ);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaK");
                        writer.WriteString(Config.ColunaK);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaL");
                        writer.WriteString(Config.ColunaL);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaM");
                        writer.WriteString(Config.ColunaM);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaN");
                        writer.WriteString(Config.ColunaN);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaO");
                        writer.WriteString(Config.ColunaO);
                        writer.WriteEndElement();

                        writer.WriteStartElement("ColunaP");
                        writer.WriteString(Config.ColunaP);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AttributeMatriculaDoc");
                        writer.WriteString(Config.AttributeMatriculaDoc);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AttributeSituacaodoc");
                        writer.WriteString(Config.AttributeSituacaodoc);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Valor_AttributeSituacaodoc");
                        writer.WriteString(Config.Valor_AttributeSituacaodoc);
                        writer.WriteEndElement();

                        writer.WriteStartElement("IDCategoriaPasta");
                        writer.WriteString(Config.IDCategoriaPasta);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Categorychecklist");
                        writer.WriteString(Config.Categorychecklist);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Chklist_empresa");
                        writer.WriteString(Config.Chklist_empresa);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Chklist_evento");
                        writer.WriteString(Config.Chklist_evento);
                        writer.WriteEndElement();

                        writer.WriteStartElement("StructPendenteID");
                        writer.WriteString(Config.StructPendenteID);
                        writer.WriteEndElement();

                        writer.WriteStartElement("DigitosStructID");
                        writer.WriteString(Config.DigitosStructID);
                        writer.WriteEndElement();

                        writer.WriteStartElement("IdUsuario");
                        writer.WriteString(Config.IdUsuario);
                        writer.WriteEndElement();

                        writer.WriteStartElement("EditarCadastro");
                        writer.WriteString(Config.EditarCadastro);
                        writer.WriteEndElement();

                        writer.WriteStartElement("FormatoData");
                        writer.WriteString(Config.FormatoData);
                        writer.WriteEndElement();

                        writer.WriteStartElement("IndiceID");
                        writer.WriteString(Config.IndiceID);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaA");
                        writer.WriteString(Config.AtribDocColunaA);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaB");
                        writer.WriteString(Config.AtribDocColunaB);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaC");
                        writer.WriteString(Config.AtribDocColunaC);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaD");
                        writer.WriteString(Config.AtribDocColunaD);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaE");
                        writer.WriteString(Config.AtribDocColunaE);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaF");
                        writer.WriteString(Config.AtribDocColunaF);
                        writer.WriteEndElement();
                        //
                        writer.WriteStartElement("AtribDocColunaG");
                        writer.WriteString(Config.AtribDocColunaG);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaH");
                        writer.WriteString(Config.AtribDocColunaH);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaI");
                        writer.WriteString(Config.AtribDocColunaI);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaJ");
                        writer.WriteString(Config.AtribDocColunaJ);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaK");
                        writer.WriteString(Config.AtribDocColunaK);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaL");
                        writer.WriteString(Config.AtribDocColunaL);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaM");
                        writer.WriteString(Config.AtribDocColunaM);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaN");
                        writer.WriteString(Config.AtribDocColunaN);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaO");
                        writer.WriteString(Config.AtribDocColunaO);
                        writer.WriteEndElement();

                        writer.WriteStartElement("AtribDocColunaP");
                        writer.WriteString(Config.AtribDocColunaP);
                        writer.WriteEndElement();



                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                        dsResultado.ReadXml(CaminhoDadosXML(caminho) + @"System.net.cnfg.xml");

                    }
                    else
                    {
                        //dsResultado.Tables[0].Rows.Add(dsResultado.Tables[0].NewRow());
                        //dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["url"] = textBox1Link.Text;
                        //dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Username"] = textBox1Login.Text;
                        //dsResultado.Tables[0].Rows[dsResultado.Tables[0].Rows.Count - 1]["Password"] = textBox2Senha.Text;

                        //dsResultado.AcceptChanges();
                        ////--  Escreve para o arquivo XML final usando o método Write
                        //dsResultado.WriteXml(CaminhoDadosXML(caminho) + @"System.net.b.xml", XmlWriteMode.IgnoreSchema);
                    }
                    MessageBox.Show("Salvo com Sucesso!", ".:: Sucesso ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                File.AppendAllText(logpath + @"\" + "log_erro.txt", "\r\n" + DateTime.Now + @" | " + ex.Message);
                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            try
            {
                

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

                                AttributeMatriculaDoc = p.Element("AttributeMatriculaDoc").Value,
                                AttributeSituacaodoc = p.Element("AttributeSituacaodoc").Value,
                                Valor_AttributeSituacaodoc = p.Element("Valor_AttributeSituacaodoc").Value,

                                IDCategoriaPasta = p.Element("IDCategoriaPasta").Value,
                                Categorychecklist = p.Element("Categorychecklist").Value,

                                Chklist_empresa = p.Element("Chklist_empresa").Value,
                                Chklist_evento = p.Element("Chklist_evento").Value,

                                StructPendenteID = p.Element("StructPendenteID").Value,
                                DigitosStructID = p.Element("DigitosStructID").Value,

                                IdUsuario = p.Element("IdUsuario").Value,
                                EditarCadastro = p.Element("EditarCadastro").Value,
                                FormatoData = p.Element("FormatoData").Value,
                                IndiceID = p.Element("IndiceID").Value,

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
                    textBox8ColunaA.Text = p.ColunaA_MatriculaPasta;
                    textBox9ColunaB.Text = p.ColunaB_Nome;
                    textBox10ColunaC.Text = p.ColunaC_Empresa;
                    textBox11ColunaD.Text = p.ColunaD_Dtadmissao;
                    textBox12ColunaE.Text = p.ColunaE_Dtdesligamento;
                    textBox13ColunaF.Text = p.ColunaF;
                    textBox14ColunaG.Text = p.ColunaG;
                    textBox15ColunaH.Text = p.ColunaH;
                    textBox16ColunaI.Text = p.ColunaI;
                    textBox17ColunaJ.Text = p.ColunaJ;
                    textBox18ColunaK.Text = p.ColunaK;
                    textBox19ColunaL.Text = p.ColunaL;
                    textBox20ColunaM.Text = p.ColunaM;
                    textBox21ColunaN.Text = p.ColunaN;
                    textBox22ColunaO.Text = p.ColunaO;
                    textBox23ColunaP.Text = p.ColunaP;

                    textBox5AtributoMatrDoc.Text = p.AttributeMatriculaDoc;
                    textBox6AtribSitDoc.Text = p.AttributeSituacaodoc;
                    textBox7VLAtribSitDoc.Text = p.Valor_AttributeSituacaodoc;

                    textBox1IDCatPasta.Text = p.IDCategoriaPasta;
                    textBox2CategChecklist.Text = p.Categorychecklist;

                    textBox1ChklistEmpresa.Text = p.Chklist_empresa;
                    textBox2ChklistEvento.Text = p.Chklist_evento;

                    textBox3StructPendID.Text = p.StructPendenteID;
                    textBox4DigStructID.Text = p.DigitosStructID;

                    textBox1IDusuario.Text = p.IdUsuario;
                    comboBox1.Text = p.EditarCadastro;
                    textBox25FormData.Text = p.FormatoData;
                    textBox1AtribIndice.Text = p.IndiceID;

                    textBox1AtribDocColunaA.Text = p.AtribDocColunaA;
                    textBox2AtribDocColunaB.Text = p.AtribDocColunaB;
                    textBox3AtribDocColunaC.Text = p.AtribDocColunaC;
                    textBox4AtribDocColunaD.Text = p.AtribDocColunaD;
                    textBox5AtribDocColunaE.Text = p.AtribDocColunaE;
                    textBox6AtribDocColunaF.Text = p.AtribDocColunaF;
                    textBox7AtribDocColunaG.Text = p.AtribDocColunaG;
                    textBox8AtribDocColunaH.Text = p.AtribDocColunaH;
                    textBox9AtribDocColunaI.Text = p.AtribDocColunaI;
                    textBox10AtribDocColunaJ.Text = p.AtribDocColunaJ;
                    textBox11AtribDocColunaK.Text = p.AtribDocColunaK;
                    textBox12AtribDocColunaL.Text = p.AtribDocColunaL;
                    textBox13AtribDocColunaM.Text = p.AtribDocColunaM;
                    textBox14AtribDocColunaN.Text = p.AtribDocColunaN;
                    textBox15AtribDocColunaO.Text = p.AtribDocColunaO;
                    textBox16AtribDocColunaP.Text = p.AtribDocColunaP;

                }

            }
            catch (Exception ex)
            {
                File.AppendAllText(logpath + @"\" + "log_erro.txt", "\r\n" + DateTime.Now + @" | " + ex.Message);
                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
