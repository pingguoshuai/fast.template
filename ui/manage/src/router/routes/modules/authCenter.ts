import {LAYOUT} from "/@/router/constant";

const authCenterRouter: MenuRoute[] = [
    {
        path: '/authCenter',
        name: 'authCenter',
        redirect: '/authCenter/apiScope',
        component: LAYOUT,
        meta:{
            title: 'message.router.authCenter',
            isLink: '',
            isHide: false,
            isKeepAlive: true,
            isAffix: false,
            isIframe: false,
            roles: ['admin', 'common'],
            icon: 'iconfont icon-quanxian'
        }
    },
    {
        path: '/authCenter/apiScope',
        name: 'apiScope',
        component: () => import('/@/views/authcenter/apiscope/index.vue'),
        meta: {
            title: 'message.router.authApiScope',
            isLink: '',
            isHide: false,
            isKeepAlive: true,
            isAffix: false,
            isIframe: false,
            roles: ['admin', 'common'],
            icon: 'iconfont icon-xitongshezhi',
        },
        parentName: 'authCenter',
        requiredPolicy:'IdsAdmin.ApiScope',
    },
    {
        path: '/authCenter/identityResource',
        name: 'identityResource',
        component: () => import('/@/views/authcenter/identityresource/index.vue'),
        meta: {
            title: 'message.router.authIdentityResource',
            isLink: '',
            isHide: false,
            isKeepAlive: true,
            isAffix: false,
            isIframe: false,
            roles: ['admin', 'common'],
            icon: 'iconfont icon-xitongshezhi',
        },
        parentName: 'authCenter',
        requiredPolicy:'IdsAdmin.IdentityResource',
    },
    {
        path: '/authCenter/apiResource',
        name: 'apiResource',
        component: () => import('/@/views/authcenter/apiresource/index.vue'),
        meta: {
            title: 'message.router.authApiResource',
            isLink: '',
            isHide: false,
            isKeepAlive: true,
            isAffix: false,
            isIframe: false,
            roles: ['admin', 'common'],
            icon: 'iconfont icon-xitongshezhi',
        },
        parentName: 'authCenter',
        requiredPolicy:'IdsAdmin.ApiResource',
    },
    {
        path: '/authCenter/apiClient',
        name: 'apiClient',
        component: () => import('/@/views/authcenter/apiclient/index.vue'),
        meta: {
            title: 'message.router.authApiClient',
            isLink: '',
            isHide: false,
            isKeepAlive: true,
            isAffix: false,
            isIframe: false,
            roles: ['admin', 'common'],
            icon: 'iconfont icon-xitongshezhi',
        },
        parentName: 'authCenter',
        requiredPolicy:'IdsAdmin.Client',
    },
];

export default authCenterRouter;