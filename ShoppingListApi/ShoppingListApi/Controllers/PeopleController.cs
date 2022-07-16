using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PeopleApi.Controllers
{
    [ApiController]
    // Discoverable endpoint: api/ShoppingList
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private static List<Person> people = new List<Person>();

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(people);
        }

        [HttpPost]
        public IActionResult Create(Person person)
        {
            people.Add(person);

            return Created("/people", people);
        }

        [HttpPatch("{personId}")]
        public IActionResult AddPet(int personId, Pet pet)
        {
            var person = FindPerson(personId);

            if (person == null)
            {
                return NotFound($"Person by id: {personId} wasn't found");
            }

            person.Pets.Add(pet);

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = FindPerson(id);

            if (person == null)
            {
                return NotFound($"Person by id: {id} wasn't found");
            }

            people.Remove(person);

            return Ok();
        }

        [HttpDelete("{personId}/pets/{petName}")]
        public IActionResult DeletePet(int personId, string petName)
        {
            var person = FindPerson(personId);

            if (person == null)
            {
                return NotFound($"Person by id: {personId} wasn't found");
            }

            var pet = FindPet(person, petName);

            if (pet == null)
            {
                return NotFound($"Pet by name: {petName} wasn't found");
            }

            person.Pets.Remove(pet);

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePersonsData(int id, Person person)
        {
            var oldPerson = FindPerson(id);

            if (oldPerson == null)
            {
                return NotFound($"Person by id: {id} wasn't found");
            }

            oldPerson.Id = person.Id;
            oldPerson.Age = person.Age;
            oldPerson.SpouseId = person.SpouseId;
            oldPerson.Pets = person.Pets;
            oldPerson.Name = person.Name;

            return Ok(oldPerson);
        }

        [HttpPatch("marry/{personId}/{otherPersonId}")]
        public IActionResult MarryTwoPeople(int personId, int otherPersonId)
        {
            var person = FindPerson(personId);
            var otherPerson = FindPerson(otherPersonId);

            if (person == null && otherPerson == null)
            {
                return NotFound($"Person by id: {personId} and person by id: {otherPersonId} were not found");
            }

            if (person == null)
            {
                return NotFound($"Person by id: {personId} wasn't found");
            }
            
            if (otherPerson == null)
            {
                return NotFound($"Person by id: {otherPersonId} wasn't found");
            }

            person.Marry(otherPerson);

            return Ok();
        }


        public Person FindPerson(int id)
        {
            foreach (var person in people)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }

        public Pet FindPet(Person person, string petName)
        {
            for (int i = 0; i < person.Pets.Count; i++)
            {
                var pet = person.Pets[i];
                if (pet.Name == petName)
                {
                    return pet;
                }
            }

            return null;
        }
    }
}
