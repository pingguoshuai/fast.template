export class baseService<createDto> {
    apiUrl: string;
    constructor(apiUrl: string) {
        this.apiUrl = apiUrl;
    }

}