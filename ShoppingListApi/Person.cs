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
    }
}
