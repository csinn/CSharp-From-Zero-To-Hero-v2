using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleAPI
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Pet> pets { get; set; } = new List<Pet>();
        public int SpouseId {  get; set; } // other person's ID
        public void Marry(People PersonToMarry)
        {
            this.SpouseId = PersonToMarry.Id;
            PersonToMarry.SpouseId = this.Id;
        }
    }
}
