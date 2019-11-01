using System;
using System.Collections.Generic;

namespace ManyToMany.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

        //a person subscribes to many magazines
        public List<Subscription> Subscriptions { get; set; }
    }
}