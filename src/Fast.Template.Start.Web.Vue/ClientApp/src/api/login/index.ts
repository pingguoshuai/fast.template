import { CreateLogin } from './model';
import { apiConfig } from '/@/config';
import { ContentTypeEnum } from '/@/enums/httpEnum';
import request from '/@/utils/request';

/**
 * 登录api接口集合
 * @method signIn 用户登录
 * @method signOut 用户退出登录
 */
export function useLoginApi() {
	return {
		signOut: (params: object) => {
			return request({
				url: '/user/signOut',
				method: 'post',
				data: params,
			});
		},
	};
}

export function signIn(params: CreateLogin) {
	return request({
		url: '/connect/token',
		method: 'post',
		data: params,
		baseURL: apiConfig.AuthUrl,
		headers: { 'Content-Type': ContentTypeEnum.FormUrlEncoded }
	});
}