﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallCRM.Model
{
    public class TimeSpending:BaseEntity
    {        
            public string Name { get; set; }            
            public Guid ProjectId { get; set; }          
            public virtual Project Project { get; set; }            
            public Guid? WorkItemId { get; set; }           
            public virtual WorkItem WorkItem { get; set; }          
            public string Worker { get; set; }
            public decimal TimeSpent { get; set; }            
            public WorkItemStatus? WorkItemStatus { get; set; }                        
        }
    }

