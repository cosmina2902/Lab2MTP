using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2MTP
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value += 10;
            progressBar1.Value -= 1;
            progressBar1.Value += 1;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                MessageBox.Show("Inregistrare reusita!");
                Application.Restart();
            }

        }

        private void btnSalveaza_Click(object sender, EventArgs e)
        {
            timer1.Start();
            using (StreamWriter w = File.AppendText("C:\\Users\\COSMINA\\OneDrive\\Desktop\\c#\\Lab2MTP\\Lab2MTP\\utilizatori.txt"))
            {
                w.WriteLine(textBox1.Text + "," + textBox2.Text);
            }
        }
    }
}
