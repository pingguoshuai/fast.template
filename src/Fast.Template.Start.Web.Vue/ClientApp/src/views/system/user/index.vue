<template>
	<div class="system-user-container">
		<el-card shadow="hover">
			<div class="system-user-search mb15">
				<!-- <el-input size="default" placeholder="请输入用户名称" style="max-width: 180px"> </el-input>
				<el-button size="default" type="primary" class="ml10">
					<el-icon>
						<ele-Search />
					</el-icon>
					查询
				</el-button> -->
				<el-button size="default" type="success" class="ml10" @click="onOpenAdd">
					<el-icon>
						<ele-FolderAdd />
					</el-icon>
					新增用户
				</el-button>
			</div>
			<el-table :data="state.resultDto.items">
				<el-table-column type="index" label="序号" width="60" />
				<el-table-column prop="userName" label="账户名称" show-overflow-tooltip></el-table-column>
				<el-table-column prop="name" label="用户名称" show-overflow-tooltip></el-table-column>
				<el-table-column prop="phoneNumber" label="手机号" show-overflow-tooltip></el-table-column>
				<el-table-column prop="email" label="邮箱" show-overflow-tooltip></el-table-column>
				<el-table-column prop="status" label="锁定启用" show-overflow-tooltip>
					<template #default="scope">
						<el-tag type="success" v-if="scope.row.lockoutEnabled">启用</el-tag>
						<el-tag type="info" v-else>禁用</el-tag>
					</template>
				</el-table-column>
				<el-table-column prop="creationTime" label="锁定结束" show-overflow-tooltip>
					<template #default="{ row }">
						{{ formatDate(row.lockoutEnd, 'yyyy-mm-dd HH:MM:ss') }}
					</template>
				</el-table-column>
				<el-table-column prop="creationTime" label="创建时间" show-overflow-tooltip>
					<template #default="{ row }">
						{{ formatDate(row.creationTime, 'yyyy-mm-dd HH:MM:ss') }}
					</template>
				</el-table-column>
				<el-table-column label="操作" width="200">
					<template #default="scope">
						<el-tooltip class="box-item" effect="dark" content="编辑" placement="top-start">
							<el-button :disabled="scope.row.userName === 'admin'" type="primary" :icon="Edit" circle size="small" @click="onOpenEdit(scope.row)" />
						</el-tooltip>
						<el-tooltip class="box-item" effect="dark" content="声明" placement="top-start">
							<el-button :disabled="scope.row.userName === 'admin'" type="primary" :icon="Tickets" circle size="small" @click="onOpenClaim(scope.row)" />
						</el-tooltip>
						<el-tooltip class="box-item" effect="dark" content="权限" placement="top-start">
							<el-button type="primary" :icon="Lock" circle size="small" @click="onOpenPermission(scope.row)" />
						</el-tooltip>
						<el-tooltip class="box-item" effect="dark" content="角色" placement="top-start">
							<el-button :disabled="scope.row.userName === 'admin'" type="primary" :icon="User" circle size="small" @click="onOpenRole(scope.row)" />
						</el-tooltip>
						<el-popconfirm title="确定删除吗?" @confirm="onDel(scope.row)">
							<template #reference>
								<!-- <el-tooltip class="box-item" effect="dark" content="删除" placement="top-start">
									<el-button :disabled="scope.row.userName === 'admin'" type="danger" :icon="Delete" circle size="small" />
								</el-tooltip> -->
								<el-button :disabled="scope.row.userName === 'admin'" type="danger" :icon="Delete" circle size="small" />
							</template>
						</el-popconfirm>
					</template>
				</el-table-column>
			</el-table>
			<el-pagination
				@size-change="onHandleSizeChange"
				@current-change="onHandleCurrentChange"
				class="mt15"
				:pager-count="5"
				:page-sizes="[2, 10, 20, 30]"
				v-model:current-page="state.queryParam.CurrentPage"
				background
				v-model:page-size="state.queryParam.maxResultCount"
				layout="total, sizes, prev, pager, next, jumper"
				:total="state.resultDto.totalCount"
			>
			</el-pagination>
		</el-card>
		<AddUer ref="addRef" :after-submit="getData" />
		<Claim ref="claimRef" />
		<Role ref="roleRef" />
		<Permission ref="permissionRef" />
	</div>
</template>

<script lang="ts" setup>
import { Edit, Delete, User, Lock, Tickets } from '@element-plus/icons-vue';
import { toRefs, reactive, onMounted, ref, defineComponent } from 'vue';
import { ElMessageBox, ElMessage } from 'element-plus';
import { formatDate } from '/@/utils';
import AddUer from '/@/views/system/user/component/add.vue';
import Claim from '/@/views/system/user/component/claim.vue';
import Role from '/@/views/system/user/component/role.vue';
import Permission from '/@/views/system/role/component/permission.vue';
import { PageRequestQuery } from '/@/types/base/querybase';
import { PageResult } from '/@/types/base/pageresult';
import { identityUserDto } from '/@/types/api/system/user/identityuser';
import { userService } from '/@/api/system/identityuser';

const addRef = ref();
const claimRef = ref();
const roleRef = ref();
const permissionRef = ref();

const state = reactive({
	queryParam: new PageRequestQuery(),
	resultDto: new PageResult<identityUserDto>(),
});

const apiService = new userService();

const getData = async () => {
	const { data } = await apiService.getListAsync(state.queryParam);
	state.resultDto = data;
};

const onOpenAdd = () => {
	addRef.value.openAdd();
};

const onOpenEdit = (row: identityUserDto) => {
	addRef.value.openEdit(row.id);
};

const onDel = async (row: identityUserDto) => {
	await apiService.deleteAsync(row.id);
	ElMessage.success('删除成功');
	getData();
};

const onOpenClaim = (row: identityUserDto) => {
	claimRef.value.openDrawer(row.id);
};

const onOpenRole = (row: identityUserDto) => {
	roleRef.value.open(row.id);
};

const onOpenPermission = (row: identityUserDto) => {
	permissionRef.value.open('U', row.id, row.userName);
};

// 分页改变
const onHandleSizeChange = (val: number) => {
	state.queryParam.MaxResultCount = val;
	getData();
};
// 分页改变
const onHandleCurrentChange = (val: number) => {
	state.queryParam.CurrentPage = val;
	getData();
};
onMounted(() => {
	getData();
});
</script>
