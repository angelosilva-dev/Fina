﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fina.Core.Requests
{
    //Não pode ser instaciada, só pode ser herdada
    public abstract class Request
    {
        public string UserId { get; set; } = string.Empty;
    }
}