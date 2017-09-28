using Ical.Net;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PublicHolidays
{
    static class Fetch
    {
        internal static async Task<Calendar> HolidaysAsync(Uri url)
        {
            using (var client = new HttpClient())
            {
                var response = await client.GetStreamAsync(url);

                return Calendar.LoadFromStream(response)?[0];
            }
        }
    }
}
