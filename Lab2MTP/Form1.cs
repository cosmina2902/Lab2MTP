namespace Lab2MTP
{
    using System.IO;
    
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists("C:\\Users\\COSMINA\\OneDrive\\Desktop\\c#\\Lab2MTP\\Lab2MTP\\utilizatori.txt"))
            {
                string[] utilizatori = File.ReadAllLines("C:\\Users\\COSMINA\\OneDrive\\Desktop\\c#\\Lab2MTP\\Lab2MTP\\utilizatori.txt");
                foreach (var line in utilizatori)
                {
                    string[] inregistrare = line.Split(',');
                    comboBox1.Items.Add(inregistrare[0]);
                }
            }
            else
                MessageBox.Show("Fisier inexistent");
        }

        private int incercari = 0;
        private void btnAutentificare_Click(object sender, EventArgs e)
        {
            
            string[] utilizatori = File.ReadAllLines("C:\\Users\\COSMINA\\OneDrive\\Desktop\\c#\\Lab2MTP\\Lab2MTP\\utilizatori.txt");
            foreach (var line in utilizatori)
            {
                string[] inregistrare = line.Split(',');
                if ((comboBox1.Text).Equals(inregistrare[0]))
                {
                    if ((textBox1.Text.Trim()).Equals(inregistrare[1].Trim()))
                    {
                        Form2 f = new Form2();
                        f.ShowDialog();
                    }
                    else
                    {
                        incercari++;
                        MessageBox.Show("Parola incorecta! Mai aveti " + (3 -
                        incercari).ToString() + " incercari.");
                    }
                }
                if (incercari == 3)
                    Application.Exit();
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {                      
              Application.Exit();
        }

        private void btnInregistrare_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();

        }
    }
}
   