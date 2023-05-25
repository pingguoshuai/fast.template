export class secretDto {
    type: string;
    hashType: number = 0;
    value: string;
    description: string;
    expiration?: Date
}