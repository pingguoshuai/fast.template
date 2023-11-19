import { RouteRecordRaw } from "vue-router";
import {demoRoutes} from './demo';

// import.meta.globEager() 直接引入所有的模块 Vite 独有的功能
const modules = import.meta.globEager('./modules/**/*.ts');
const routeModuleList: RouteRecordRaw[] = [];

const LoginRoute : RouteRecordRaw= {
    path: '/login',
    name: 'login',
    component: () => import('/@/views/login/index.vue'),
    meta: {
        title: '登录',
    },
};

const notFoundAndNoPower:Array<RouteRecordRaw> = [
    {
        path: '/:path(.*)*',
        name: 'notFound',
        component: () => import('/@/views/error/404.vue'),
        meta: {
            title: 'message.staticRoutes.notFound',
            isHide: true,
        },
    },
    {
        path: '/401',
        name: 'noPower',
        component: () => import('/@/views/error/401.vue'),
        meta: {
            title: 'message.staticRoutes.noPower',
            isHide: true,
        },
    },
];

export const basicRoutes : RouteRecordRaw[] = [
    LoginRoute,
    ...notFoundAndNoPower,
    ...demoRoutes
];