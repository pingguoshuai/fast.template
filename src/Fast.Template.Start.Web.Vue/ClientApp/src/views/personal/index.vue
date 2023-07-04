<template>
	<div class="personal">
		<el-row>
			<!-- 更新信息 -->
			<el-col :span="24">
				<el-card shadow="hover" class="mt15 personal-edit" header="更新信息">
					<div class="personal-edit-title">基本信息</div>
					<el-form :model="state.formData" ref="formRef" size="default" label-width="40px" class="mt35 mb35">
						<el-row :gutter="35">
							<el-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4" class="mb20">
								<el-form-item label="用户名" prop="userName" label-width="70px">
									<el-input v-model="state.formData.userName" placeholder="请输入用户名" clearable disabled></el-input>
								</el-form-item>
							</el-col>
							<el-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4" class="mb20">
								<el-form-item label="邮箱" prop="email" label-width="70px" :rules="[{ required: true, type: 'email', message: '请输入邮箱' }]">
									<el-input v-model="state.formData.email" placeholder="请输入邮箱" clearable></el-input>
								</el-form-item>
							</el-col>
							<el-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4" class="mb20">
								<el-form-item label="姓" label-width="70px">
									<el-input v-model="state.formData.surname" placeholder="请输入姓" clearable></el-input>
								</el-form-item>
							</el-col>
							<el-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4" class="mb20">
								<el-form-item label="名" label-width="70px">
									<el-input v-model="state.formData.name" placeholder="请输入名" clearable></el-input>
								</el-form-item>
							</el-col>
							<el-col :xs="24" :sm="12" :md="8" :lg="6" :xl="4" class="mb20">
								<el-form-item label="手机" prop="phoneNumber" label-width="70px" :rules="[{ required: true, type: 'phone', message: '请输入手机' }]">
									<el-input v-model="state.formData.phoneNumber" placeholder="请输入手机" clearable></el-input>
								</el-form-item>
							</el-col>
							<el-col :xs="24" :sm="24" :md="24" :lg="24" :xl="24">
								<el-form-item>
									<el-button type="primary" @click="onSubmit">
										<el-icon>
											<ele-Position />
										</el-icon>
										更新个人信息
									</el-button>
									<el-button type="warning" @click="showPwd = true"> 修改密码 </el-button>
								</el-form-item>
							</el-col>
						</el-row>
					</el-form>
				</el-card>
			</el-col>
		</el-row>
		<el-dialog v-model="showPwd" title="修改密码" width="30%" :before-close="closeDialog">
			<el-form ref="changeFormRef" :model="state.pwdForm">
				<el-form-item label="旧密码" :label-width="80" prop="currentPassword" :rules="[{ required: true, message: '请输入旧密码' }]">
					<el-input v-model="state.pwdForm.currentPassword" type="password" autocomplete="off" />
				</el-form-item>
				<el-form-item label="新密码" :label-width="80" prop="newPassword" :rules="[{ required: true, message: '请输入新密码' }]">
					<el-input v-model="state.pwdForm.newPassword" type="password" autocomplete="off" />
				</el-form-item>
				<el-form-item label="确认密码" :label-width="80" prop="confirmPassword" :rules="[{ validator: validateConfirmPassword }]">
					<el-input v-model="state.pwdForm.confirmPassword" type="password" autocomplete="off" />
				</el-form-item>
			</el-form>
			<template #footer>
				<span class="dialog-footer">
					<el-button @click="closeDialog">取消</el-button>
					<el-button type="primary" @click="onChangePwd"> 确定 </el-button>
				</span>
			</template>
		</el-dialog>
	</div>
</template>

<script setup lang="ts">
import { ElMessage } from 'element-plus';
import { reactive, onMounted, ref } from 'vue';
import { accountService } from '/@/api/account';
import { changePasswordInput, ProfileDto } from '/@/api/account/model';

const formRef = ref();
const changeFormRef = ref();
const showPwd = ref(false);

const state = reactive({
	formData: new ProfileDto(),
	pwdForm: new changePasswordInput(),
});

const apiService = new accountService();
const getData = async () => {
	const { data } = await apiService.getAsync();
	state.formData = data;
};

const onSubmit = async () => {
	await formRef.value?.validate();
	await apiService.updateAsync(state.formData);
	ElMessage.success('操作成功');
};
const validateConfirmPassword = (rule: any, value: any, callback: any) => {
	if (value === '') {
		callback(new Error('请确认密码'));
	} else if (value !== state.pwdForm.newPassword) {
		callback(new Error('两次密码输入不一致!'));
	} else {
		callback();
	}
};

const closeDialog = async () => {
	changeFormRef.value?.resetFields();
	showPwd.value = false;
	state.pwdForm = new changePasswordInput();
};

const onChangePwd = async () => {
	await changeFormRef.value?.validate();
	await apiService.changePasswordAsync(state.pwdForm);
	ElMessage.success('操作成功');
	closeDialog();
};

onMounted(() => {
	getData();
});
</script>

<style scoped lang="scss">
@import '../../theme/mixins/index.scss';
.personal {
	.personal-user {
		height: 130px;
		display: flex;
		align-items: center;
		.personal-user-left {
			width: 100px;
			height: 130px;
			border-radius: 3px;
			:deep(.el-upload) {
				height: 100%;
			}
			.personal-user-left-upload {
				img {
					width: 100%;
					height: 100%;
					border-radius: 3px;
				}
				&:hover {
					img {
						animation: logoAnimation 0.3s ease-in-out;
					}
				}
			}
		}
		.personal-user-right {
			flex: 1;
			padding: 0 15px;
			.personal-title {
				font-size: 18px;
				@include text-ellipsis(1);
			}
			.personal-item {
				display: flex;
				align-items: center;
				font-size: 13px;
				.personal-item-label {
					color: var(--el-text-color-secondary);
					@include text-ellipsis(1);
				}
				.personal-item-value {
					@include text-ellipsis(1);
				}
			}
		}
	}
	.personal-info {
		.personal-info-more {
			float: right;
			color: var(--el-text-color-secondary);
			font-size: 13px;
			&:hover {
				color: var(--el-color-primary);
				cursor: pointer;
			}
		}
		.personal-info-box {
			height: 130px;
			overflow: hidden;
			.personal-info-ul {
				list-style: none;
				.personal-info-li {
					font-size: 13px;
					padding-bottom: 10px;
					.personal-info-li-title {
						display: inline-block;
						@include text-ellipsis(1);
						color: var(--el-text-color-secondary);
						text-decoration: none;
					}
					& a:hover {
						color: var(--el-color-primary);
						cursor: pointer;
					}
				}
			}
		}
	}
	.personal-recommend-row {
		.personal-recommend-col {
			.personal-recommend {
				position: relative;
				height: 100px;
				border-radius: 3px;
				overflow: hidden;
				cursor: pointer;
				&:hover {
					i {
						right: 0px !important;
						bottom: 0px !important;
						transition: all ease 0.3s;
					}
				}
				i {
					position: absolute;
					right: -10px;
					bottom: -10px;
					font-size: 70px;
					transform: rotate(-30deg);
					transition: all ease 0.3s;
				}
				.personal-recommend-auto {
					padding: 15px;
					position: absolute;
					left: 0;
					top: 5%;
					color: var(--next-color-white);
					.personal-recommend-msg {
						font-size: 12px;
						margin-top: 10px;
					}
				}
			}
		}
	}
	.personal-edit {
		.personal-edit-title {
			position: relative;
			padding-left: 10px;
			color: var(--el-text-color-regular);
			&::after {
				content: '';
				width: 2px;
				height: 10px;
				position: absolute;
				left: 0;
				top: 50%;
				transform: translateY(-50%);
				background: var(--el-color-primary);
			}
		}
		.personal-edit-safe-box {
			border-bottom: 1px solid var(--el-border-color-light, #ebeef5);
			padding: 15px 0;
			.personal-edit-safe-item {
				width: 100%;
				display: flex;
				align-items: center;
				justify-content: space-between;
				.personal-edit-safe-item-left {
					flex: 1;
					overflow: hidden;
					.personal-edit-safe-item-left-label {
						color: var(--el-text-color-regular);
						margin-bottom: 5px;
					}
					.personal-edit-safe-item-left-value {
						color: var(--el-text-color-secondary);
						@include text-ellipsis(1);
						margin-right: 15px;
					}
				}
			}
			&:last-of-type {
				padding-bottom: 0;
				border-bottom: none;
			}
		}
	}
}
</style>
