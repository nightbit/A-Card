using System;
namespace A_Card.Classes
{
    public class Animal
    {
        public string uuid { get; set; } //KEY

        public string name { get; set; }
        public string species { get; set; }
        public string birthday { get; set; }
        public string chip { get; set; } = "";

        public Owner owner { get; set; }

        public Animal(string name, string species, string birthday, string chip, Owner owner)
        {
            this.uuid = Guid.NewGuid().ToString();
            this.name = name;
            this.species = species;
            this.birthday = birthday;
            this.chip = chip;
            this.owner = owner;
        }
    }
}

