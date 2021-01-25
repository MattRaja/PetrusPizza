import { IPizzaName } from './../domain/IPizzaName';
import { autoinject } from 'aurelia-framework';
import { BaseService } from './base-service';
import { HttpClient } from 'aurelia-fetch-client';
import { IFetchResponse } from 'types/IFetchResponse';

@autoinject
export class PizzaNameService extends BaseService<IPizzaName> {
    
    constructor(protected httpClient: HttpClient){
        super('PizzaNames', httpClient);
    }


    async getAllForPizzaName(PizzaNameId: string): Promise<IFetchResponse<IPizzaName[]>> {
        try {
            const response = await this.httpClient
                .fetch(this.apiEndpointUrl + '?IPizzaNameId=' + PizzaNameId, {
                    cache: "no-store"
                });
            // happy case
            if (response.ok) {
                const data = (await response.json()) as IPizzaName[];
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
