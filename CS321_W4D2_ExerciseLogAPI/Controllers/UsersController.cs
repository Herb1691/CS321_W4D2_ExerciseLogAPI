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
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET api/books
        [HttpGet]
        public IActionResult Get()
        {
            var userModels = _userService
                .GetAll()
                .ToApiModels(); // convert Books to BookModels

            return Ok(userModels);
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
            var user = _userService.Get(id);
            if (user == null) return NotFound();
            return Ok(user.ToApiModel());
        }

        // create a new book
        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] UserModel newUser)
        {
            try
            {

                // add the new book
                _userService.Add(newUser.ToDomainModel());
            }
            catch (System.Exception ex)
            {
                ModelState.AddModelError("AddUser", ex.GetBaseException().Message);
                return BadRequest(ModelState);
            }

            return CreatedAtAction("Get", new { Id = newUser.Id }, newUser);
        }

        // PUT api/books/:id
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserModel updatedUser)
        {
            var user = _userService.Update(updatedUser.ToDomainModel());
            if (user == null) return NotFound();
            return Ok(user.ToApiModel());
        }

        // DELETE api/books/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _userService.Get(id);
            if (user == null) return NotFound();
            _userService.Remove(user);
            return NoContent();
        }
    }
}