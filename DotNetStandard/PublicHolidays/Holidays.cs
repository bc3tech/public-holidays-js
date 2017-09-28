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
                .Where(e => e.Start.Date > DateTime.Today
                    && e.Start.Date <= DateTime.Today.AddYears(1)
                    && e.Summary.IndexOf(name ?? string.Empty, StringComparison.OrdinalIgnoreCase) != -1)
                .Select(e => new Event(e.Summary, e.Start.Date));

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

        public override string ToString()
        {
            return $@"{Name}: {Date.ToShortDateString()}";
        }
    }
}
