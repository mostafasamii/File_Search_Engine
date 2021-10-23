using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Windows.Forms;
using System.Xml;


namespace WindowsFormsApp3
{
    public partial class Save_file : Form
    {
        public static string fn = "";

        public Save_file()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = @textBox2.Text + "\\" + textBox1.Text + ".txt";
            FileInfo fi = new FileInfo(fileName);

            if (textBox1.Text.Count() == 0 || textBox2.Text.Count() == 0 || checkedListBox1.CheckedItems.Count == 0)
            {

                if (checkedListBox1.CheckedItems.Count == 0)
                {
                    MessageBox.Show("Please choose a category.");
                }
                else
                {
                    MessageBox.Show("Please enter all information.");
                }
            }
            // Check if file already exists. If yes, delete it. 
            else if (fi.Exists)
            {
                MessageBox.Show("This file already exists!");
            }

            // Create a new file 
            else
            {
                using (StreamWriter sw = fi.CreateText())
                {
                    sw.WriteLine(Add_file.filecontent);

                }
                fn = textBox1.Text;
                string name = textBox1.Text;
                string path = textBox2.Text;
                List<string> categories = new List<string>();

                foreach (string item in checkedListBox1.CheckedItems)
                {
                    categories.Add(item);
                }
                if (!File.Exists("Files.xml"))
                {
                    XmlWriter writer = XmlWriter.Create("Files.xml");

                    writer.WriteStartDocument();

                    writer.WriteStartElement("Files");

                    writer.WriteStartElement("File");

                    writer.WriteStartElement("Name");
                    writer.WriteString(name);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Path");
                    writer.WriteString(path);
                    writer.WriteEndElement();

                    writer.WriteStartElement("Categories");
                    for (int i = 0; i < categories.Count; i++)
                    {
                        writer.WriteStartElement("Category");
                        writer.WriteString(categories[i]);
                        writer.WriteEndElement();
                    }
                    writer.WriteEndElement();

                    writer.WriteEndElement();

                    writer.WriteEndElement();

                    writer.WriteEndDocument();
                    writer.Close();
                }
                else
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load("Files.xml");

                    XmlElement files = doc.CreateElement("File");
                    XmlElement node = doc.CreateElement("Name");
                    node.InnerText = name;
                    files.AppendChild(node);

                    node = doc.CreateElement("Path");
                    node.InnerText = path;
                    files.AppendChild(node);

                    node = doc.CreateElement("Categories");
                    for (int i = 0; i < categories.Count; i++)
                    {
                        XmlElement node2 = doc.CreateElement("Category");
                        node2.InnerText = categories[i];
                        node.AppendChild(node2);
                    }
                    files.AppendChild(node);

                    XmlElement root = doc.DocumentElement;

                    root.AppendChild(files);

                    doc.Save("Files.xml");
                    MessageBox.Show("Added", "Add File", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }


            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            Add_file f = new Add_file();
            f.Show();
            this.Hide();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            textBox2.Text = folderBrowserDialog1.SelectedPath;
        }

        private void Save_file_Load(object sender, EventArgs e)
        {
            string[] fields = Add_file.filecontent.Split(' ','\n');
            List<string> load = new List<string>();
            List<Tuple<string, string>> revd = new List<Tuple<string, string>>();
            XmlDocument doc = new XmlDocument();
            doc.Load("fileCategories.xml");
            XmlNodeList cat = doc.GetElementsByTagName("Category");
            for (int i = 0; i < cat.Count; i++)
            {
                XmlNodeList children = cat[i].ChildNodes;
                string name = children[0].InnerText;
                XmlNodeList smallchildren = children[1].ChildNodes;
                for (int j = 0; j < smallchildren.Count; j++)
                {
                    string keywords = smallchildren[j].InnerText;
                    revd.Add(new Tuple<string, string>(keywords, name));
                }
            }
            for (int i = 0; i < fields.Count(); i++)
            {
                for (int j = 0; j < revd.Count; j++)
                {
                    if (revd[j].Item1 == fields[i] && !(load.Contains(revd[j].Item2)))
                    {
                        load.Add(revd[j].Item2);
                    }
                }
            }
            for (int i = 0; i < load.Count; i++)
            {
                checkedListBox1.Items.Add(load[i], CheckState.Unchecked);
            }
        }
        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Categories C = new Categories();
            textBox3.CharacterCasing = CharacterCasing.Lower;
            string[] fields = Add_file.filecontent.Split(' ','\n');
            int cnt = 0;
            List<string> tmp = new List<string>();
            C.name = textBox3.Text;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                C.keywords.Add(dataGridView1.Rows[i].Cells[0].Value.ToString().ToLower());
            }
            for (int i = 0; i < C.keywords.Count; i++)
            {
                if (fields.Contains(C.keywords[i]))
                {
                    cnt++;
                }
            }

            if (cnt == 0)
            {
                MessageBox.Show("None of the keywords exist in the file. Please enter the keywords again.");
                dataGridView1.Rows.Clear();
            }
            else
            {
                XmlDocument doc = new XmlDocument();
                List<Categories> cat = new List<Categories>();
                List<string> neww = new List<string>();
                bool b = false;
                bool a = false;
                bool c = false;
                /************************************************************************************/
                //get name category and keywords 
                textBox1.CharacterCasing = CharacterCasing.Lower;
                /****************************************************************************************/
                //read the xml file & check if we have the same category or not & if we have some or the same keywords we store it 
                if (textBox3.Text.Length == 0 || C.keywords.Count == 0)
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
                                }
                                else
                                {
                                    DialogResult res1 = MessageBox.Show("This Category already exist. Do you want to add the new keywords to the existing category? ",
                                           "Add Category", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                                    if (res1 == DialogResult.Yes)
                                    {
                                        for (int m = 0; m < neww.Count; m++)
                                        {
                                            XmlElement node2 = doc.CreateElement("Keyword");
                                            node2.InnerText = neww[m];
                                            list[i].ChildNodes[1].AppendChild(node2);
                                        }
                                        if (!checkedListBox1.Items.Contains(textBox3.Text))
                                        {
                                            checkedListBox1.Items.Add(textBox3.Text, CheckState.Unchecked);
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
                    
                            checkedListBox1.Items.Add(textBox3.Text, CheckState.Unchecked);
                        }
                        if (c == false)
                        {
                            DialogResult res2 = MessageBox.Show("Added", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        textBox3.Text = null;
                        dataGridView1.Rows.Clear();
                        doc.Save("fileCategories.xml");
                        panel1.Visible = false;
                    }
                }
            }
        }
    }
}