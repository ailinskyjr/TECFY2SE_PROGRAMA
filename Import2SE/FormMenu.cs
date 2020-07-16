using Import2SE;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static Import2SE.Form5;
using System.Xml;
using System.Xml.Linq;
using Import2SE.Dados;
using static Import2SE.Form1;
using XML_BD;
using System.Data;

namespace Import2SE
{
    public partial class FormMenu : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        String caminho = AppDomain.CurrentDomain.BaseDirectory;


        public FormMenu()
        {
            InitializeComponent();
            GetValSessaoMenu();

        }

        public void AbrirFormNoPanel<Forms>() where Forms : Form, new()
        {
            Form formulario;
            formulario = panelConteudo.Controls.OfType<Forms>().FirstOrDefault();

            if (formulario == null)
            {
                formulario = new Forms();
                formulario.TopLevel = false;
                //formulario.FormBorderStyle = FormBorderStyle.None;
                //formulario.Dock = DockStyle.Fill;
                panelConteudo.Controls.Add(formulario);
                panelConteudo.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
            else
            {
                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
                formulario.BringToFront();
            }
        }

        //private void btnRestaurar_Click(object sender, EventArgs e)
        //{
        //    this.WindowState = FormWindowState.Normal;
        //    btnRestaurar.Visible = false;
        //    btnMaximizar.Visible = true;
        //}

        //private void btnMaximizar_Click(object sender, EventArgs e)
        //{//
        //    this.WindowState = FormWindowState.Maximized;
        //    btnRestaurar.Visible = true;
        //}

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form4>();
        }

        private void btnVendas_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form3>();
        }
        private void btnCompras_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form2>();
        }

        private void panelCabecalho_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panelCabecalho_Paint(object sender, PaintEventArgs e)
        {

        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void excluirPorCategoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form2>();
        }

        private void pesquisarMatriculaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form3>();
        }

        private void criarPastaFuncionarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form4>();
        }

        private void associarPastaXDocumentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form7>();
        }

        private void integraçãoSEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form5>();
        }

        private void configuraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form6>();
        }

        private void panelConteudo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnContas_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form7>();
        }

        private void label2ClientMenu_Click(object sender, EventArgs e)
        {
            //Form5 form5 = new Form5();

            //label2ClientMenu.Text = "Ambiente:" +;
            this.Refresh();
        }

        private void panelMenu_Paint(object sender, PaintEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void integraçãoTESTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form8>();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            //btnRestaurar.Visible = true;

        }

        private void sessãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form10ConfIntegra>();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
        }


        private void FormMenu_Load(object sender, EventArgs e)
        {
            GetValSessaoMenu();            
        }


        public void GetValSessaoMenu()
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
                    label2M.Text = p.Cliente;                                      
                }
                sendText(label2M.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ".:: ALERTA ::.", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            sendText(label2M.Text);
        }

        public void sendText(string msg)
        {
            label2M.Text = msg;
            label2M.Refresh();
            panelCabecalho.Refresh();
            //FormMenu FormMenu = new FormMenu ();
            //FormMenu.Refresh();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form11Edit>();
        }

        private void button1Congig_Click(object sender, EventArgs e)
        {
            AbrirFormNoPanel<Form8>();
        }

        //public  FormMenu(string valor)
        //{
        //    label2M.Text = valor;
        //    label2M.Refresh();
        //}

    }
}
