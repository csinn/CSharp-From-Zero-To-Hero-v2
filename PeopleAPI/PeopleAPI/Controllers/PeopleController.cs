using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;

namespace PeopleAPI.Controllers
{
    [ApiController]

    // http://localhost:44313/api/People
    [Route("api/[controller]")]
    public class PeopleController : ControllerBase
    {
        private static List<People> _PeopleList = new List<People>();

        [HttpPost]
        public IActionResult CreatePerson(People person)
        {
            _PeopleList.Add(person);

            return Created("/person", _PeopleList);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_PeopleList);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            People person = FindPersonById(id);

            if (person == null)
                return NotFound($"Person with the id {id} was not found");

            return Ok(person);
        }

        [HttpPatch("{PersonsId}")]
        public IActionResult AddPet(int PersonsId, Pet pet)
        {
            People person = FindPersonById(PersonsId);

            if (person == null)
                return NotFound($"Person with the id {PersonsId} was not found");

            person.pets.Add(pet);

            return Ok();
        }

        [HttpGet("{id}/pets")]
        public IActionResult GetPets(int id)
        {
            People person = FindPersonById(id);

            if (person == null)
                return NotFound($"Person with the id {id} was not found");

            return Ok(person.pets);
        }

        [HttpDelete("{PersonsId}")]
        public IActionResult DeletePerson(int PersonsId)
        {
            People person = FindPersonById(PersonsId);

            if (person == null)
                return NotFound($"Person with the id {PersonsId} was not found");

            _PeopleList.Remove(person);

            return Ok();
        }

        [HttpDelete("{PersonsId}/pets/{PetsName}")]
        public IActionResult RemovePet(int PersonsId, string PetsName)
        {
            People person = FindPersonById(PersonsId);

            if (person == null)
                return NotFound($"Person with the id {PersonsId} was not found");

            Pet pet1 = FindPersonsPet(person, PetsName);

            if (pet1 == null)
                return NotFound($"Pet with the name {PetsName} was not found");

            person.pets.Remove(pet1);

            return Ok();
        }

        [HttpPut("{PersonsId}")]
        public IActionResult UpdateData(int personsid, People person)
        {
            var oldPerson = FindPersonById(personsid);

            if (oldPerson == null)
                return NotFound($"User by the Id {personsid} was not found");

            oldPerson.Id = person.Id;
            oldPerson.Name = person.Name;
            oldPerson.Age = person.Age;
            oldPerson.pets = person.pets;
            oldPerson.SpouseId = person.SpouseId;

            return Ok(oldPerson);
        }

        [HttpPatch("marry/{persons1id}/{persons2id}")]
        public IActionResult Marry(int persons1id, int persons2id)
        {
            var person1 = FindPersonById(persons1id);

            if (person1 == null)
                return NotFound($"User by the Id {persons1id} was not found");

            var person2 = FindPersonById(persons2id);

            if (person2 == null)
                return NotFound($"User by the Id {persons2id} was not found");

            person1.Marry(person2);

            return Ok();
        }

        private People FindPersonById(int id)
        {
            foreach (var person in _PeopleList)
            {
                if (person.Id == id)
                {
                    return person;
                }
            }

            return null;
        }

        private Pet FindPersonsPet(People person, string PetsName)
        {
            foreach (var pet in person.pets)
            {
                if (pet.Name == PetsName)
                    return pet;
            }

            return null;
        }
    }
}
