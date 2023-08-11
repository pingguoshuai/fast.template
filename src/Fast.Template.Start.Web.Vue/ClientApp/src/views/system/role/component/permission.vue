<template>
	<el-dialog title="permission" v-model="state.isShow" width="30%" :before-close="closeDialog">
		<span></span>
		<template #footer>
			<span>
				<el-button @click="closeDialog">Cancel</el-button>
				<el-button type="primary" @click="">OK</el-button>
			</span>
		</template>
	</el-dialog>
</template>
<script lang="ts" setup>
import { reactive, ref } from 'vue';

const state = reactive({
	isShow: false,
});

const closeDialog = () => {
	state.isShow = false;
};

const open = () => {
	state.isShow = true;
};

defineExpose({ open, closeDialog });
</script>
