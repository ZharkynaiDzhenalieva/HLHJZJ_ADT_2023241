using System;
using HLHJZJ_ADT_2023241.Logic;
using HLHJZJ_ADT_2023241.Models;
using Microsoft.AspNetCore.Mvc;

namespace HLHJZJ_ADT_2023241.Endpoint
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductLogic productlogic;
        public ProductController(IProductLogic productlogic)
        {
            this.productlogic = productlogic;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productlogic.ReadAll();
        }

        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return productlogic.Read(id);
        }

        [HttpPost]
        public void Post([FromBody] Product value)
        {
            productlogic.Create(value);
        }

        [HttpPut]
        public void Put([FromBody] Product value)
        {
            productlogic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var CarToDelete = this.productlogic.Read(id);
            productlogic.Delete(id);

        }
    }
}

