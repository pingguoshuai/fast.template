export interface UpdatePermissionDto {
    name: string;
    IsGranted: boolean;
}

export class GetPermissionListResultDto {
    entityDisplayName: string;
    groups: PermissionGroupDto[];
}

export class PermissionGroupDto {
    name: string;
    displayName: string;
    displayNameKey: string;
    displayNameResource: string;
    permissions: PermissionGrantInfoDto[];
}

export interface PermissionGrantInfoDto {
    name: string;
    displayName: string;
    parentName: string;
    isGranted: boolean;
    allowedProviders: string[];
    grantedProviders: ProviderInfoDto[];
}

export interface ProviderInfoDto {
    providerName: string;
    ProviderKey: string;
}