using System.Collections.Generic;
using NotesService.Api.Models;

namespace NotesService.Api.Repositories
{
    public interface INoteRepository
    {
        void Add(Note note);

        IEnumerable<Note> GetAll();

        Note GetById(int id);

        void Remove(Note note);
    }
}
