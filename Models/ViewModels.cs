namespace ManyToMany.Models
{
    public class PeopleMagazine
    {
        public Person Subscriber {get; set;}
        public Magazine Subscribee {get; set;}
    }
}