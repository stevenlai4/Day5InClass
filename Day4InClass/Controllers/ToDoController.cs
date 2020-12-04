using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day4InClass.Data;
using Day4InClass.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day4InClass.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _db;

        public ToDoController(ToDoContext db)
        {
            _db = db;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var todos = _db.ToDos.ToList();

                if (!todos.Any())
                {
                    return NoContent();
                }

                return Ok(todos);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}", Name = "GetOne")]
        public IActionResult GetById(int id)
        {
            var todo = _db.ToDos.Where(t => t.Id == id).FirstOrDefault();
            return new ObjectResult(todo);
        }

        /// <summary>
        /// Creates a TodoItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "description": "Item1",
        ///        "isComplete": true,
        ///        "priority": 1,
        ///        "createdOn": "2020-01-01T00:00:00.0000001"
        ///     }
        /// </remarks> 
        /// <param name="todo"></param>
        /// <returns>A newly created Todo Item</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is not saved</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Create(ToDo todo)
        {
            if (todo.Description != null || todo.Description != "")
            {
                try
                {
                    _db.ToDos.Add(todo);
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return CreatedAtRoute("GetTodo", new { id = todo.Id }, todo);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("MyEdit")]
        public IActionResult Update(ToDo todo)
        {
            // Old value
            var item = _db.ToDos.Where(t => t.Id == todo.Id).FirstOrDefault();

            if(item == null)
            {
                return NotFound();
            }
            else
            {
                item.IsComplete = todo.IsComplete;
                _db.SaveChanges();
            }

            return Ok(item);
        }


        /// <summary>
        /// Deletes a specific ToDo.
        /// </summary> 
        /// <param name="Id"></param>
        [HttpDelete]
        [Route("MyDelete")]
        public IActionResult Delete(long Id)
        {
            var item = _db.ToDos.Where(t => t.Id == Id).FirstOrDefault();

            if(item == null)
            {
                return NotFound();
            }
     
            _db.ToDos.Remove(item);
            _db.SaveChanges();
            return Ok(item);
        }
    }
}
