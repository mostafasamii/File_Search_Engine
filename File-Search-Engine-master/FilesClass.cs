using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public class FilesClass
    {
        public string name{get; set;}
        public string path{get; set;}
        public List<string> cat { get; set; }
        public FilesClass()
        {
            cat = new List<string>();
        }
    }
}