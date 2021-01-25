import { IPerson } from './../domain/IPerson';
import { autoinject } from 'aurelia-framework';
import { BaseService } from './base-service';
import { HttpClient } from 'aurelia-fetch-client';
import { IFetchResponse } from 'types/IFetchResponse';

@autoinject
export class PersonService extends BaseService<IPerson> {
    
    constructor(protected httpClient: HttpClient){
        super('Persons', httpClient);
    }


    async getAllForPerson(PersonId: string): Promise<IFetchResponse<IPerson[]>> {
        try {
            const response = await this.httpClient
                .fetch(this.apiEndpointUrl + '?IPersonId=' + PersonId, {
                    cache: "no-store"
                });
            // happy case
            if (response.ok) {
                const data = (await response.json()) as IPerson[];
                // console.log(data);
                return {
                    statusCode: response.status,
                    data: data
                }
            }

            // something went wrong
            return {
                statusCode: response.status,
                errorMessage: response.statusText
            }

        } catch (reason) {
            return {
                statusCode: 0,
                errorMessage: JSON.stringify(reason)
            }
        }
    }

}
