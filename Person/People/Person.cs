using System;
using System.Collections.Generic;

namespace Person
{
    public class Person
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Gender { get; set; }
        public int Age { get; set; }
        public int SpouseId { get; set; }
        public List<Pet> PetList { get; set; } = new List<Pet>();
    }
}