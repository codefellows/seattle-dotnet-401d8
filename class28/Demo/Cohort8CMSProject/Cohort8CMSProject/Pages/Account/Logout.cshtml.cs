﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cohort8CMSProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cohort8CMSProject.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private SignInManager<ApplicationUser> _signInManager;

        public LogoutModel(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;

        }   

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}