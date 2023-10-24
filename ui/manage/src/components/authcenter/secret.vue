<template>
	<el-drawer v-model="state.isShow" title="密钥管理" :before-close="handleClose" size="35%">
		<div class="drawer__content">
			<el-form :model="state.ruleForm" ref="ruleFormRef">
				<el-form-item label="密钥类型" label-width="80px" prop="type" :rules="[{ required: true, message: '请选择密钥类型' }]">
					<el-select v-model="state.ruleForm.type" placeholder="" filterable>
						<el-option v-for="item in state.secretTypes" :key="item" :label="item" :value="item"> </el-option>
					</el-select>
				</el-form-item>
				<el-form-item label="哈希类型" label-width="80px" prop="hashType" v-show="state.ruleForm.type == 'SharedSecret'">
					<el-select v-model="state.ruleForm.hashType" placeholder="" filterable>
						<el-option v-for="item in state.hashTypes" :key="item.value" :label="item.key" :value="item.value"> </el-option>
					</el-select>
				</el-form-item>
				<el-form-item label="密钥值" label-width="80px" prop="value" :rules="[{ required: true, message: '请填写密钥值' }]">
					<el-input v-model="state.ruleForm.value" autocomplete="off" />
				</el-form-item>
				<el-form-item label="到期时间" label-width="80px" prop="value">
					<el-date-picker v-model="state.ruleForm.expiration" type="date" :editable="false" format="YYYY-MM-DD" placeholder="选择日期时间">
					</el-date-picker>
				</el-form-item>
				<el-form-item label="描述" label-width="80px" prop="description">
					<el-input v-model="state.ruleForm.description" autocomplete="off" />
				</el-form-item>
			</el-form>
			<div class="pl30 pt30 pb30">
				<el-button type="primary" @click="onSubmit">新 增</el-button>
			</div>
		</div>
		<div>
			<el-table :data="state.resultDto">
				<el-table-column property="type" label="类型" width="180" />
				<el-table-column property="description" label="描述" width="80" />
				<el-table-column prop="expiration" label="到期时间" show-overflow-tooltip>
					<template #default="{ row }">
						{{ formatDate(row.expiration, 'yyyy-mm-dd') }}
					</template>
				</el-table-column>
				<el-table-column #default="{ row }" width="60">
					<el-popconfirm title="确定删除吗?" @confirm="onDelete(row.value, row.type)">
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
import { secretDto } from '/@/api/authcenter/model';
import request from '/@/utils/request';
import { formatDate } from '/@/utils';
import { IKeyValue } from '/@/types/base/keyvalue';

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
	ruleForm: new secretDto(),
	secretTypes: [] as string[],
	hashTypes: [] as IKeyValue[],
});

const openDrawer = (id: string) => {
	state.isShow = true;
	state.id = id;
	state.ruleForm.type = state.secretTypes[0];
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
	// return;
	await request({
		url: props.postUrl.format(state.id),
		method: 'POST',
		data: state.ruleForm,
	});
	ruleFormRef.value?.resetFields();
	getData();
};

const onDelete = async (value: string, type: string) => {
	await request({
		url: props.deleteUrl.format(state.id, encodeURIComponent(value), type),
		method: 'DELETE',
	});
	getData();
};

const handleClose = () => {
	ruleFormRef.value?.resetFields();
	state.isShow = false;
	state.resultDto = [];
	state.ruleForm = new secretDto();
};

onMounted(async () => {
	const { data } = await authConfigService.getSecretTypes();
	state.secretTypes = data;

	{
		const { data } = await authConfigService.getHashTypes();
		state.hashTypes = data;
	}
});

defineExpose({
	openDrawer,
});
</script>
