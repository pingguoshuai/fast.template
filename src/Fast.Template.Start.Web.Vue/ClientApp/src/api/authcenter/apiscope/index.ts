
import request from '/@/utils/request';
import { ApiScopeDto, CreateApiScope } from "/@/types/api/authcenter/apiscope";
import { AxiosPromise } from 'axios';
import { apiConfig } from '/@/config';
import { PageResult } from '/@/types/base/pageresult';
import { IPageRequestQuery } from '/@/types/base/querybase';
import { IKeyValue } from '/@/types/base/kv';

export const apiScopeGetList = (input: IPageRequestQuery): AxiosPromise<PageResult<ApiScopeDto>> => {
    return request({
        url: '/api/IdsAdmin/api-scope',
        method: 'get',
        params: input,
        baseURL: apiConfig.BaseUrl
    });
}

export const apiScopeCreate = (input: CreateApiScope): AxiosPromise<ApiScopeDto> => {
    return request({
        url: '/api/IdsAdmin/api-scope',
        method: 'POST',
        data: input,
        baseURL: apiConfig.BaseUrl
    });
}

export const apiScopeUpdate = (id: string, input: CreateApiScope): AxiosPromise<ApiScopeDto> => {
    return request({
        url: `/api/IdsAdmin/api-scope/${id}`,
        method: 'PUT',
        data: input,
        baseURL: apiConfig.BaseUrl
    });
}

export const apiScopeDetail = (id: string): AxiosPromise<ApiScopeDto> => {
    return request({
        url: `/api/IdsAdmin/api-scope/${id}`,
        method: 'GET',
        baseURL: apiConfig.BaseUrl
    });
}

export const apiScopeDelete = (id: string): AxiosPromise<ApiScopeDto> => {
    return request({
        url: `/api/IdsAdmin/api-scope/${id}`,
        method: 'DELETE',
        baseURL: apiConfig.BaseUrl
    });
}

export const apiScopeGetItemAsnyc = (): AxiosPromise<IKeyValue[]> => {
    return request({
        url: `/api/IdsAdmin/api-scope/items`,
        method: 'GET'
    });
}