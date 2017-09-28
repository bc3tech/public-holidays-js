using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicHolidays
{
    public static class Holidays
    {
        public static async Task<IEnumerable<Event>> GetAsync(Filter filter, string name = null)
        {
            var targetUri = Url.GetFor(filter.Country, filter.Language);

            var calendar = await Fetch.HolidaysAsync(targetUri);

            return calendar.Events
                .Where(e => e.Name.IndexOf(name ?? string.Empty, StringComparison.OrdinalIgnoreCase) != -1)
                .Select(e => new Event(e.Name, e.Start.Date));

        }
    }

    public struct Event
    {
        public Event(string name, DateTime date)
        {
            Name = name;
            Date = date;
        }

        public string Name { get; }
        public DateTime Date { get; }
    }
}
