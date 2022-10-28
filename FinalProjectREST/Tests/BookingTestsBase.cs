using FinalProjectREST.DataModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectREST.Tests
{
    public class BookingTestsBase
    {
        public RestClient RestClient { get; set; }
        public BookingJson BookingDetails { get; set; }

        [TestInitialize]
        public void Initilize()
        {
            RestClient = new RestClient();
        }
    }
}
