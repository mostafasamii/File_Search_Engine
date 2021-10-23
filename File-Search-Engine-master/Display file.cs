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
    public partial class Display_file : Form
    {
        public Display_file()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("Categories", "Categories");
            XmlDocument doc = new XmlDocument();
            doc.Load("Files.xml");
            XmlNodeList list = doc.GetElementsByTagName("Name");
            for (int i = 0; i < list.Count; i++)
            {
                comboBox1.Items.Add(list[i].InnerText);
            }
            label2.Hide();
            label3.Hide();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            if (radioButton1.Checked)
            {
                label2.Show();
                label3.Show();
                XmlDocument doc = new XmlDocument();
                doc.Load("Files.xml");
                XmlNodeList list = doc.GetElementsByTagName("File");
                string name = comboBox1.Text;
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList l = list[i].ChildNodes;
                    if (l[0].InnerText == name)
                    {
                        label3.Text = l[1].InnerText;
                        XmlNodeList cat = l[2].ChildNodes;
                        
                        
                        for (int j = 0; j < cat.Count; j++)
                        {
                            dataGridView1.Rows.Add(cat[j].InnerText);
                        }
                        
                        break;
                    }
                }
                

            }
            if (radioButton2.Checked)
            {
                label2.Hide();
                label3.Hide();
                XmlDocument doc = new XmlDocument();
                doc.Load("Files.xml");
                XmlNodeList list = doc.GetElementsByTagName("File");
                string name = comboBox1.Text;
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList l = list[i].ChildNodes;
                    if (l[0].InnerText == name)
                    {
                        XmlNodeList cat = l[2].ChildNodes;
                       

                        for (int j = 0; j < cat.Count; j++)
                        {
                            dataGridView1.Rows.Add(cat[j].InnerText);
                        }

                        break;
                    }
                }

            }

        }
    }
}
