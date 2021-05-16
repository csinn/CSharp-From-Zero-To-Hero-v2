using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApi
{
    public class Person
    {
        public int Id { get; set; }
        public int SpouseId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Pet> Pets { get; set; }


        public void UpdatePerson(Person newDetails) {
            if (Id != newDetails.Id) Id = newDetails.Id;

            if (SpouseId != newDetails.SpouseId) SpouseId = newDetails.SpouseId;

            if (Name != newDetails.Name) Name = newDetails.Name;

            if (Age != newDetails.Age) Age = newDetails.Age;

            if (Pets != newDetails.Pets) Pets = newDetails.Pets;
        }
    }
}
