using System.Collections.Generic;

namespace PersonPetsApi
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int SpouseId { get; set; }
        public List<Pet> Pets { get; set; }

        public Person UpdatePerson(Person person)
        {
            this.Id = person.Id;
            this.Name = person.Name;
            this.Age = person.Age;
            this.SpouseId = person.SpouseId;

            return this;
        }

        public static void Marry(Person person1, Person person2)
        {
            person1.SpouseId = person2.Id;
            person2.SpouseId = person1.Id;
        }
    }
}
