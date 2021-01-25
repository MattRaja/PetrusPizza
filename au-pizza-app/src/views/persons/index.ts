import { AlertType } from './../../types/AlertType';
import { autoinject } from 'aurelia-framework';
import { IAlertData } from 'types/IAlertData';
import { IPerson } from 'domain/IPerson';
import { PersonService } from 'service/person-service';

@autoinject
export class PersonsIndex {
    private _alert: IAlertData | null = null;
    private _persons: IPerson[] = [];

    constructor(private personService: PersonService) {

    }

    attached() {
        this.personService.getPersons().then(
            response => {
                if (response.statusCode >= 200 && response.statusCode < 300) {
                    this._alert = null;
                    this._persons = response.data!;
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