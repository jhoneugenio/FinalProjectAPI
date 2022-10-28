using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectHTTP.DataModels
{
    public class BookingJson
    {
        [JsonProperty("bookingid")]
        public int BookingId { get; set; }

        [JsonProperty("booking")]
        public GetBookingJson Booking { get; set; }
    }
}
