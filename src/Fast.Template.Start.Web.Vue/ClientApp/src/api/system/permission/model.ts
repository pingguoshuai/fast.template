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
    // isAllGranted: boolean = true;

    private _isAllGranted: boolean;

    public get IsAllGranted(): boolean {
        // console.log(111111);
        this._isAllGranted = this.permissions.every((item) => item.isGranted);
        return this._isAllGranted;
    }

    public set IsAllGranted(value: boolean) {
        console.log(111111);
        this._isAllGranted = value;
        this.permissions.forEach((item) => {
            item.isGranted = value;
        })
    }
}

export interface PermissionGrantInfoDto {
    name: string;
    displayName: string;
    parentName: string;
    isGranted: boolean;
    allowedProviders: string[];
    grantedProvides: ProviderInfoDto[];
}

export interface ProviderInfoDto {
    providerName: string;
    ProviderKey: string;
}