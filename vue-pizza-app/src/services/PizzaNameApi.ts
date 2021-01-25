import Axios from 'axios';
import { IPizzaName } from '@/domain/IPizzaName';
import { IPizzaNameEdit } from '@/domain/IPizzaNameEdit';

export abstract class PizzaNameApi {
    private static axios = Axios.create(
        {
            baseURL: "https://localhost:5001/api/v1.0/PizzaNames/",
            headers: {
                common: {
                    'Content-Type': 'application/json'
                }
            }
        }
    )

    static async getAll(): Promise<IPizzaName[]> {
        const url = "";
        try {
            const response = await this.axios.get<IPizzaName[]>(url);
            console.log('getAll response', response);
            if (response.status === 200) {
                return response.data;
            }
            return [];
        } catch (error) {
            console.log('error: ', (error as Error).message);
            return [];
        }
    }

    static async create(pizzaName: string[], jwt: string): Promise<void> {
        const url = "";
        console.log("increate:", pizzaName)
        try {
            const response = await this.axios.post<IPizzaName>(url, pizzaName, { headers: { Authorization: 'Bearer ' + jwt } });
            console.log('create response', response);
            if (response.status === 200) {
                return;
            }
            return;
        } catch (error) {
            console.log('error: ', (error as Error).message);
        }
    }

    static async edit(pizzaName: IPizzaNameEdit, jwt: string): Promise<void> {
        const url = "" + pizzaName.Id;
        try {
            const response = await this.axios.put<IPizzaName>(url, pizzaName, { headers: { Authorization: 'Bearer ' + jwt } });
            if (response.status === 200) {
                return;
            }
            return;
        } catch (error) {
            console.log('error: ', (error as Error).message);
        }
    }

    static async delete(id: string, jwt: string): Promise<void> {
        const url = "" + id;
        try {
            const response = await this.axios.delete<IPizzaName>(url, { headers: { Authorization: 'Bearer ' + jwt } });
            console.log('delete response', response);
            if (response.status === 200) {
                return;
            }
            return;
        } catch (error) {
            console.log('error: ', (error as Error).message);
        }
    }
}
