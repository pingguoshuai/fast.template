import { AxiosPromise } from "axios";
import { clientDto, createClientDto } from "../../../types/api/authcenter/client";
import { PageResult } from "/@/types/base/pageresult";
import { IPageRequestQuery } from "/@/types/base/querybase";
import request from "/@/utils/request";

export class apiClient {
    createAsync(input: createClientDto): AxiosPromise<clientDto> {
        return request({
            url: '/api/IdsAdmin/client',
            method: 'POST',
            data: input
        });
    }

    updateAsync(id: string, input: createClientDto): AxiosPromise<clientDto> {
        return request({
            url: `/api/IdsAdmin/client/${id}`,
            method: 'PUT',
            data: input
        });
    }
    getListAsync(input: IPageRequestQuery): AxiosPromise<PageResult<clientDto>> {
        return request({
            url: '/api/IdsAdmin/client',
            method: 'get',
            params: input
        });
    }
    deleteAsync(id: string) {
        return request({
            url: `/api/IdsAdmin/client/${id}`,
            method: 'DELETE'
        });
    }
    getAsync(id: string) {
        return request({
            url: `/api/IdsAdmin/client/${id}`,
            method: 'GET'
        });
    }
}