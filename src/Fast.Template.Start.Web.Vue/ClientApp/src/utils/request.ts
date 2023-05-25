import axios, { AxiosRequestConfig, AxiosRequestHeaders } from 'axios';
import { ElMessage, ElMessageBox } from 'element-plus';
import { apiConfig } from '../config';
import { ContentTypeEnum, RequestEnum } from '../enums/httpEnum';
import { Local, Session } from '/@/utils/storage';
import qs from 'qs'
import { useUserInfo } from '../stores/userInfo';
import { hideLoading, showLoading } from './loading';

function supportFormData(config: AxiosRequestConfig) {
	const header = config.headers;
	if (header != null && Reflect.has(config, 'data') && config.method?.toUpperCase() != RequestEnum.GET) {
		const contentType = header['Content-Type'];
		if (contentType == ContentTypeEnum.FormUrlEncoded) {
			config.data = qs.stringify(config.data)
		}
	}
}

// 配置新建一个 axios 实例
const service = axios.create({
	baseURL: apiConfig.BaseUrl,
	timeout: 50000,
	headers: { 'Content-Type': 'application/json' },
});

// 添加请求拦截器
service.interceptors.request.use(
	(config: AxiosRequestConfig) => {
		showLoading();
		supportFormData(config)

		const { userInfos } = useUserInfo();
		if (userInfos.token) {
			const header = config.headers as AxiosRequestHeaders;
			header.Authorization = Local.get('token');
		}
		return config;
	},
	error => {
		return Promise.reject(error);
	}
);

// 添加响应拦截器
service.interceptors.response.use(
	(response) => {
		setTimeout(() => {
			hideLoading();
		}, 200);
		return response;
	},
	(error) => {
		setTimeout(() => {
			hideLoading();
		}, 200);
		const status = error.response.status;
		if (status === 401) {
			Session.clear(); // 清除浏览器全部临时缓存
			Local.clear(); // 清除浏览器全部临时缓存
			window.location.href = '/'; // 去登录页
			ElMessageBox.alert('你已被登出，请重新登录', '提示', {})
				.then(() => { })
				.catch(() => { });
		}
		ElMessage.error(error.response.data.error.message);
		return Promise.reject(error);
	}
);

// 导出 axios 实例
export default service;
