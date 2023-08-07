using System.Collections.Generic;

namespace Fast.Template.IdsAdmin.Consts
{
    public class ClientConst
    {
        public static readonly List<string> StandardClaims = new ()
        {
            "email",
            "role",
            "openid",
            "profile",
            "name",
            "given_name",
            "family_name",
            "middle_name",
            "nickname",
            "preferred_username",
            "picture",
            "website",
            "gender",
            "birthdate",
            "zoneinfo",
            "locale",
            "address",
            "updated_at"
        };

        /// <summary>
        /// 密钥类型
        /// </summary>
        public static readonly List<string> SecretTypes = new()
        {
            "SharedSecret",
            "X509Thumbprint",
            "X509Name",
            "X509CertificateBase64",
            "JWK"
        };

        /// <summary>
        /// 签名算法列表
        /// </summary>
        public static readonly List<string> SigningAlgorithms = new()
        {
            "RS256",
            "RS384",
            "RS512",
            "PS256",
            "PS384",
            "PS512",
            "ES256",
            "ES384",
            "ES512"
        };

        /// <summary>
        /// 授权类型列表
        /// </summary>
        public static readonly List<string> GrantTypes = new()
        {
            "implicit",
            "client_credentials",
            "authorization_code",
            "hybrid",
            "password",
            "urn:ietf:params:oauth:grant-type:device_code",
            "delegation"
        };
    }
}
