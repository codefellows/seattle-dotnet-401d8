﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cohort8CMSProject.Models.Handlers
{
    public class RequiredEmailRequirement : IAuthorizationRequirement
    {
        public RequiredEmailRequirement()
        {

        }
    }
}
