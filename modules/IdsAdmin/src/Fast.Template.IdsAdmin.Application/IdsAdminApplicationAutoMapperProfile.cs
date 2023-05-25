using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Fast.Template.IdsAdmin.ApiResources.Dtos;
using Fast.Template.IdsAdmin.ApiScopes.Dtos;
using Fast.Template.IdsAdmin.Clients.Dtos;
using Fast.Template.IdsAdmin.IdentityResources.Dtos;
using Volo.Abp.IdentityServer.ApiResources;
using Volo.Abp.IdentityServer.ApiScopes;
using Volo.Abp.IdentityServer.Clients;
using Volo.Abp.IdentityServer.IdentityResources;

namespace Fast.Template.IdsAdmin;

public class IdsAdminApplicationAutoMapperProfile : Profile
{
    public IdsAdminApplicationAutoMapperProfile()
    {
        #region ApiScope

        CreateMap<ApiScope, ApiScopeDto>();
        CreateMap<CreateApiScopeDto, ApiScope>(MemberList.Source);
        CreateMap<ApiScopePropertyDto, ApiScopeProperty>(MemberList.Source);
        CreateMap<ApiScopeProperty, ApiScopePropertyDto>();

        #endregion

        #region IdentityResource

        CreateMap<IdentityResource, IdentityResourceDto>();
        CreateMap<CreateIdentityResourceDto, IdentityResource>(MemberList.Source);
        CreateMap<IdentityResourceProperty, IdentityResourcePropertyDto>();
        CreateMap<IdentityResourcePropertyDto, IdentityResourceProperty>(MemberList.Source);
        #endregion

        #region ApiResources

        CreateMap<ApiResource, ApiResourceDto>(MemberList.None)
            .ForMember(dest => dest.AllowedAccessTokenSigningAlgorithms,
                m => m.MapFrom(src =>
                    string.IsNullOrEmpty(src.AllowedAccessTokenSigningAlgorithms)
                        ? new List<string>()
                        : src.AllowedAccessTokenSigningAlgorithms.Split(',', System.StringSplitOptions.None).ToList()));
            ;

        CreateMap<CreateApiResourceDto, ApiResource>(MemberList.None).ForMember(
            x => x.AllowedAccessTokenSigningAlgorithms,
            m => m.MapFrom(src => string.Join(",", src.AllowedAccessTokenSigningAlgorithms)));

        CreateMap<ApiResourceSecret, ApiResourceSecretDto>(MemberList.None);
        CreateMap<ApiResourceSecretDto, ApiResourceSecret>(MemberList.None);

        CreateMap<ApiResourceProperty, ApiResourcePropertyDto>();
        CreateMap<ApiResourcePropertyDto, ApiResourceProperty>(MemberList.Source);

        CreateMap<ApiResourceClaim, string>()
            .ConstructUsing(x => x.Type)
            .ReverseMap()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

        #endregion

        #region Client

        CreateMap<Client, ClientDto>()
            .ForMember(dest => dest.AllowedIdentityTokenSigningAlgorithms,
                m => m.MapFrom(src =>
                    string.IsNullOrEmpty(src.AllowedIdentityTokenSigningAlgorithms)
                        ? new List<string>()
                        : src.AllowedIdentityTokenSigningAlgorithms.Split(',', System.StringSplitOptions.None)
                            .ToList()));

        CreateMap<CreateClientDto, Client>(MemberList.None).ForMember(
            x => x.AllowedIdentityTokenSigningAlgorithms,
            m => m.MapFrom(src => string.Join(",", src.AllowedIdentityTokenSigningAlgorithms)));

        CreateMap<ClientSecret, ClientSecretDto>(MemberList.None);
        CreateMap<ClientSecretDto, ClientSecret>(MemberList.None);

        CreateMap<ClientProperty, ClientPropertyDto>();
        CreateMap<ClientPropertyDto, ClientProperty>(MemberList.Source);

        CreateMap<ClientClaim, ClientClaimDto>();
        CreateMap<ClientClaimDto, ClientClaim>(MemberList.Source);
        #endregion
    }
}
