using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectREST.DataModels
{
    public class TokenJson
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
