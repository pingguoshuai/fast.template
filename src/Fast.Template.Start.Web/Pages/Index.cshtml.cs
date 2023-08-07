using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Fast.Template.Start.Web.Pages;

public class IndexModel : StartPageModel
{
    public void OnGet()
    {

    }

    public async Task OnPostLoginAsync()
    {
        await HttpContext.ChallengeAsync("oidc");
    }
}
