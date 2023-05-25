// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MVCFlowerShopWeek3.Areas.Identity.Data;

namespace MVCFlowerShopWeek3.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<MVCFlowerShopWeek3User> _userManager;
        private readonly SignInManager<MVCFlowerShopWeek3User> _signInManager;

        public IndexModel(
            UserManager<MVCFlowerShopWeek3User> userManager,
            SignInManager<MVCFlowerShopWeek3User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Phone]
            [Display(Name = "Phone number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Please enter the customer name!")]
            [Display(Name = "Customer Full Name")]
            [StringLength(100, ErrorMessage = "Only 5 to 100 chars allowed in this column!", MinimumLength = 5)]
            public string CustomerName { get; set; }



            [Required(ErrorMessage = "Please enter the customer Age!")]
            [Display(Name = "Customer Age")]
            [Range(12, 100, ErrorMessage = "This website only allowed chiledr that at least 12 years old!")]
            public int CustomerAge { get; set; }

            [Required(ErrorMessage = "Please enter the customer Address!")]
            [Display(Name = "Customer Address")]
            public string CustomerAddress { get; set; }


            [Required(ErrorMessage = "Please enter the customer Date of Birth!")]
            [Display(Name = "Customer BirthDate")]
            [DataType(DataType.Date)]
            public DateTime CustomerDate { get; set; }
        }

        private async Task LoadAsync(MVCFlowerShopWeek3User user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Username = userName;

            Input = new InputModel
            {
                //left related to input form, righ side related to database table
                PhoneNumber = phoneNumber,
                CustomerName = user.CustomerName,
                CustomerAge = user.CustomerAge,
                CustomerDate = user.CustomerDOB,
                CustomerAddress = user.CustomerAddress
            };
        }

        public async Task<IActionResult> OnGetAsync() //first loading page
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync() //form submssion function
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if(Input.CustomerDate != user.CustomerDOB)
            {
                user.CustomerDOB = Input.CustomerDate;
            }

            if (Input.CustomerAge != user.CustomerAge)
            {
                user.CustomerAge = Input.CustomerAge;
            }

            if (Input.CustomerAddress != user.CustomerAddress)
            {
                user.CustomerAddress = Input.CustomerAddress;
            }

            //update the database using the new user info
            await _userManager.UpdateAsync(user);

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
