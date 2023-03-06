using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace Spanzuratoarea
{
    public partial class Form1 : Form
    {
        private string cuvNou;
        private char litera;
        private bool jocTerminat = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Text = "Ai 3 incercari!";
            if (File.Exists("cuvinte.txt"))
            {
                string[] cuvinte = File.ReadAllLines("cuvinte.txt");
                Random r = new Random();
                string cuvant = cuvinte[r.Next(cuvinte.Length)];
                string[] cuvSplit = cuvant.Split(',');
                cuvNou = cuvSplit[0];
                string cuvIndicatii = cuvSplit[1];
                int contor = 0;
                int totalWidth = cuvNou.Length * 50;
                int startX = (listView1.Width - totalWidth) / 2;
                int startY = (listView1.Height - 50) / 2;

                foreach (char lit in cuvNou)
                {
                    litera = lit;
                    TextBox textBox = new TextBox();
                    textBox.Location = new Point(startX + contor * 50, startY);
                    textBox.Size = new Size(30, 25);
                    textBox.TextAlign = HorizontalAlignment.Center;
                    textBox.TextChanged += TextBox_TextChanged1;
                    listView1.Controls.Add(textBox);
                    contor++;
                }
                label5.Text = cuvIndicatii;

            }
            else
                MessageBox.Show("Fisier inexistent");
        }

        private void TextBox_TextChanged1(object? sender, EventArgs e)
        {

            foreach (Control control in listView1.Controls)
            {
                if (control is TextBox textBox)
                {
                    if (!Regex.Match(textBox.Text, "^[A-Z]*$").Success || (textBox.Text.Length > 1))
                    {
                        MessageBox.Show("Va rog completati cu o serie corespunzatoare");
                        textBox.Clear();
                        return;
                    }
                }
            }
        }


        private int greseala = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            int punctaj = 0;
            bool toatecCorecte = true;

            foreach (Control control in listView1.Controls)
            {
                if (control is TextBox textBox)
                {
                    char literaCurenta = cuvNou[control.TabIndex];
                    if (textBox.Text == literaCurenta.ToString())
                    {
                        punctaj += 10;
                        textBox.BackColor = Color.White;
                    }
                    else
                    {
                        greseala++;
                        textBox.BackColor = Color.MistyRose;
                        textBox.Clear();

                        if (greseala == 1)
                        {
                            label6.Text = "Mai ai 2 incercari";
                        }
                        else if (greseala == 2)
                        {
                            label6.Text = "Mai ai o incercare";
                        }
                        else if (greseala == 3)
                        {
                            MessageBox.Show("Ai pierdut!");
                            Application.Restart();
                        }
                        toatecCorecte = false;
                    }
                }
            }
            if (toatecCorecte)
            {
                MessageBox.Show("Ai castigat!");
                Application.Restart();
            }


            textBox1.Text = punctaj.ToString();
        }

    }
}  