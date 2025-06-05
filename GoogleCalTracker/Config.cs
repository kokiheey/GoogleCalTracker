using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace GoogleCalTracker
{
    public class Config
    {
        public string TimeZone = "Serbia/Belgrade";

        public List<EventType> eventTypes;

        public string calendarId;
    }
}
