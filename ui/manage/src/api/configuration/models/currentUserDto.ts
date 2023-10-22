export interface currentUserDto {
    isAuthenticated: boolean;
    id: string;
    tenanId: string;
    impersonatorUserId: string;
    impersonatorTenantId: string;
    impersonatorUserName: string;
    impersonatorTenantName: string;
    userName: string;
    name: string;
    surName: string;
    email: string;
    emailVerified: boolean;
    phoneNumber: string;
    phoneNumberVerified: boolean;
    roles: string[];
}

export class UserInfoState {
    isAuthenticated: boolean;
    id: string;
    tenanId: string;
    impersonatorUserId: string;
    impersonatorTenantId: string;
    impersonatorUserName: string;
    impersonatorTenantName: string;
    userName: string;
    name: string;
    surName: string;
    email: string;
    emailVerified: boolean;
    phoneNumber: string;
    phoneNumberVerified: boolean;
    roles: string[];
    photo: string;
}