using FinalProjectHTTP.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectHTTP.Tests.TestData
{
    public class GenerateBooking
    {
        public static GetBookingJson bookingDetails()
        {
            DateTime dt = DateTime.UtcNow.Date;
            Bookingdates bookingDates = new Bookingdates();
            bookingDates.Checkin = dt;
            bookingDates.Checkout = dt.AddDays(1);

            return new GetBookingJson
            {
                Firstname = "EYPIAY",
                Lastname = "PAYNAL EKSAM",
                Totalprice = 69,
                Depositpaid = true,
                Bookingdates = bookingDates,
                Additionalneeds = "Promotional stuff"
            };
        }
    }
}
