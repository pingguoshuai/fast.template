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
			<el-tab-pane class="pl30" v-for="group in state.permissionDto.groups" :key="group.displayNameKey" :label="group.displayNameKey" :name="group.displayNameKey">
				<!-- <el-tree ref="tree" :data="item.permissions" :props="defaultProps" empty-text="" show-checkbox highlight-current @node-click=""></el-tree> -->
				<el-row :gutter="20" class="mb20">
					<el-col :span="24" :offset="0">
						<el-checkbox v-model="group.isAllGranted" label="全选" @change="checkboxAllChange(group)" size="large" />
					</el-col>
				</el-row>

				<el-row :gutter="20">
					<el-col v-for="item in group.permissions" :class="{ pl30: item.parentName }" :span="getSpan(item)">
						<el-checkbox v-model="item.isGranted" :label="item.displayName" @change="checkboxChange(item, group.permissions)" size="large" />
					</el-col>
				</el-row>
			</el-tab-pane>
		</el-tabs>
	</el-dialog>
</template>
<script lang="ts" setup>
import { onMounted, reactive, ref } from 'vue';
import { permissionService } from '/@/api/system/permission';
import { GetPermissionListResultDto, PermissionGrantInfoDto, PermissionGroupDto } from '/@/api/system/permission/model';

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

// const isDisabled = () => {
// 	return props
// };

const checkboxAllChange = (group: PermissionGroupDto) => {
	console.log(group);
};

const checkboxChange = (item: PermissionGrantInfoDto, permissions: PermissionGrantInfoDto[]) => {
	console.log(item.isGranted);
	console.log(item.parentName);

	//分组选中，子元素全部选中
	if (!item.parentName && item.isGranted) {
		permissions.forEach((element) => {
			if (item.name == element.parentName) {
				element.isGranted = true;
			}
		});
	}

	// 分组未选中，子元素全部不选中
	if (!item.parentName && !item.isGranted) {
		permissions.forEach((element) => {
			if (item.name == element.parentName) {
				element.isGranted = false;
			}
		});
	}
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
