﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical_App_1.Shared.Models
{
    public class Result<T>
    {
        public bool Status { get; set; }
        public List<string> Message { get; set; }
        public T Data { get; set; }
    }
}
