import { baseService } from "../../baseService";
import { createRoleDto, roleDto } from "./model";
import { IPageRequestQuery } from "/@/types/base/querybase";

export class roleService extends baseService<roleDto, createRoleDto, IPageRequestQuery> {
    constructor() {
        super("/api/identity/roles")
    }
}

export default new roleService();