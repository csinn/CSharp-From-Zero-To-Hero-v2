using System.Collections.Generic;

namespace PeopleApi
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int SpouseId { get; set; }
        public List<Pet> Pets { get; set; } = new List<Pet>();

        public void Marry(Person otherPerson)
        {
            this.SpouseId = otherPerson.Id;
            otherPerson.SpouseId = this.Id;
        }
    }
}
