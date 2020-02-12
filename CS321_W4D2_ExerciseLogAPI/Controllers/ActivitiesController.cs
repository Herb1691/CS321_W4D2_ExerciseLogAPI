using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CS321_W4D2_ExerciseLogAPI.ApiModels;
using CS321_W4D2_ExerciseLogAPI.Core.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CS321_W4D2_ExerciseLogAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActivitiesController : Controller
    {
        private IActivityService _activityService;

        public ActivitiesController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            var activityModels = _activityService
                .GetAll()
                .ToApiModels(); // convert Books to BookModels

            return Ok(activityModels);
        }

        //// TODO: Add a route that returns all books for an author
        //// GET api/author/{authorId}/books
        //[HttpGet("/api/authors/{authorId}/books")]
        //public IActionResult GetBooksForAuthor(int authorId)
        //{
        //    var bookModels = _bookService
        //        .GetBooksForAuthor(authorId)
        //        .ToApiModels();

        //    return Ok(bookModels);
        //}

        // get specific book by id
        // GET api/books/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var activity = _activityService.Get(id);
            if (activity == null) return NotFound();
            return Ok(activity.ToApiModel());
        }

        // create a new book
        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] ActivityModel newActivity)
        {
            try
            {

                // add the new book
                _activityService.Add(newActivity.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddActivity", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newActivity.Id }, newActivity);
        }

        // PUT api/books/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ActivityModel updatedActivity)
        {
            var activity = _activityService.Update(updatedActivity.ToDomainModel());
            if (activity == null) return NotFound();
            return Ok(activity.ToApiModel());
        }

        // DELETE api/books/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var activity = _activityService.Get(id);
            if (activity == null) return NotFound();
            _activityService.Remove(activity);
            return NoContent();
        }
    }
}
