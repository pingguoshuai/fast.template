import axios, { AxiosInstance, AxiosRequestConfig } from 'axios';
import { ElMessage, ElMessageBox } from 'element-plus';
import { Local, Session } from '/@/utils/storage';
import qs from 'qs';
import { ContentTypeEnum, RequestEnum } from '../enums/httpEnum';
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
const service: AxiosInstance = axios.create({
	baseURL: import.meta.env.VITE_API_URL,
	timeout: 50000,
	headers: { 'Content-Type': 'application/json' },
	paramsSerializer: {
		serialize(params) {
			return qs.stringify(params, { allowDots: true });
		},
	},
});

// 添加请求拦截器
service.interceptors.request.use(
	(config) => {
		showLoading();
		supportFormData(config)

		// 在发送请求之前做些什么 token
		if (Session.get('token')) {
			config.headers!['Authorization'] = `${Session.get('token')}`;
		}
		return config;
	},
	(error) => {
		// 对请求错误做些什么
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
		ElMessage.error(error.response.data.error.message);
		if (error.code == 'ECONNABORTED') {
			setTimeout(() => {
				hideLoading();
				Session.clear(); // 清除浏览器全部临时缓存
				Local.clear(); // 清除浏览器全部临时缓存
				window.location.href = '/'; // 去登录页
			}, 200);
			return Promise.reject(error);
		}
		// 对响应数据做点什么
		const status = error.response.status;
		if (status === 401) {
			Session.clear(); // 清除浏览器全部临时缓存
			Local.clear(); // 清除浏览器全部临时缓存
			window.location.href = '/'; // 去登录页
			ElMessageBox.alert('你已被登出，请重新登录', '提示', {})
				.then(() => { })
				.catch(() => { });
		} else {
			setTimeout(() => {
				hideLoading();
			}, 200);
		}
		return Promise.reject(error);
		// // 对响应错误做点什么
		// if (error.message.indexOf('timeout') != -1) {
		// 	ElMessage.error('网络超时');
		// } else if (error.message == 'Network Error') {
		// 	ElMessage.error('网络连接错误');
		// } else {
		// 	if (error.response.data) ElMessage.error(error.response.statusText);
		// 	else ElMessage.error('接口路径找不到');
		// }
		// return Promise.reject(error);
	}
);

// 导出 axios 实例
export default service;
