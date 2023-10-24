<template>
	<el-dialog title="新增" v-model="isShowDialog" width="600px" :before-close="handleClose">
		<el-form :model="ruleForm" size="default" ref="ruleFormRef" label-width="140px" class="system-scope-container">
			<el-form-item label="名称" prop="name" :rules="[{ required: true, message: '请填写名称' }]">
				<el-input v-model="ruleForm.name" clearable></el-input>
			</el-form-item>
			<el-form-item label="显示名称" prop="displayName">
				<el-input v-model="ruleForm.displayName" clearable></el-input>
			</el-form-item>
			<el-form-item label="描述" prop="description">
				<el-input v-model="ruleForm.description" clearable type="textarea"></el-input>
			</el-form-item>
			<el-form-item label="启用" prop="enabled">
				<el-switch v-model="ruleForm.enabled"> </el-switch>
			</el-form-item>
			<el-form-item label="在发现文档中显示" prop="showInDiscoveryDocument">
				<el-switch v-model="ruleForm.showInDiscoveryDocument" inline-prompt> </el-switch>
			</el-form-item>
			<el-form-item label="必须" prop="required">
				<el-switch v-model="ruleForm.required" inline-prompt> </el-switch>
			</el-form-item>
			<el-form-item label="强调" prop="emphasize">
				<el-switch v-model="ruleForm.emphasize" inline-prompt> </el-switch>
			</el-form-item>
			<el-form-item label="用户声明">
				<!-- <el-input v-model="ruleForm.name" clearable></el-input> -->
				<el-select
					class="elselect"
					v-model="ruleForm.userClaims"
					multiple
					filterable
					allow-create
					default-first-option
					:reserve-keyword="false"
					prop="userClaims"
				>
					<el-option v-for="item in options" :key="item" :label="item" :value="item" />
				</el-select>
			</el-form-item>
		</el-form>
		<template #footer>
			<span class="dialog-footer">
				<el-button @click="onCancel" size="default">取 消</el-button>
				<el-button type="primary" @click="onSubmit">新 增</el-button>
			</span>
		</template>
	</el-dialog>
</template>

<script lang="ts" setup>
import { ElMessage } from 'element-plus';
import { reactive, toRefs, defineComponent, ref, onMounted } from 'vue';
import { identityResourceService } from '/@/api/authcenter/identityresource';
import authConfigService from '/@/api/authcenter/authConfig';
import { createIdentityResourceDto } from '/@/api/authcenter/identityresource/model';
import { msgTool } from '/@/utils/msgTool';

const props = defineProps({
	afterSubmit: Function,
});
const ruleFormRef = ref();
const _identityResourceService = new identityResourceService();
const state = reactive({
	isAdd: true,
	isShowDialog: false,
	entityId: '',
	ruleForm: new createIdentityResourceDto(),
	options: [] as string[],
});
const { isShowDialog, ruleForm, options } = toRefs(state);
// 打开弹窗
const openAdd = () => {
	state.isAdd = true;
	state.isShowDialog = true;
};
const openEdit = async (id: string) => {
	state.isAdd = false;
	state.entityId = id;
	state.isShowDialog = true;
	const { data } = await _identityResourceService.getAsync(id);
	state.ruleForm = data;
};
const handleClose = async () => {
	await msgTool.confirm('确定要关闭吗?');
	closeDialog();
};
// 关闭弹窗
const closeDialog = async () => {
	ruleFormRef.value?.resetFields();
	state.isShowDialog = false;
	state.ruleForm = new createIdentityResourceDto();
};
// 取消
const onCancel = () => {
	handleClose();
};
// 新增
const onSubmit = async () => {
	await ruleFormRef.value?.validate();
	if (state.isAdd) {
		await _identityResourceService.createAsync(state.ruleForm);
	} else {
		await _identityResourceService.updateAsync(state.entityId, state.ruleForm);
	}
	props.afterSubmit?.();
	ElMessage.success('操作成功');
	closeDialog();
};
// 页面加载时
onMounted(async () => {
	const { data } = await authConfigService.getStandardClaims();
	state.options = data;
});
defineExpose({
	openAdd,
	openEdit,
	props,
});
</script>
<style scoped lang="scss">
.system-scope-container {
	.elselect {
		width: 100%;
	}
}
</style>
