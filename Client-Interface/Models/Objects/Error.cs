using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerAppDemo.Models.Objects
{
    public class Error
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
        [JsonProperty("httpStatus")]
        public int HttpStatus { get; set; }
        // public string[] implementationDetails { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
