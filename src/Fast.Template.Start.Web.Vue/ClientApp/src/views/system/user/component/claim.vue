<template>
	<el-drawer v-model="state.isShow" title="声明管理" :before-close="handleClose" size="40%">
		<div class="drawer__content">
			<el-form :model="state.ruleForm" ref="ruleFormRef">
				<el-form-item label="用户声明" label-width="80px" prop="claimType" :rules="[{ required: true, message: '声明值' }]">
					<!-- <el-input v-model="ruleForm.name" clearable></el-input> -->
					<el-select class="elselect" v-model="state.ruleForm.claimType" filterable allow-create default-first-option :reserve-keyword="false" prop="claimType">
						<el-option v-for="item in state.claims" :key="item" :label="item" :value="item" />
					</el-select>
				</el-form-item>
				<!-- <el-form-item label="声明类型" label-width="80px" prop="type" :rules="[
                    { required: true, message: '声明类型' }
                ]">
                    <el-input v-model="state.ruleForm.type" autocomplete="off" />
                </el-form-item> -->
				<el-form-item label="声明值" label-width="80px" prop="claimValue" :rules="[{ required: true, message: '声明值' }]">
					<el-input v-model="state.ruleForm.claimValue" autocomplete="off" />
				</el-form-item>
			</el-form>
			<div class="pl30 pt30 pb30">
				<el-button type="primary" @click="onSubmit">新 增</el-button>
			</div>
		</div>
		<div>
			<el-table :data="state.resultDto">
				<el-table-column property="claimType" label="声明类型" width="200" />
				<el-table-column property="claimValue" label="声明值" />
				<el-table-column #default="{ row }">
					<el-popconfirm title="确定删除吗?" @confirm="onDelete(row)">
						<template #reference>
							<el-button size="small" text type="primary">删除</el-button>
						</template>
					</el-popconfirm>
				</el-table-column>
			</el-table>
		</div>
	</el-drawer>
</template>
<script lang="ts" setup>
import { Edit, Delete } from '@element-plus/icons-vue';
import { onMounted, reactive, ref } from 'vue';
import { getStandardClaims } from '/@/api/config';
import { userService } from '/@/api/system/identityuser';
import { claimDto } from '/@/types/api/system/user/claim';
import request from '/@/utils/request';

const ruleFormRef = ref();
const apiService = new userService();

const state = reactive({
	resultDto: [],
	id: '',
	isShow: false,
	claims: [],
	ruleForm: new claimDto(),
});

const openDrawer = (id: string) => {
	state.isShow = true;
	state.id = id;
	getData();
};

const getData = async () => {
	const { data } = await apiService.getCliamsAsync(state.id);
	console.log(data);
	state.resultDto = data;
};

const onSubmit = async () => {
	await ruleFormRef.value.validate();
	await apiService.addClaimAsync(state.id, state.ruleForm);
	ruleFormRef.value?.resetFields();
	getData();
};

const onDelete = async (row: claimDto) => {
	await apiService.removeClaimAsync(state.id, row);
	getData();
};

const handleClose = () => {
	ruleFormRef.value?.resetFields();
	state.isShow = false;
	state.resultDto = [];
};
onMounted(async () => {
	{
		const { data } = await getStandardClaims();
		state.claims = data;
	}
});
defineExpose({
	openDrawer,
});
</script>
