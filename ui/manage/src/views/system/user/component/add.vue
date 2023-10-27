<template>
	<el-dialog title="编辑" v-model="state.isShow" width="35%" :before-close="closeDialog">
		<el-form :model="state.formData" ref="formRef" label-width="80px">
			<el-form-item label="用户名" prop="userName" :rules="[{ required: true, message: '请填写用户名' }]">
				<el-input v-model="state.formData.userName"></el-input>
			</el-form-item>
			<el-form-item label="密码" prop="password" :rules="[{ required: true, message: '请填写密码' }]">
				<el-input v-model="state.formData.password" type="password"></el-input>
			</el-form-item>
			<el-form-item label="Email" prop="email" :rules="[{ required: true, type: 'email', message: '请填写Email' }]">
				<el-input v-model="state.formData.email"></el-input>
			</el-form-item>
			<el-form-item label="姓" prop="surname">
				<el-input v-model="state.formData.surname"></el-input>
			</el-form-item>
			<el-form-item label="名" prop="name">
				<el-input v-model="state.formData.name"></el-input>
			</el-form-item>
			<el-form-item label="手机号" prop="phoneNumber">
				<el-input v-model="state.formData.phoneNumber"></el-input>
			</el-form-item>
			<el-form-item label="锁定启用" prop="lockoutEnabled">
				<el-switch v-model="state.formData.lockoutEnabled" />
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
import userService from '/@/api/system/identityuser';
import { createIdentityUserDto } from '/@/api/system/identityuser/model';

const props = defineProps<{
	afterSubmit: Function;
}>();

const formRef = ref();
const state = reactive({
	isShow: false,
	isAdd: true,
	entityId: '',
	formData: new createIdentityUserDto(),
});

const openAdd = () => {
	state.isShow = true;
	state.isAdd = true;
};

const openEdit = async (id: string) => {
	state.isAdd = false;
	state.entityId = id;
	state.isShow = true;
	const { data } = await userService.getAsync(id);
	state.formData = data as unknown as createIdentityUserDto;
};

const onSubmit = async () => {
	await formRef.value?.validate();
	if (state.isAdd) {
		await userService.createAsync(state.formData);
	} else {
		await userService.updateAsync(state.entityId, state.formData);
	}
	props.afterSubmit();
	ElMessage.success('操作成功');
	closeDialog();
};

const closeDialog = async () => {
	formRef.value?.resetFields();
	state.isShow = false;
	state.formData = new createIdentityUserDto();
};

defineExpose({
	openAdd,
	openEdit,
});
</script>
