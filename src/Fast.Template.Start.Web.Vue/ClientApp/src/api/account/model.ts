export class ProfileDto {
    userName: string;
    email: string;
    name: string;
    surName: string;
    phoneNumber: string;
    isExternal: boolean;
    hasPassword: boolean;
    concurrencyStamp: string;
}

export class changePasswordInput {
    currentPassword: string;
    newPassword: string;
}