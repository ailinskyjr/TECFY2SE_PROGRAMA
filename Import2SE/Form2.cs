using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Import2SE.softexpert;
using System.Windows.Forms;
using static Import2SE.Form1;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Import2SE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private static int IDDelDoc = 1;
        private static string logpath = ConfigurationManager.AppSettings["PastaDestinoLog"].ToString();
        private static string ExcluirDocumentos = "Log_ExcluirDocumentos";
        private static string logExcluirDocumentos = logpath + @"\" + ExcluirDocumentos;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(logExcluirDocumentos))
            {
                Directory.CreateDirectory(logExcluirDocumentos);
            }


            //Variaveis
            searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
            SEClient SeachDoc = Conection.GetConnection();
            var texto = "";
            var CampoText = textBoxCateg.Text.Replace(" ", "");

            if (Categoria.Checked)
            {
                try
                {
                    listBox1DelDoc.Visible = true;
                    listBox1DelDoc.Items.Clear();

                    if (CampoText != "" && CampoText != null)
                    {
                        searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = CampoText };
                        searchDocumentReturn = SeachDoc.searchDocument(searchDocumentFilter, null, null);

                        foreach (var item in (searchDocumentReturn.RESULTS))
                        {
                            listBox1DelDoc.Items.Add(item.IDDOCUMENT + " - " + item.NMTITLE);
                        }
                        int total = searchDocumentReturn.RESULTS.Count();

                        DialogResult dr = MessageBox.Show("Total de arquivos " + total + ", Deseja realmente excluir? ", "..:: Atenção ::..", MessageBoxButtons.YesNo);
                        switch (dr)
                        {
                            case DialogResult.No:
                                break;


                            case DialogResult.Yes:
                                if (searchDocumentReturn.RESULTS.Count() > 0)
                                {
                                    foreach (var item in (searchDocumentReturn.RESULTS))
                                    {
                                        texto = @"Total de Registros: " + total + " Excluindo ... " + item.IDDOCUMENT;
                                        sendText(texto);

                                        string RetornDelete = DeleteDocument.DeletDocument(CampoText, item.IDDOCUMENT);
                                        total = total - 1;
                                    }

                                    MessageBox.Show("Concluido!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    textBoxCateg.Text = "";
                                    sendText("");
                                }
                                else
                                {
                                    MessageBox.Show("Sem registro para excluir! \n ou \n Categoria Digitado errado", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return;
                                }
                                break;

                        }

                    }
                    else
                    {
                        MessageBox.Show("Categoria não digitada!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    File.AppendAllText(logExcluirDocumentos + @"\" + "log_erro_ExcluirDocumentos.txt", "\r\n" + DateTime.Now + @" |" + ex.Message.ToString() + @";");
                    MessageBox.Show(ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

            }
            else if (Matricula.Checked)
            {
                if (CampoText != "" && CampoText != null)
                {
                    try
                    {
                        listBox1DelDoc.Visible = true;
                        listBox1DelDoc.Items.Clear();

                        var fileNameArray = Path.GetFileName(CampoText).ToString().Split(new char[] { Convert.ToChar(",") });

                        documentDataReturn documentDataReturn = new documentDataReturn();

                        foreach (var item in (fileNameArray))
                        {

                            documentDataReturn = SeachDoc.viewDocumentData(item, "", "", "");
                            listBox1DelDoc.Items.Add(documentDataReturn.IDDOCUMENT + " - " + documentDataReturn.NMTITLE);
                        }

                        if (documentDataReturn.IDDOCUMENT != "" && documentDataReturn.IDDOCUMENT != null)
                        {
                            DialogResult dr = MessageBox.Show("Deseja realmente excluir? ", "..:: Atenção ::..", MessageBoxButtons.YesNo);

                            switch (dr)
                            {
                                case DialogResult.No:
                                    break;

                                case DialogResult.Yes:


                                    foreach (var item in (fileNameArray))
                                    {
                                        var IdDoc = documentDataReturn.IDDOCUMENT;
                                        var IdCat = documentDataReturn.IDCATEGORY;

                                        texto = @" Excluindo ... " + IdDoc + @" - " + documentDataReturn.NMTITLE;
                                        sendText(texto);

                                        string RetornDelete = DeleteDocument.DeletDocument(IdCat, item);
                                        sendText("");
                                    }
                                    MessageBox.Show("Concluido!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    break;


                            }

                            listBox1DelDoc.Items.Clear();
                            ////if (RetornDelete == true) {
                            //    MessageBox.Show("Concluido!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            ////}

                        }
                        else
                        {
                            listBox1DelDoc.Visible = false;
                            MessageBox.Show("\n Sem registro para Excluir! \n ou \n Registro Digitado errado!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        File.AppendAllText(logExcluirDocumentos + @"\" + "log_erro_ExcluirDocumentos.txt", "\r\n" + DateTime.Now + @" |" + ex.Message.ToString() + @";");
                        MessageBox.Show(ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                }
                else
                {
                    MessageBox.Show("Registro não digitado!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }


        public void sendText(string msg)
        {
            label3.Text = msg;
            label3.Refresh();
        }

        #region DELETEDOC
        public class DeleteDocument
        {
            public static string DeletDocument(string IDCATEGORY, string IdDocumento)
            {
                try
                {
                    string Justificativa = "Exclusão Documento";
                    SEClient DeletDoc = Conection.GetConnection();
                    string RetornoDelet = DeletDoc.deleteDocument(IDCATEGORY, IdDocumento, "", Justificativa);

                    File.AppendAllText(logExcluirDocumentos + @"\" + "log_ExcluirDocumentos.txt", "\r\n" + DateTime.Now + @" | Deletado Documento " + IdDocumento + @" " + RetornoDelet.Substring(3).ToString() + @";");

                    IDDelDoc = 1;

                    if (RetornoDelet.Contains("1:"))
                    {
                        return "Sucesso";
                    }
                    else
                    {
                        return "false";
                    }

                }
                catch (Exception ex)
                {
                    while (IDDelDoc <= 2)
                    {
                        IDDelDoc++;
                        Thread.Sleep(Convert.ToInt32(5000));
                        File.AppendAllText(logExcluirDocumentos + @"\" + "log_erro_Excluir_Documentos.txt", "\r\n" + DateTime.Now + @" | " + ex.Message.ToString() + @";");
                        return DeletDocument(IDCATEGORY, IdDocumento);
                    }
                    return "false";
                }
            }
        }
        #endregion

        private void textBoxCateg_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = new TextBox();
            tb.SelectAll();
        }

        private void Matricula_CheckedChanged(object sender, EventArgs e)
        {

            labelBoxmatr.Text = "Mais de uma separar por Virgula";
            if (Categoria.Checked == true)
            {
                Matricula.Checked = false;
            }



        }

        private void Categoria_CheckedChanged(object sender, EventArgs e)
        {
            labelBoxmatr.Text = "";
            if (Matricula.Checked == true)
            {

                Categoria.Checked = false;
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {



        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            listBox1DelDoc.Items.Clear();
            textBoxCateg.Text = "";
        }

        private void listBox1DelDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
            foreach (object item in listBox1DelDoc.SelectedItems)
            {
                copy_buffer.AppendLine(item.ToString());
                if (copy_buffer.Length > 0)
                {
                    Clipboard.SetText(copy_buffer.ToString());
                }
            }
        }

        documentDataReturn searchDocumentReturn2 = new documentDataReturn();
        SEClient SeachDoc2 = Conection.GetConnection();

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;

                var categ = textBox1categ.Text.Replace(" ", "");

                if (categ != "" && categ != null)
                {
                    listBox1PSTsemDOC.Items.Clear();
                    sendText2("");

                    searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
                    searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = categ };
                    SEClient SeachDoc = Conection.GetConnection();
                    searchDocumentReturn = SeachDoc.searchDocument(searchDocumentFilter, null, null);

                    if (searchDocumentReturn.RESULTS.Count() > 0)
                    {
                        foreach (var item in (searchDocumentReturn.RESULTS))
                        {
                            //documentDataReturn searchDocumentReturn2 = new documentDataReturn();
                            //SEClient SeachDoc2 = Conection.GetConnection();
                            searchDocumentReturn2 = SeachDoc2.viewDocumentData(item.IDDOCUMENT, "", "", "");

                            sendText2("Pesquisando... " + item.IDDOCUMENT);

                            if (searchDocumentReturn2.ELECTRONICFILE.Count() == 0)
                            {
                                listBox1PSTsemDOC.Items.Add(item.IDDOCUMENT + " - " + item.NMTITLE);
                                cont++;
                            }
                        }
                        sendText2("Total de Documentos: " + cont);

                        if (cont > 0)
                        {
                            DialogResult dr = MessageBox.Show("Deseja realmente excluir? ", "..:: Atenção ::..", MessageBoxButtons.YesNo);

                            switch (dr)
                            {
                                case DialogResult.No:
                                    break;

                                case DialogResult.Yes:

                                    foreach (var item in (searchDocumentReturn.RESULTS))
                                    {
                                        searchDocumentReturn2 = SeachDoc2.viewDocumentData(item.IDDOCUMENT, "", "", "");

                                        if (searchDocumentReturn2.ELECTRONICFILE.Count() == 0)
                                        {
                                            sendText3("Excluindo... " + searchDocumentReturn2.IDDOCUMENT + " - " + searchDocumentReturn2.NMTITLE);
                                            var RetornDelete = DeleteDocument.DeletDocument(searchDocumentReturn2.IDCATEGORY, searchDocumentReturn2.IDDOCUMENT);
                                        }
                                    }
                                    break;
                            }
                            MessageBox.Show("Finalizado Exclusão!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            sendText3("");
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Digite a categoria !", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        public void sendText3(string msg)
        {
            label5Exclui.Text = msg;
            label5Exclui.Visible = true;
            label5Exclui.Refresh();
        }


        public void sendText2(string msg)
        {
            label4Pesq.Text = msg;
            label4Pesq.Visible = true;
            label4Pesq.Refresh();
        }

        private void label4Pesq_Click(object sender, EventArgs e)
        {

        }

        private void listBox1PSTsemDOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
            foreach (object item in listBox1PSTsemDOC.SelectedItems)
                copy_buffer.AppendLine(item.ToString());
            if (copy_buffer.Length > 0)
                Clipboard.SetText(copy_buffer.ToString());
        }

        private void button4_Click(object sender, EventArgs e)
        {

            dateTimePicker1Inicio.Text = Convert.ToString(System.DateTime.Now.ToString("yyyy-MM-dd"));
            var inicio = "2020-06-19";


            var fim = dateTimePicker2Fim.Text;

            searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
            searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = textBox1CategDate.Text };
            SEClient SeachDoc = Conection.GetConnection();
            searchDocumentReturn = SeachDoc.searchDocument(searchDocumentFilter, null, null);

            foreach (var item in (searchDocumentReturn.RESULTS.Where(p => p.DTDOCUMENT == inicio  &&  p.DTDOCUMENT == fim)))
            {

                var data = item.DTDOCUMENT;
                var id = item.IDDOCUMENT;
                var nome = item.NMTITLE;


            }
        }
    }
}
