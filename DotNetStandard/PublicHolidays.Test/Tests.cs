using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace PublicHolidays.Test
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void FetchUsHolidays()
        {
            try
            {
                var holidays =
                Holidays.GetAsync(new Filter()).GetAwaiter().GetResult();

                Assert.IsNotNull(holidays);
                Assert.IsTrue(holidays.Any());

                foreach (var h in holidays)
                {
                    Console.WriteLine(h.ToString());
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FetchCanadianHolidays()
        {
            try
            {
                var holidays =
                Holidays.GetAsync(new Filter(@"ca", @"fr")).GetAwaiter().GetResult();

                Assert.IsNotNull(holidays);
                Assert.IsTrue(holidays.Any());

                foreach (var h in holidays)
                {
                    Console.WriteLine(h.ToString());
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetThanksgiving()
        {
            try
            {
                var holidays =
                Holidays.GetAsync(new Filter(name: @"thanksgiving")).GetAwaiter().GetResult();

                Assert.IsNotNull(holidays);
                Assert.IsTrue(holidays.Any(), @"No holidays found");

                foreach (var h in holidays)
                {
                    Console.WriteLine(h.ToString());
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.ToString());
            }

            Assert.IsTrue(true);
        }
    }
}
