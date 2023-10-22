import { baseService } from "../../baseService";
import { apiResourceDto, createApiResourceDto } from "./mode";
import { IPageRequestQuery } from "/@/types/base/querybase";

export class apiResourceService extends baseService<apiResourceDto, createApiResourceDto, IPageRequestQuery>{
    constructor() {
        super("/api/IdsAdmin/api-resource");
    }
}