<template>
	<el-drawer v-model="state.isShow" title="声明管理" :before-close="handleClose">
		<div class="drawer__content">
			<el-form :model="state.ruleForm" ref="ruleFormRef">
				<el-form-item label="用户声明" label-width="80px">
					<!-- <el-input v-model="ruleForm.name" clearable></el-input> -->
					<el-select class="elselect" v-model="state.ruleForm.type" filterable allow-create default-first-option :reserve-keyword="false" prop="type">
						<el-option v-for="item in state.claims" :key="item" :label="item" :value="item" />
					</el-select>
				</el-form-item>
				<!-- <el-form-item label="声明类型" label-width="80px" prop="type" :rules="[
                    { required: true, message: '声明类型' }
                ]">
                    <el-input v-model="state.ruleForm.type" autocomplete="off" />
                </el-form-item> -->
				<el-form-item label="声明值" label-width="80px" prop="value" :rules="[{ required: true, message: '声明值' }]">
					<el-input v-model="state.ruleForm.value" autocomplete="off" />
				</el-form-item>
			</el-form>
			<div class="pl30 pt30 pb30">
				<el-button type="primary" @click="onSubmit">新 增</el-button>
			</div>
		</div>
		<div>
			<el-table :data="state.resultDto">
				<el-table-column property="type" label="声明类型" width="200" />
				<el-table-column property="value" label="声明值" />
				<el-table-column #default="{ row }">
					<el-popconfirm title="确定删除吗?" @confirm="onDelete(row.type)">
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
import { onMounted, reactive, ref } from 'vue';
import authConfigService from '/@/api/authcenter/authConfig';
import request from '/@/utils/request';

const props = defineProps<{
	loadUrl: string;
	postUrl: string;
	deleteUrl: string;
}>();

const ruleFormRef = ref();

const state = reactive({
	resultDto: [],
	id: '',
	isShow: false,
	claims: [] as string[],
	ruleForm: { type: '', value: '' },
});

const openDrawer = (id: string) => {
	state.isShow = true;
	state.id = id;
	getData();
};

const getData = async () => {
	const { data } = await request({
		url: props.loadUrl.format(state.id),
		method: 'GET',
	});
	state.resultDto = data;
};

const onSubmit = async () => {
	await ruleFormRef.value.validate();
	await request({
		url: props.postUrl.format(state.id),
		method: 'POST',
		data: state.ruleForm,
	});
	ruleFormRef.value?.resetFields();
	getData();
};

const onDelete = async (type: string) => {
	await request({
		url: props.deleteUrl.format(state.id, type),
		method: 'DELETE',
	});
	getData();
};

const handleClose = () => {
	ruleFormRef.value?.resetFields();
	state.isShow = false;
	state.resultDto = [];
};
onMounted(async () => {
	{
		const { data } = await authConfigService.getStandardClaims();
		state.claims = data;
	}
});
defineExpose({
	openDrawer,
});
</script>
