using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public enum FileType
    {
        [Display(Name="Döküman")]
        Document = 0,
        [Display(Name = "Fotoğraf")]
        Photo = 1,
        [Display(Name = "Ses")]
        Audio = 2,
        [Display(Name = "Video")]
        Video = 3    
    }
}
