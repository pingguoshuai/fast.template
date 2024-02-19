import {createRouter, createWebHashHistory} from "vue-router";
import {basicRoutes} from "/@/router/routes";
import NProgress from "nprogress";
import {Session} from "/@/utils/storage";
import {useRoutesList} from "/@/stores/routesList";
import pinia from "/@/stores";
import {storeToRefs} from "pinia";
import {useKeepALiveNames} from "/@/stores/keepAliveNames";

export function formatFlatteningRoutes(arr: any) {
    if (arr.length <= 0) return false;
    for (let i = 0; i < arr.length; i++) {
        if (arr[i].children) {
            arr = arr.slice(0, i + 1).concat(arr[i].children, arr.slice(i + 1));
        }
    }
    return arr;
}

/**
 * 一维数组处理成多级嵌套数组（只保留二级：也就是二级以上全部处理成只有二级，keep-alive 支持二级缓存）
 * @description isKeepAlive 处理 `name` 值，进行缓存。顶级关闭，全部不缓存
 * @link 参考：https://v3.cn.vuejs.org/api/built-in-components.html#keep-alive
 * @param arr 处理后的一维路由菜单数组
 * @returns 返回将一维数组重新处理成 `定义动态路由（dynamicRoutes）` 的格式
 */
export function formatTwoStageRoutes(arr: any) {
    if (arr.length <= 0) return false;
    const newArr: any = [];
    const cacheList: Array<string> = [];
    arr.forEach((v: any) => {
        if (v.path === '/') {
            newArr.push({ component: v.component, name: v.name, path: v.path, redirect: v.redirect, meta: v.meta, children: [] });
        } else {
            // 判断是否是动态路由（xx/:id/:name），用于 tagsView 等中使用
            // 修复：https://gitee.com/lyt-top/vue-next-admin/issues/I3YX6G
            if (v.path.indexOf('/:') > -1) {
                v.meta['isDynamic'] = true;
                v.meta['isDynamicPath'] = v.path;
            }
            newArr[0].children.push({ ...v });
            // 存 name 值，keep-alive 中 include 使用，实现路由的缓存
            // 路径：/@/layout/routerView/parent.vue
            if (newArr[0].meta.isKeepAlive && v.meta.isKeepAlive) {
                cacheList.push(v.name);
                const stores = useKeepALiveNames(pinia);
                stores.setCacheKeepAlive(cacheList);
            }
        }
    });
    return newArr;
}

export const router = createRouter({
    history: createWebHashHistory(),
    /**
     * 说明：
     * 1、notFoundAndNoPower 默认添加 404、401 界面，防止一直提示 No match found for location with path 'xxx'
     * 2、backEnd.ts(后端控制路由)、frontEnd.ts(前端控制路由) 中也需要加 notFoundAndNoPower 404、401 界面。
     *    防止 404、401 不在 layout 布局中，不设置的话，404、401 界面将全屏显示
     */
    routes: [
        ...basicRoutes
    ],
});

router.beforeEach(async (to,from)=>{
    NProgress.configure({showSpinner:false});
    
    if (to.meta.title) NProgress.start();

    const token = Session.get('token');
    if (to.path === 'login' && !token){
        NProgress.done();
        return true;
    }
    
    //未登录
    if(!token) {
        Session.clear();
        NProgress.done();
        return {name:'login',params:{redirect:to.path,params:JSON.stringify(to.query ? to.query : to.params)}};
    }
    
    //已登录，进入登录页，跳转到首页
    if (token && to.path === '/login'){
        NProgress.done();
        return {name:'home'};
    }

    const storesRoutesList = useRoutesList(pinia);
    const { routesList } = storeToRefs(storesRoutesList);
    
    if(routesList.value.length === 0){
        // return {path:to.path,query:to.query};
        return true;
    }else {
        return true;
    }
});

router.afterEach(()=>{
    
});

export default router;