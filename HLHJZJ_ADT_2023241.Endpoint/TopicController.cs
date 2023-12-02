using System;
using HLHJZJ_ADT_2023241.Logic;
using HLHJZJ_ADT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

namespace HLHJZJ_ADT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class TopicController : ControllerBase
	{
        ITopicLogic logic;

        public TopicController(ITopicLogic logic)
        {
            this.logic = logic;
        }

        // GET: api/<TopicController>
        //returns the list of Topic
        [HttpGet]
        public IEnumerable<Topic> Get()
        {
            return logic.ReadAll(); 
        }
        //returns exact Topic via id
        [HttpGet("{id}")]
        public Topic Get(int id)
        {
            return logic.Read(id);
        }
        //creates new topic
        [HttpPost]
        public void Post([FromBody] Topic value)
        {
            logic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Topic value)
        {
            logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var BrandToDelete = this.logic.Read(id);
            logic.Delete(id);
        }
    }
}

