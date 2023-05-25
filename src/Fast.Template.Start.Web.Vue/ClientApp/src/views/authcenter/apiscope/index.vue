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
					新增作用域
				</el-button>
			</div>
			<el-table :data="resultDto.items" style="width: 100%">
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
				<el-table-column label="操作" width="200">
					<template #default="scope">
						<el-button size="small" text type="primary" @click="onOpenEdit(scope.row)">修改</el-button>
						<el-button size="small" text type="primary" @click="openProperty(scope.row)">管理属性</el-button>
						<!-- <el-button size="small" text type="primary" @click="onRowDel(scope.row)">删除</el-button> -->
						<el-popconfirm title="确定删除吗?" @confirm="onRowDel(scope.row.id)">
							<template #reference>
								<el-button size="small" text type="primary">删除</el-button>
							</template>
						</el-popconfirm>
					</template>
				</el-table-column>
			</el-table>
			<el-pagination @size-change="onHandleSizeChange" @current-change="onHandleCurrentChange" class="mt15"
				:pager-count="5" :page-sizes="[2, 10, 20, 30]" v-model:current-page="queryParam.CurrentPage" background
				v-model:page-size="queryParam.maxResultCount" layout="total, sizes, prev, pager, next, jumper"
				:total="resultDto.totalCount">
			</el-pagination>
		</el-card>
		<AddScope ref="addScopeRef" @reload="getData" />
		<ManageProperty ref="propertyRef" loadUrl="/api/IdsAdmin/api-scope/{0}/properties"
			postUrl="/api/IdsAdmin/api-scope/{0}/add-propery"
			deleteUrl="/api/IdsAdmin/api-scope/{0}/remove-propery?key={1}" />
	</div>
</template>

<script lang="ts">
import { toRefs, reactive, onMounted, ref, defineComponent } from 'vue';
import { ElMessage } from 'element-plus';
import AddScope from './component/add.vue';
import ManageProperty from '/@/components/authcenter/property.vue';
import { formatDate } from '/@/utils'
import { ApiScopeDto } from '/@/types/api/authcenter/apiscope';
import { PageResult } from '/@/types/base/pageresult';
import { apiScopeDelete, apiScopeGetList } from '/@/api/authcenter/apiscope';
import { PageRequestQuery } from '/@/types/base/querybase';

export default defineComponent({
	name: 'authScope',
	components: { AddScope, ManageProperty },
	setup() {
		const addScopeRef = ref();
		const propertyRef = ref();
		const state = reactive({
			formatDate,
			queryParam: new PageRequestQuery(),
			resultDto: new PageResult<ApiScopeDto>()
		});

		async function getData(): Promise<void> {
			await apiScopeGetList(state.queryParam)
				.then(res => {
					state.resultDto = res.data
					console.log(state.resultDto)
				})
		}

		// 打开新增
		const onOpenAdd = () => {
			addScopeRef.value.openAdd();
		};
		// 打开修改
		const onOpenEdit = (row: ApiScopeDto) => {
			console.log(addScopeRef.value)
			addScopeRef.value.openEdit(row.id);
		};

		const openProperty = async (row: ApiScopeDto) => {
			propertyRef.value.openDrawer(row.id);
		};

		// 删除
		const onRowDel = async (id: string) => {
			await apiScopeDelete(id);
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
		// 页面加载时
		onMounted(() => {
			getData();
		});
		return {
			addScopeRef,
			propertyRef,
			onOpenAdd,
			onOpenEdit,
			openProperty,
			onRowDel,
			onHandleSizeChange,
			onHandleCurrentChange,
			getData,
			...toRefs(state),
		};
	},
});
</script>
