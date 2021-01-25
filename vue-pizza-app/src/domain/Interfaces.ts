export interface IBalance {
    id: string;
    personId: string;
    paymentId: string;
}

export interface ICulture {
    code: string;
    name: string;
}

export interface ILoginResponse {
    token: string;
    status: string;
}

export interface IDefaultTopping {
    id: string;
    pizzaNameId: string;
    ToppingId: string;
}

export interface IExtraToppingsOnItem {
    id: string;
    toppingNameId: string;
    itemRowId: string;
    price: number;
}

export interface IItemRow {
    id: string;
    pizzaOrderId: string;
    amount: number;
}

export interface IOrder {
    id: string;
    appuserId: string;
    sumWithoutVAT: number;
    sumWithVAT: number;
    orderNr: number;
    orderDate: Date;
}

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

export interface IPayment {
    id: string
    paymentMethodNameId: string;
    userPaymentId: string;
    paymentDate: Date;
    paymentAmount: number;
}

export interface IPerson {
    id: string;
    firstName: string;
    lastName: string;
}

export interface IPizzaName {
    id: string;
    nameOfPizza: string;
    price: number;
    orderCount: number;
}

export interface IPizzaOrder {
    id: string;
    pizzaSizeId: string;
    pizzaTypeId: string;
    price: number;
}

export interface IPizzaSize {
    id: string;
    pizzaSizeName: string;
    price: number;
}

export interface IPizzaType {
    id: string;
    pizzaTypeName: string;
    price: number;
}

export interface ITopping {
    id: string;
    toppingName: string;
    price: number;
}
