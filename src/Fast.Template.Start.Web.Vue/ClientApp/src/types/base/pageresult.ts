export interface IPageResult<T> {
    items: Array<T>;
    totalCount: number;
}

export class PageResult<T> {
    items: Array<T> = [];
    totalCount: number = 0;
    constructor() {

    }
}