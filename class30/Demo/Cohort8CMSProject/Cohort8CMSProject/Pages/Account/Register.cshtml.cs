using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Cohort8CMSProject.Models;
using Cohort8CMSProject.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cohort8CMSProject.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signinMananger;

        [BindProperty]
        public RegisterViewModel Input { get; set; }
        public string ReturnUrl { get; set; }

        public RegisterModel(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signinMananger = signInManager;
        }
        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");

            if(ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = Input.Email,
                    Email = Input.Email,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    Birthday = Input.Birthday
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    // Custom Type Claim "Full Name"
                    Claim fullNameClaim = new Claim("FullName", $"{user.FirstName} {user.LastName}");

                    // Birthday Claim
                    Claim bdClaim = new Claim(ClaimTypes.DateOfBirth, new DateTime(user.Birthday.Year, user.Birthday.Month, user.Birthday.Day).ToString("u"), ClaimValueTypes.DateTime);

                    // Email Claim
                    Claim emailClaim = new Claim(ClaimTypes.Email, user.Email, ClaimValueTypes.Email);

                    // color Claim
                    Claim colorClaim = new Claim("FavoriteColor", "red");

                List<Claim> myClaims = new List<Claim>
                {
                    fullNameClaim,
                    bdClaim,
                    emailClaim,
                    colorClaim
                };

                    ClaimsIdentity ci = new ClaimsIdentity();
                    ci.AddClaims(myClaims);
                    ClaimsPrincipal cp = new ClaimsPrincipal();
                        cp.AddIdentity(ci);


                   await _userManager.AddClaimsAsync(user, myClaims);

                    if(user.Email.ToLower() == "amanda@codefellows.com")
                    {
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
                        await _userManager.AddToRoleAsync(user, ApplicationRoles.CatLady);

                    }
                    await _userManager.AddToRoleAsync(user, ApplicationRoles.Member);

                    
                    await _signinMananger.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }


            }

            return Page();

        }


    }
}