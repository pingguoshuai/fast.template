import { CreationAuditedEntityDto } from "/@/types/base/entity";

export class createClientDto {
    clientId: string;
    clientName: string;
    description: string;
    protocolType: string = "oidc";
    enabled: boolean = true;
    allowedScopes: string[];
    allowedGrantTypes: string[];
}

export class updateClientDto {
    clientId: string;
    clientName: string;
    protocolType: string = "oidc";
    description: string;
    enabled: boolean = true;
    allowedScopes: string[];
    allowedGrantTypes: string[];
    requireClientSecret: boolean;

    requireConsent: boolean = false;
    clientUri: string;
    logoUri: string;
    allowRememberConsent: boolean = true;
    alwaysIncludeUserClaimsInIdToken: boolean = false;
    requirePkce: boolean = true;
    allowPlainTextPkce: boolean = false;
    allowAccessTokensViaBrowser: boolean = false;
    allowOfflineAccess: boolean = false;
    redirectUris: Array<string>;


    requireRequestObject: boolean = false;
    frontChannelLogoutUri: string;
    frontChannelLogoutSessionRequired: string;
    backChannelLogoutSessionRequired: boolean = true;
    backChannelLogoutUri: string;
    postLogoutRedirectUris: Array<string>;
    identityProviderRestrictions: Array<string>;
    userSsoLifetime?: number;

    identityTokenLifetime: number = 300;
    allowedIdentityTokenSigningAlgorithms: string[];
    accessTokenLifetime: number = 3600;
    accessTokenType: number = 0;
    authorizationCodeLifetime: number = 300;
    consentLifetime?: number;
    absoluteRefreshTokenLifetime: number = 2592000;
    slidingRefreshTokenLifetime: number = 1296000;
    refreshTokenUsage: number = 1;
    refreshTokenExpiration: number;
    allowedCorsOrigins: Array<string>;
    updateAccessTokenClaimsOnRefresh: boolean = false;
    enableLocalLogin: boolean = true;
    includeJwtId: boolean = true;
    alwaysSendClientClaims: boolean = false;
    clientClaimsPrefix: string = 'client_';
    pairWiseSubjectSalt: string;

    userCodeType: string;
    deviceCodeLifetime: number = 300;
}

export class clientDto extends CreationAuditedEntityDto {
    clientId: string;
    clientName: string;
    description: string;
    protocolType: string;
    enabled: boolean;
    allowedScopes: string[];
    allowedGrantTypes: string[];
}