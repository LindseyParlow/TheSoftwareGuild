﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringOrderingSystem.Models.Responses
{
    public abstract class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
