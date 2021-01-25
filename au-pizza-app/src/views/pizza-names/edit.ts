import { PizzaNameService } from 'service/pizza-name-service';
import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';
import { IPizzaNameEdit } from 'domain/IPizzaNameEdit';

@autoinject
export class PizzaNamesEdit {
    private _alert: IAlertData | null = null;

    private _pizzaName?: IPizzaNameEdit;

    constructor(private pizzaNameService: PizzaNameService, private router: Router) {
    }

    attached() {
    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        if (params.id && typeof (params.id) == 'string') {
            this.pizzaNameService.getPizzaName(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._pizzaName = response.data!;
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

    onSubmit(event: Event) {

        let inputValue = this._pizzaName!.price;
        this._pizzaName!.price = inputValue.toString.length == 0 ? 0 : Number(inputValue);
        let nameInput = this._pizzaName!.nameOfPizza;
        this._pizzaName!.nameOfPizza = nameInput.toString.length == 0 ? "" : nameInput;

        this.pizzaNameService
            .updatePizzaName(this._pizzaName!)
            .then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this.router.navigateToRoute('pizzanames-index', {});
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
