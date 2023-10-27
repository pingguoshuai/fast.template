<template>
	<el-dialog title="角色" v-model="state.isShow" width="30%" :before-close="closeDialog">
		<el-form :model="state.formData" ref="formRef" label-width="80px" :inline="false">
			<el-form-item label="角色">
				<el-select class="m-2" v-model="state.formData.roleNames" placeholder="请选择角色" multiple>
					<el-option v-for="item in state.roles" :key="item.name" :label="item.name" :value="item.name" />
				</el-select>
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
import { reactive, ref, onMounted } from 'vue';
import userService from '/@/api/system/identityuser';
import { roleDto } from '/@/api/system/role/model';
import { identityUserUpdateRolesDto } from '/@/api/system/identityuser/model';

const formRef = ref();

const state = reactive({
	isShow: false,
	entityId: '',
	formData: new identityUserUpdateRolesDto(),
	roles: [] as roleDto[],
});

const open = async (id: string) => {
	state.isShow = true;
	state.entityId = id;
	const { data } = await userService.getRolesAsync(id);
	let roles: string[] = [];
	data.items.forEach(function (item: roleDto) {
		roles.push(item.name);
	});
	state.formData.roleNames = roles;
};

const onSubmit = async () => {
	await formRef.value?.validate();
	await userService.updateRolesAsync(state.entityId, state.formData);
	ElMessage.success('操作成功');
	closeDialog();
};

const closeDialog = async () => {
	formRef.value?.resetFields();
	state.isShow = false;
	state.formData = new identityUserUpdateRolesDto();
};

onMounted(async () => {
	const { data } = await userService.getAssignableRolesAsync();
	state.roles = data.items;
});

defineExpose({
	open,
});
</script>
