using FinalProjectREST.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectREST.Tests.TestData
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
                Firstname = "ABODYAT",
                Lastname = "REST",
                Totalprice = 18,
                Depositpaid = true,
                Bookingdates = bookingDates,
                Additionalneeds = "None"
            };
        }
    }
}
