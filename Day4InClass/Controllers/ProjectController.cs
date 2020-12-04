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
    public class ProjectController : ControllerBase
    {
        private readonly ProjectContext _db;

        public ProjectController(ProjectContext db)
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
                var projects = _db.Projects.ToList();

                if (!projects.Any())
                {
                    return NoContent();
                }

                return Ok(projects);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{id}", Name = "GetOneProject")]
        public IActionResult GetById(int id)
        {
            var project = _db.Projects.Where(p => p.Id == id).FirstOrDefault();
            return new ObjectResult(project);
        }

        /// <summary>
        /// Creates a ProjectItem.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Project
        ///     {
        ///        "description": "Item1",
        ///        "isComplete": true,
        ///        "priority": 1,
        ///        "createdOn": "2020-01-01T00:00:00.0000001"
        ///     }
        /// </remarks> 
        /// <param name="project"></param>
        /// <returns>A newly created Project Item</returns>
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is not saved</response>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public IActionResult Create(Project project)
        {
            if (project.Description != null || project.Description != "")
            {
                try
                {
                    _db.Projects.Add(project);
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return CreatedAtRoute("GetProject", new { id = project.Id }, project);
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("MyProjectEdit")]
        public IActionResult Update(Project project)
        {
            // Old value
            var item = _db.Projects.Where(p => p.Id == project.Id).FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                item.IsComplete = project.IsComplete;
                _db.SaveChanges();
            }

            return Ok(item);
        }

        /// <summary>
        /// Deletes a specific Project.
        /// </summary> 
        /// <param name="Id"></param>
        [HttpDelete]
        [Route("MyProjectDelete")]
        public IActionResult Delete(long Id)
        {
            var item = _db.Projects.Where(p => p.Id == Id).FirstOrDefault();

            if (item == null)
            {
                return NotFound();
            }

            _db.Projects.Remove(item);
            _db.SaveChanges();
            return Ok(item);
        }
    }
}
