import { IPayment } from './../domain/IPayment';
import { autoinject } from 'aurelia-framework';
import { BaseService } from './base-service';
import { HttpClient } from 'aurelia-fetch-client';
import { IFetchResponse } from 'types/IFetchResponse';

@autoinject
export class PaymentService extends BaseService<IPayment> {
    
    constructor(protected httpClient: HttpClient){
        super('Payments', httpClient);
    }


    async getAllForPayment(paymentId: string): Promise<IFetchResponse<IPayment[]>> {
        try {
            const response = await this.httpClient
                .fetch(this.apiEndpointUrl + '?IPaymentId=' + paymentId, {
                    cache: "no-store"
                });
            // happy case
            if (response.ok) {
                const data = (await response.json()) as IPayment[];
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
