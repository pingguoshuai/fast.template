export interface UpdatePermissionDto {
    name: string;
    IsGranted: boolean;
}

export interface GetPermissionListResultDto {
    entityDisplayName: string;
    groups: PermissionGroupDto[];
}

export interface PermissionGroupDto {
    name: string;
    displayName: string;
    dispalyNameKey: string;
    dispalyNameResource: string;
    permissions: PermissionGrantInfoDto[];
}

export interface PermissionGrantInfoDto {
    name: string;
    dispalyName: string;
    parentName: string;
    isGranted: boolean;
    allowedProviders: string[];
    grantedProvides: ProviderInfoDto[];
}

export interface ProviderInfoDto {
    providerName: string;
    ProviderKey: string;
}