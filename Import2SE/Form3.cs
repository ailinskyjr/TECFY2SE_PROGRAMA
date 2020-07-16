//Pesquisa Documento
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Import2SE.Form1;
using Import2SE.softexpert;
using System.Configuration;
using System.IO;
using System.Net;
using System.Diagnostics;

namespace Import2SE
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        TextBox tb = new TextBox();

        private void button1_Click(object sender, EventArgs e)
        {
            var matrORcat = RecMatricula.Text.Replace(" ", "");

            if (CheckMatricula.Checked)
            {
                try
                {
                    //DeletDocument(Matricula);

                    if (matrORcat != "" && matrORcat != null)
                    {
                        //listBoxLista.Visible = true;
                        listBoxLista.Items.Clear();
                        labelList.Text = "";

                        documentDataReturn searchDocumentReturn2 = new documentDataReturn();
                        SEClient SeachDoc2 = Conection.GetConnection();
                        searchDocumentReturn2 = SeachDoc2.viewDocumentData(matrORcat, "", "", "");


                        if (searchDocumentReturn2.IDDOCUMENT != null && searchDocumentReturn2.IDDOCUMENT != "")
                        {
                            listBoxLista.Visible = true;
                            labelList.Text = ("MATRICULA:  " + searchDocumentReturn2.IDDOCUMENT + "\r" +
                                           "NOME:  " + searchDocumentReturn2.NMTITLE + "\r" +
                                           "CATEGORIA:  " + searchDocumentReturn2.IDCATEGORY + " - " + searchDocumentReturn2.NMCATEGORY + "\r" +
                                           "DATA DE CRIAÇÃO:  " + searchDocumentReturn2.DTDOCUMENT + "\r" +
                                           ".. :: Atributos::.. ");

                            foreach (var item in (searchDocumentReturn2.ATTRIBUTTES))
                            {
                                if (item.ATTRIBUTTEVALUE.Count() <= 0)
                                {
                                    item.ATTRIBUTTEVALUE = null;
                                    listBoxLista.Items.Add(item.ATTRIBUTTENAME + " = " + "");
                                }
                                else
                                {
                                    listBoxLista.Items.Add(item.ATTRIBUTTENAME + " = " + item.ATTRIBUTTEVALUE[0]);
                                }

                            }


                        }
                        else
                        {
                            MessageBox.Show("Documento não localizado !", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("Digite a matricula !", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro :" + ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (Categoria.Checked)
            {
                try
                {

                    if (matrORcat != "" && matrORcat != null)
                    {
                        listBoxLista.Visible = true;
                        listBoxLista.Items.Clear();

                        searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
                        searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = matrORcat };
                        SEClient SeachDoc = Conection.GetConnection();
                        searchDocumentReturn = SeachDoc.searchDocument(searchDocumentFilter, null, null);

                        labelList.Text = "Total de Documentos: " + Convert.ToString(searchDocumentReturn.RESULTS.Count());

                        if (searchDocumentReturn.RESULTS.Count() > 0)
                        {
                            foreach (var item in (searchDocumentReturn.RESULTS))
                            {
                                listBoxLista.Items.Add(item.IDDOCUMENT + " - " + item.NMTITLE);
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
        }
        private void RecMatricula_TextChanged(object sender, EventArgs e)
        {            
            tb.SelectAll();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void Form3_Load(object sender, EventArgs e)
        {
        }

        private void Matricula_CheckedChanged(object sender, EventArgs e)
        {
            if (Categoria.Checked == true)
            {
                CheckMatricula.Checked = false;
            }
        }

        private void Categoria_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckMatricula.Checked == true)
            {
                Categoria.Checked = false;
            }
        }

        private void listBoxLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
            foreach (object item in listBoxLista.SelectedItems)
            {
                copy_buffer.AppendLine(item.ToString());
                if (copy_buffer.Length > 0)
                {
                    Clipboard.SetText(copy_buffer.ToString());
                }
            }
        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            listBoxLista.Items.Clear();
            labelList.Text = "";
            RecMatricula.Text = "";


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                int cont = 0;

                var categ = textBox1categ.Text.Replace(" ", "");

                if (categ != "" && categ != null)
                {
                    listBox1PSTsemDOC.Items.Clear();
                    sendText("");

                    searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
                    searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = categ };
                    SEClient SeachDoc = Conection.GetConnection();
                    searchDocumentReturn = SeachDoc.searchDocument(searchDocumentFilter, null, null);

                    if (searchDocumentReturn.RESULTS.Count() > 0)
                    {
                        foreach (var item in (searchDocumentReturn.RESULTS))
                        {
                            documentDataReturn searchDocumentReturn2 = new documentDataReturn();
                            SEClient SeachDoc2 = Conection.GetConnection();
                            searchDocumentReturn2 = SeachDoc2.viewDocumentData(item.IDDOCUMENT, "", "", "");

                            sendText("Pesquisando... " + item.IDDOCUMENT);

                            if (searchDocumentReturn2.ELECTRONICFILE.Count() == 0)
                            {
                                listBox1PSTsemDOC.Items.Add(item.IDDOCUMENT + " - " + item.NMTITLE);
                                cont++;
                            }
                        }
                        sendText("Total de Documentos: " + cont);
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

        public void sendText(string msg)
        {
            label4Pesq.Text = msg;
            label4Pesq.Visible = true;
            label4Pesq.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listBox1PSTsemDOC_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (e.Control && e.KeyCode == Keys.C) { }
            //{
            System.Text.StringBuilder copy_buffer = new System.Text.StringBuilder();
            foreach (object item in listBox1PSTsemDOC.SelectedItems)
                copy_buffer.AppendLine(item.ToString());
            if (copy_buffer.Length > 0)
                Clipboard.SetText(copy_buffer.ToString());
        }

        private void textBox1categ_TextChanged(object sender, EventArgs e)
        {         
            tb.SelectAll();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4Pesq_Click(object sender, EventArgs e)
        {

        }
    }
}

