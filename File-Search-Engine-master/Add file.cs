using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{

    public partial class Add_file : Form
    {
        public static string filecontent="";
        public Add_file()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            filecontent=richTextBox1.Text;
            if (filecontent.Count() == 0)
            {
                MessageBox.Show("Please enter the file.");
            }
            else
            {
                Save_file sv = new Save_file();
                sv.Show();
                this.Hide();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home h = new Home();
            h.Show();
            this.Hide();
        }

        private void Add_file_Load(object sender, EventArgs e)
        {

        }
    }
}
