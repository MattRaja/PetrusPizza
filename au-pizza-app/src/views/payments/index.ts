import { AlertType } from './../../types/AlertType';
import { autoinject } from 'aurelia-framework';
import { IAlertData } from 'types/IAlertData';
import { IPayment } from 'domain/IPayment';
import { PaymentService } from 'service/payment-service';

@autoinject
export class PaymentsIndex {
    private _alert: IAlertData | null = null;
    private _payments: IPayment[] = [];

    constructor(private paymentService: PaymentService) {

    }

    attached() {
        this.paymentService.getPayments().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._payments = response.data!;
                } else {
                    // show error message
                    this._alert = {
                        message: response.statusCode.toString() + ' - ' + response.errorMessage,
                        type: AlertType.Danger,
                        dismissable: true,
                    }
                }
            }
        );
    }

}