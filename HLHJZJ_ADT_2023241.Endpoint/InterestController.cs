using System;
using HLHJZJ_ADT_2023241.Logic;
using HLHJZJ_ADT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

namespace HLHJZJ_ADT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        IInterestLogic logic;

        public InterestController(IInterestLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<TopicController>
        //returns the list of Interests
        [HttpGet]
        public IEnumerable<Interest> Get()
        {
            return logic.ReadAll();
        }
        //returns exact Interest via id
        [HttpGet("{id}")]
        public Interest Get(int id)
        {
            return logic.Read(id);
        }
        //creates new interest
        [HttpPost]
        public void Post([FromBody] Interest value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Interest value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var InterestToDelete = this.logic.Read(id);
            logic.Delete(id);
        }
    }
}

