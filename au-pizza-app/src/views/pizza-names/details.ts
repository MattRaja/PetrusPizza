import { PizzaNameService } from 'service/pizza-name-service';
import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction } from 'aurelia-router';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';
import { IPizzaName } from 'domain/IPizzaName';

@autoinject
export class PizzaNamesDetails {

    private _pizzaname?: IPizzaName;    
    private _alert: IAlertData | null = null;


    constructor(private pizzanameService: PizzaNameService) {

    }

    attached() {
    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        console.log(params);
        if (params.id && typeof (params.id) == 'string') {
            this.pizzanameService.getPizzaName(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._pizzaname = response.data!;
                    } else {
                        // show error message
                        this._alert = {
                            message: response.statusCode.toString() + ' - ' + response.errorMessage,
                            type: AlertType.Danger,
                            dismissable: true,
                        }
                        this._pizzaname = undefined;
                    }
                }                
            );
        }
    }

}
