using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;

namespace GoogleCalTracker
{
    public static class GoogleCalendarApi
    {
        public static async Task<Colors> GetAvailableColorsAsync()
        {
            UserCredential credential;

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { CalendarService.Scope.CalendarReadonly },
                    "user",
                    CancellationToken.None);
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Calendar Tracker",
            });

            Colors colors = await service.Colors.Get().ExecuteAsync();
            return colors;
        }

        public static async Task CreateEvent(EventType eventType, DateTime startTime, DateTime endTime)
        {
            UserCredential credential;
            Config config = ConfigLoader.GetConfig();

            using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
            {
                credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    new[] { CalendarService.Scope.CalendarReadonly },
                    "user",
                    CancellationToken.None);
            }

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "Google Calendar Tracker",
            });

            var newEvent = new Event()
            {
                Summary = eventType.Name,
                Start = new EventDateTime()
                {
                    DateTime = startTime,
                    TimeZone = config.TimeZone,

                },
                End = new EventDateTime()
                {
                    DateTime = endTime,
                    TimeZone = config.TimeZone,
                },
                ColorId = eventType.colorId,
            };

            if(eventType.tags != null)
            {
                Dictionary<string, string> tg = new Dictionary<string, string>();
                int ind = 0;
                foreach (string tag in eventType.tags)
                {
                    tg["t" + ind.ToString()] = tag;
                    ind++;
                }
                newEvent.ExtendedProperties = new Event.ExtendedPropertiesData()
                {
                    Private__ = tg
                };
            }

            var request = service.Events.Insert(newEvent, config.calendarId);
            var response = await request.ExecuteAsync();

            Console.WriteLine($"succes: {response.HtmlLink}");
        }

    }
}
