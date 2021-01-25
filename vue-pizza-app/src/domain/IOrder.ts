export interface IOrder {
    id?: string;
    appuserId: string;
    sumWithoutVAT?: number;
    sumWithVAT?: number;
    orderNr?: number;
    orderDate?: Date;
}
