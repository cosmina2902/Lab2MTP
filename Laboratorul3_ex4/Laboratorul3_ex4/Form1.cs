using System.Data;

namespace Laboratorul3_ex4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml("autori.xml");
            dataGridView1.DataSource = dataSet.Tables[0];
            dataGridView1.Columns["author"].HeaderText = "Autor";
            dataGridView1.Columns["title"].HeaderText = "Titlu";
            dataGridView1.Columns["price"].HeaderText = "Preț";
        }
    }
}