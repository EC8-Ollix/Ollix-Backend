﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.UserAggregate
{
    public enum UserType
    {
        [Description("ADMIN")]
        Admin,
        [Description("CLIENT")]
        Client
    }
}