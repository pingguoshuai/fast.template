import { AuditedEntityDto } from "/@/types/base/entity";


export class createIdentityResourceDto {
    name: string;
    displayName: string;
    description: string;
    showInDiscoveryDocument: boolean = true;
    required: boolean;
    emphasize: string;
    enabled: boolean = true;
    userClaims: string[];
    constructor() {
    }
}

export class identityResourceDto extends AuditedEntityDto {
    name: string;
    displayName: string;
    description: string;
    showInDiscoveryDocument: boolean = true;
    required: boolean;
    emphasize: string;
    enabled: boolean = true;
    userClaims: string[];
    constructor() {
        super()
    }
}