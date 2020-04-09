using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NotesService.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [JsonIgnore]
        public List<Note> Notes { get; set; }
    }
}
