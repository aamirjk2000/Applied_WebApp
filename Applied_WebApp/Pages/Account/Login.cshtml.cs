using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace Applied_WebApp.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential MyCredential { get; set; }


        public void OnGet()
        {
            Credential MyCredential = new Credential();
            MyCredential.Username = "Admin";
            MyCredential.Password = "Password";

            

        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();

            if (MyCredential.Username == "Admin" && MyCredential.Password == "Password")
            {
                var Claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "Admin"),
                    new Claim(ClaimTypes.Email, "aamir@jahangir.com")
                };

                var Identity = new ClaimsIdentity(Claims, "MyCookieAuth");
                ClaimsPrincipal MyClaimsPrincipal = new ClaimsPrincipal(Identity);
                await HttpContext.SignInAsync("MyCookieAuth", MyClaimsPrincipal);

                return Redirect("/Index2");

            }
            return Page();

        }
    }
    public class Credential
    {
        [Required]
        public string Username { get; set; } = "User Name";

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}

