﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Coach : User
    {
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
