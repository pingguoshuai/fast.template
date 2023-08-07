using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using IdentityServer4.Models;

namespace Fast.Template.IdsAdmin.Clients.Dtos
{
    public class CreateClientDto
    {
        /// <summary>
        /// 客户端标识
        /// </summary>
        [MaxLength(128)]
        public virtual string ClientId { get; set; }

        /// <summary>
        /// 客户端名称
        /// </summary>
        [MaxLength(128)]
        public virtual string ClientName { get; set; }

        /// <summary>
        /// 协议类型
        /// </summary>
        [MaxLength(64)]
        public virtual string ProtocolType { get; set; } = "oidc";

        /// <summary>
        /// 启用
        /// </summary>
        public virtual bool Enabled { get; set; } = true;

        /// <summary>
        /// 描述
        /// </summary>
        [MaxLength(1024)]
        public virtual string Description { get; set; }

        /// <summary>
        /// 客户端地址
        /// </summary>
        [MaxLength(256)]
        public virtual string ClientUri { get; set; }

        /// <summary>
        /// 客户端logo
        /// </summary>
        [MaxLength(512)]
        public virtual string LogoUri { get; set; }

        /// <summary>
        /// 需要客户端密钥：如果设置为false，则在令牌端点请求令牌时不需要客户端机密
        /// </summary>
        public virtual bool RequireClientSecret { get; set; }

        /// <summary>
        /// 指定是否需要同意屏幕（UI）
        /// </summary>
        public virtual bool RequireConsent { get; set; } = false;

        /// <summary>
        /// 允许记住授权
        /// </summary>
        public virtual bool AllowRememberConsent { get; set; } = true;

        /// <summary>
        /// 始终在身份令牌中包含声明：当同时请求id令牌和访问令牌时，是否应始终将用户声明添加到id令牌，而不是要求客户端使用UserInfo端点
        /// </summary>
        public virtual bool AlwaysIncludeUserClaimsInIdToken { get; set; } = false;

        /// <summary>
        /// 开启Pkce授权校验
        /// </summary>
        public virtual bool RequirePkce { get; set; } = true;

        /// <summary>
        /// 是否可以使用普通方法发送验证密钥（不推荐，默认为false）
        /// </summary>
        public virtual bool AllowPlainTextPkce { get; set; } = false;

        /// <summary>
        /// 控制是否通过此客户端的浏览器传输访问令牌（默认为<c>false</c>）。
        /// 当允许多种响应类型时，这可以防止访问令牌的意外泄漏。
        /// </summary>
        public virtual bool AllowAccessTokensViaBrowser { get; set; } = false;

        /// <summary>
        /// 允许离线访问。默认值为<c>false</c>。
        /// </summary>
        public virtual bool AllowOfflineAccess { get; set; } = false;

        /// <summary>
        /// 重定向uri
        /// </summary>
        public List<string> RedirectUris { get; set; }

        /// <summary>
        /// 作用域
        /// </summary>
        public List<string> AllowedScopes { get; set; }

        /// <summary>
        /// 允许的授权类型
        /// </summary>
        public List<string> AllowedGrantTypes { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        public List<ClientPropertyDto> Properties { get; set; }

        /// <summary>
        /// 客户端密钥
        /// </summary>
        public List<ClientSecretDto> ClientSecrets { get; set; }

        #region 可不填

        /// <summary>
        /// 必须在授权请求上使用请求对象
        /// </summary>
        public virtual bool RequireRequestObject { get; set; } = false;

        /// <summary>
        /// 前端通道注销Uri；
        /// 客户端上基于HTTP前端通道的注销的注销URI。
        /// </summary>
        [MaxLength(512)]
        public virtual string FrontChannelLogoutUri { get; set; }

        /// <summary>
        /// 需要前端通道注销会话
        /// 是否应将用户的会话id发送到FrontChannelLogoutUri。默认值为<c>true</c>。
        /// </summary>
        public virtual bool FrontChannelLogoutSessionRequired { get; set; } = true;

        /// <summary>
        /// 后端通道退出Uri；
        /// 指定客户端上基于HTTP反向通道的注销的注销URI。
        /// </summary>
        [MaxLength(512)]
        public virtual string BackChannelLogoutUri { get; set; }

        /// <summary>
        /// 需要后端通道注销会话；
        /// 是否应将用户的会话id发送到BackChannelLogoutUri。默认值为<c>true</c>
        /// </summary>
        public virtual bool BackChannelLogoutSessionRequired { get; set; } = true;

        /// <summary>
        /// 注销重定向Uri
        /// </summary>
        public virtual List<string> PostLogoutRedirectUris { get; set; }

        /// <summary>
        /// 身份提供程序限制
        /// </summary>
        public virtual List<string> IdentityProviderRestrictions { get; set; }

        /// <summary>
        /// 身份令牌生命周期（秒）（默认为300秒/5分钟）
        /// </summary>
        public virtual int IdentityTokenLifetime { get; set; } = 300;

        /// <summary>
        /// 允许的签名算法列表。如果为空，将使用服务器默认签名算法。
        /// </summary>
        [MaxLength(128)]
        public virtual List<string> AllowedIdentityTokenSigningAlgorithms { get; set; }

        /// <summary>
        /// 访问令牌生命周期（秒）（默认为3600秒/1小时）
        /// </summary>
        public virtual int AccessTokenLifetime { get; set; } = 3600;

        /// <summary>
        /// 访问令牌类型（默认为JWT）。
        /// </summary>
        public virtual int AccessTokenType { get; set; } = 0;

        /// <summary>
        /// 授权码生命周期（秒）（默认为300秒/5分钟）
        /// </summary>
        public virtual int AuthorizationCodeLifetime { get; set; } = 300;

        /// <summary>
        /// 用户同意的生存期（秒）。默认为null（无过期）
        /// </summary>
        public virtual int? ConsentLifetime { get; set; } = null;

        /// <summary>
        /// 刷新令牌的最长生存期（秒）。默认值为2592000秒/30天
        /// </summary>
        public virtual int AbsoluteRefreshTokenLifetime { get; set; } = 2592000;

        /// <summary>
        /// 刷新令牌的滑动生存期（秒）。默认为1296000秒/15天
        /// </summary>
        public virtual int SlidingRefreshTokenLifetime { get; set; } = 1296000;

        /// <summary>
        /// 重用：刷新令牌时，刷新令牌句柄将保持不变
        /// 一次性：刷新令牌时将更新刷新令牌句柄
        /// </summary>
        public virtual int RefreshTokenUsage { get; set; } = TokenUsage.OneTimeOnly.GetHashCode();

        /// <summary>
        /// 绝对：刷新令牌将在固定时间点过期（由绝对刷新令牌生命周期指定）
        /// 滑动：刷新令牌时，刷新令牌的生存期将被更新（按SlidingRefreshTokenLifetime中指定的数量）。寿命不会超过绝对寿命。
        /// </summary>
        public virtual int RefreshTokenExpiration { get; set; }

        /// <summary>
        /// 允许跨域来源
        /// </summary>
        public List<string> AllowedCorsOrigins { get; set; }

        /// <summary>
        /// 是否应在刷新令牌请求时更新访问令牌（及其声明）。
        /// 默认值为<c>false</c>。
        /// </summary>
        public virtual bool UpdateAccessTokenClaimsOnRefresh { get; set; } = false;

        /// <summary>
        /// 客户端是否允许本地登录。默认值为<c>true</c>。
        /// </summary>
        public virtual bool EnableLocalLogin { get; set; } = true;

        /// <summary>
        /// JWT访问令牌是否应包含标识符。默认值为<c>true</c>。
        /// </summary>
        public virtual bool IncludeJwtId { get; set; } = true;

        /// <summary>
        /// 该值指示客户端声明应始终包含在访问令牌中，还是仅包含在客户端凭据流中。
        /// 默认值为<c>false</c>
        /// </summary>
        public virtual bool AlwaysSendClientClaims { get; set; } = false;

        /// <summary>
        /// 客户端声明前缀。默认为<c>client_</c>。
        /// </summary>
        [MaxLength(256)]
        public virtual string ClientClaimsPrefix { get; set; } = "client_";

        /// <summary>
        /// 配对主体盐；
        /// 此客户端的用户在成对主体生成中使用的salt值。
        /// </summary>
        [MaxLength(128)]
        public virtual string PairWiseSubjectSalt { get; set; }

        /// <summary>
        /// 用户SSO生命周期；
        /// 自上次用户身份验证以来的最长持续时间（秒）。
        /// </summary>
        public virtual int? UserSsoLifetime { get; set; }

        /// <summary>
        /// 用户代码类型；
        /// 设备流用户代码的类型。
        /// </summary>
        [MaxLength(128)]
        public virtual string UserCodeType { get; set; }

        /// <summary>
        /// 设备代码生存期。
        /// </summary>
        public virtual int DeviceCodeLifetime { get; set; } = 300;

        #endregion
    }
}
