import { AxiosPromise } from "axios";
import { apiConfig } from "/@/config";
import { createIdentityUserDto, identityUserDto, identityUserUpdateRolesDto, claimDto } from "/@/api/system/identityuser/model";
import { IPageRequestQuery } from "/@/types/base/querybase";
import request from "/@/utils/request";
import { baseService } from "../../baseService";
import { ListResultDto } from "/@/types/base/listresultdto";
import { roleDto } from "../role/model";

export class userService extends baseService<identityUserDto, createIdentityUserDto, IPageRequestQuery> {
    constructor() {
        super("/api/identity/users")
    }

    getRolesAsync(id: string) {
        return request({
            url: `/api/identity/users/${id}/roles`,
            method: 'GET',
            baseURL: apiConfig.AccountUrl
        });
    }

    getAssignableRolesAsync(): AxiosPromise<ListResultDto<roleDto>> {
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
    }

    removeClaimAsync(id: string, input: claimDto) {
        return request({
            url: `/api/identity/users/${id}/remove-claim?ClaimType=${input.claimType}&ClaimValue=${input.claimValue}`,
            method: 'DELETE',
            baseURL: apiConfig.AccountUrl
        });
    }
}

export default new userService();