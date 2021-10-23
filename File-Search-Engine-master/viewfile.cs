using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace WindowsFormsApp3
{
    public partial class viewfile : Form
    {
        public viewfile()
        {
            InitializeComponent();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void viewfile_Load(object sender, EventArgs e)
        {

     
        }

        private void viewfile_Load_1(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(Display_categories.searchingFile, FileMode.Open);
            StreamReader sr = new StreamReader(fs);
            string x = "";
            
            while (sr.Peek() != -1)
            {
                x += sr.ReadLine();
                x += "~";
            }

                richTextBox1.Text = x.Replace("~",System.Environment.NewLine);
                int index = 0;
                for (int i = 0; i < Display_categories.keywords.Count; i++)
                {
                    while (index < richTextBox1.Text.LastIndexOf(Display_categories.keywords[i]))
                    {
                        richTextBox1.Find(Display_categories.keywords[i], index, richTextBox1.TextLength, RichTextBoxFinds.None);
                        richTextBox1.SelectionBackColor = Color.PaleVioletRed;
                        index = richTextBox1.Text.IndexOf(Display_categories.keywords[i], index) + 1;
                    }
                }            
                fs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}