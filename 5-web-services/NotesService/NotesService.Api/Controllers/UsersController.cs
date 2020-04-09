using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesService.Api.Repositories;

namespace NotesService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly INoteRepository _noteRepository;

        public UsersController(INoteRepository noteRepository)
        {
            _noteRepository = noteRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_noteRepository.GetAllUsers());
        }

        [HttpGet("{userId}/notes")]
        public IActionResult GetNotes(int userId)
        {
            try
            {
                return Ok(_noteRepository.GetAllByUser(userId));
            }
            catch (InvalidOperationException)
            {
                return NotFound();
            }
        }
    }
}