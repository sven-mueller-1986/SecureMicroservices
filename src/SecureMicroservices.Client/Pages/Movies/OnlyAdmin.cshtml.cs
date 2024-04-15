using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SecureMicroservices.Client.Authentication;
using SecureMicroservices.Client.Models;

namespace SecureMicroservices.Client.Pages.Movies
{
    [Authorize(Roles = "admin")]
    public class OnlyAdminModel(IIdentityApi identityApi)
        : PageModel
    {
        public string UserInfo { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            UserInfo = await identityApi.GetUserInfoAsync();

            //var userInfoDictionary = new Dictionary<string, string>();

            //foreach (var claim in userInfoResponse.Claims) 
            //{ 
            //    userInfoDictionary.Add(claim.Type, claim.Value);
            //}

            //UserInfo = new UserInfoViewModel(userInfoDictionary);

            return Page();
        }
    }
}
