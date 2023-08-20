<template>
	<el-dialog :title="state.title" v-model="state.isShow" width="70%" :before-close="closeDialog">
		<span></span>
		<template #footer>
			<span>
				<el-button @click="closeDialog">Cancel</el-button>
				<el-button type="primary" @click="updatePermissions">OK</el-button>
			</span>
		</template>
		<el-tabs v-model="activeName" type="card" tab-position="left" @tab-click="tabChange" class="demo-tabs">
			<el-tab-pane v-for="group in state.permissionDto.groups" :key="group.displayNameKey" :label="group.displayNameKey" :name="group.displayNameKey">
				<el-scrollbar height="600px">
					<!-- <el-tree ref="tree" :data="item.permissions" :props="defaultProps" empty-text="" show-checkbox highlight-current @node-click=""></el-tree> -->
					<el-row>
						<el-col :span="24" :offset="0">
							<el-checkbox v-model="state.IsAllGranted" label="全选" @change="checkboxTabAllChange(group)" size="large" />
						</el-col>
					</el-row>

					<el-row>
						<el-col v-for="item in group.permissions" :class="{ pl30: item.parentName }" :span="getSpan(item)">
							<el-checkbox v-model="item.isGranted" :disabled="isGrantedByOtherProviderName(item)" :label="item.displayName" @change="checkboxChange(group, item, group.permissions)" size="large" />
						</el-col>
					</el-row>
				</el-scrollbar>
			</el-tab-pane>
		</el-tabs>
	</el-dialog>
</template>
<script lang="ts" setup>
import { onMounted, reactive, ref } from 'vue';
import { permissionService } from '/@/api/system/permission';
import { GetPermissionListResultDto, PermissionGrantInfoDto, PermissionGroupDto, ProviderInfoDto } from '/@/api/system/permission/model';
import { ElMessage, imageEmits, stepProps } from 'element-plus';

const service = new permissionService();
const activeName = ref('first');
const state = reactive({
	isShow: false,
	permissionDto: new GetPermissionListResultDto(),
	title: 'permission',
	currentProviderName: '',
	currnetProviderKey: '',
	currnetProviderKeyDisplayName: '',
	IsAllGranted: false,
});

const selectGroup = ref<PermissionGroupDto>();

const open = (providerName: string, providerKey: string, displayName: string) => {
	state.isShow = true;
	state.currentProviderName = providerName;
	state.currnetProviderKey = providerKey;
	getData(providerName, providerKey, displayName);
};

const closeDialog = () => {
	state.isShow = false;
	state.permissionDto = new GetPermissionListResultDto();
	state.title = 'permission';
	state.currentProviderName = '';
	state.currnetProviderKey = '';
};

const getSpan = (item: PermissionGrantInfoDto) => {
	return item.parentName ? 12 : 24;
};

// const IsAllGranted = (item: PermissionGrantInfoDto) => {
// 	return item.isGranted;
// };

const tabChange = (tab: any, event: any) => {
	setTabCheckBoxState(state.permissionDto.groups[tab.index]);
};

const setTabCheckBoxState = (group: PermissionGroupDto) => {
	state.IsAllGranted = group.permissions.every((element) => element.isGranted);
};

const isGrantedByOtherProviderName = (item: PermissionGrantInfoDto) => {
	if (item.grantedProviders.length) {
		return item.grantedProviders.findIndex((p) => p.providerName !== state.currentProviderName) > -1;
	}
	return false;
};

const checkboxTabAllChange = (group: PermissionGroupDto) => {
	// console.log(group);
	group.permissions.forEach((element) => {
		if (element.isGranted && isGrantedByOtherProviderName(element)) {
			return;
		}
		element.isGranted = state.IsAllGranted;
	});
};

const checkboxChange = (group: PermissionGroupDto, item: PermissionGrantInfoDto, permissions: PermissionGrantInfoDto[]) => {
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
	setTabCheckBoxState(group);
};

const updatePermissions = async () => {
	const permissions: any = [];
	state.permissionDto?.groups?.forEach((element: any) => {
		if (element.permissions) {
			permissions.push(...element.permissions);
		}
	});

	await service.updateAsync(state.currentProviderName, state.currnetProviderKey, permissions);

	ElMessage.success('操作成功');
	closeDialog();
};

const getData = async (providerName: string, providerKey: string, displayName: string) => {
	const { data } = await service.getAsync(providerName, providerKey);

	state.permissionDto = data;
	state.title = 'permission-' + displayName;
	activeName.value = data.groups.length > 0 ? data.groups[0].displayNameKey : '';
	selectGroup.value = data.groups[0];
};

onMounted(() => {
	// getData();
});

defineExpose({ open, closeDialog });
</script>
<style>
.demo-tabs > .el-tabs__content {
	padding: 5px 32px;
	color: #6b778c;
	font-size: 32px;
	font-weight: 600;
}

.el-tabs--right .el-tabs__content,
.el-tabs--left .el-tabs__content {
	height: 100%;
}
</style>
