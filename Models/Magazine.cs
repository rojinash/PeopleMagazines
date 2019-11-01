using System;
using System.Collections.Generic;

namespace ManyToMany.Models
{
    public class Magazine
    {
        public int MagazineId { get; set; }
        public string Title { get; set; }
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //a magazine has many readers
        public List<Subscription> Readers { get; set; }
    }
}