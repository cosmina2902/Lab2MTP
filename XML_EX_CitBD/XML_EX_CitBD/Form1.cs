using System.Xml.Serialization;
using System.IO;

namespace XML_EX_CitBD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Date> D1 = new List<Date>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Date>));
            D1.Add(new Date() { ID = 1, Name = "Chirila", Prenume = "Oana" });
            using(FileStream fs= new FileStream(Environment.CurrentDirectory+"\\BD.xml",FileMode.Create,FileAccess.Write))
            {
                serializer.Serialize(fs, D1);
                MessageBox.Show("Bd creata");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Date> D1 = new List<Date>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<Date>));
            using(FileStream fs = new FileStream(Environment.CurrentDirectory+"\\BD.xml",FileMode.Open,FileAccess.Read))
            {
                D1 = serializer.Deserialize(fs) as List<Date>;
            }
            dataGridView1.DataSource = D1;
        }
    }
}