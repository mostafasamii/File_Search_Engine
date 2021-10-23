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
    public partial class Display_categories : Form
    {
        public static List<Tuple<string, string>> fpath = new List<Tuple<string, string>>();
        public static List<string> keywords = new List<string>();
        public static string searchingFile = "";
        
        public Display_categories()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home hhh = new Home();
            hhh.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton_show_keywords.Checked)
            {
                dataGridView_show_details.Visible = false;
                dataGridView_show_keywords.Visible = true;
                dataGridView_show_keywords.Rows.Clear();
                string ans = comboBox1.SelectedItem.ToString();
                XmlDocument doc = new XmlDocument();
                doc.Load("fileCategories.xml");
                XmlNodeList cats = doc.GetElementsByTagName("Category");
                for (int i = 0; i < cats.Count; i++)
                {
                    XmlNodeList name_kyewords = cats[i].ChildNodes;
                    if (name_kyewords[0].InnerText == ans)
                    {
                        XmlNodeList keywords = name_kyewords[1].ChildNodes;
                        for (int j = 0; j < keywords.Count; j++)
                        {
                            dataGridView_show_keywords.Rows.Add(keywords[j].InnerText);
                        }
                    }
                }
            }
            else if (radioButton_show_details.Checked)
            {
                dataGridView_show_details.Visible = true;
                dataGridView_show_keywords.Visible = false;
                string cat = comboBox1.SelectedItem.ToString();
                Dictionary<string, Dictionary<string, Tuple<int, List<int>>>> s = new Dictionary<string, Dictionary<string, Tuple<int, List<int>>>>();
                XmlDocument doc = new XmlDocument();
                doc.Load("Files.xml");
                XmlNodeList files = doc.GetElementsByTagName("File");
                for (int i = 0; i < files.Count; i++)
                {
                    XmlNodeList node = files[i].ChildNodes;
                    XmlNodeList child = node[2].ChildNodes;
                    for (int j = 0; j < child.Count; j++)
                    {
                        if(cat==child[j].InnerText)
                        {
                            string f = "";
                            f += node[1].InnerText+"\\"+node[0].InnerText+".txt";
                            fpath.Add(new Tuple<string,string>(node[0].InnerText,f));
                        }
                    }
                }
                doc = new XmlDocument();
                doc.Load("fileCategories.xml");
                XmlNodeList clist = doc.GetElementsByTagName("Category");
                for (int i = 0; i < clist.Count; i++)
                {
                    XmlNodeList node = clist[i].ChildNodes;
                    if (node[0].InnerText == cat)
                    {
                        XmlNodeList child = node[1].ChildNodes;
                        for (int j = 0; j < child.Count; j++)
                        {
                            keywords.Add(child[j].InnerText);
                        }
                        break;
                    }
                }

                for (int i = 0; i < keywords.Count; i++)
                {
                    Dictionary<string, Tuple<int, List<int>>> d = new Dictionary<string, Tuple<int, List<int>>>();
                    dataGridView_show_details.Rows.Clear();
                    for (int j = 0; j < fpath.Count; j++)
                    {
                        FileStream fs = new FileStream(fpath[j].Item2, FileMode.Open, FileAccess.Read);
                        StreamReader sr = new StreamReader(fs);
                        int cnt = 0;
                        int kcnt = 0;
                        List<int> lines = new List<int>();
                        while(sr.Peek()!=-1)
                        {
                            string line = sr.ReadLine();
                            cnt++;
                            string[] fields = line.Split(' ');
                            bool a = false;
                            for (int k = 0; k < fields.Count();k++ )
                            {
                                if (fields[k] == keywords[i])
                                {
                                    a = true;
                                    
                                    kcnt++;
                                }
                            }
                            if (a == true)
                            {
                                lines.Add(cnt);
                            }
                        }
                        Tuple<int, List<int>> t = new Tuple<int, List<int>>(kcnt,lines);
                        d[fpath[j].Item1]=t;

                        fs.Close();
                    }
                    s.Add(keywords[i], d);
                }
                dataGridView_show_details.ColumnCount = 4;
                dataGridView_show_details.Columns[0].Name = "Keyword";
                dataGridView_show_details.Columns[1].Name = "FileName";
                dataGridView_show_details.Columns[2].Name = "Count";
                dataGridView_show_details.Columns[3].Name = "Lines";
                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                dataGridView_show_details.Columns.Add(btn);
                btn.HeaderText = "View File";
                btn.Text = "View";
                for (int i = 0; i < s.Count; i++)
                {
                    string st = s.Keys.ElementAt(i);
                    Dictionary<string, Tuple<int, List<int>>> minis = s[st];
                    for (int j = 0; j < minis.Count; j++)
                    {
                        string st2 = minis.Keys.ElementAt(j);
                        Tuple<int, List<int>> minit = minis[st2];
                        for (int k = 0; k < minit.Item2.Count; k++)
                        {
                            dataGridView_show_details.Rows.Add(st,st2,minit.Item1,minit.Item2[k]);
                        }
                    }
                }
            

            }
        }

        private void Display_categories_Load(object sender, EventArgs e)
        {
            
        }

        private void Display_categories_Load_1(object sender, EventArgs e)
        {
            dataGridView_show_details.Visible = false;
            dataGridView_show_keywords.Visible = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("fileCategories.xml");
            XmlNodeList cats_name = doc.GetElementsByTagName("Name");
            for (int i = 0; i < cats_name.Count; i++)
            {
                comboBox1.Items.Add(cats_name[i].InnerText);
            }
            dataGridView_show_details.AutoGenerateColumns = false;
        }

        private void dataGridView_show_keywords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton_show_details_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView_show_details_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string filename = dataGridView_show_details.Rows[e.RowIndex].Cells[1].Value.ToString();
            for (int i = 0; i < fpath.Count; i++)
            {
                if (fpath[i].Item1 == filename)
                {
                    searchingFile = fpath[i].Item2;

                }
            }
            if (e.ColumnIndex == 4)
            {
                viewfile f = new viewfile();
                f.Show();
            }
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            fpath.Clear();
            keywords.Clear();
        }
  
        
    }
}