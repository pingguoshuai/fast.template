<template>
    <el-drawer v-model="state.isShow" title="属性管理" :before-close="handleClose">
        <div class="drawer__content">
            <el-form :model="state.ruleForm" ref="ruleFormRef">
                <el-form-item label="键" label-width="80px" prop="key" :rules="[
                    { required: true, message: '请填写键' }
                ]">
                    <el-input v-model="state.ruleForm.key" autocomplete="off" />
                </el-form-item>
                <el-form-item label="值" label-width="80px" prop="value" :rules="[
                    { required: true, message: '请填写值' }
                ]">
                    <el-input v-model="state.ruleForm.value" autocomplete="off" />
                </el-form-item>
            </el-form>
            <div class="pl30 pt30 pb30">
                <el-button type="primary" @click="onSubmit">新 增</el-button>
            </div>
        </div>
        <div>
            <el-table :data="state.resultDto">
                <el-table-column property="key" label="键" width="200" />
                <el-table-column property="value" label="值" />
                <el-table-column #default="{ row }">
                    <el-popconfirm title="确定删除吗?" @confirm="onDelete(row.key)">
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
import { reactive, ref } from 'vue';
import request from '/@/utils/request';

const props = defineProps<{
    loadUrl: string,
    postUrl: string,
    deleteUrl: string
}>();

const ruleFormRef = ref();

const state = reactive({
    resultDto: [],
    id: "",
    isShow: false,
    ruleForm: { key: "", value: "" }
});

const openDrawer = (id: string) => {
    state.isShow = true;
    state.id = id;
    getData();
}

const getData = async () => {
    const { data } = await request({
        url: props.loadUrl.format(state.id),
        method: 'GET'
    });
    state.resultDto = data;
}

const onSubmit = async () => {
    await ruleFormRef.value.validate();
    await request({
        url: props.postUrl.format(state.id),
        method: 'POST',
        data: state.ruleForm
    });
    ruleFormRef.value?.resetFields();
    getData();
}

const onDelete = async (key: string) => {
    await request({
        url: props.deleteUrl.format(state.id, key),
        method: 'DELETE'
    });
    getData();
}

const handleClose = () => {
    ruleFormRef.value?.resetFields();
    state.isShow = false;
    state.resultDto = [];
}

defineExpose({
    openDrawer
});
</script>