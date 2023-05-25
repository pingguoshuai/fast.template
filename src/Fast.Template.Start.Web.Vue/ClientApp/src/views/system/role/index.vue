<template>
	<div class="system-role-container">
		<el-card shadow="hover">
			<div class="system-user-search mb15">
				<!-- <el-input size="default" placeholder="请输入角色名称" style="max-width: 180px"> </el-input>
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
					新增角色
				</el-button>
			</div>
			<el-table :data="state.resultDto.items" style="width: 100%">
				<el-table-column type="index" label="序号" width="60" />
				<el-table-column prop="name" label="角色名称" show-overflow-tooltip></el-table-column>
				<el-table-column prop="status" label="公开" show-overflow-tooltip>
					<template #default="scope">
						<el-icon color="green" :size="20" v-if="scope.row.isPublic"><ele-CircleCheckFilled /></el-icon>
						<el-icon color="red" :size="20" v-else><ele-CircleCloseFilled /></el-icon>
					</template>
				</el-table-column>
				<el-table-column prop="status" label="默认" show-overflow-tooltip>
					<template #default="scope">
						<el-icon color="green" :size="20" v-if="scope.row.isDefault"><ele-CircleCheckFilled /></el-icon>
						<el-icon color="red" :size="20" v-else><ele-CircleCloseFilled /></el-icon>
					</template>
				</el-table-column>
				<el-table-column label="操作" width="100">
					<template #default="scope">
						<el-button :disabled="scope.row.isStatic" size="small" text type="primary" @click="onOpenEdit(scope.row)">修改</el-button>
						<el-popconfirm title="确定删除吗?" @confirm="onDel(scope.row.id)">
							<template #reference>
								<el-button :disabled="scope.row.isStatic" size="small" text type="primary">删除</el-button>
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
		<Add ref="addRef" :after-submit="getData" />
		<!-- <EditRole ref="editRoleRef" /> -->
	</div>
</template>

<script setup lang="ts">
import { onMounted, reactive, ref } from 'vue';
import Add from '/@/views/system/role/component/add.vue';
import { roleService } from '/@/api/system/role';
import { roleDto } from '/@/types/api/system/role';
import { PageResult } from '/@/types/base/pageresult';
import { PageRequestQuery } from '/@/types/base/querybase';
import { ElMessage } from 'element-plus';

const addRef = ref();

const state = reactive({
	queryParam: new PageRequestQuery(),
	resultDto: new PageResult<roleDto>(),
});

const apiService = new roleService();

const onOpenAdd = () => {
	addRef.value.openAdd();
};

const onOpenEdit = (row: roleDto) => {
	addRef.value.openEdit(row.id);
};

const onDel = async (row: roleDto) => {
	await apiService.deleteAsync(row.id);
	ElMessage.success('删除成功');
	getData();
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

const getData = async () => {
	const { data } = await apiService.getListAsync(state.queryParam);
	state.resultDto = data;
};

onMounted(() => {
	getData();
});
</script>
