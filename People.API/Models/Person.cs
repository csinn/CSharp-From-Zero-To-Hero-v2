using System.Collections.Generic;

namespace People.API.Models
{
    public class Person
    {
        private const int _notMarried = -1;
        public int Age { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Pet> Pets { get; set; } = new();
        public int SpouseId { get; set; } = _notMarried;

        public void Marry(Person otherPerson)
        {
            if(otherPerson.SpouseId == _notMarried)
            {
                otherPerson.SpouseId = Id;
                SpouseId = otherPerson.Id;
            }

            // Can't marry more than one person at a time
        }
    }
}