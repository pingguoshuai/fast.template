import { AxiosPromise } from "axios";
import { apiConfig } from "/@/config";
import { roleDto } from "/@/types/api/system/role";
import { claimDto } from "/@/types/api/system/user/claim";
import { createIdentityUserDto, identityUserDto, identityUserUpdateRolesDto } from "/@/types/api/system/user/identityuser";
import { PageResult } from "/@/types/base/pageresult";
import { IPageRequestQuery } from "/@/types/base/querybase";
import request from "/@/utils/request";

export class userService {
    createAsync(input: createIdentityUserDto): AxiosPromise<identityUserDto> {
        return request({
            url: '/api/identity/users',
            method: 'POST',
            data: input,
            baseURL: apiConfig.AccountUrl
        });
    }

    updateAsync(id: string, input: createIdentityUserDto): AxiosPromise<identityUserDto> {
        return request({
            url: `/api/identity/users/${id}`,
            method: 'PUT',
            data: input,
            baseURL: apiConfig.AccountUrl
        });
    }
    getListAsync(input: IPageRequestQuery): AxiosPromise<PageResult<identityUserDto>> {
        return request({
            url: '/api/identity/users',
            method: 'get',
            params: input,
            baseURL: apiConfig.AccountUrl
        });
    }
    deleteAsync(id: string) {
        return request({
            url: `/api/identity/users/${id}`,
            method: 'DELETE',
            baseURL: apiConfig.AccountUrl
        });
    }
    getAsync(id: string) {
        return request({
            url: `/api/identity/users/${id}`,
            method: 'GET',
            baseURL: apiConfig.AccountUrl
        });
    }

    getRolesAsync(id: string) {
        return request({
            url: `/api/identity/users/${id}/roles`,
            method: 'GET',
            baseURL: apiConfig.AccountUrl
        });
    }

    getAssignableRolesAsync() {
        return request({
            url: `/api/identity/users/assignable-roles`,
            method: 'GET',
            baseURL: apiConfig.AccountUrl
        });
    }

    updateRolesAsync(id: string, input: identityUserUpdateRolesDto) {
        return request({
            url: `/api/identity/users/${id}/roles`,
            method: 'PUT',
            data: input,
            baseURL: apiConfig.AccountUrl
        });
    }

    getByUsernameAsync(userName: string): AxiosPromise<identityUserDto> {
        return request({
            url: `/api/identity/users/find-by-username`,
            method: 'GET',
            params: { userName: userName },
            baseURL: apiConfig.AccountUrl
        });
    }

    getByEmailAsync(email: string): AxiosPromise<identityUserDto> {
        return request({
            url: `/api/identity/users/find-by-email`,
            method: 'GET',
            params: { email: email },
            baseURL: apiConfig.AccountUrl
        });
    }

    getCliamsAsync(id: string): AxiosPromise<claimDto[]> {
        return request({
            url: `/api/identity/users/${id}/claims`,
            method: 'GET',
            baseURL: apiConfig.AccountUrl
        });
    }

    addClaimAsync(id: string, input: claimDto) {
        return request({
            url: `/api/identity/users/${id}/add-claim`,
            method: 'POST',
            data: input,
            baseURL: apiConfig.AccountUrl
        });
    };

    removeClaimAsync(id: string, input: claimDto) {
        return request({
            url: `/api/identity/users/${id}/remove-claim?ClaimType=${input.claimType}&ClaimValue=${input.claimValue}`,
            method: 'DELETE',
            baseURL: apiConfig.AccountUrl
        });
    }
}