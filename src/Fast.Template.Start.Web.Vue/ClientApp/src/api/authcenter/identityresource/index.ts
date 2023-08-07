import { createIdentityResourceDto, identityResourceDto } from "/@/types/api/authcenter/identityresource";
import { AxiosPromise } from "axios";
import request from "/@/utils/request";
import { PageResult } from "/@/types/base/pageresult";
import { IPageRequestQuery } from "/@/types/base/querybase";

export class identityResource {
    createAsync(input: createIdentityResourceDto): AxiosPromise<identityResourceDto> {
        return request({
            url: '/api/IdsAdmin/identity-resource',
            method: 'POST',
            data: input
        });
    }

    updateAsync(id: string, input: createIdentityResourceDto): AxiosPromise<identityResourceDto> {
        return request({
            url: `/api/IdsAdmin/identity-resource/${id}`,
            method: 'PUT',
            data: input
        });
    }
    getListAsync(input: IPageRequestQuery): AxiosPromise<PageResult<identityResourceDto>> {
        return request({
            url: '/api/IdsAdmin/identity-resource',
            method: 'get',
            params: input
        });
    }
    deleteAsync(id: string) {
        return request({
            url: `/api/IdsAdmin/identity-resource/${id}`,
            method: 'DELETE'
        });
    }
    getAsync(id: string) {
        return request({
            url: `/api/IdsAdmin/identity-resource/${id}`,
            method: 'GET'
        });
    }
}