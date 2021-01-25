export interface IPayment {
    id: string
    paymentMethodNameId: string;
    userPaymentId: string;
    paymentDate: Date;
    paymentAmount: number;
}
