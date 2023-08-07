import { AuditedEntityDto } from "../../base/entity";

export class createApiResourceDto {
    name: string;
    displayName: string;
    description: string;
    enabled: boolean = true;
    showInDiscoveryDocument: boolean = true;
    userClaims: string[];
    scopes: string[];
    allowedAccessTokenSigningAlgorithms: string[];
    secrets: apiResourceSecretDto[];
    constructor() {
    }
}

export class apiResourceDto extends AuditedEntityDto {
    name: string;
    displayName: string;
    description: string;
    enabled: boolean = true;
    showInDiscoveryDocument: boolean = true;
    userClaims: string[];
    scopes: string[];
    allowedAccessTokenSigningAlgorithms: string[];
    secrets: apiResourceSecretDto[];
    constructor() {
        super()
    }
}

class apiResourceSecretDto {
    type: string;
    value: string;
    description: string;
    expiration?: Date
}