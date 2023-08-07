using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;
using Volo.Abp.Localization;
using Volo.Abp.IdentityServer.Clients;

namespace Fast.Template.Start.Pages;

public class IndexModel : AbpPageModel
{
    public List<Client> Clients { get; protected set; }

    public IReadOnlyList<LanguageInfo>? Languages { get; protected set; }

    public string? CurrentLanguage { get; protected set; }

    protected IClientRepository ClientRepository { get; }

    protected ILanguageProvider LanguageProvider { get; }

    public IndexModel(IClientRepository clientRepository, ILanguageProvider languageProvider)
    {
        ClientRepository = clientRepository;
        LanguageProvider = languageProvider;
    }

    public async Task OnGetAsync()
    {
        Clients = await ClientRepository.GetListAsync(includeDetails: true);

        Languages = await LanguageProvider.GetLanguagesAsync();
        CurrentLanguage = CultureInfo.CurrentCulture.DisplayName;
    }
}
