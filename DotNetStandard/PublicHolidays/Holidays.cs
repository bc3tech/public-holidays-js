using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicHolidays
{
    /// <summary></summary>
    public static class Holidays
    {

        /// <summary>
        /// Gets the holidays for the United States in English for the next year (from today).
        /// </summary>
        /// <returns></returns>
        public static Task<IEnumerable<Event>> GetAsync() => GetAsync(new Filter());

        /// <summary>
        /// Gets the holidays matching <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns></returns>
        public static async Task<IEnumerable<Event>> GetAsync(Filter filter)
        {
            var targetUri = Url.GetFor(filter.Country, filter.Language);

            var calendar = await Fetch.HolidaysAsync(targetUri);

            return calendar.Events
                .Where(e => e.Start.Date > DateTime.Today
                    && e.Start.Date <= DateTime.Today.AddYears(1)
                    && e.Summary.IndexOf(filter.Name ?? string.Empty, StringComparison.OrdinalIgnoreCase) != -1)
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
