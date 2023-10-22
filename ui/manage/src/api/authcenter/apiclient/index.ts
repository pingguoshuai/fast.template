import { baseService } from "../../baseService";
import { clientDto, createClientDto } from "./model";
import { IPageRequestQuery } from "/@/types/base/querybase";

export class apiClientService extends baseService<clientDto, createClientDto, IPageRequestQuery>{
    constructor() {
        super("/api/IdsAdmin/client");
    }
}