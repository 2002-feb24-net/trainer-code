using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Api.Models
{
    public class Note
    {
        public int Id { get; set; }

        public User Author { get; set; }

        public bool IsPublic { get; set; }

        public string Text { get; set; }

        public DateTime DateModified { get; set; } = DateTime.Now;

        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    }
}
