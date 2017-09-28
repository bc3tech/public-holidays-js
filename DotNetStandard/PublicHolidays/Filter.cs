using System;

namespace PublicHolidays
{
    public class Filter
    {
        public Filter(string country = @"us", string language = @"en")
        {
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));

            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentNullException(nameof(language));

            this.Country = country;
            this.Language = language;
        }

        public string Country { get; }
        public string Language { get; }

        internal bool Matches(dynamic holiday, dynamic options)
        {
            if (options.start && holiday.start < options.start)
            {
                return false;
            }
            if (options.end && holiday.end > options.end)
            {
                return false;
            }

            return true;
        }
    }
}
