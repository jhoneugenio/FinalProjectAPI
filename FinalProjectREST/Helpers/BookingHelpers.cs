using FinalProjectREST.DataModels;
using FinalProjectREST.Resources;
using FinalProjectREST.Tests.TestData;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectREST.Helpers
{
    public class BookingHelper
    {
        public static async Task<RestResponse<BookingJson>> AddNewBooking(RestClient restClient)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var postRequest = new RestRequest(Endpoints.BaseBookingMethod).AddJsonBody(GenerateBooking.bookingDetails());

            return await restClient.ExecutePostAsync<BookingJson>(postRequest);
        }

        public static async Task<RestResponse<GetBookingJson>> GetBookingById(RestClient restClient, int bookingId)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var getRequest = new RestRequest(Endpoints.MethodByBookingById(bookingId));

            return await restClient.ExecuteGetAsync<GetBookingJson>(getRequest);
        }

        public static async Task<RestResponse> DeleteBookingById(RestClient restClient, int bookingId)
        {
            var token = await GetAuthToken(restClient);
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");
            restClient.AddDefaultHeader("Cookie", "token=" + token);

            var getRequest = new RestRequest(Endpoints.MethodByBookingById(bookingId));

            return await restClient.DeleteAsync(getRequest);
        }

        public static async Task<RestResponse<GetBookingJson>> UpdateBookingById(RestClient restClient, GetBookingJson booking, int bookingId)
        {
            var token = await GetAuthToken(restClient);
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");
            restClient.AddDefaultHeader("Cookie", "token=" + token);

            var putRequest = new RestRequest(Endpoints.MethodByBookingById(bookingId)).AddJsonBody(booking);

            return await restClient.ExecutePutAsync<GetBookingJson>(putRequest);
        }

        private static async Task<string> GetAuthToken(RestClient restClient)
        {
            restClient = new RestClient();
            restClient.AddDefaultHeader("Accept", "application/json");

            var postRequest = new RestRequest(Endpoints.GenerateToken).AddJsonBody(Authentication.userTokenDetails());
            var generateToken = await restClient.ExecutePostAsync<TokenJson>(postRequest);

            return generateToken.Data.Token;
        }
    }
}
