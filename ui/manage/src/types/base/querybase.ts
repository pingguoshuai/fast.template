export interface IPageRequestQuery {
    CurrentPage: number;
    MaxResultCount: number;
}

export class PageRequestQuery implements IPageRequestQuery {
    private currentPage: number = 1;
    public get CurrentPage(): number {
        return this.currentPage;
    }
    public set CurrentPage(value: number) {
        this.currentPage = value;
        this.skipCount = (this.CurrentPage - 1) * this.MaxResultCount
    }

    maxResultCount: number = 10;
    public get MaxResultCount(): number {
        return this.maxResultCount;
    }
    public set MaxResultCount(value: number) {
        this.maxResultCount = value;
        this.skipCount = (this.CurrentPage - 1) * this.MaxResultCount
    }

    skipCount: number = 0;

    constructor(maxCount: number = 10) {
        if (maxCount != null) {
            this.maxResultCount = maxCount;
        }
    }
}