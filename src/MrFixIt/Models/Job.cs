﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MrFixIt.Models
{
    //builds out table for jobs
    //incorrect. our database should be plural 
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Completed { get; set; }
        public bool Pending { get; set; }
        public bool Active { get; set; }
        //public virtual links tables with worker
        public virtual Worker Worker { get; set; }
    }
}
