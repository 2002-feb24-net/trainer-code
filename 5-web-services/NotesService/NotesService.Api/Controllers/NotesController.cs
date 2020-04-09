﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesService.Api.Models;
using NotesService.Api.Repositories;

namespace NotesService.Api.Controllers
{
    // Route attribute -- attribute routing.
    //     with attribute routing, [controller] is a placeholder for this controller's name
    [Route("api/[controller]")] // "prefix all the action methods' routes with /api/notes"
    [ApiController] // put this on controllers for web APIs to enable various behaviors
                    // (e.g. - automatic modelstate checking with a 400 Bad Request response on failure)
    public class NotesController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public NotesController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        // GET: api/notes
        [HttpGet]
        [Produces("application/xml")] // this action method only produces xml media type
        public IActionResult Get([FromQuery] DateTime? since = null)
        {
            IEnumerable<Note> notes = _noteRepository.GetAll(since);
            return Ok(notes);
            // (200 OK response, with the notes serialized in the response body -- instead of some view's HTML)
        }

        // GET: api/notes/5
        [HttpGet("{id}")] // 1. this action method's route will append
                                        // "/{id}" to the controller's overall route, where id is a route parameter
                                        // 2. the route's name is "Get" so it can be referenced elsewhere
                                        // 3. only HTTP GET will be routed to this action method.
        public ActionResult<Note> GetById(int id) // because this says "int", model binding will fail if id wasn't an int
        {
            if (_noteRepository.GetById(id) is Note note)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError);

                // contentresult gives more control, like this
                //string json = JsonSerializer.Serialize(note);
                //return new ContentResult
                //{
                //    StatusCode = 200,
                //    ContentType = "application/json",
                //    Content = json
                //};

                return note;
            }
            // otherwise it's null, so no such id found
            return NotFound(); // 404 Not Found response
        }

        // POST: api/notes
        [HttpPost]
        [Consumes("application/xml")] // this action method won't accept JSON as input, only XML
        [ProducesResponseType(201, Type = typeof(Note))]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Note note)
        {
            // this code here is effectively automatic because of ApiControllerAttribute
            // if (!ModelState.IsValid) return BadRequest(ModelState);

            _noteRepository.Add(note);
            // id is now set
            return CreatedAtAction(nameof(GetById), new { id = note.Id }, note);
        }

        // ignores changing the tags
        // PUT: api/notes/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Note note)
        {
            // successful update for PUT returns 204 No Content with empty body, or 200 OK
            if (_noteRepository.GetById(id) is Note oldNote)
            {
                oldNote.DateModified = DateTime.Now;
                oldNote.Author = note.Author;
                oldNote.IsPublic = note.IsPublic;
                oldNote.Text = note.Text;
                return NoContent();
                //return StatusCode(204);
            }
            return NotFound();
        }

        // DELETE: api/notes/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // successful DELETE returns 204 No Content with empty body
            if (_noteRepository.GetById(id) is Note note)
            {
                _noteRepository.Remove(note);
                return NoContent();
            }
            return NotFound();
        }
    }
}
