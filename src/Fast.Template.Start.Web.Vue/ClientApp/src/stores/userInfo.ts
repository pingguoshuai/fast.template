import { defineStore } from 'pinia';
import Cookies from 'js-cookie';
import { UserInfosStates } from './interface';
import { Local, Session } from '/@/utils/storage';
import { UserState } from '../types/store/user';
import { CreateLogin } from '../api/login/model';
import { signIn } from '../api/login';
import { getUserInfo } from '../api/system/user';
import { UserInfo } from '../types/api/system/user/user';
import { AxiosPromise } from 'axios';

/**
 * 用户信息
 * @methods setUserInfos 设置用户信息
 */
export const useUserInfo = defineStore('userInfo', {
	state: (): UserInfosStates => ({
		userInfos: {
			token:Local.get('token'),
			userName: '',
			photo: '',
			time: 0,
			roles: [],
			authBtnList: [],
			email : '',
			sub : ''
		}
	}),
	actions: {
		login(request:CreateLogin){
			return new Promise((resolve, reject) => {
				signIn(request).then((response)=>{
					const {access_token,token_type} = response.data;
					const token = token_type + ' ' + access_token;
					Local.set('token',token);
					Session.set('token',token);
					this.userInfos.token = token;
					resolve(response)
				})
				.catch((error) => {
				  reject(error);
				});
			});
		},
		async setUserInfos() {
			// 存储用户信息到浏览器缓存
			if (Session.get('userInfo')) {
				this.userInfos = Session.get('userInfo');
			} else {
				const userInfos = await this.getApiUserInfo() as UserInfo;
				const { name, sub, role, email } = userInfos;
				this.userInfos.userName = name;
				this.userInfos.sub = sub;
				if(typeof(role) == 'string'){
					this.userInfos.roles = [role];
				}
				this.userInfos.email = email;
				Session.set('userInfo',this.userInfos);
			}
		},
		// 模拟接口数据
		// https://gitee.com/lyt-top/vue-next-admin/issues/I5F1HP
		async getApiUserInfo() {
			return new Promise((resolve, reject) => {
				// setTimeout(() => {
				// 	// 模拟数据，请求接口时，记得删除多余代码及对应依赖的引入
				// 	const userName = Cookies.get('userName');
				// 	// 模拟数据
				// 	let defaultRoles: Array<string> = [];
				// 	let defaultAuthBtnList: Array<string> = [];
				// 	// admin 页面权限标识，对应路由 meta.roles，用于控制路由的显示/隐藏
				// 	let adminRoles: Array<string> = ['admin'];
				// 	// admin 按钮权限标识
				// 	let adminAuthBtnList: Array<string> = ['btn.add', 'btn.del', 'btn.edit', 'btn.link'];
				// 	// test 页面权限标识，对应路由 meta.roles，用于控制路由的显示/隐藏
				// 	let testRoles: Array<string> = ['common'];
				// 	// test 按钮权限标识
				// 	let testAuthBtnList: Array<string> = ['btn.add', 'btn.link'];
				// 	// 不同用户模拟不同的用户权限
				// 	if (userName === 'admin') {
				// 		defaultRoles = adminRoles;
				// 		defaultAuthBtnList = adminAuthBtnList;
				// 	} else {
				// 		defaultRoles = testRoles;
				// 		defaultAuthBtnList = testAuthBtnList;
				// 	}
				// 	// 用户信息模拟数据
				// 	const userInfos = {
				// 		userName: userName,
				// 		photo:
				// 			userName === 'admin'
				// 				? 'https://img2.baidu.com/it/u=1978192862,2048448374&fm=253&fmt=auto&app=138&f=JPEG?w=504&h=500'
				// 				: 'https://img2.baidu.com/it/u=2370931438,70387529&fm=253&fmt=auto&app=138&f=JPEG?w=500&h=500',
				// 		time: new Date().getTime(),
				// 		roles: defaultRoles,
				// 		authBtnList: defaultAuthBtnList,
				// 	};
				// 	resolve(userInfos);
				// }, 3000);
				getUserInfo()
				.then(({data})=>{
					if (!data) {
					  return reject('Verification failed, please Login again.');
					}
					
					resolve(data)
				})
				.catch(error=>{
					reject(error);
				});
			});
		},
	},
});
