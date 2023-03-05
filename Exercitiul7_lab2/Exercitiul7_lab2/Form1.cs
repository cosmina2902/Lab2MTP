using System.Windows.Forms;

namespace Exercitiul7_lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            IncarcareClase();
            dateTimePicker1.CalendarTitleBackColor = Color.SkyBlue;


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

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
        }
        private void IncarcareJucatori(string clasa)
        {
            flowLayoutPanel1.Controls.Clear();
            string path = Application.StartupPath + "\\" + clasa;
            foreach (string fileName in Directory.EnumerateFiles(path, "*.txt"))
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string cnp = Path.GetFileNameWithoutExtension(fileName);
                    string nume = sr.ReadLine();
                    string post = sr.ReadLine();
                    Persoana j = new Persoana(cnp, nume, post);
                    Button btn = new Button();
                    btn.Text = j.Nume;
                    btn.Width = 320;
                    btn.Height = 42;
                    btn.TextAlign = ContentAlignment.MiddleCenter;
                    btn.BackColor = Color.SkyBlue;
                    btn.Tag = j;
                    flowLayoutPanel1.Controls.Add(btn);
                    btn.Click += Btn_Click;

                }
            }
        }

        private void Btn_Click(object? sender, EventArgs e)
        {


            groupBox1.Controls.Clear();
            Button btn = (Button)sender;
            Persoana j = (Persoana)btn.Tag;
            textBox1.Text = j.Nume;
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label2);
            textBox2.Text = j.Post;
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(label3);
            textBox3.Text = j.Cnp;
            groupBox1.Controls.Add(textBox3);
            groupBox1.Controls.Add(label4);
            string  data = "";
            switch(j.Cnp[0])
            {
                case '1':
                    data += "19";
                    break;
                case '2':
                    data += "19";
                    break;
                case '5':
                    data += "20";
                    break;
                case '6':
                    data += "20";
                    break;
            }
            data += j.Cnp[1];
            data += j.Cnp[2];
            data += "-" + j.Cnp[3]; data += j.Cnp[4];
            data += "-" + j.Cnp[5] + j.Cnp[6];
            dateTimePicker1.Value=DateTime.Parse(data);
            groupBox1.Controls.Add(dateTimePicker1);
            groupBox1.Controls.Add(label5);
            var nastere = DateTime.Now - dateTimePicker1.Value;
            int zi = (int)(nastere.TotalDays / 365.25);
            textBox4.Text = zi.ToString();
            groupBox1.Controls.Add(textBox4);
            groupBox1.Controls.Add(label6);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IncarcareJucatori(comboBox1.Text);
            
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            flowLayoutPanel1.VerticalScroll.Value = vScrollBar1.Value;

        }

        private void flowLayoutPanel1_Resize(object sender, PaintEventArgs e)
        {
            vScrollBar1.Minimum = 0;
            vScrollBar1.Maximum = flowLayoutPanel1.VerticalScroll.Maximum;
            vScrollBar1.SmallChange = 7;
            vScrollBar1.LargeChange = vScrollBar1.SmallChange * 12;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
 }
