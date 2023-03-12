using System.Xml;

namespace Laborator3_XML
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int> buttonClicks = new Dictionary<string, int>();
        public Form1()

        {
            
            InitializeComponent();
            foreach (Button buton in flowLayoutPanel1.Controls.OfType<Button>())
            {
                buttonClicks[buton.Name] = 0;
            }
        }
        private int contor = 0;
        private void Click_button(object sender, EventArgs e)
        {

            if (buttonClicks.ContainsKey(((Button)sender).Name))
            {
                buttonClicks[((Button)sender).Name]++;
            }
            else
            {
                buttonClicks[((Button)sender).Name] = 1;
            }
        }
     //   Apoi, în evenimentul button11_Click, trebuie să accesați valoarea tag-ului(etichetei) fiecărui buton și să
        

        private void button11_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "utf-8", "");
            xml.AppendChild(xmlDeclaration);

            XmlNode root = xml.CreateNode(XmlNodeType.Element, "Buttons", "");
            xml.AppendChild(root);

            foreach (Button buton in flowLayoutPanel1.Controls.OfType<Button>())
            {
                XmlNode xmlNode = xml.CreateElement("button");
                XmlAttribute nameAttribute = xml.CreateAttribute("name");
                nameAttribute.Value = buton.Name;
                xmlNode.Attributes.Append(nameAttribute);

                XmlNode culoareNode = xml.CreateElement("culoare");
                culoareNode.InnerText = buton.BackColor.ToString();
                xmlNode.AppendChild(culoareNode);


                XmlNode clickNode = xml.CreateElement("clicks");
                clickNode.InnerText = buttonClicks.ContainsKey(buton.Name) ? buttonClicks[buton.Name].ToString() : "0";
                xmlNode.AppendChild(clickNode);

                root.AppendChild(xmlNode);
            }

            xml.Save("fisier.xml");
            MessageBox.Show("Fisier scris!");

        }
    }
}