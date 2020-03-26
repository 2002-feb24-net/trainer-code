using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcProjectStarter.Models
{
    public class Song
    {
        public int id { get; set; }
        public string title { get; set; }

        public string genre { get; set; }
        public string artist { get; set; }
        public string album { get; set; }

        //annotation
        public DateTime ReleaseDate { get; set; }

    }
}
