using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Person.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private static List<Person> _personList = new List<Person>();
        
        [HttpPost]
        public IActionResult Create(Person person)
        {
            _personList.Add(person);

            return Ok(person);
        }

        [HttpPatch("{id}")]

        public IActionResult AddPet(Pet pet, int id)
        {
            Person person = GetPerson(id);

            if (person == null)
            {
                return NotFound($"person with id:{id} not found");
            }
            
            person.PetList.Add(pet);

            return Ok(person.PetList);
        }

        [HttpPatch("{id}/update")]
        public IActionResult UpdatePerson(Person person, int id)
        {
            var _person = GetPerson(id);

            if (_person == null)
            {
                return NotFound($"person with id:{id} not found");
            }

            _person.Age = person.Age;
            _person.Gender = person.Gender;
            _person.Name = person.Name;
            _person.PetList = person.PetList;
            _person.SpouseId = person.SpouseId;

            return Ok(_person);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = GetPerson(id);

            if (person == null)
            {
                return NotFound($"person with id:{id} not found");
            }

            _personList.Remove(person);

            return Ok();
        }

        [HttpDelete("{id}/{petName}")]
        public IActionResult DeletePet(int id, string petName)
        {
            var person = GetPerson(id);

            if (person == null)
            {
                return NotFound($"person with id:{id} not found");
            }

            var pet = GetPet(person, petName);

            if (pet == null)
            {
                return NotFound($"pet with name: {petName} not found");
            }

            person.PetList.Remove(pet);

            return Ok();
        }

        [HttpPatch("{id1}/{id2}")]
        public IActionResult Marry(int id1, int id2)
        {
            var person1 = GetPerson(id1);
            var person2 = GetPerson(id2);

            if (person1 == null || person2 == null)
            {
                return NotFound($"One of the people was not found");
            }

            person1.SpouseId = person2.Id;
            person2.SpouseId = person1.Id;

            return Ok($"{person1.Name} and {person2.Name} have been married");
        }

        private Pet GetPet(Person person, string petName)
        {
            foreach (var pet in person.PetList)
            {
                if (pet.Name == petName)
                {
                    return pet;
                }
            }

            return null;
        }

        [HttpGet]
        public IActionResult GetPeople()
        {
            return Ok(_personList);
        }

        private Person GetPerson(int id)
        {
            foreach (var  person in _personList)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }
    }
}