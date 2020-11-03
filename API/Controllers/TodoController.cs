using System;
using System.Collections.Generic;
using System.Linq;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/todo")]
    public class ProductsController : ControllerBase
    {
        private readonly ITodoRepository repository;
        public ProductsController(ITodoRepository repository)
        {
            this.repository = repository;
        }
        [HttpGet]
        public ActionResult<List<Todo>> Get() => repository.GetAll().ToList();
        [HttpGet("{id}", Name = "GetById")]
        public ActionResult<Todo> GetById(int id) => repository.GetById(id);
        [HttpGet("active")]
        public ActionResult<List<Todo>> GetActive() => repository.GetTodoActive().ToList();
        [HttpGet("done")]
        public ActionResult<List<Todo>> GetDone() => repository.GetTodoDone().ToList();
        [HttpPost]
        public void Post([FromBody] Todo todo)
        {
            this.repository.Create(todo);
        }
        [HttpPut]
        public void Update([FromBody] Todo todo)
        {
            this.repository.Update(todo);
        }
        [HttpPut("{id}")]
        public void Update(int id, [FromBody] Todo todo)
        {
            this.repository.UpdateById(id, todo);
        }
        [HttpDelete]
        public void Delete([FromBody] Todo todo)
        {
            this.repository.Remove(todo);
        }
        [HttpDelete("{id}", Name = "DeleteById")]
        public void DeleteById(int id)
        {
            this.repository.RemoveById(id);
        }
    }
}