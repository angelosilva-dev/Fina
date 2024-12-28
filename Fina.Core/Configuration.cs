using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core
{
    public static class Configuration
    {
        public const int DefaultPageNumber = 1;
        public const int DefaultPageSize = 25;
        public const int DefaultStatusCode = 200;

        //Api - Backend
        public static string BackendUrl { get; set; } = "http://localhost:5092";

        //Web - Frontend
        public static string FrontendUrl { get; set; } = "http://localhost:5106";
    }
}
