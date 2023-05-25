<template>
	<el-dialog title="编辑" v-model="state.isShow" width="35%" :before-close="closeDialog">
		<el-form :model="state.formData" ref="formRef" label-width="80px">
			<el-form-item label="用户名" prop="name" :rules="[{ required: true, message: '请填写角色名称' }]">
				<el-input v-model="state.formData.name"></el-input>
			</el-form-item>
			<el-form-item label="公开" prop="isPublic">
				<el-switch v-model="state.formData.isPublic" />
			</el-form-item>
			<el-form-item label="默认" prop="isDefault">
				<el-switch v-model="state.formData.isDefault" />
			</el-form-item>
		</el-form>

		<template #footer>
			<span class="dialog-footer">
				<el-button @click="closeDialog">取 消</el-button>
				<el-button type="primary" @click="onSubmit">确 定</el-button>
			</span>
		</template>
	</el-dialog>
</template>
<script setup lang="ts">
import { ElMessage } from 'element-plus';
import { reactive, ref } from 'vue';
import { roleService } from '/@/api/system/role';
import { createRoleDto } from '/@/types/api/system/role';

const props = defineProps<{
	afterSubmit: Function;
}>();

const formRef = ref();
const state = reactive({
	isShow: false,
	isAdd: true,
	entityId: '',
	formData: new createRoleDto(),
});

const apiService = new roleService();

const openAdd = () => {
	state.isShow = true;
	state.isAdd = true;
};

const openEdit = async (id: string) => {
	state.isAdd = false;
	state.entityId = id;
	state.isShow = true;
	const { data } = await apiService.getAsync(id);
	state.formData = data;
};

const onSubmit = async () => {
	await formRef.value?.validate();
	if (state.isAdd) {
		await apiService.createAsync(state.formData);
	} else {
		await apiService.updateAsync(state.entityId, state.formData);
	}
	props.afterSubmit();
	ElMessage.success('操作成功');
	closeDialog();
};

const closeDialog = async () => {
	formRef.value?.resetFields();
	state.isShow = false;
	state.formData = new createRoleDto();
};

defineExpose({
	openAdd,
	openEdit,
});
</script>
