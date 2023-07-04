export class ProfileDto {
    userName: string;
    email: string;
    name: string;
    surname: string;
    phoneNumber: string;
    isExternal: boolean;
    hasPassword: boolean;
    concurrencyStamp: string;
    extraProperties: any;
}

export class changePasswordInput {
    currentPassword: string;
    newPassword: string;
    confirmPassword: string;
}