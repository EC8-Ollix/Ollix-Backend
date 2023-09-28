﻿using Ollix.Domain.ValueObjects;
using Ollix.SharedKernel;
using Ollix.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ollix.Domain.ClientAppAggregate
{
    public class ClientApp : EntityBase
    {
        public string? CompanyName { get; set; }
        public string? BussinessName { get; set; }
        public CNPJ? Cnpj { get; set; }
    }
}