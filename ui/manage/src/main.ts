import { createApp } from 'vue';
import pinia from '/@/stores/index';
import App from '/@/App.vue';
import router from '/@/router';
import { directive } from '/@/directive/index';
import { i18n } from '/@/i18n/index';
import other from '/@/utils/other';

import ElementPlus from 'element-plus';
import '/@/theme/index.scss';
import VueGridLayout from 'vue-grid-layout';



String.prototype.format = function () {
    var args = arguments;
    return this.replace(/{(\d+)}/g, function (match, number) {
        return typeof args[number] != 'undefined'
            ? args[number]
            : match
            ;
    });
};

function bootstrap() {
    const app = createApp(App);
    directive(app);
    other.elSvg(app);

    app.use(pinia);
    app.use(router);
    app.use(ElementPlus);
    app.use(i18n);
    app.use(VueGridLayout);
    app.mount('#app');
}

bootstrap();
