using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Project:BaseEntity
    {
        public Project()
        {           
            Tasks = new HashSet<Task>();
            TimeSpendings = new HashSet<TimeSpending>();
        }        
        public string Name { get; set; }        
        public string Description { get; set; }        
        public string Managers { get; set; }        
        public string BussinessAnalyists { get; set; }        
        public string Developers { get; set; }        
        public DateTime? StartDate { get; set; }   
        public TaskStatus? TaskStatus { get; set; }
        public ICollection<WorkItem> WorkItems { get; set; }
        public ICollection<TimeSpending> TimeSpendings { get; set; }    
        public decimal TotalTimeSpent { get { return TimeSpendings.Sum(s => s.TimeSpent); } }
    }
}
