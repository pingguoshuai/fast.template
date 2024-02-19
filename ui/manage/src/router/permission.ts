import {Session} from "/@/utils/storage";
import {useUserInfo} from "/@/stores/userInfo";
import pinia from "/@/stores";
import {useRoutesList} from "/@/stores/routesList";
import {basicRoutes} from "/@/router/routes";
import {useTagsViewRoutes} from "/@/stores/tagsViewRoutes";
import {formatFlatteningRoutes, formatTwoStageRoutes} from "/@/router/index";

export async function generateRoutes(){
    if (!Session.get('token')) return false;
    
    //初始化用户信息
    await useUserInfo(pinia).setUserInfos();

    if (useUserInfo().userInfos.roles.length <= 0) return Promise.resolve(true);
    
    //pinia routesList 中添加路由
    await setRouteList();
    
    
    //添加动态路由
    
}

async function handleDynamicRoute(){
    
}

export async function setRouteList(){
    const storesRoutesList = useRoutesList(pinia);
    // const filterResult = setFilterMenu(dynamicRoutes[0].children);
    const filterResult = setFilterMenu(basicRoutes[0].children);
    // console.log(filterResult);
    
    await storesRoutesList.setRoutesList(filterResult);
    
    const storesTagsView = useTagsViewRoutes(pinia);
    // let result = formatTwoStageRoutes(formatFlatteningRoutes(setFilterMenu(dynamicRoutes)))[0].children;
    let result = formatTwoStageRoutes(formatFlatteningRoutes(setFilterMenu(basicRoutes)))[0].children;
    // console.log(result);
    await storesTagsView.setTagsViewRoutes(result);
}

export function setFilterMenu(routes:any)  {
    if (routes.length <= 0) return false;
    
    const result : any = [];
    
    routes.forEach((route:any) => {
        const item = {...route};
        
        if(!item.meta.isHide){
            
            if (item.children){
                item.children = setFilterMenu(item.children);
            }
            
            result.push(item);
        }
        
    });
    
    return result;
}