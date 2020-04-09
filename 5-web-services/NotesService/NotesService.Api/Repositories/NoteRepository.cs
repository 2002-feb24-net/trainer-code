using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesService.Api.Models;

namespace NotesService.Api.Repositories
{
    public class NoteRepository : INoteRepository
    {
        private readonly List<Note> _notes;
        private readonly List<Tag> _tags;
        private readonly List<User> _users;

        public NoteRepository()
        {
            _users = new List<User>
            {
                new User { Id = 1, Name = "Harold" },
                new User { Id = 2, Name = "Nick" }
            };

            _tags = new List<Tag>
            {
                new Tag { Id = 1, Name = "services" },
                new Tag { Id = 2, Name = "basic" },
                new Tag { Id = 3, Name = "advanced" }
            };

            _notes = new List<Note>
            {
                new Note {
                    Id = 1,
                    Author = _users.First(u => u.Name == "Nick"),
                    IsPublic = true,
                    Text = "REST stands for representational state transfer",
                    Tags = new List<Tag>
                    {
                        _tags.First(t => t.Name == "services"),
                        _tags.First(t => t.Name == "basic")
                    }
                },
                new Note {
                    Id = 2,
                    Author = _users.First(u => u.Name == "Harold"),
                    IsPublic = false,
                    Text = "C# is an OOP language",
                    Tags = new List<Tag>
                    {
                        _tags.First(t => t.Name == "basic")
                    }
                }
            };
        }

        public IEnumerable<Note> GetAll()
        {
            return _notes.ToList();
        }

        public Note GetById(int id)
        {
            return _notes.FirstOrDefault(n => n.Id == id);
        }

        public void Add(Note note)
        {
            note.Id = _notes.Max(n => n.Id) + 1;
            _notes.Add(note);
        }

        public void Remove(Note note)
        {
            _notes.Remove(note);
        }
    }
}
