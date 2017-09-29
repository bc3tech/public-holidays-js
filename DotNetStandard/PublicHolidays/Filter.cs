using System;

namespace PublicHolidays
{
    /// <summary></summary>
    public class Filter
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Filter"/> class.
        /// </summary>
        /// <param name="country">The country whose public holidays calendar should be loaded. Default: United States</param>
        /// <param name="language">The language in which to load the calendar. Default: English</param>
        /// <param name="startDate">The first date on which a public holiday may occur. Default: today</param>
        /// <param name="endDate">The last date on which a public holiday may occur. Default: 1 year from today</param>
        /// <param name="name">The name of the holiday to perform a case-insensitive substring search for.</param>
        /// <exception cref="System.ArgumentNullException">
        /// country
        /// or
        /// language
        /// </exception>
        public Filter(string country = @"us", string language = @"en", DateTime? startDate = null, DateTime? endDate = null, string name = null)
        {
            if (string.IsNullOrWhiteSpace(country)) throw new ArgumentNullException(nameof(country));

            if (string.IsNullOrWhiteSpace(language)) throw new ArgumentNullException(nameof(language));

            this.Country = country;
            this.Language = language;

            this.StartDate = startDate ?? DateTime.Today;
            this.EndDate = endDate ?? DateTime.Today.AddYears(1);
        }

        /// <summary>
        /// Gets or sets the country whose public holidays calendar should be loaded.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the language in which to load the calendar.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the first date on which a public holiday may occur.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Gets or sets the last date on which a public holiday may occur.
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Gets or sets the name of the holiday to search for.
        /// </summary>
        public string Name { get; set; }
    }
}
