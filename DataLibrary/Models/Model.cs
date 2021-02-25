using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class Model
    {
        public int Id { get; set; }
        public int Modelid { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Size { get; set; }
        public string Platform { get; set; }
        public string Category { get; set; }
        public string Material { get; set; }
        public string Style { get; set; }
        public string Render { get; set; }
        public string Color { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }

        public string FileName { get; set; }
        public string ImagePath { get; set; }
        public string FilePath { get; set; }
    }
}
