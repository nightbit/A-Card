using System;

namespace A_Card.Classes
{
    public class Owner
    {
        public Owner(string ssn, string firstname, string lastname, string email, string phone,
            string password, string birthday, string streetAndNumber, string zip, string city, string country)
        {
            this.ssn = ssn;
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.phone = phone;
            this.password = password;
            this.birthday = birthday;
            this.streetAndNumber = streetAndNumber;
            this.zip = zip;
            this.city = city;
            this.country = country;
        }

        public string ssn { get; set; } //KEY

        public string firstname { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string password { get; set; }
        public string birthday { get; set; }
        public string streetAndNumber { get; set; }
        public string zip { get; set; }
        public string city { get; set; }
        public string country { get; set; }

        public virtual ICollection<Animal> Animals { get; set; }

    }
}

