using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCalTracker
{
    public class EventType
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public List<string>? tags { get; set; }

        public EventType(int Id, string Name, List<string> ? tags)
        {
            this.Id = Id;
            this.Name = Name;
            if(tags != null)
            {
                this.tags = new List<string>();
                foreach(string tag in tags) this.tags.Add(tag);
            }
        }

    }
}
