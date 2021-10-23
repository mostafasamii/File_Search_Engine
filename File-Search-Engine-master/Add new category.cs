using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp3
{
    public partial class Add_new_category : Form
    {
        public Add_new_category()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save_file sf = new Save_file();
            sf.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Categories C=new Categories();
            string[] fields = Add_file.filecontent.Split(' ');
            textBox1.CharacterCasing = CharacterCasing.Lower;
            int cnt = 0;
            List<string> tmp = new List<string>();
            C.name = textBox1.Text;
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                C.keywords.Add(dataGridView1.Rows[i].Cells[0].Value.ToString().ToLower());
            }
            for (int i = 0; i < C.keywords.Count ;i++ )
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
                List<Categories> cat = new List<Categories>();
                List<string> neww = new List<string>();
                bool b = false;
                bool a = false;
                bool c = false;
                /*************************************************************************************/
                XmlSerializer ser = new XmlSerializer(typeof(List<Categories>));
                using (FileStream f = new FileStream("fileCategories.xml", FileMode.OpenOrCreate, FileAccess.Read))
                {
                    if (f.Length != 0)
                    {
                        cat = (List<Categories>)ser.Deserialize(f);
                    }

                    f.Close();
                }
                //check if we have the same category or not & if we have some or the same keywords we store it 
                for (int i = 0; i < cat.Count; i++)
                {
                    if (cat[i].name == C.name)
                    {
                        a = true;
                        for (int j = 0; j < C.keywords.Count; j++)
                        {
                            for (int k = 0; k < cat[i].keywords.Count; k++)
                            {
                                if (C.keywords[j] == cat[i].keywords[k])
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

                            DialogResult res1 = MessageBox.Show("Some of the keywords already exist. Do you want to add the new keywords to the existing category? ",
                                "Add Category", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
                            if (res1 == DialogResult.Yes)
                            {
                                for (int m = 0; m < neww.Count; m++)
                                {
                                    cat[i].keywords.Add(neww[m]);
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
                    cat.Add(C);
                }
                XmlSerializer serr = new XmlSerializer(typeof(List<Categories>));
                FileStream Fs = new FileStream("fileCategories.xml", FileMode.OpenOrCreate, FileAccess.Write);
                serr.Serialize(Fs, cat);
                Fs.Close();
                if (c == false)
                {
                    DialogResult res2 = MessageBox.Show("Added", "Add Category", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            
        }
    }
}