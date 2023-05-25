import { IPageRequestQuery } from "../../../types/base/querybase";
import { AxiosPromise } from "axios";
import request from "/@/utils/request";
import { PageResult } from "/@/types/base/pageresult";
import { apiResourceDto, createApiResourceDto } from "/@/types/api/authcenter/apiresource";

export class apiResource {
    createAsync(input: createApiResourceDto): AxiosPromise<apiResourceDto> {
        return request({
            url: '/api/IdsAdmin/api-resource',
            method: 'POST',
            data: input
        });
    }

    updateAsync(id: string, input: createApiResourceDto): AxiosPromise<apiResourceDto> {
        return request({
            url: `/api/IdsAdmin/api-resource/${id}`,
            method: 'PUT',
            data: input
        });
    }
    getListAsync(input: IPageRequestQuery): AxiosPromise<PageResult<apiResourceDto>> {
        return request({
            url: '/api/IdsAdmin/api-resource',
            method: 'get',
            params: input
        });
    }
    deleteAsync(id: string) {
        return request({
            url: `/api/IdsAdmin/api-resource/${id}`,
            method: 'DELETE'
        });
    }
    getAsync(id: string) {
        return request({
            url: `/api/IdsAdmin/api-resource/${id}`,
            method: 'GET'
        });
    }
}