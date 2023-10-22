import { baseService } from "../../baseService";
import { createIdentityResourceDto, identityResourceDto } from "./model";
import { IPageRequestQuery } from "/@/types/base/querybase";

export class identityResourceService extends baseService<identityResourceDto, createIdentityResourceDto, IPageRequestQuery>{
    constructor() {
        super("/api/IdsAdmin/identity-resource");
    }
}