using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApi
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();
        public int SpouseId { get; set; }

        public void Marry(Person otherPerson)
        {
            this.SpouseId = otherPerson.Id;
            otherPerson.SpouseId = this.Id;
        }
    }
}
