﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.ApiModel
{
    public class ApiViewUser : ApiBaseEntity
    {
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
