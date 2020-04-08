using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesService.Api.Models
{
    public class Note
    {
        public int Id { get; set; }

        public string Author { get; set; }

        public bool IsPublic { get; set; }

        public string Text { get; set; }
    }
}
