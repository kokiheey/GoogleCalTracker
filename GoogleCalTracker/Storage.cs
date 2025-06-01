using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
namespace GoogleCalTracker
{
    public static class Storage
    {
        public static string storePath = "items.json";

        public static void Save(List<EventType> items)
        {
            string json = JsonSerializer.Serialize(items);
            File.WriteAllText(storePath, json);
        }

        public static List<EventType> Load()
        {
            if (!File.Exists(storePath)) return new List<EventType>();
            string json = File.ReadAllText(storePath);
            return JsonSerializer.Deserialize<List<EventType>>(json) ?? new List<EventType>();
        }
    }
}
