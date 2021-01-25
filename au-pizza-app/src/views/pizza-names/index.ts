import { AlertType } from './../../types/AlertType';
import { autoinject } from 'aurelia-framework';
import { IAlertData } from 'types/IAlertData';
import { IPizzaName } from 'domain/IPizzaName';
import { PizzaNameService } from 'service/pizza-name-service';

@autoinject
export class PersonsIndex {
    private _alert: IAlertData | null = null;
    private _pizzaNames: IPizzaName[] = [];

    constructor(private pizzaNameService: PizzaNameService) {

    }

    attached() {
        this.pizzaNameService.getPizzaNames().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._pizzaNames = response.data!;
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