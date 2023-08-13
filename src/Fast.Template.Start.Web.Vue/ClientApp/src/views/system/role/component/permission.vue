<template>
	<el-dialog :title="state.title" v-model="state.isShow" width="70%" :before-close="closeDialog">
		<span></span>
		<template #footer>
			<span>
				<el-button @click="closeDialog">Cancel</el-button>
				<el-button type="primary" @click="">OK</el-button>
			</span>
		</template>
		<el-tabs v-model="activeName" type="card" tab-position="left" @tab-click="">
			<el-tab-pane v-for="group in state.permissionDto.groups" :key="group.displayNameKey" :label="group.displayNameKey" :name="group.displayNameKey">
				<!-- <el-tree ref="tree" :data="item.permissions" :props="defaultProps" empty-text="" show-checkbox highlight-current @node-click=""></el-tree> -->
				<el-row :gutter="20">
					<el-col v-for="item in group.permissions" :class="{ pl30: item.parentName }" :span="getSpan(item)">
						<el-checkbox v-model="item.isGranted" :label="item.displayName" size="large" />
					</el-col>
				</el-row>
			</el-tab-pane>
		</el-tabs>
	</el-dialog>
</template>
<script lang="ts" setup>
import { onMounted, reactive, ref } from 'vue';
import { permissionService } from '/@/api/system/permission';
import { GetPermissionListResultDto, PermissionGrantInfoDto } from '/@/api/system/permission/model';

const service = new permissionService();
const activeName = ref('first');
const state = reactive({
	isShow: false,
	permissionDto: new GetPermissionListResultDto(),
	title: 'permission',
});

const defaultProps = {
	children: 'children',
	label: 'displayName',
};

const closeDialog = () => {
	state.isShow = false;
};

const open = (providerName: string, providerKey: string) => {
	state.isShow = true;
	getData(providerName, providerKey);
};
const getSpan = (item: PermissionGrantInfoDto) => {
	return item.parentName ? 8 : 24;
};

const getData = async (providerName: string, providerKey: string) => {
	const { data } = await service.getAsync(providerName, providerKey);
	state.permissionDto = data;
	state.title = 'permission-' + providerKey;
	activeName.value = data.groups.length > 0 ? data.groups[0].displayNameKey : '';
	console.log(data);
};

onMounted(() => {
	// getData();
});

defineExpose({ open, closeDialog });
</script>
