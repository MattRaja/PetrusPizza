import { PersonService } from 'service/person-service';
import { autoinject } from 'aurelia-framework';
import { RouteConfig, NavigationInstruction, Router } from 'aurelia-router';
import { IAlertData } from 'types/IAlertData';
import { AlertType } from 'types/AlertType';
import { IPersonEdit } from 'domain/IPersonEdit';

@autoinject
export class PersonsEdit {
    private _alert: IAlertData | null = null;

    private _person?: IPersonEdit;

    constructor(private personService: PersonService, private router: Router) {
    }

    attached() {
    }

    activate(params: any, routeConfig: RouteConfig, navigationInstruction: NavigationInstruction) {
        if (params.id && typeof (params.id) == 'string') {
            this.personService.getPerson(params.id).then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this._person = response.data!;
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

        let inputValue = this._person!.firstName;
        this._person!.firstName = inputValue.toString.length == 0 ? "" : inputValue;
        let lastNameInput = this._person!.lastName;
        this._person!.lastName = lastNameInput.toString.length == 0 ? "" : lastNameInput;

        this.personService
            .updatePerson(this._person!)
            .then(
                response => {
                    if (response.statusCode >= 200 && response.statusCode < 300) {
                        this._alert = null;
                        this.router.navigateToRoute('persons-index', {});
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
