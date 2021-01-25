import { PaymentService } from 'service/payment-service';
import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';

@autoinject
export class PaymentsCreate {
    private _alert: IAlertData | null = null;


    _paymentMethodNameId = "";
    _userPaymentId = "";
    _paymentDate = new Date;
    _paymentAmount = 0;


    constructor(private paymentService: PaymentService, private router: Router) {

    }

    attached() {

    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {

    }

    onSubmit(event: Event) {
        console.log(event);
        this.paymentService
            .createPayment({ paymentMethodNameId: this._paymentMethodNameId, userPaymentId: this._userPaymentId,
                 paymentDate: this._paymentDate, paymentAmount: this._paymentAmount })
            .then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this.router.navigateToRoute('payments-index', {});
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

        event.preventDefault();
    }

}
