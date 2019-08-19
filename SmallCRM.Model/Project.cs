using System;
using System.Collections.Generic;
using System.Linq;

namespace SmallCRM.Model
{
    public class Project:BaseEntity
    {
        public Project()
        {
            WorkItems = new HashSet<WorkItem>();
            TimeSpendings = new HashSet<TimeSpending>();
        }        
        public string Name { get; set; }        
        public string Description { get; set; }        
        public string Managers { get; set; }        
        public string BussinessAnalyists { get; set; }        
        public string Developers { get; set; }        
        public virtual DateTime? StartDate { get; set; }   
        public virtual  WorkItemStatus? WorkItemStatus { get; set; }
        public virtual ICollection<WorkItem> WorkItems { get; set; }
        public virtual ICollection<TimeSpending> TimeSpendings { get; set; }    
        public decimal TotalTimeSpent { get { return TimeSpendings.Sum(s => s.TimeSpent); } }
    }
}
