using System;
namespace A_Card.Classes
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
}

