using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
   public class MainCompany:BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<Company> Companies { get; set; }

    }
}
