
import { AxiosPromise } from "axios";
import request from "/@/utils/request";
import { IPageResult } from "../types/base/pageresult";

export class baseService<TEntityDto, TCreateDto, TQueryInput> {
    apiUrl: string;
    constructor(apiUrl: string) {
        this.apiUrl = apiUrl;
    }
    createAsync(input: TCreateDto): AxiosPromise<TEntityDto> {
        return request({
            url: this.apiUrl,
            method: 'POST',
            data: input
        })
    }

    updateAsync(id: string, input: TCreateDto): AxiosPromise<TEntityDto> {
        return request({
            url: `${this.apiUrl}/${id}`,
            method: 'PUT',
            data: input
        });
    }

    deleteAsync(id: string) {
        return request({
            url: `${this.apiUrl}/${id}`,
            method: 'DELETE'
        });
    }

    getAsync(id: string): AxiosPromise<TEntityDto> {
        return request({
            url: `${this.apiUrl}/${id}`,
            method: 'GET'
        });
    }

    getListAsync(input: TQueryInput): AxiosPromise<IPageResult<TEntityDto>> {
        return request({
            url: this.apiUrl,
            method: 'get',
            params: input
        });
    }
}