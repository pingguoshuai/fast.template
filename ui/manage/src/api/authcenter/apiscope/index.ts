import { baseService } from "../../baseService";
import { apiScopeDto, createApiScopeDto } from "./model";
import { IPageRequestQuery } from "/@/types/base/querybase";

export class apiScopeService extends baseService<apiScopeDto, createApiScopeDto, IPageRequestQuery> {
    constructor() {
        super("/api/IdsAdmin/api-scope");
    }
}

export default new apiScopeService();