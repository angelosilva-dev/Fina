using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Requests
{
    //Não pode ser instaciada, só pode ser herdada
    public abstract class PagedRequest : Request
    {
        public int PageSize { get; set; } = Configuration.DefaultPageSize;
        public int PageNumber { get; set; } = Configuration.DefaultPageNumber;
    }
}
