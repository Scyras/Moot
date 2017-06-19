using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Moot.Model
{
    public class Event
    {
        public DateTime StartAt { get; set; }

        public int Duration { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Uri WebLink { get; set; }
    }
}
