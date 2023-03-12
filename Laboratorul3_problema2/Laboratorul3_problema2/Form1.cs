using System.Xml;

namespace Laboratorul3_problema2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load("fisier.xml");

            // get the list of buttons from the XML file
            XmlNodeList buttons = doc.SelectNodes("//button");

            // create a button for each element in the list
            foreach (XmlNode button in buttons)
            {
                // get the button properties from the XML
                string name = button.Attributes["name"].Value;
                string color = button.SelectSingleNode("culoare").InnerText.Replace("Color [", "").Replace("]", "");

                int clicks = int.Parse(button.SelectSingleNode("clicks").InnerText);

                // create the button with the properties
                Button newButton = new Button();
                newButton.Text = $" {name}\nClicks: {clicks}";
                newButton.BackColor = System.Drawing.Color.FromName(color);
                newButton.Click += new EventHandler(Button_Click);
                newButton.Width = 200;
                newButton.Height = 70;
                newButton.BackColor = Color.FromName(color);

                // add the button to the flow layout panel
                flowLayoutPanel1.Controls.Add(newButton);
            }
        }

        private void Button_Click(object? sender, EventArgs e)
        {
            // update the click count on the button
            Button clickedButton = (Button)sender;
            string[] buttonText = clickedButton.Text.Split('\n');

            int currentClicks = int.Parse(buttonText[1].Substring(8));
            clickedButton.Text = $"{buttonText[0]}\nClicks: {currentClicks }";
        }
    }
}