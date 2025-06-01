using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleCalTracker
{
    public class EventItem
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public EventItem(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }

    }
}
