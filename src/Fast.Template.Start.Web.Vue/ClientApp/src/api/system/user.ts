import { AxiosPromise } from 'axios';
import { apiConfig } from '/@/config';
import { UserInfo } from '/@/types/api/system/user/user';
import request from '/@/utils/request';

export function getUserInfo(): AxiosPromise<UserInfo> {
  return request({
    url: '/connect/userinfo',
    method: 'get',
    baseURL: apiConfig.AuthUrl
  });
}