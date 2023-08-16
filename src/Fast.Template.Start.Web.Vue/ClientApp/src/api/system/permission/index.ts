import { AxiosPromise } from "axios";
import { apiConfig } from "/@/config";
import request from "/@/utils/request";
import { GetPermissionListResultDto, PermissionGroupDto, UpdatePermissionDto } from "./model";

export class permissionService {
    getAsync(providerName: string, providerKey: string): AxiosPromise<GetPermissionListResultDto> {
        return request({
            url: `/api/permission-management/permissions?providerName=${providerName}&providerKey=${providerKey}`,
            method: 'GET',
            baseURL: apiConfig.BaseUrl
        }).then((res) => {
            for (var i = 0, len = res.data.groups.length; i < len; i++) {
                // res.data.groups[i].IsAllGranted = res.data.groups[i].permissions.every((item: any) => item.isGranted);
                res.data.groups[i] = Object.assign(new PermissionGroupDto(), res.data.groups[i]);
            }
            console.log(res)
            return res;
        });
    };
    updateAsync(providerName: string, providerKey: string, input: UpdatePermissionDto[]) {
        return request({
            url: `/api/permission-management/permissions?providerName=${providerName}&providerKey=${providerKey}`,
            method: 'PUT',
            data: input,
            baseURL: apiConfig.BaseUrl
        });
    }
}