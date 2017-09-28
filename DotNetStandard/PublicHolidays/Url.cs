using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Reflection;

namespace PublicHolidays
{
    static class Url
    {
        static JObject _countries = JObject.Load(new JsonTextReader(new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(@"PublicHolidays.countries.json"))));

        internal static Uri GetFor(string country, string lang)
        {
            lang = lang.Trim().ToLowerInvariant();
            country = country.Trim().ToLowerInvariant();

            country = _countries.Value<string>(country) ?? country;

            return new Uri($@"https://calendar.google.com/calendar/ical/{lang}.{country}%23holiday%40group.v.calendar.google.com/public/basic.ics");
        }
    }
}
