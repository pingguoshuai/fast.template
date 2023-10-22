import { baseService } from "../../baseService";
import { clientDto, createClientDto } from "./model";
import { IPageRequestQuery } from "/@/types/base/querybase";

export class apiScopeService extends baseService<clientDto, createClientDto, IPageRequestQuery> {
    constructor() {
        super("/api/IdsAdmin/api-scope");
    }
}