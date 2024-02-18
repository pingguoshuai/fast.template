import {createRouter, createWebHashHistory} from "vue-router";
import {basicRoutes} from "/@/router/routes";
import NProgress from "nprogress";
import {Session} from "/@/utils/storage";

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
});

router.afterEach(()=>{
    
});

export default router;