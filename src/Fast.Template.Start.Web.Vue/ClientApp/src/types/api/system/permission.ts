export class permissionListResultDto {
    entityDisplayName: string;
    groups: Array<permissionGroupDto>;
}

class permissionGroupDto {
    name: string;
    displayName: string;
    permissions: Array<permissionGrantInfoDto>;
}

class permissionGrantInfoDto {
    name: string;
    displayName: string;
    parentName: string;
    isGranted: boolean;
    allowProviders: Array<string>;
    grantedProviders: Array<providerInfoDto>;
}

class providerInfoDto {
    providerName: string;
    orividerKey: string;
}