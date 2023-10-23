import { CreationAuditedEntityDto } from "/@/types/base/entity";

export class createApiScopeDto {
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

export class apiScopeDto extends CreationAuditedEntityDto {
    name: string;
    displayName: string;
    description: string;
    showInDiscoveryDocument: boolean;
    required: boolean;
    emphasize: string;
    enabled: boolean;
    userClaims: string[];
}