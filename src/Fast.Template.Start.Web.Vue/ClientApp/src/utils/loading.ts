import { ElLoading } from 'element-plus';
import { nextTick } from 'vue';
import '/@/theme/loading.scss';

/**
 * 页面全局 Loading
 * @method start 创建 loading
 * @method done 移除 loading
 */
export const NextLoading = {
	// 创建 loading
	start: () => {
		const bodys: Element = document.body;
		const div = <HTMLElement>document.createElement('div');
		div.setAttribute('class', 'loading-next');
		const htmls = `
			<div class="loading-next-box">
				<div class="loading-next-box-warp">
					<div class="loading-next-box-item"></div>
					<div class="loading-next-box-item"></div>
					<div class="loading-next-box-item"></div>
					<div class="loading-next-box-item"></div>
					<div class="loading-next-box-item"></div>
					<div class="loading-next-box-item"></div>
					<div class="loading-next-box-item"></div>
					<div class="loading-next-box-item"></div>
					<div class="loading-next-box-item"></div>
				</div>
			</div>
		`;
		div.innerHTML = htmls;
		bodys.insertBefore(div, bodys.childNodes[0]);
		window.nextLoading = true;
	},
	// 移除 loading
	done: () => {
		nextTick(() => {
			window.nextLoading = false;
			const el = <HTMLElement>document.querySelector('.loading-next');
			el?.parentNode?.removeChild(el);
		});
	},
};

let loadingRequestCount = 0;
let loadingInstance: any;

export const showLoading = () => {
	if (loadingRequestCount == 0) {
		loadingInstance = ElLoading.service({
			lock: true,
			text: "请求中",
			background: 'rgba(0, 0, 0, 0.1)'
		});
	}
	loadingRequestCount++;
}

export const hideLoading = () => {
	if (loadingRequestCount <= 0) return;
	loadingRequestCount--;
	if (loadingRequestCount === 0) {
		loadingInstance.close();
	}
}