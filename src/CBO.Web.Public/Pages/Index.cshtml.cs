using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace CBO.Web.Public.Pages;

public class IndexModel : CBOPublicPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
