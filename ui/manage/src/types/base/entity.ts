export interface IEntityDto {
    id: string;
}

export interface ICreationAuditedEntityDto extends IEntityDto {
    creationTime?: Date;
    creatorId?: string;
}

export interface IAuditedEntityDto extends ICreationAuditedEntityDto {
    lastModificationTime?: Date;
    lastModifierId?: string;
}

export class EntityDto implements IEntityDto {
    id: string;
    constructor() {

    }
}

export class CreationAuditedEntityDto extends EntityDto implements ICreationAuditedEntityDto {
    creationTime?: Date;
    creatorId?: string;
}

export class AuditedEntityDto extends CreationAuditedEntityDto implements IAuditedEntityDto {
    constructor() {
        super();
    }
}