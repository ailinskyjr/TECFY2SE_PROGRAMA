using System;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using Import2SE.Dados;
using System.IO;
using System.Linq;
using Import2SE;
using static Import2SE.Form5;
using static Import2SE.Form10ConfIntegra;
using System.Drawing;

namespace XML_BD
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        String idintegra;
        String caminho = AppDomain.CurrentDomain.BaseDirectory;

        Form10ConfIntegra Form10ConfIntegra = new Form10ConfIntegra();

        public void GetDados()
        {
            try
            {
                DataSet dsResultado = new DataSet();
                dsResultado.ReadXml(CaminhoDadosXML(caminho) + @"System.net.b.xml");
                if (dsResultado.Tables.Count != 0)
                {
                    if (dsResultado.Tables[0].Rows.Count > 0)
                    {
                        dgvDados.DataSource = dsResultado.Tables[0];
                        Form10ConfIntegra.GetDadosComboBox();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ".:: ALERTA ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static string CaminhoDadosXML(string caminho)
        {

            if (caminho.IndexOf("\\bin\\Debug") != 0)
            {
                caminho = caminho.Replace("\\bin\\Debug", "");
            }
            return caminho;
        }

        private void Form8_Load(object sender, EventArgs e)
        {         
            //GetDadosComboBox();
            GetValSessao(); 
            
            GetDados();
            dgvDados.Refresh();   
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
                    comboBox2.Text = p.Cliente;
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
            cmb = comboBox2;
            cmb.DropDownWidth = 120;
            Controls.Add(cmb);

            try
            {
                DataSet dsStore = new DataSet();
                dsStore.ReadXml(CaminhoDadosXML(caminho) + @"System.net.b.xml");
                comboBox2.DataSource = dsStore.Tables["B_dado"];
                comboBox2.DisplayMember = "Cliente";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ".:: ALERTA ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            int x = (this.Width / 10) - (form9.Width / 10);
            int y = (this.Height / 10) - (form9.Height / 10);
            form9.Location = new Point(x, y);

            form9.Show();
            //GetDadosComboBox();
            
        }


        private void Form8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }
        }


        private void dgvDados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Form9 form9 = new Form9();

            idintegra = dgvDados.Rows[e.RowIndex].Cells["id"].Value.ToString();

            if (dgvDados.Columns[e.ColumnIndex] == dgvDados.Columns["editar"])
            {
                string id = dgvDados.Rows[e.RowIndex].Cells["id"].Value.ToString();
                string Cliente = dgvDados.Rows[e.RowIndex].Cells["Cliente"].Value.ToString();
                string url = dgvDados.Rows[e.RowIndex].Cells["url"].Value.ToString();
                string Username = dgvDados.Rows[e.RowIndex].Cells["Username"].Value.ToString();
                string Password = dgvDados.Rows[e.RowIndex].Cells["Password"].Value.ToString();

                using (var Form5 = new Form5(id, Cliente, url, Username, Password))
                {
                    Form5.ShowDialog();
                }
            }
            else if (dgvDados.Columns[e.ColumnIndex] == dgvDados.Columns["excluir"])
            {
                DialogResult dr = MessageBox.Show("Deseja realmente excluir? ", "..:: Atenção ::..", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.No:
                        break;

                    case DialogResult.Yes:

                        string id = dgvDados.Rows[e.RowIndex].Cells["id"].Value.ToString();

                        string sXMLFile = (CaminhoDadosXML(caminho) + @"System.net.b.xml");

                        DataSet ds = new DataSet();

                        ds.ReadXml(sXMLFile);

                        string strID = id;
                        if (!string.IsNullOrEmpty(strID))
                        {
                            ds.Tables["B_dado"].Select(" id = '" + strID + "'")[0].Delete();

                            ds.AcceptChanges();

                            ds.WriteXml(sXMLFile);

                            GetDados();

                        }
                        break;
                }
            }
        }

        private void dgvDados_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewColumn coluna in dgvDados.Columns)
            {
                switch (coluna.Name)
                {
                    case "Cliente":
                        coluna.Width = 175;
                        break;

                    case "url":
                        coluna.Width = 270;

                        break;

                    //case "Username":
                    //    coluna.Width = 215;
                    //    break;
                    //case "Password":
                    //    coluna.Width = 125;
                    //    break;

                    case "editar":
                        coluna.DisplayIndex = 5;
                        coluna.Width = 23;
                        break;

                    case "excluir":
                        coluna.DisplayIndex = 5;
                        break;

                    default:
                        coluna.Visible = false;
                        break;
                }
            }
        }

        private void dgvDados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dgvDados.Rows[e.RowIndex].Cells["editar"].ToolTipText = "Editar";
            dgvDados.Rows[e.RowIndex].Cells["Excluir"].ToolTipText = "Excluir";
        }


        //
        //ComboBox cmb;       

        //private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{         
        //    this.Refresh();           
        //}

        private void tabPage1_Click(object sender, EventArgs e)
        {

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
                DataRow dRow = ds.Tables["B_dado"].Select(" Cliente = '" + comboBox2.Text + "'")[0];
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
                        sessao.Cliente = comboBox2.Text.Replace(" ", "");
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

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            this.Visible = true;
            this.Refresh();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void GetDadosComboBox()
        //{
        //    cmb = comboBox1;           
        //    cmb.DropDownWidth = 120;            
        //    Controls.Add(cmb);

        //    try
        //    {
        //        DataSet dsStore = new DataSet();
        //        dsStore.ReadXml(CaminhoDadosXML(caminho) + @"System.net.b.xml");
        //        comboBox1.DataSource = dsStore.Tables["B_dado"];
        //        comboBox1.DisplayMember = "Cliente";
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, ".:: ALERTA ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }


        //}

    }
}
