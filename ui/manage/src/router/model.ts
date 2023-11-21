
interface MenuRoute{
    path: string;
    name?: string;
    component: any;
    redirect?: string;
    parentName?: string;
    requiredPolicy?: string;
    order?: number;
    meta?: MenuMeta;
}

interface MenuMeta{
    title?: string;
    isLink?: string;
    isHide?: boolean;
    isKeepAlive?: boolean;
    isAffix?: boolean;
    isIframe?: boolean;
    order?: number;
    icon?: string;
    roles?: string[];
}