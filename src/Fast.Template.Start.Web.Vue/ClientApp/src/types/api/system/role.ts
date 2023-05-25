export class createRoleDto {
    name: string;
    isDefault: boolean;
    isPublic: boolean = true;
}

export class roleDto {
    id: string;
    name: string;
    isDefault: boolean;
    isStatic: boolean;
    isPublic: boolean;
}