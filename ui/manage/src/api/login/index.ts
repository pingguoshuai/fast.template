import { AxiosPromise } from 'axios';
import { CreateLogin, UserInfo } from './model';
import { apiConfig } from '/@/config';
import { ContentTypeEnum } from '/@/enums/httpEnum';
import request from '/@/utils/request';

/**
 * （不建议写成 request.post(xxx)，因为这样 post 时，无法 params 与 data 同时传参）
 *
 * 登录api接口集合
 * @method signIn 用户登录
 * @method signOut 用户退出登录
 */
// export function useLoginApi() {
// 	return {
// 		signIn: (data: CreateLogin) => {
// 			return request({
// 				url: '/connect/token',
// 				method: 'post',
// 				data,
// 				baseURL: apiConfig.AuthUrl,
// 				headers: { 'Content-Type': ContentTypeEnum.FormUrlEncoded }
// 			});
// 		},
// 		getUserInfo(): AxiosPromise<UserInfo> {
// 			return request({
// 				url: '/connect/userinfo',
// 				method: 'get',
// 				baseURL: apiConfig.AuthUrl
// 			});
// 		},
// 		signOut: (data: CreateLogin) => {
// 			return request({
// 				url: '/connect/token',
// 				method: 'post',
// 				data,
// 				baseURL: apiConfig.AuthUrl,
// 				headers: { 'Content-Type': ContentTypeEnum.FormUrlEncoded }
// 			});
// 		},
// 	};
// }

export const useLoginApi = {
	signIn: (data: CreateLogin) => {
		return request({
			url: '/connect/token',
			method: 'post',
			data,
			baseURL: apiConfig.AuthUrl,
			headers: { 'Content-Type': ContentTypeEnum.FormUrlEncoded }
		});
	},
	getUserInfo(): AxiosPromise<UserInfo> {
		return request({
			url: '/connect/userinfo',
			method: 'get',
			baseURL: apiConfig.AuthUrl
		});
	},
	signOut: (data: CreateLogin) => {
		return request({
			url: '/connect/token',
			method: 'post',
			data,
			baseURL: apiConfig.AuthUrl,
			headers: { 'Content-Type': ContentTypeEnum.FormUrlEncoded }
		});
	},
}
