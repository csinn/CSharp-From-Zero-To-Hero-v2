using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeopleApi.Controllers
{

    // Homework:
    //  Add person
    //  Add a pet to an existing person
    //  Remove person
    //  Remove pet from an existing person
    //  Update an existing person data
    //  Marry two people

    [Route("api/[controller]")]
    [ApiController]
    public class PeopleApiController : ControllerBase
    {
        private static List<Person> personList = new List<Person>();

        [HttpPost]
        public IActionResult AddPerson(Person personObj)
        {
            personList.Add(personObj);

            return Created("/peopleapi", personObj);
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            return Ok(personList);
        }

        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            Person personObj = FindPersonById(id);

            if (personObj == null)
            {
                return NotFound($"Person by id {id} was not found.");
            }

            return Ok(personObj);
        }

        [HttpPut("{id}")]
        public IActionResult AddPetToPersonChosenById(int id, Pet petObj)
        {
            Person personObj = FindPersonById(id);
            if (personObj == null)
            {
                return NotFound($"Person by id {id} was not found.");
            }

            personObj.Pets.Add(petObj);

            return Ok(personObj);
        }

        [HttpDelete("{id}")]
        public IActionResult RemovePerson(int id)
        {
            Person personObj= FindPersonById(id);

            if (personObj == null)
            {
                return NotFound($"Shopping list by id {id} was not found.");
            }

            personList.Remove(personObj);

            return Ok();
        }

        [HttpPut("{id}/{petName}")]
        public IActionResult RemovePetFromPerson(int id, string petName)
        {
            Person personObj = FindPersonById(id);
            if (personObj == null)
            {
                return NotFound($"Person by id {id} was not found.");
            }

            Pet petObj = FindPetByName(personObj.Pets, petName);
            if (petObj == null)
            {
                return NotFound($"Pet by name of {petName} was not found.");
            }

            RemovePetObjectFromPersonObject(personObj, petObj);
            personObj = FindPersonById(id);
            return Ok(personObj);
        }

        [HttpPatch("{id}/updatePerson")]
        public IActionResult UpdatePersonDetails(int id, Person personObj)
        {
            if (FindPersonById(id) == null)
            {
                return NotFound($"Person by id {id} was not found.");
            }

            UpdatePersonObjectInList(id, personObj);
            return Ok();
        }

        [HttpPut("{id}/{spouseId}/marry")]
        public IActionResult MarryPersons(int id,int spouseId) 
        {
            if (FindPersonById(id) == null || FindPersonById(spouseId) == null)
            {
                return NotFound($"Person by id {id} was not found.");
            }
            ChangeSpouseIds(id, spouseId);

            return Ok();
        }

        /// <summary>
        /// Returns found Pet object when provided a List of Pet object and search name
        /// </summary>
        /// <param name="petList">List to search in</param>
        /// <param name="petName">Name to search for</param>
        /// <returns></returns>
        private Pet FindPetByName(List<Pet> petList,string petName)
        {
            return petList.Find(x => x.Name == petName);
        }
        
        /// <summary>
        /// Removes Pet object from owner in main personList;
        /// </summary>
        /// <param name="ownerObj"></param>
        /// <param name="petObj"></param>
        private void RemovePetObjectFromPersonObject(Person ownerObj, Pet petObj)
        {
            foreach (Person personObj in personList)
            {
                if (personObj == ownerObj)
                {
                    ownerObj.Pets.Remove(petObj);
                }
            }
        }

        /// <summary>
        /// Changing original object from list found by Id, to new provided object
        /// </summary>
        /// <param name="id">Person Id to look for and update</param>
        /// <param name="newPersonObj">New object that updates old one</param>
        private void UpdatePersonObjectInList(int id, Person newPersonObj)
        {
            for (int i = 0; i < personList.Count; i++)
            {
                if (personList[i].Id == id)
                {
                    personList[i].UpdatePerson(newPersonObj);
                }
            }
           
        }

        /// <summary>
        /// Changes SpouseId properties of Person object in personList. 
        /// </summary>
        /// <param name="id">ID of first person to marry</param>
        /// <param name="spouseId">ID of second person to marry</param>
        private void ChangeSpouseIds(int id, int spouseId)
        {
            foreach (Person personObj in personList)
            {
                if (personObj.Id == id)
                {
                    personObj.SpouseId = spouseId;
                }
                else if (personObj.Id == spouseId)
                {
                    personObj.SpouseId = id;
                }
            }
        }

        private Person FindPersonById(int id)
        {
            return personList.Find(x => x.Id == id);
        }

    }
}
