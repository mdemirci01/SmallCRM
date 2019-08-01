using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Document:BaseEntity
    {
        public string Name { get; set; }
        public string File { get; set; }     
        public string Description { get; set; }
        public FileType Type { get; set; }
        public string Extension { get; set; }
        public int Size { get; set; }
        

    }
}
