using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.ToDo
{
    [Route("api/[controller]")]
    public class ToDoController : Controller
    {
        private Data.ToDo.ToDoRepository _repository = new Data.ToDo.ToDoRepository();

        // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repository.Get();

            if (result == null || result.Count <= 0) {
                return NoContent();
            }

            return Ok(result);
        }
        
        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            if (!_repository.Put(id, value)) {
                return NotFound();
            }

            return Ok();
        }
    }
}
