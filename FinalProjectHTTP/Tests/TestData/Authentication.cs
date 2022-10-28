using FinalProjectHTTP.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectHTTP.Tests.TestData
{
    public class Authentication
    {
        public static UserTokenJson userTokenDetails()
        {
            return new UserTokenJson
            {
                Username = "admin",
                Password = "password123"
            };
        }
    }
}
