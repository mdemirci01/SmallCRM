using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class Task:BaseEntity
    {
        public Task()
        {           
            TimeSpendings = new HashSet<TimeSpending>();
        }                     
        public string Name { get; set; }        
        public string Description { get; set; }        
        public string AssignedTo { get; set; }                
        public DateTime? StartDate { get; set; }        
        public DateTime? EndDate { get; set; }        
        public string Category { get; set; }        
        public TaskStatus? TaskStatus { get; set; }        
        public Guid ProjectId { get; set; }        
        public Project Project { get; set; }
        public ICollection<TimeSpending> TimeSpendings { get; set; }       
        public decimal TotalTimeSpent { get { return TimeSpendings.Sum(s => s.TimeSpent); } }
    }
}
