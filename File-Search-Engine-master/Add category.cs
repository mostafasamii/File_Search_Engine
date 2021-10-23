using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp3
{
    public partial class Add_category : Form
    {
        //List<Categories> cat;
        public Add_category()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Home hp = new Home();
            hp.Show();
            this.Hide();

        }

        private void Add_category_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            Categories C = new Categories();
            List<Categories> cat = new List<Categories>();
            List<string> neww = new List<string>();
            bool b = false;
            bool a = false;
            bool c = false;
            /************************************************************************************/
            //get name category and keywords 
            textBox1.CharacterCasing = CharacterCasing.Lower;
            C.name = textBox1.Text;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                C.keywords.Add(dataGridView1.Rows[i].Cells[0].Value.ToString().ToLower());
            }
            /****************************************************************************************/
            //read the xml file & check if we have the same category or not & if we have some or the same keywords we store it 
            if (textBox1.Text.Length == 0 || C.keywords.Count == 0)
            {
                MessageBox.Show("Please enter all information.");
            }
            else
            {
                if (!File.Exists("fileCategories.xml"))
                {
                    XmlWriter writer = XmlWriter.Create("fileCategories.xml");
                    writer.WriteStartDocument();//
                    writer.WriteStartElement("Categories");
                    writer.WriteStartElement("Category");//
                    writer.WriteStartElement("Name");//
                    writer.WriteString(C.name);
                    writer.WriteEndElement();
                    writer.WriteStartElement("Keywords");
                    for (int i = 0; i < C.keywords.Count; i++)
                    {
                        writer.WriteStartElement("Keyword");
                        writer.WriteString(C.keywords[i]);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();
                    writer.WriteEndElement();//
                    writer.WriteEndElement();
                    writer.WriteEndDocument();//
                    writer.Close();
                }
                else
                {
                    doc.Load("fileCategories.xml");
                    XmlNodeList list = doc.GetElementsByTagName("Category");
                    for (int i = 0; i < list.Count; i++)
                    {
                        XmlNodeList category = list[i].ChildNodes;
                        XmlNodeList key = category[1].ChildNodes;
                        if (category[0].InnerText == C.name)
                        {
                            a = true;
                            for (int j = 0; j < C.keywords.Count; j++)
                            {
                                for (int k = 0; k < key.Count; k++)
                                {
                                    if (C.keywords[j] == key[k].InnerText)
                                    {
                                        b = true;
                                    }
                                }
                                if (b == false)
                                {
                                    neww.Add(C.keywords[j]);
                                }
                                b = false;
                            }
                            if (neww.Count == 0)
                            {
                                MessageBox.Show("This category already exists with the same keywords");
                                c = true;
                            }
                            else
                            {
                                
                                DialogResult res1 = MessageBox.Show("This Category already exists. Do you want to add the new keywords to the existing category? ",
                                       "Add Category", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                                if (res1 == DialogResult.Yes)
                                {
                                    for (int m = 0; m < neww.Count; m++)
                                    {
                                        XmlElement node2 = doc.CreateElement("Keyword");
                                        node2.InnerText = neww[m];
                                        list[i].ChildNodes[1].AppendChild(node2);
                                    }
                                }
                                else
                                {
                                    c = true;
                                }
                            }

                        }
                    }
                    if (a == false)
                    {
                        XmlElement categoryy = doc.CreateElement("Category");
                        XmlElement name = doc.CreateElement("Name");
                        name.InnerText = C.name;
                        categoryy.AppendChild(name);
                        name = doc.CreateElement("Keywords");
                        for (int i = 0; i < C.keywords.Count; i++)
                        {
                            XmlElement node2 = doc.CreateElement("Keywords");
                            node2.InnerText = C.keywords[i];
                            name.AppendChild(node2);
                        }
                        categoryy.AppendChild(name);
                        XmlElement root = doc.DocumentElement;
                        root.AppendChild(categoryy);
                    }
                    if (c == false)
                    {
                        DialogResult res2 = MessageBox.Show("Added", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    doc.Save("fileCategories.xml");
                    Home h = new Home();
                    h.Show();
                    this.Hide();
                }
            }
        }
    }

}
