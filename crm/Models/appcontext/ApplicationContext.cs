﻿using crm.Models.api.server;
using crm.Models.user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crm.Models.appcontext
{
    public class ApplicationContext
    {
        public BaseServerApi ServerApi { get; set; }
        public BaseUser User { get; set; }
        
    }
}
