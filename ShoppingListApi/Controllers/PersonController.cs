using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PersonPetsApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private static List<Person> _people = new List<Person>();

        [HttpPost]
        public IActionResult Create(Person person)
        {
            _people.Add(person);

            return Created("/person", person);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_people);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var person = FindPerson(id);

            if (person == null)
            {
                return NotFound($"Person by id {id} was not found.");

            }

            return Ok(person);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = FindPerson(id);

            if (person == null)
            {
                return NotFound($"Person by id {id} was not found.");
            }

            _people.Remove(person);

            return Ok();
        }

        [HttpDelete("{id}/{name}")]
        public IActionResult DeletePet(int id, string name)
        {
            var person = FindPerson(id);

            if (person == null)
            {
                return NotFound($"Person by id {id} was not found.");
            }
            else
            {
                if (person.Pets.Any(x => x.Name == name))
                {
                    person.Pets.Remove(person.Pets.Where(x => x.Name == name).FirstOrDefault());

                    return Ok();
                }
            }

            return NotFound($"Pet by name {name} was not found for person {id}.");
        }

        [HttpPatch("{personId}")]
        public IActionResult AddPet(int personId, Pet pet)
        {
            var person = FindPerson(personId);

            if (person == null)
            {
                return NotFound($"Person by id {personId} was not found.");
            }

            person.Pets.Add(pet);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePerson(int id, Person person)
        {
            var oldPerson = FindPerson(id);

            if (oldPerson == null)
            {
                return NotFound($"Person by id {id} was not found.");
            }

            oldPerson.Pets = person.Pets;
            oldPerson.Name = person.Name;
            oldPerson.Age = person.Age;
            oldPerson.SpouseId = person.SpouseId;
            return Ok();
        }

        [HttpPatch("{personId1}/marry/{personId2}")]
        public IActionResult MarryPeople(int personId1, int personId2)
        {
            var person1 = FindPerson(personId1);
            var person2 = FindPerson(personId2);

            if (person1 == null)
            {
                return NotFound($"Person by id {personId1} was not found.");
            }
            else if(person2 == null)
            {
                return NotFound($"Person by id {personId2} was not found.");
            }
            else if(person1 == person2)
            {
                return BadRequest($"Person cannot marry themself.");
            }
            else
            {
                Marry(person1, person2);
            }

            return Ok();
        }

        private void Marry(Person person1, Person person2)
        {
            person1.SpouseId = person2.Id;
            person2.SpouseId = person1.Id;
        }

        private Person FindPerson(int id)
        {
            foreach (var person in _people)
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
