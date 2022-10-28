using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProjectHTTP.DataModels
{
    public class TokenJson
    {
        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
