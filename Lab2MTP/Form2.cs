using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Lab2MTP
{

    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            IncarcareClase();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void IncarcareClase()
        {
            flowLayoutPanel1.Controls.Clear();
            comboBox1.Items.Clear();
            foreach (string dirPath in Directory.EnumerateDirectories(Application.StartupPath))
            {
                // adauga numele directorului, fara cale
                DirectoryInfo dirName = new DirectoryInfo(dirPath);
                comboBox1.Items.Add(dirName.Name);
            }
        }
        private void IncarcaEleviClasa(string clasa)
        {
            flowLayoutPanel1.Controls.Clear();
            string path = Application.StartupPath + "\\" + clasa;
            foreach (string fileName in Directory.EnumerateFiles(path, "*.cls"))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string cnp = Path.GetFileNameWithoutExtension(fileName);
                    string nume = sr.ReadLine();
                    string adresa = sr.ReadLine();
                    Persoana j = new Persoana(cnp, nume, adresa);
                    Button btn = new Button();
                    btn.Text = j.Nume;
                    btn.Width = 200;
                    btn.Height = 42;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.BackColor = Color.LightGray;
                    btn.Tag = j;
                    flowLayoutPanel1.Controls.Add(btn);
                    btn.Click += Btn_Click;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IncarcaEleviClasa(comboBox1.Text);
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Button btn = (Button)sender;
            Persoana j = (Persoana)btn.Tag;
            listBox1.Items.Add("Numele: " + j.Nume);
            listBox1.Items.Add("CNP: " + j.Cnp);
            listBox1.Items.Add("Adresa: " + j.Adresa);
        }
    }
}
