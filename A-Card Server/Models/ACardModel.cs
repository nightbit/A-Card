using System;
using System.Security;

namespace A_Card_Server.Models
{
    public class Animal
    {
        public string uuid { get; set; } //KEY

        public string name { get; set; }
        public string species { get; set; }
        public DateTime birthday { get; set; } = DateTime.Now;
        public string chip { get; set; } = "";

        public Owner owner { get; set; }
    }
    public class Owner
    {
        public string ssn { get; set; } //KEY

        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public DateTime birthday { get; set; }
        public string streetAndNumber { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }
    }
}

