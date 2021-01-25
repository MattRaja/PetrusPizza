export interface IOrderRow {
    id: string;
    orderId: string;
    itemRowId: string;
    extraToppingsOnItemNameId: string;
    amount: number;
    price: number;
    VAT: number;
    sum: number;
    sumWithVAT: number;
}
