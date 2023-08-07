import { AxiosPromise } from "axios";
import { changePasswordInput, ProfileDto } from "./model";
import request from "/@/utils/request";

export class accountService {
    getAsync(): AxiosPromise<ProfileDto> {
        return request({
            url: "/api/account/my-profile",
            method: "GET",
        });
    }

    updateAsync(input: ProfileDto): AxiosPromise<ProfileDto> {
        return request({
            url: "/api/account/my-profile",
            method: "PUT",
            data: input
        });
    }

    changePasswordAsync(input: changePasswordInput) {
        return request({
            url: "/api/account/my-profile/change-password",
            method: "POST",
            data: input
        });
    }
}