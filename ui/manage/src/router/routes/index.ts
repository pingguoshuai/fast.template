import { RouteRecordRaw } from "vue-router";
import {demoRoutes} from './demo';
import {LAYOUT} from "/@/router/constant";

// import.meta.globEager() 直接引入所有的模块 Vite 独有的功能
export const modulesRoutes = import.meta.globEager('./modules/**/*.ts');
const routeModuleList: RouteRecordRaw[] = [];

const LoginRoute : RouteRecordRaw= {
    path: '/login',
    name: 'login',
    component: () => import('/@/views/login/index.vue'),
    meta: {
        title: '登录',
        isHide: true,
    },
};

const HomeRoute : RouteRecordRaw= {
    path: '/',
    name: '/',
    component: LAYOUT,
    redirect: '/home',
    meta: {
        isKeepAlive: true,
        title: 'message.router.home',
        isLink: '',
        isHide: false,
        isAffix: true,
        isIframe: false,
        roles: ['admin', 'common'],
        icon: 'iconfont icon-shouye',
    },
    children:[
        {
            path: '/home',
            name: 'home',
            component: () => import('/@/views/home/index.vue'),
            meta: {
                title: 'message.router.home',
                isLink: '',
                isHide: false,
                isKeepAlive: true,
                isAffix: true,
                isIframe: false,
                roles: ['admin', 'common'],
                icon: 'iconfont icon-shouye',
            },
        },
        ...demoRoutes
    ]
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
    HomeRoute,
    LoginRoute,
    ...notFoundAndNoPower
];