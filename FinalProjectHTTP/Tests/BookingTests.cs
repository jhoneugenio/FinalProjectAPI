using FinalProjectHTTP.DataModels;
using FinalProjectHTTP.Resources;
using FinalProjectHTTP.Helpers;
using FinalProjectHTTP.Tests.TestData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

[assembly: Parallelize(Workers = 10, Scope = ExecutionScope.MethodLevel)]
namespace FinalProjectHTTP.Tests
{
    [TestClass]
    public class BookingTests
    {
        private BookingHelpers _bookingHelpers;

        [TestMethod]
        public async Task CreateBooking()
        {
            _bookingHelpers = new BookingHelpers();

            #region create data
            var addBooking = await _bookingHelpers.AddNewBooking();
            var getResponse = JsonConvert.DeserializeObject<BookingJson>(addBooking.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(addBooking.StatusCode, HttpStatusCode.OK);
            #endregion

            #region get created data
            var getCreatedBooking = await _bookingHelpers.GetBookingById(getResponse.BookingId);
            var getCreatedBookingResponse = JsonConvert.DeserializeObject<GetBookingJson>(getCreatedBooking.Content.ReadAsStringAsync().Result);
            #endregion

            #region assert created data
            var expectedData = GenerateBooking.bookingDetails();
            Assert.AreEqual(expectedData.Firstname, getCreatedBookingResponse.Firstname);
            Assert.AreEqual(expectedData.Lastname, getCreatedBookingResponse.Lastname);
            Assert.AreEqual(expectedData.Totalprice, getCreatedBookingResponse.Totalprice);
            Assert.AreEqual(expectedData.Depositpaid, getCreatedBookingResponse.Depositpaid);
            Assert.AreEqual(expectedData.Bookingdates.Checkin, getCreatedBookingResponse.Bookingdates.Checkin);
            Assert.AreEqual(expectedData.Bookingdates.Checkout, getCreatedBookingResponse.Bookingdates.Checkout);
            Assert.AreEqual(expectedData.Additionalneeds, getCreatedBookingResponse.Additionalneeds);
            #endregion

            #region clean test data
            await _bookingHelpers.DeleteBookingById(getResponse.BookingId);
            #endregion
        }

        [TestMethod]
        public async Task UpdateBooking()
        {
            _bookingHelpers = new BookingHelpers();

            #region create data
            var addBooking = await _bookingHelpers.AddNewBooking();
            var getResponse = JsonConvert.DeserializeObject<BookingJson>(addBooking.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(addBooking.StatusCode, HttpStatusCode.OK);
            #endregion

            #region get created data
            var getCreatedBooking = await _bookingHelpers.GetBookingById(getResponse.BookingId);
            var getCreatedBookingResponse = JsonConvert.DeserializeObject<GetBookingJson>(getCreatedBooking.Content.ReadAsStringAsync().Result);
            #endregion

            #region update data
            var updatedData = new GetBookingJson()
            {
                Firstname = "Team.put.updated",
                Lastname = "Spirit.put.updated",
                Totalprice = getCreatedBookingResponse.Totalprice,
                Depositpaid = getCreatedBookingResponse.Depositpaid,
                Bookingdates = getCreatedBookingResponse.Bookingdates,
                Additionalneeds = getCreatedBookingResponse.Additionalneeds
            };

            var updateBooking = await _bookingHelpers.UpdateBookingById(updatedData, getResponse.BookingId);
            var getUpdateBookingResponse = JsonConvert.DeserializeObject<BookingJson>(updateBooking.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(updateBooking.StatusCode, HttpStatusCode.OK);
            #endregion

            #region get updated data
            var getUpdatedBooking = await _bookingHelpers.GetBookingById(getResponse.BookingId);
            var getUpdatedBookingResponse = JsonConvert.DeserializeObject<GetBookingJson>(getUpdatedBooking.Content.ReadAsStringAsync().Result);
            #endregion

            #region assert updated data
            Assert.AreEqual(updatedData.Firstname, getUpdatedBookingResponse.Firstname);
            Assert.AreEqual(updatedData.Lastname, getUpdatedBookingResponse.Lastname);
            Assert.AreEqual(updatedData.Totalprice, getUpdatedBookingResponse.Totalprice);
            Assert.AreEqual(updatedData.Depositpaid, getUpdatedBookingResponse.Depositpaid);
            Assert.AreEqual(updatedData.Bookingdates.Checkin, getUpdatedBookingResponse.Bookingdates.Checkin);
            Assert.AreEqual(updatedData.Bookingdates.Checkout, getUpdatedBookingResponse.Bookingdates.Checkout);
            Assert.AreEqual(updatedData.Additionalneeds, getUpdatedBookingResponse.Additionalneeds);
            #endregion

            #region clean test data
            await _bookingHelpers.DeleteBookingById(getResponse.BookingId);
            #endregion
        }

        [TestMethod]
        public async Task DeleteCreatedBooking()
        {
            _bookingHelpers = new BookingHelpers();

            #region create data
            var addBooking = await _bookingHelpers.AddNewBooking();
            var getResponse = JsonConvert.DeserializeObject<BookingJson>(addBooking.Content.ReadAsStringAsync().Result);

            Assert.AreEqual(addBooking.StatusCode, HttpStatusCode.OK);
            #endregion

            #region delete test data
            var deleteBooking = await _bookingHelpers.DeleteBookingById(getResponse.BookingId);
            #endregion

            #region assert if data was successfully deleted
            Assert.AreEqual(deleteBooking.StatusCode, HttpStatusCode.Created);
            #endregion
        }

        [TestMethod]
        public async Task GetInvalidBookingId()
        {
            _bookingHelpers = new BookingHelpers();
            Random random = new Random();
            int randomNumber = random.Next(696969, 6969696);

            #region get created data
            var getCreatedBooking = await _bookingHelpers.GetBookingById(randomNumber);
            #endregion

            #region assert invalid data
            Assert.AreEqual(getCreatedBooking.StatusCode, HttpStatusCode.NotFound);
            #endregion

        }
    }
}
