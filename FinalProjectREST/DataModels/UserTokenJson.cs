using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectREST.DataModels
{
    public class UserTokenJson
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
