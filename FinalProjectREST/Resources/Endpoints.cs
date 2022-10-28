﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectREST.Resources
{
    public class Endpoints
    {
        public const string baseURL = "https://restful-booker.herokuapp.com/";
        public const string UserEndpoint = "booking";
        public const string AuthEndpoint = "auth";

        public static string MethodByBookingById(int bookingId) => $"{baseURL}{UserEndpoint}/{bookingId}";
        public static string BaseBookingMethod => $"{baseURL}{UserEndpoint}";
        public static string GenerateToken => $"{baseURL}{AuthEndpoint}";
    }
}
