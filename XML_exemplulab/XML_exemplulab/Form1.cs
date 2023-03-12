
using System.Xml;

namespace XML_exemplulab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            XmlDeclaration xmlDeclaration = xml.CreateXmlDeclaration("1.0", "utf-8", "");
            xml.AppendChild(xmlDeclaration);
            XmlNode root = xml.CreateNode(XmlNodeType.Element, "students", "");
            xml.AppendChild(root);
            foreach(string student in listBox1.Items)
            {
                XmlNode xmlNode = xml.CreateNode(XmlNodeType.Element, "student", "");
                xmlNode.InnerText=student;
                root.AppendChild(xmlNode);
            }
            xml.Save("studenti.xml");
            MessageBox.Show("Xml salvat cu succes");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string[] students = new string[] { "Ana,3,21,Informatica", "Ioana,1,20,Fizica", "Paul,2,22,Istorie", "Andrei,4,23,Calculatoare" };
            XmlDocument xml = new XmlDocument();
            XmlNode root = xml.CreateNode(XmlNodeType.Element, "students", "");
            xml.AppendChild(root);
            foreach( string student in students)
            {
                string[] stInfo = student.Split(',');
                XmlNode studentNode = xml.CreateNode(XmlNodeType.Element, "student", "");
                XmlAttribute y = xml.CreateAttribute("an");
                y.Value=stInfo[1].Trim();
                XmlAttribute age = xml.CreateAttribute("varsta");
                age.Value=stInfo[2].Trim();
                studentNode.Attributes.Append(y);
                studentNode.Attributes.Append(age);

                XmlNode studentName = xml.CreateNode(XmlNodeType.Element, "nume", "");
                studentName.InnerText = stInfo[0].Trim();
                XmlNode studentSpec = xml.CreateNode(XmlNodeType.Element, "specialitatea", "");
                studentSpec.InnerText = stInfo[3].Trim();
                studentNode.AppendChild(studentName);
                studentNode.AppendChild(studentSpec);

                root.AppendChild(studentNode);
            }
            xml.Save("studenti2.xml");
            MessageBox.Show("Scris cu succes");
        }
    }
}