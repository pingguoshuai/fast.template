<template>
	<div class="system-scope-container">
		<el-card shadow="hover">
			<div class="system-user-search mb15">
				<!-- <el-input size="default" placeholder="请输入作用域名称" style="max-width: 180px"> </el-input>
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
					新增Api资源
				</el-button>
			</div>
			<el-table :data="state.resultDto.items" style="width: 100%">
				<el-table-column type="index" label="序号" width="60" />
				<el-table-column prop="name" label="名称" show-overflow-tooltip></el-table-column>
				<el-table-column prop="displayName" label="显示名称" show-overflow-tooltip></el-table-column>
				<el-table-column prop="status" label="启用" show-overflow-tooltip>
					<template #default="scope">
						<el-tag type="success" v-if="scope.row.enabled">启用</el-tag>
						<el-tag type="info" v-else>禁用</el-tag>
					</template>
				</el-table-column>
				<el-table-column prop="description" label="描述" show-overflow-tooltip></el-table-column>
				<el-table-column prop="creationTime" label="创建时间" show-overflow-tooltip>
					<template #default="{ row }">
						{{ formatDate(row.creationTime, 'yyyy-mm-dd HH:MM:ss') }}
					</template>
				</el-table-column>
				<el-table-column label="操作" width="280">
					<template #default="scope">
						<el-button size="small" text type="primary" @click="onOpenEdit(scope.row)">修改</el-button>
						<el-button size="small" text type="primary" @click="openProperty(scope.row.id)">管理属性</el-button>
						<el-button size="small" text type="primary" @click="openSecret(scope.row.id)">管理密钥</el-button>
						<el-popconfirm title="确定删除吗?" @confirm="onRowDel(scope.row.id)">
							<template #reference>
								<el-button size="small" text type="primary">删除</el-button>
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
		<AddForm ref="addRef" :after-submit="getData" />
		<ManageProperty
			ref="propertyRef"
			loadUrl="/api/IdsAdmin/api-resource/{0}/properties"
			postUrl="/api/IdsAdmin/api-resource/{0}/add-propery"
			deleteUrl="/api/IdsAdmin/api-resource/{0}/remove-propery?key={1}"
		/>
		<ManageSecret
			ref="secretRef"
			loadUrl="/api/IdsAdmin/api-resource/{0}/secrets"
			postUrl="/api/IdsAdmin/api-resource/{0}/add-secret"
			deleteUrl="/api/IdsAdmin/api-resource/{0}/remove-secret?value={1}&type={2}"
		/>
	</div>
</template>

<script lang="ts" setup>
import { reactive, onMounted, ref } from 'vue';
import { ElMessage } from 'element-plus';
import AddForm from './component/add.vue';
import ManageProperty from '/@/components/authcenter/property.vue';
import ManageSecret from '/@/components/authcenter/secret.vue';
import { formatDate } from '/@/utils';
import { PageResult } from '/@/types/base/pageresult';
import apiResourceService from '/@/api/authcenter/apiresource';
import { apiResourceDto } from '/@/api/authcenter/apiresource/model';
import { PageRequestQuery } from '/@/types/base/querybase';

const addRef = ref();
const propertyRef = ref();
const secretRef = ref();
const state = reactive({
	queryParam: new PageRequestQuery(),
	resultDto: new PageResult<apiResourceDto>(),
});

async function getData(): Promise<void> {
	await apiResourceService.getListAsync(state.queryParam).then((res) => {
		state.resultDto = res.data;
		console.log(state.resultDto);
	});
}

const onOpenAdd = () => {
	addRef.value.openAdd();
};
const onOpenEdit = (row: apiResourceDto) => {
	addRef.value.openEdit(row.id);
};

const openProperty = (id: string) => {
	propertyRef.value.openDrawer(id);
};

const openSecret = (id: string) => {
	secretRef.value.openDrawer(id);
};

const onRowDel = async (id: string) => {
	await apiResourceService.deleteAsync(id);
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
onMounted(() => {
	getData();
});
</script>
