using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotesClient.ServiceAccess;
using NotesClient.ServiceAccess.Models;

namespace NotesClient.UI.Controllers
{
    public class NotesController : Controller
    {
        private readonly INotesService _notesService;

        public NotesController(INotesService notesService)
        {
            _notesService = notesService;
        }

        // GET: Notes
        public async Task<ActionResult> Index()
        {
            return View(await _notesService.GetAllAsync());
        }

        // GET: Notes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Notes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Note note)
        {
            try
            {
                await _notesService.AddAsync(note);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                // should provide better error feedback to user
                return View(note);
            }
        }
    }
}
