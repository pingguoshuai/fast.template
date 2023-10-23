<template>
	<el-drawer title="编辑" v-model="state.isShow" size="50%" :before-close="closeDialog">
		<el-form :model="state.ruleForm" ref="formRef" label-width="180px" :inline="false" size="default">
			<el-tabs v-model="activeName" type="card" tab-position="top" @tab-click="">
				<el-tab-pane label="基本" name="first">
					<el-form-item label="名称" prop="clientId" :rules="[{ required: true, message: '请填写名称' }]">
						<el-input v-model="state.ruleForm.clientId" clearable></el-input>
					</el-form-item>
					<el-form-item label="显示名称" prop="clientName">
						<el-input v-model="state.ruleForm.clientName" clearable></el-input>
					</el-form-item>
					<el-form-item label="描述" prop="description">
						<el-input v-model="state.ruleForm.description" clearable type="textarea"></el-input>
					</el-form-item>
					<el-form-item label="启用" prop="enabled">
						<el-switch v-model="state.ruleForm.enabled"> </el-switch>
					</el-form-item>
					<el-form-item label="协议类型">
						<el-select class="elselect" v-model="state.ruleForm.protocolType" default-first-option :reserve-keyword="false" prop="protocolType">
							<el-option v-for="item in state.protocolTypes" :key="item.value" :label="item.text" :value="item.value" />
						</el-select>
					</el-form-item>
					<el-form-item label="授权类型">
						<el-select class="elselect" v-model="state.ruleForm.allowedGrantTypes" multiple filterable allow-create default-first-option :reserve-keyword="false" prop="userClaims">
							<el-option v-for="item in state.grantTypes" :key="item" :label="item" :value="item" />
						</el-select>
					</el-form-item>
					<el-form-item label="作用域">
						<el-select class="elselect" v-model="state.ruleForm.allowedScopes" multiple default-first-option :reserve-keyword="false" prop="scopes">
							<el-option v-for="item in state.scopeList" :key="item" :label="item" :value="item" />
						</el-select>
					</el-form-item>
					<el-form-item label="重定向Uri" v-for="(item, index) in state.redirectUris" :key="index">
						<el-col :span="22" :offset="0">
							<el-input v-model="state.redirectUris[index]"></el-input>
						</el-col>
						<el-col :span="2" :offset="0" class="pl5">
							<el-button type="success" size="small" :icon="Plus" circle v-if="index === 0" @click="state.redirectUris.push('')" />
							<el-button type="danger" size="small" :icon="Delete" circle v-else @click="state.redirectUris.splice(index, 1)" />
						</el-col>
					</el-form-item>
					<el-form-item label="需要客户端密钥">
						<el-switch v-model="state.ruleForm.requireClientSecret"> </el-switch>
					</el-form-item>
					<el-form-item label="在授权请求上使用请求对象" prop="requireRequestObject">
						<el-switch v-model="state.ruleForm.requireRequestObject"> </el-switch>
					</el-form-item>
					<el-form-item label="开启Pkce校验" prop="requirePkce">
						<el-switch v-model="state.ruleForm.requirePkce"> </el-switch>
					</el-form-item>
					<el-form-item label="允许纯文本Pkce" prop="allowPlainTextPkce">
						<el-switch v-model="state.ruleForm.allowPlainTextPkce"> </el-switch>
					</el-form-item>
					<el-form-item label="允许离线访问" prop="allowOfflineAccess">
						<el-switch v-model="state.ruleForm.allowOfflineAccess"> </el-switch>
					</el-form-item>
					<el-form-item label="允许通过浏览器访问令牌" prop="allowAccessTokensViaBrowser">
						<el-switch v-model="state.ruleForm.allowAccessTokensViaBrowser"></el-switch>
					</el-form-item>
				</el-tab-pane>
				<el-tab-pane label="认证/注销" name="second">
					<el-form-item label="前端通道注销Uri" prop="frontChannelLogoutUri">
						<el-input v-model="state.ruleForm.frontChannelLogoutUri" clearable></el-input>
					</el-form-item>
					<el-form-item label="需要前端通道注销会话" prop="frontChannelLogoutSessionRequired">
						<el-switch v-model="state.ruleForm.frontChannelLogoutSessionRequired"></el-switch>
					</el-form-item>
					<el-form-item label="后端通道退出Uri" prop="backChannelLogoutUri">
						<el-input v-model="state.ruleForm.backChannelLogoutUri" clearable></el-input>
					</el-form-item>
					<el-form-item label="需要后端通道注销会话" prop="backChannelLogoutSessionRequired">
						<el-switch v-model="state.ruleForm.backChannelLogoutSessionRequired"></el-switch>
					</el-form-item>
					<el-form-item label="启用本地登录" prop="enableLocalLogin">
						<el-switch v-model="state.ruleForm.enableLocalLogin"></el-switch>
					</el-form-item>
					<el-row :gutter="20">
						<el-col :span="12" :offset="0"></el-col>
						<el-col :span="12" :offset="0"></el-col>
					</el-row>
					<el-form-item label="注销重定向Uri" v-for="(item, index) in state.postLogoutRedirectUris" :key="index">
						<el-col :span="22" :offset="0">
							<el-input v-model="state.postLogoutRedirectUris[index]"></el-input>
						</el-col>
						<el-col :span="2" :offset="0" class="pl5">
							<el-button type="success" size="small" :icon="Plus" circle v-if="index === 0" @click="addLogoutUri" />
							<el-button type="danger" size="small" :icon="Delete" circle v-else @click="removeLogoutUri(index)" />
						</el-col>
					</el-form-item>
					<el-form-item label="身份提供程序限制" v-for="(item, index) in state.identityProviderRestrictions" :key="index">
						<el-col :span="22" :offset="0">
							<el-input v-model="state.identityProviderRestrictions[index]"></el-input>
						</el-col>
						<el-col :span="2" :offset="0" class="pl5">
							<el-button type="success" size="small" :icon="Plus" circle v-if="index === 0" @click="state.identityProviderRestrictions.push('')" />
							<el-button type="danger" size="small" :icon="Delete" circle v-else @click="state.identityProviderRestrictions.splice(index, 1)" />
						</el-col>
					</el-form-item>
					<el-form-item label="用户SSO生命周期" prop="userSsoLifetime">
						<el-input-number v-model="state.ruleForm.userSsoLifetime" clearable></el-input-number>
					</el-form-item>
				</el-tab-pane>
				<el-tab-pane label="令牌" name="third">
					<el-form-item label="身份令牌生命周期" prop="identityTokenLifetime">
						<el-input-number v-model="state.ruleForm.identityTokenLifetime"></el-input-number>
					</el-form-item>
					<el-form-item label="允许的签名算法列表">
						<el-select
							class="elselect"
							v-model="state.ruleForm.allowedIdentityTokenSigningAlgorithms"
							multiple
							default-first-option
							:reserve-keyword="false"
							prop="allowedAccessTokenSigningAlgorithms"
						>
							<el-option v-for="item in state.signingAlgorithms" :key="item" :label="item" :value="item" />
						</el-select>
					</el-form-item>
					<el-form-item label="访问令牌生命周期" prop="accessTokenLifetime">
						<el-input-number v-model="state.ruleForm.accessTokenLifetime"></el-input-number>
					</el-form-item>
					<el-form-item label="访问令牌类型" prop="accessTokenType">
						<el-select class="elselect" v-model="state.ruleForm.accessTokenType" default-first-option :reserve-keyword="false" prop="scopes">
							<el-option v-for="item in state.accessTokenTypes" :key="item.value" :label="item.text" :value="item.value" />
						</el-select>
					</el-form-item>
					<el-form-item label="授权码生命周期" prop="authorizationCodeLifetime">
						<el-input-number v-model="state.ruleForm.authorizationCodeLifetime"></el-input-number>
					</el-form-item>
					<el-form-item label="绝对刷新令牌生命周期" prop="absoluteRefreshTokenLifetime">
						<el-input-number v-model="state.ruleForm.absoluteRefreshTokenLifetime"></el-input-number>
					</el-form-item>
					<el-form-item label="滚动刷新令牌生命周期" prop="slidingRefreshTokenLifetime">
						<el-input-number v-model="state.ruleForm.slidingRefreshTokenLifetime"></el-input-number>
					</el-form-item>
					<el-form-item label="刷新令牌使用情况" prop="refreshTokenUsage">
						<el-select class="elselect" v-model="state.ruleForm.refreshTokenUsage" default-first-option :reserve-keyword="false" prop="scopes">
							<el-option v-for="item in state.tokenUsages" :key="item.value" :label="item.text" :value="item.value" />
						</el-select>
					</el-form-item>
					<el-form-item label="刷新令牌过期">
						<el-select class="elselect" v-model="state.ruleForm.refreshTokenExpiration" default-first-option :reserve-keyword="false" prop="scopes">
							<el-option v-for="item in state.tokenExpirations" :key="item.value" :label="item.text" :value="item.value" />
						</el-select>
					</el-form-item>
					<el-form-item label="允许跨域来源" v-for="(item, index) in state.allowedCorsOrigins" :key="index">
						<el-col :span="22" :offset="0">
							<el-input v-model="state.allowedCorsOrigins[index]"></el-input>
						</el-col>
						<el-col :span="2" :offset="0" class="pl5">
							<el-button type="success" size="small" :icon="Plus" circle v-if="index === 0" @click="state.allowedCorsOrigins.push('')" />
							<el-button type="danger" size="small" :icon="Delete" circle v-else @click="state.allowedCorsOrigins.splice(index, 1)" />
						</el-col>
					</el-form-item>
					<el-form-item label="刷新时更新访问令牌声明" prop="updateAccessTokenClaimsOnRefresh">
						<el-switch v-model="state.ruleForm.updateAccessTokenClaimsOnRefresh"></el-switch>
					</el-form-item>
					<el-form-item label="包括 Jwt 标识" prop="includeJwtId">
						<el-switch v-model="state.ruleForm.includeJwtId"></el-switch>
					</el-form-item>
					<el-form-item label="始终发送客户端声明" prop="alwaysSendClientClaims">
						<el-switch v-model="state.ruleForm.alwaysSendClientClaims"></el-switch>
					</el-form-item>
					<el-form-item label="始终在身份令牌中包含用户声明" prop="alwaysIncludeUserClaimsInIdToken">
						<el-switch v-model="state.ruleForm.alwaysIncludeUserClaimsInIdToken"></el-switch>
					</el-form-item>
					<el-form-item label="客户端声明前缀" prop="clientClaimsPrefix">
						<el-input v-model="state.ruleForm.clientClaimsPrefix" clearable></el-input>
					</el-form-item>
					<el-form-item label="配对主体盐" prop="pairWiseSubjectSalt">
						<el-input v-model="state.ruleForm.pairWiseSubjectSalt" clearable></el-input>
					</el-form-item>
				</el-tab-pane>
				<el-tab-pane label="同意界面" name="fourth">
					<el-form-item label="需要同意" prop="requireConsent">
						<el-switch v-model="state.ruleForm.requireConsent"></el-switch>
					</el-form-item>
					<el-form-item label="允许记住同意" prop="frontChannelLogoutSessionRequired">
						<el-switch v-model="state.ruleForm.allowRememberConsent"></el-switch>
					</el-form-item>
					<el-form-item label="客户端Uri" prop="clientUri">
						<el-input v-model="state.ruleForm.clientUri" clearable></el-input>
					</el-form-item>
					<el-form-item label="LogoUri" prop="logoUri">
						<el-input v-model="state.ruleForm.logoUri" clearable></el-input>
					</el-form-item>
				</el-tab-pane>
				<el-tab-pane label="设备流程" name="fifth">
					<el-form-item label="用户代码类型" prop="clientUri">
						<el-input v-model="state.ruleForm.userCodeType" clearable></el-input>
					</el-form-item>
					<el-form-item label="设备代码生命周期" prop="userSsoLifetime">
						<el-input-number v-model="state.ruleForm.deviceCodeLifetime"></el-input-number>
					</el-form-item>
				</el-tab-pane>
			</el-tabs>
		</el-form>
		<template #footer>
			<span class="dialog-footer">
				<el-button @click="closeDialog">取 消</el-button>
				<el-button type="primary" @click="onSubmit">OK</el-button>
			</span>
		</template>
	</el-drawer>
</template>

<script setup lang="ts">
import { Plus, Delete } from '@element-plus/icons-vue';
import { ElMessage } from 'element-plus';
import { onMounted, reactive, ref } from 'vue';
import { apiClient } from '/@/api/authcenter/apiclient';
import { getAccessTokenTypes, getGrantTypes, getScopes, getSigningAlgorithms, getTokenExpirations, getTokenUsages } from '/@/api/config';
import { updateClientDto } from '/@/types/api/authcenter/client';
const props = defineProps({
	afterSubmit: Function,
});

const activeName = ref('first');
const formRef = ref();

const state = reactive({
	isShow: false,
	entityId: '',
	ruleForm: new updateClientDto(),
	redirectUris: [''], //重定向url
	postLogoutRedirectUris: [''], //注销重定向uri
	allowedCorsOrigins: [''], //允许跨域来源
	identityProviderRestrictions: [''], //身份提供程序限制
	protocolTypes: [
		{
			text: 'OpenID Connect',
			value: 'oidc',
		},
	],
	grantTypes: [],
	scopeList: [],
	signingAlgorithms: [],
	accessTokenTypes: [],
	tokenUsages: [],
	tokenExpirations: [],
});

const apiService = new apiClient();
const open = async (id: string) => {
	state.isShow = true;
	state.entityId = id;
	const { data } = await apiService.getAsync(id);
	state.ruleForm = data;
	if (data.redirectUris?.length > 0) {
		state.redirectUris = data.redirectUris;
	}
	if (data.postLogoutRedirectUris?.length > 0) {
		state.postLogoutRedirectUris = data.postLogoutRedirectUris;
	}
	if (data.allowedCorsOrigins?.length > 0) {
		state.allowedCorsOrigins = data.allowedCorsOrigins;
	}
	if (data.identityProviderRestrictions?.length > 0) {
		state.identityProviderRestrictions = data.identityProviderRestrictions;
	}
};
const addLogoutUri = () => {
	state.postLogoutRedirectUris.push('');
};
const removeLogoutUri = (index: number) => {
	state.postLogoutRedirectUris.splice(index, 1);
};
const closeDialog = async () => {
	formRef.value?.resetFields();
	state.isShow = false;
	state.redirectUris = [''];
	state.postLogoutRedirectUris = [''];
	state.allowedCorsOrigins = [''];
	state.identityProviderRestrictions = [''];
	// state.ruleForm = new createClientDto();
};

const onSubmit = async () => {
	await formRef.value?.validate();
	state.ruleForm.redirectUris = state.redirectUris.filter(function (item) {
		return item != '';
	});
	state.ruleForm.postLogoutRedirectUris = state.postLogoutRedirectUris.filter(function (item) {
		return item != '';
	});
	state.ruleForm.identityProviderRestrictions = state.identityProviderRestrictions.filter(function (item) {
		return item != '';
	});
	state.ruleForm.allowedCorsOrigins = state.allowedCorsOrigins.filter(function (item) {
		return item != '';
	});
	await apiService.updateAsync(state.entityId, state.ruleForm);
	ElMessage.success('操作成功');
	console.log(state.ruleForm);
};

onMounted(async () => {
	{
		const { data } = await getGrantTypes();
		state.grantTypes = data;
	}
	{
		const { data } = await getScopes();
		state.scopeList = data;
	}
	{
		const { data } = await getSigningAlgorithms();
		state.signingAlgorithms = data;
	}
	{
		const { data } = await getAccessTokenTypes();
		state.accessTokenTypes = data;
	}
	{
		const { data } = await getTokenUsages();
		state.tokenUsages = data;
	}
	{
		const { data } = await getTokenExpirations();
		state.tokenExpirations = data;
	}
});

defineExpose({
	open,
	props,
});
</script>
