import { AxiosPromise } from "axios";
import { apiConfig } from "/@/config";
import { createRoleDto, roleDto } from "/@/types/api/system/role";
import { PageResult } from "/@/types/base/pageresult";
import { IPageRequestQuery } from "/@/types/base/querybase";
import request from "/@/utils/request";

export class roleService {
    createAsync(input: createRoleDto) {
        return request({
            url: '/api/identity/roles',
            method: 'POST',
            data: input,
            baseURL: apiConfig.AccountUrl
        });
    }

    updateAsync(id: string, input: createRoleDto) {
        return request({
            url: `/api/identity/roles/${id}`,
            method: 'PUT',
            data: input,
            baseURL: apiConfig.AccountUrl
        });
    }

    getAsync(id: string) {
        return request({
            url: `/api/identity/roles/${id}`,
            method: 'GET',
            baseURL: apiConfig.AccountUrl
        });
    }

    getListAsync(input: IPageRequestQuery): AxiosPromise<PageResult<roleDto>> {
        return request({
            url: '/api/identity/roles',
            method: 'get',
            params: input,
            baseURL: apiConfig.AccountUrl
        });
    }

    deleteAsync(id: string) {
        return request({
            url: `/api/identity/roles/${id}`,
            method: 'DELETE',
            baseURL: apiConfig.AccountUrl
        });
    }
}