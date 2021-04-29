using System.Collections.Generic;

namespace People.API.Models
{
    public class Person
    {
        public int Age { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; } = new();
        public int SpouseId { get; set; } = -1;

        public void Marry(Person otherPerson)
        {
            if(otherPerson.SpouseId == -1)
            {
                otherPerson.SpouseId = Id;
                SpouseId = otherPerson.Id;
            }

            // Can't marry more than one person at a time
        }
    }
}