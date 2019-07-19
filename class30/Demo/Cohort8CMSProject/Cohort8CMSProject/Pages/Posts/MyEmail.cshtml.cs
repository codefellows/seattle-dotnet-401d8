﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cohort8CMSProject.Pages.Posts
{
    [Authorize(Policy = "CodefellowsEmail")]
    public class MyEmailModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}