using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Import2SE.Dados;
using static Import2SE.FormMenu;

namespace Import2SE
{
    public partial class Form10ConfIntegra : Form
    {
        public Form10ConfIntegra()
        {
            InitializeComponent();

        }
        String caminho = AppDomain.CurrentDomain.BaseDirectory;

        private void Form10ConfIntegra_Load(object sender, EventArgs e)
        {
            GetDadosComboBox();
            GetValSessao();
        }

        public static string CaminhoDadosXML(string caminho)
        {
            if (caminho.IndexOf("\\bin\\Debug") != 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            return caminho;
        }


        public void GetValSessao()
        {
            try
            {
                XDocument doc = XDocument.Load((CaminhoDadosXML(caminho) + @"System.net.sess.xml"));
                var prods = from p in doc.Descendants("B_ses")
                            select new
                            {
                                Cliente = p.Element("Cliente").Value,
                            };
                foreach (var p in prods)
                {
                    comboBox1.Text = p.Cliente;  
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ".:: ALERTA ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        ComboBox cmb;
        public void GetDadosComboBox()
        {
            cmb = comboBox1;
            cmb.DropDownWidth = 120;
            Controls.Add(cmb);

            try
            {
                DataSet dsStore = new DataSet();
                dsStore.ReadXml(CaminhoDadosXML(caminho) + @"System.net.b.xml");
                comboBox1.DataSource = dsStore.Tables["B_dado"];
                comboBox1.DisplayMember = "Cliente";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ".:: ALERTA ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                FormMenu FormMenu = new FormMenu();
                //Pesquisa no Config o ID/Cliente

                DataSet ds;
                string sXMLFile = (CaminhoDadosXML(caminho) + @"System.net.b.xml");
                ds = new DataSet();
                ds.ReadXml(sXMLFile);

                //Fazer uma busca no DataSet para encontrar o cliente com o ID da QueryString
                DataRow dRow = ds.Tables["B_dado"].Select(" Cliente = '" + comboBox1.Text + "'")[0];
                string id = dRow.ItemArray[0].ToString();
                string idURL = dRow.ItemArray[2].ToString();
                string idPassw = dRow.ItemArray[4].ToString();
                string idLogin = dRow.ItemArray[3].ToString();
                //


                // Salva na sessão a configuração ID/Cliente
                using (DataSet dsResultado = new DataSet())
                {
                    dsResultado.ReadXml(CaminhoDadosXML(caminho) + @"System.net.sess.xml");
                    if (dsResultado.Tables.Count != 0)
                    {
                        sessao sessao = new sessao();
                        sessao.Cliente = comboBox1.Text.Replace(" ", "");
                        sessao.id = id.Replace(" ", "");
                        sessao.url = idURL;
                        sessao.Password = idPassw;
                        sessao.Username = idLogin;

                        XmlTextWriter writer = new XmlTextWriter(CaminhoDadosXML(caminho) + @"System.net.sess.xml", System.Text.Encoding.UTF8);

                        writer.WriteStartDocument(true);
                        writer.Formatting = Formatting.Indented;
                        writer.Indentation = 2;
                        writer.WriteStartElement("B_sessao");
                        writer.WriteStartElement("B_ses");

                        writer.WriteStartElement("id");
                        writer.WriteString(sessao.id);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Cliente");
                        writer.WriteString(sessao.Cliente);
                        writer.WriteEndElement();


                        writer.WriteStartElement("url");
                        writer.WriteString(sessao.url);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Password");
                        writer.WriteString(sessao.Password);
                        writer.WriteEndElement();

                        writer.WriteStartElement("Username");
                        writer.WriteString(sessao.Username);
                        writer.WriteEndElement();


                        writer.WriteEndElement();
                        writer.WriteEndDocument();
                        writer.Close();
                        dsResultado.ReadXml(CaminhoDadosXML(caminho) + @"System.net.sess.xml");

                    }
                }
              

                MessageBox.Show("Salvo com sucesso !", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
               FormMenu.GetValSessaoMenu();             
                
            }
            catch (Exception ex)
            {                
                MessageBox.Show("Erro " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }




        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
