<template>
	<el-form size="large" class="login-content-form">
		<el-form-item class="login-animation1">
			<el-input type="text" :placeholder="$t('message.account.accountPlaceholder1')" v-model="ruleForm.username" clearable autocomplete="off">
				<template #prefix>
					<el-icon class="el-input__icon">
						<ele-User />
					</el-icon>
				</template>
			</el-input>
		</el-form-item>
		<el-form-item class="login-animation2">
			<el-input :type="isShowPassword ? 'text' : 'password'" :placeholder="$t('message.account.accountPlaceholder2')" v-model="ruleForm.password" autocomplete="off">
				<template #prefix>
					<el-icon class="el-input__icon">
						<ele-Unlock />
					</el-icon>
				</template>
				<template #suffix>
					<i class="iconfont el-input__icon login-content-password" :class="isShowPassword ? 'icon-yincangmima' : 'icon-xianshimima'" @click="isShowPassword = !isShowPassword"> </i>
				</template>
			</el-input>
		</el-form-item>
		<el-form-item class="login-animation3">
			<el-col :span="15">
				<el-input type="text" maxlength="4" :placeholder="$t('message.account.accountPlaceholder3')" v-model="ruleForm.code" clearable autocomplete="off">
					<template #prefix>
						<el-icon class="el-input__icon">
							<ele-Position />
						</el-icon>
					</template>
				</el-input>
			</el-col>
			<el-col :span="1"></el-col>
			<el-col :span="8">
				<el-button class="login-content-code">1234</el-button>
			</el-col>
		</el-form-item>
		<el-form-item class="login-animation4">
			<el-button type="primary" class="login-content-submit" round @click="onSignIn" :loading="loading.signIn">
				<span>{{ $t('message.account.accountBtnText') }}</span>
			</el-button>
		</el-form-item>
	</el-form>
</template>

<script lang="ts">
import { toRefs, reactive, defineComponent, computed } from 'vue';
import { useRoute, useRouter } from 'vue-router';
import { ElMessage } from 'element-plus';
import { useI18n } from 'vue-i18n';
import Cookies from 'js-cookie';
import { storeToRefs } from 'pinia';
import { useThemeConfig } from '/@/stores/themeConfig';
import { initFrontEndControlRoutes } from '/@/router/frontEnd';
import { initBackEndControlRoutes } from '/@/router/backEnd';
import { Session } from '/@/utils/storage';
import { formatAxis } from '/@/utils/formatTime';
import { NextLoading } from '/@/utils/loading';
import { signIn } from '/@/api/login';
import { CreateLogin } from '/@/api/login/model';
import { useUserInfo } from '/@/stores/userInfo';

export default defineComponent({
	name: 'loginAccount',
	setup() {
		const { t } = useI18n();
		const storesThemeConfig = useThemeConfig();
		const { themeConfig } = storeToRefs(storesThemeConfig);
		const route = useRoute();
		const router = useRouter();
		const state = reactive({
			isShowPassword: false,
			ruleForm: {
				username: 'admin',
				password: '1q2w3E*',
				// password: '111111',
				grant_type: 'password',
				client_id: 'Start_App',
				client_secret: '1q2w3e*',
				scope: 'Template profile phone email role openid',
				code: '',
			} as CreateLogin,
			loading: {
				signIn: false,
			},
		});
		// 时间获取
		const currentTime = computed(() => {
			return formatAxis(new Date());
		});
		// 登录
		const onSignIn = async () => {
			state.loading.signIn = true;
			// // 存储 token 到浏览器缓存
			// Session.set('token', Math.random().toString(36).substr(0));
			// // 模拟数据，对接接口时，记得删除多余代码及对应依赖的引入。用于 `/src/stores/userInfo.ts` 中不同用户登录判断（模拟数据）
			// Cookies.set('userName', state.ruleForm.userName);
			// if (!themeConfig.value.isRequestRoutes) {
			// 	// 前端控制路由，2、请注意执行顺序
			// await initFrontEndControlRoutes();
			// 	signInSuccess();
			// } else {
			// 	// 模拟后端控制路由，isRequestRoutes 为 true，则开启后端控制路由
			// 	// 添加完动态路由，再进行 router 跳转，否则可能报错 No match found for location with path "/"
			// 	await initBackEndControlRoutes();
			// 	// 执行完 initBackEndControlRoutes，再执行 signInSuccess
			// 	signInSuccess();
			// }
			useUserInfo()
				.login(state.ruleForm)
				.then(async () => {
					// await initFrontEndControlRoutes();
					signInSuccess();
				})
				.catch(() => {});
		};
		// 登录成功后的跳转
		const signInSuccess = () => {
			// 初始化登录成功时间问候语
			let currentTimeInfo = currentTime.value;
			// 登录成功，跳到转首页
			// 如果是复制粘贴的路径，非首页/登录页，那么登录成功后重定向到对应的路径中
			if (route.query?.redirect) {
				router.push({
					path: route.query?.redirect as string,
					query: Object.keys(route.query?.params as string).length > 0 ? JSON.parse(route.query?.params as string) : '',
				});
			} else {
				router.push('/');
			}
			// 登录成功提示
			// 关闭 loading
			state.loading.signIn = true;
			const signInText = t('message.signInText');
			ElMessage.success(`${currentTimeInfo}，${signInText}`);
			// 添加 loading，防止第一次进入界面时出现短暂空白
			NextLoading.start();
		};
		return {
			onSignIn,
			...toRefs(state),
		};
	},
});
</script>

<style scoped lang="scss">
.login-content-form {
	margin-top: 20px;

	@for $i from 1 through 4 {
		.login-animation#{$i} {
			opacity: 0;
			animation-name: error-num;
			animation-duration: 0.5s;
			animation-fill-mode: forwards;
			animation-delay: calc($i/10) + s;
		}
	}

	.login-content-password {
		display: inline-block;
		width: 20px;
		cursor: pointer;

		&:hover {
			color: #909399;
		}
	}

	.login-content-code {
		width: 100%;
		padding: 0;
		font-weight: bold;
		letter-spacing: 5px;
	}

	.login-content-submit {
		width: 100%;
		letter-spacing: 2px;
		font-weight: 300;
		margin-top: 15px;
	}
}
</style>
