import { CreationAuditedEntityDto } from "/@/types/base/entity";


class identityUserCreateOrUpdateDto {
    userName: string;
    name: string;
    surname: string;
    email: string;
    phoneNumber: string;
    isActive: boolean;
    lockoutEnabled: boolean;
}

export class createIdentityUserDto extends identityUserCreateOrUpdateDto {
    password: string;
    roleNames: string[];
}

export class identityUserDto extends CreationAuditedEntityDto {
    userName: string;
    name: string;
    surname: string;
    email: string;
    emailConfirmed: boolean;
    phoneNumber: string;
    phoneNumberConfirmed: boolean;
    isActive: boolean;
    lockoutEnabled: boolean;
    lockoutEnd: Date;
    concurrencyStamp: string;
}

export class identityUserUpdateRolesDto {
    roleNames: string[];
}