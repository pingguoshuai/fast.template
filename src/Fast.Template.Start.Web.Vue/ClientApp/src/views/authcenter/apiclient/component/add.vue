<template>
	<el-dialog title="新增" v-model="isShowDialog" width="600px" :before-close="handleClose">
		<el-form :model="ruleForm" size="default" ref="ruleFormRef" label-width="140px" class="system-scope-container">
			<el-form-item label="名称" prop="clientId" :rules="[
				{ required: true, message: '请填写名称' }
			]">
				<el-input v-model="ruleForm.clientId" clearable></el-input>
			</el-form-item>
			<el-form-item label="显示名称" prop="clientName">
				<el-input v-model="ruleForm.clientName" clearable></el-input>
			</el-form-item>
			<el-form-item label="描述" prop="description">
				<el-input v-model="ruleForm.description" clearable type="textarea"></el-input>
			</el-form-item>
			<el-form-item label="启用" prop="enabled">
				<el-switch v-model="ruleForm.enabled">
				</el-switch>
			</el-form-item>
			<el-form-item label="协议类型">
				<el-select class="elselect" v-model="ruleForm.protocolType" default-first-option
					:reserve-keyword="false" prop="protocolType">
					<el-option v-for="item in protocolTypes" :key="item.value" :label="item.text" :value="item.value" />
				</el-select>
			</el-form-item>
			<el-form-item label="授权类型">
				<el-select class="elselect" v-model="ruleForm.allowedGrantTypes" multiple filterable allow-create
					default-first-option :reserve-keyword="false" prop="userClaims">
					<el-option v-for="item in grantTypes" :key="item" :label="item" :value="item" />
				</el-select>
			</el-form-item>
			<el-form-item label="作用域">
				<el-select class="elselect" v-model="ruleForm.allowedScopes" multiple default-first-option
					:reserve-keyword="false" prop="scopes">
					<el-option v-for="item in scopeList" :key="item" :label="item" :value="item" />
				</el-select>
			</el-form-item>
		</el-form>
		<template #footer>
			<span class="dialog-footer">
				<el-button @click="onCancel" size="default">取 消</el-button>
				<el-button type="primary" @click="onSubmit">确 定</el-button>
			</span>
		</template>
	</el-dialog>
</template>

<script lang="ts">
import { ElMessage } from 'element-plus';
import { reactive, toRefs, defineComponent, ref, onMounted } from 'vue';
import { apiClient } from '/@/api/authcenter/apiclient';
import { getGrantTypes, getScopes, getStandardClaims } from '/@/api/config';
import { createClientDto } from '/@/types/api/authcenter/client';
import { msgTool } from '/@/utils/msgTool';

export default defineComponent({
	name: 'AddApiResource',
	props: {
		afterSubmit: Function
	},
	setup(props) {
		const ruleFormRef = ref();
		const apiService = new apiClient();
		const state = reactive({
			isAdd: true,
			isShowDialog: false,
			entityId: '',
			ruleForm: new createClientDto(),
			options: [],
			signingAlgorithms: [],
			scopeList: [],
			grantTypes: [],
			protocolTypes: [
				{
					text: "OpenID Connect",
					value: "oidc"
				}
			]
		});
		// 打开弹窗
		const openAdd = () => {
			state.isAdd = true;
			state.isShowDialog = true;
		};
		const openEdit = async (id: string) => {
			state.isAdd = false;
			state.entityId = id;
			state.isShowDialog = true;
			const { data } = await apiService.getAsync(id);
			state.ruleForm = data;
		};
		const handleClose = async () => {
			await msgTool.confirm('确定要关闭吗?');
			closeDialog();
		};
		// 关闭弹窗
		const closeDialog = async () => {
			ruleFormRef.value?.resetFields()
			state.isShowDialog = false;
			state.ruleForm = new createClientDto();
		};
		// 取消
		const onCancel = () => {
			handleClose();
		};
		// 新增
		const onSubmit = async () => {
			await ruleFormRef.value?.validate()
			if (state.isAdd) {
				await apiService.createAsync(state.ruleForm);
			} else {
				await apiService.updateAsync(state.entityId, state.ruleForm);
			}
			props.afterSubmit();
			ElMessage.success('操作成功')
			closeDialog();
		};
		// 页面加载时
		onMounted(async () => {
			{
				const { data } = await getGrantTypes();
				state.grantTypes = data;
			}
			{
				const { data } = await getScopes();
				state.scopeList = data;
			}
		});
		return {
			openAdd,
			openEdit,
			closeDialog,
			handleClose,
			onCancel,
			onSubmit,
			ruleFormRef,
			...toRefs(state),
		};
	},
});
</script>
<style scoped lang="scss">
.system-scope-container {
	.elselect {
		width: 100%;
	}
}
</style>