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

namespace Import2SE
{
    public partial class Form11Edit : Form
    {
        public Form11Edit()
        {
            InitializeComponent();
        }
        TextBox tb = new TextBox();

        documentDataReturn searchDocumentReturn2 = new documentDataReturn();
        SEClient SeachDoc2 = Conection.GetConnection();

        #region Old
        //private void Pesquisar_Click(object sender, EventArgs e)
        //{
        //    var matrORcat = RecMatricula.Text.Replace(" ", "");

        //    if (CheckMatricula.Checked)
        //    {
        //        try
        //        {
        //            //DeletDocument(Matricula);

        //            if (matrORcat != "" && matrORcat != null)
        //            {
        //                //listBoxLista.Visible = true;
        //                listBoxLista.Items.Clear();
        //                labelList.Text = "";

        //                //documentDataReturn searchDocumentReturn2 = new documentDataReturn();
        //                //SEClient SeachDoc2 = Conection.GetConnection();
        //                searchDocumentReturn2 = SeachDoc2.viewDocumentData(matrORcat, "", "", "");


        //                if (searchDocumentReturn2.IDDOCUMENT != null && searchDocumentReturn2.IDDOCUMENT != "")
        //                {
        //                    listBoxLista.Visible = true;
        //                    labelList.Text = ("MATRICULA:  " + searchDocumentReturn2.IDDOCUMENT + "\r" +
        //                                   "NOME:  " + searchDocumentReturn2.NMTITLE + "\r" +
        //                                   "CATEGORIA:  " + searchDocumentReturn2.IDCATEGORY + " - " + searchDocumentReturn2.NMCATEGORY + "\r" +
        //                                   "DATA DE CRIAÇÃO:  " + searchDocumentReturn2.DTDOCUMENT + "\r" +
        //                                   ".. :: Atributos::.. ");

        //                    foreach (var item in (searchDocumentReturn2.ATTRIBUTTES))
        //                    {
        //                        if (item.ATTRIBUTTEVALUE.Count() <= 0)
        //                        {
        //                            item.ATTRIBUTTEVALUE = null;
        //                            listBoxLista.Items.Add(item.ATTRIBUTTENAME + " = " + "");
        //                        }
        //                        else
        //                        {
        //                            listBoxLista.Items.Add(item.ATTRIBUTTENAME + " = " + item.ATTRIBUTTEVALUE[0]);
        //                        }

        //                    }


        //                }
        //                else
        //                {
        //                    MessageBox.Show("Documento não localizado !", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    return;
        //                }

        //            }
        //            else
        //            {
        //                MessageBox.Show("Digite a matricula !", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Erro :" + ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    else if (Categoria.Checked)
        //    {
        //        try
        //        {
        //            if (matrORcat != "" && matrORcat != null)
        //            {
        //                listBoxLista.Visible = true;
        //                listBoxLista.Items.Clear();


        //                searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
        //                searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = matrORcat };
        //                SEClient SeachDoc = Conection.GetConnection();
        //                searchDocumentReturn = SeachDoc.searchDocument(searchDocumentFilter, null, null);

        //                labelList.Text = "Total de Documentos: " + Convert.ToString(searchDocumentReturn.RESULTS.Count());

        //                if (searchDocumentReturn.RESULTS.Count() > 0)
        //                {
        //                    foreach (var item in (searchDocumentReturn.RESULTS))
        //                    {
        //                        listBoxLista.Items.Add(item.IDDOCUMENT + " - " + item.NMTITLE);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("Digite a categoria !", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                return;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Erro: " + ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }

        //    }
        //}
        #endregion

        private void listBoxLista_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Limpar_Click(object sender, EventArgs e)
        {
            //listBoxLista.Items.Clear();
            //labelList.Text = "";
            //RecMatricula.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var RecMatricula = textBox1Titulo.Text.Replace(" ", "");
            var TituloEditar = textBox2TituloEditar.Text;

            if (checkBox2Titulo.Checked)
            {
                try
                {
                    if (RecMatricula != "" && RecMatricula != null && TituloEditar != "" && TituloEditar != null)
                    {
                        searchDocumentReturn2 = SeachDoc2.viewDocumentData(RecMatricula, "", "", "");

                        if (searchDocumentReturn2.IDDOCUMENT != "" && searchDocumentReturn2.IDDOCUMENT != null)
                        {
                            var Idcategory = searchDocumentReturn2.IDCATEGORY;
                            var returnEdit = SeachDoc2.editDocument(Idcategory, RecMatricula, "", "", TituloEditar, "");
                        }
                        else
                        {
                            MessageBox.Show("Identificador não localizado \r ou \r Digitado errado!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Digite os dados para Alteração!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show("Alterado com sucesso!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (checkBox1Atributos.Checked)
            {
                try
                {

                    if (RecMatricula != "" && RecMatricula != null && textBox1ValorAtrib.Text != "" && textBox1ValorAtrib.Text != null)
                    {
                        var RecebAtrib = comboBox1RecebAtrib.Text;
                        var ValorAtrib = textBox1ValorAtrib.Text;

                        var returnEditAtr = SeachDoc2.setAttributeValue(RecMatricula, "", RecebAtrib, ValorAtrib);

                    }
                    else
                    {
                        MessageBox.Show("Digite os dados para Alteração!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    MessageBox.Show("Alterado com sucesso!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void textBox1Titulo_TextChanged(object sender, EventArgs e)
        {
            tb.SelectAll();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2Titulo.Checked == true)
            {
                checkBox1Atributos.Checked = false;
                textBox2TituloEditar.Visible = true;
                comboBox1RecebAtrib.Items.Clear();
                comboBox1RecebAtrib.Visible = false;
                textBox1ValorAtrib.Visible = false;
                label5valor.Visible = false;
            }
        }

        private void checkBox1Atributos_CheckedChanged(object sender, EventArgs e)
        {
            var RecMatricula = textBox1Titulo.Text.Replace(" ", "");


            textBox2TituloEditar.Clear();
            textBox2TituloEditar.Visible = false;
            comboBox1RecebAtrib.Visible = true;
            textBox1ValorAtrib.Visible = true;
            label5valor.Visible = true;

            if (checkBox1Atributos.Checked == true)
            {
                checkBox2Titulo.Checked = false;

                searchDocumentReturn2 = SeachDoc2.viewDocumentData(RecMatricula, "", "", "");

                if (searchDocumentReturn2.IDDOCUMENT != null && searchDocumentReturn2.IDDOCUMENT != "")
                {
                    foreach (var item in (searchDocumentReturn2.ATTRIBUTTES))
                    {
                        comboBox1RecebAtrib.Items.Add(item.ATTRIBUTTENAME);
                    }
                }
                else
                {
                    MessageBox.Show("Identificador não localizado \r ou \r Digitado errado!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
            else if (checkBox1Atributos.Checked == false)
            {
                comboBox1RecebAtrib.Items.Clear();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2TituloEditar_TextChanged(object sender, EventArgs e)
        {
            tb.SelectAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            tb.SelectAll();
        }

        private void comboBox1RecebAtrib_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1TituloPastaAluno_CheckedChanged(object sender, EventArgs e)
        {

            try
            {

                var CategPastaAluno = textBox1CategPastaAluno.Text.Replace(" ", "");

                if (CategPastaAluno != "" && CategPastaAluno != null)
                {

                    if (checkBox1TituloPastaAluno.Checked == true)
                    {
                        checkBox2AtribPastaAluno.Checked = false;
                        checkBox2Titulo.Checked = false;

                        string msg = "Formar o titulo com o valores dos atributos";
                        sendText(msg);
                        comboBox1PastaAlunos.Visible = false;
                        label7Traço.Visible = false;

                        comboBox1PastaAluno.Items.Clear();
                        comboBox2PastaAluno.Items.Clear();
                        comboBox3PastaAluno.Items.Clear();
                        comboBox1PastaAlunos.Items.Clear();

                        searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
                        searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = CategPastaAluno };
                        searchDocumentReturn = SeachDoc2.searchDocument(searchDocumentFilter, null, null);

                        string id = searchDocumentReturn.RESULTS[0].IDDOCUMENT;

                        searchDocumentReturn2 = SeachDoc2.viewDocumentData(id, "", "", "");

                        if (searchDocumentReturn2.IDDOCUMENT != null && searchDocumentReturn2.IDDOCUMENT != "")
                        {
                            foreach (var item in (searchDocumentReturn2.ATTRIBUTTES))
                            {
                                comboBox1PastaAluno.Items.Add(item.ATTRIBUTTENAME);
                                comboBox2PastaAluno.Items.Add(item.ATTRIBUTTENAME);
                                comboBox3PastaAluno.Items.Add(item.ATTRIBUTTENAME);
                                comboBox1PastaAlunos.Items.Add(item.ATTRIBUTTENAME);

                            }
                        }
                        else
                        {
                            MessageBox.Show("Identificador não localizado \r ou \r Digitado errado!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                    }
                    else if (checkBox1Atributos.Checked == false)
                    {
                        //comboBox1RecebAtrib.Items.Clear();
                    }
                }
                else
                {
                    MessageBox.Show("Categoria não digitada!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    checkBox1TituloPastaAluno.Checked = false;
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
            label7TextAtributos.Text = msg;
            label7TextAtributos.Visible = true;
            label7TextAtributos.Refresh();
        }


        private void button2EditPastaAluno_Click(object sender, EventArgs e)
        {
            try
            {
                var CategPastaAluno = textBox1CategPastaAluno.Text;
                var txtBox1 = comboBox1PastaAluno.Text;
                var txtBox2 = comboBox2PastaAluno.Text;
                var txtBox3 = comboBox3PastaAluno.Text;
                var txtBox4 = comboBox1PastaAlunos.Text;
                var NewValor = "";
                string VltxtBox1 = "";
                var VltxtBox2 = "";
                var VltxtBox3 = "";

                if (checkBox1TituloPastaAluno.Checked)
                {

                    searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
                    searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = CategPastaAluno };
                    searchDocumentReturn = SeachDoc2.searchDocument(searchDocumentFilter, null, null);

                    if (searchDocumentReturn.RESULTS.Count() > 0)
                    {
                        foreach (var item in searchDocumentReturn.RESULTS)
                        {
                            searchDocumentReturn2 = SeachDoc2.viewDocumentData(item.IDDOCUMENT, "", "", "");

                            foreach (var item2 in searchDocumentReturn2.ATTRIBUTTES.Where(p => p.ATTRIBUTTENAME == txtBox1 || p.ATTRIBUTTENAME == txtBox2 || p.ATTRIBUTTENAME == txtBox3))
                            {
                                if (item2.ATTRIBUTTENAME == txtBox1)
                                {
                                    VltxtBox1 = item2.ATTRIBUTTEVALUE[0];
                                }
                                else if (item2.ATTRIBUTTENAME == txtBox2)
                                {
                                    VltxtBox2 = item2.ATTRIBUTTEVALUE[0];
                                }
                                else if (item2.ATTRIBUTTENAME == txtBox3)
                                {
                                    VltxtBox3 = item2.ATTRIBUTTEVALUE[0];
                                }
                            }

                            NewValor = (VltxtBox1 + "-" + VltxtBox2 + "-" + VltxtBox3 + "-"+ textBoxTITULO.Text).Replace("--", "");

                            var returnEdit = SeachDoc2.editDocument(CategPastaAluno, item.IDDOCUMENT, "", "", NewValor, "");

                        }
                    }
                    MessageBox.Show("Edição Finalizada!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (checkBox2AtribPastaAluno.Checked)
                {
                    searchDocumentReturn searchDocumentReturn = new searchDocumentReturn();
                    searchDocumentFilter searchDocumentFilter = new searchDocumentFilter { IDCATEGORY = CategPastaAluno };
                    searchDocumentReturn = SeachDoc2.searchDocument(searchDocumentFilter, null, null);

                    if (searchDocumentReturn.RESULTS.Count() > 0)
                    {
                        foreach (var item in searchDocumentReturn.RESULTS)
                        {
                            searchDocumentReturn2 = SeachDoc2.viewDocumentData(item.IDDOCUMENT, "", "", "");

                            foreach (var item2 in searchDocumentReturn2.ATTRIBUTTES.Where(p => p.ATTRIBUTTENAME == txtBox1 || p.ATTRIBUTTENAME == txtBox2 || p.ATTRIBUTTENAME == txtBox3))
                            {
                                if (item2.ATTRIBUTTENAME == txtBox1)
                                {
                                    VltxtBox1 = item2.ATTRIBUTTEVALUE[0];
                                }
                                else if (item2.ATTRIBUTTENAME == txtBox2)
                                {
                                    VltxtBox2 = item2.ATTRIBUTTEVALUE[0];
                                }
                                else if (item2.ATTRIBUTTENAME == txtBox3)
                                {
                                    VltxtBox3 = item2.ATTRIBUTTEVALUE[0];
                                }
                            }

                            NewValor = (VltxtBox1 + "-" + VltxtBox2 + "-" + VltxtBox3).Replace("--", "");

                            var returnEdit = SeachDoc2.setAttributeValue(item.IDDOCUMENT, "", txtBox4, NewValor);

                        }
                    }
                    MessageBox.Show("Edição Finalizada!", ".:: Alerta ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void checkBox2AtribPastaAluno_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1CategPastaAluno.Text != "" && textBox1CategPastaAluno.Text != null)
            {
                checkBox1TituloPastaAluno.Checked = false;
                label7TextAtributos.Visible = false;
                comboBox1PastaAlunos.Visible = true;
                label7Traço.Visible = true;

                string msg = "Incluir valor no atributo com valores de outros atributos";
                sendText(msg);
                //comboBox1PastaAluno.Items.Clear(); 
                //comboBox2PastaAluno.Items.Clear(); 
                //comboBox3PastaAluno.Items.Clear(); 

            }
            else
            {
                MessageBox.Show("Categoria não digitada!", ".:: Atenção ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                checkBox2AtribPastaAluno.Checked = false;
                return;
            }
        }

        private void Limpar_Click_1(object sender, EventArgs e)
        {

        }

        private void Pesquisar_Click_1(object sender, EventArgs e)
        {

        }

        private void CheckMatricula_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
