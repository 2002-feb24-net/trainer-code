using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcProjectStarter.Data;
using MvcProjectStarter.Models;

namespace MvcProjectStarter.Controllers
{
    public class SongsController : Controller
    {
        // our application has stuff that happens on the server side (in ASP.NET Core, and in the database)
        // as well as a few things that happen on the client side (in the user's browser):
        //    CSS styling, anything in JS, filling out forms, clicking on links
        // we have a need to do input validation in both of these places.

        // client-side validation.
        //   if we don't have this, then the user can have typoed data in 20 different form fields
        //   and he won't see an error message until he clicks "submit".
        // ways to achieve in general: HTML form validation attributes, and JS
        // because it can be bypassed so easily, it's really just for good user experience (immediate feedback)

        // server-side validation.
        //   we need this because the user's browser can't necessarily be trusted.
        //   it's fundamentally necessary for data consistency / security.

        // in ASP.NET Core MVC, the tools we have to achieve those...
        // server-side validation.
        //   first of all, you can just write code that looks at the results of model binding
        //   we have a property on Controller called ModelState
        //   during model binding, the Data Annotations validation attributes are checked
        //      and the errors are stored in ModelState.
        //   this is mostly useful when recieving form data

        // if you render a view with ModelState containing errors (e.g. with a form)
        // then the validation tag helpers (div asp-validation-summary, span asp-validation-for) display those messages.

        // client side validation in ASP.NET Core MVC -
        // _also_ driven by Data Annotations on the viewmodel,
        // with the help of JavaScript written by Microsoft, included in a partial view on the forms
        // the input tag helper generates HTML attributes read by that JavaScript based on Data Annotations

        // so in summary... both server- and client-side validation are implemented
        //   with the help of Data Annotations and tag/HTML helpers.

        private readonly MvcSongContext _context;

        public SongsController(MvcSongContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Song.ToListAsync());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .FirstOrDefaultAsync(m => m.id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("title,genre,artist,album,ReleaseDate")] Song song)
        {
            // check ModelState for any validation errors based on the Data Annotations ValidationAttributes.
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.FindAsync(id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,title,genre,artist,album,ReleaseDate")] Song song)
        {
            if (id != song.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .FirstOrDefaultAsync(m => m.id == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var song = await _context.Song.FindAsync(id);
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(int id)
        {
            return _context.Song.Any(e => e.id == id);
        }
    }
}
