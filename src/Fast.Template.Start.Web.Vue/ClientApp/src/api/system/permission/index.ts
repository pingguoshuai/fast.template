import { AxiosPromise } from "axios";
import { apiConfig } from "/@/config";
import request from "/@/utils/request";
import { GetPermissionListResultDto, PermissionGrantInfoDto, PermissionGroupDto, UpdatePermissionDto } from "./model";

export class permissionService {
    getAsync(providerName: string, providerKey: string): AxiosPromise<GetPermissionListResultDto> {
        return request({
            url: `/api/permission-management/permissions?providerName=${providerName}&providerKey=${providerKey}`,
            method: 'GET',
            baseURL: apiConfig.BaseUrl
        });
    };
    updateAsync(providerName: string, providerKey: string, input: PermissionGrantInfoDto[]) {
        return request({
            url: `/api/permission-management/permissions?providerName=${providerName}&providerKey=${providerKey}`,
            method: 'PUT',
            data: { permissions: input },
            baseURL: apiConfig.BaseUrl
        });
    }
}