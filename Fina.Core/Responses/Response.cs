using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Fina.Core.Responses
{
    public class Response<TData>
    {
        #region Constructor
        [JsonConstructor]
        public Response() => _code = Configuration.DefaultStatusCode;

        public Response(TData? data, int code = Configuration.DefaultStatusCode, string? message = null)
        {
            Data = data;
            Message = message;
            _code = code;
        }
        #endregion

        private int _code = Configuration.DefaultStatusCode;

        public string? Message { get; set; }

        [JsonIgnore]
        public bool IsSuccess => _code >= 200 && _code <= 299;

        public TData? Data { get; set; }
    }
}
