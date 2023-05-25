import { CreationAuditedEntityDto } from "../../base/entity";

export class CreateApiScope {
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

export class ApiScopeDto extends CreationAuditedEntityDto {
    name: string;
    displayName: string;
    description: string;
    showInDiscoveryDocument: boolean;
    required: boolean;
    emphasize: string;
    enabled: boolean;
    userClaims: string[];
}