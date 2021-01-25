import Axios from 'axios';
import { ITopping } from '@/domain/ITopping';
import { IToppingEdit } from '@/domain/IToppingEdit';

export abstract class ToppingApi {
    private static axios = Axios.create(
        {
            baseURL: "https://localhost:5001/api/v1.0/Toppings/",
            headers: {
                common: {
                    'Content-Type': 'application/json'
                }
            }
        }
    )

    static async getAll(): Promise<ITopping[]> {
        const url = "";
        try {
            console.log('getAll response2', url);

            const response = await this.axios.get<ITopping[]>(url);
            console.log('getAll response topping', response);
            if (response.status === 200) {
                return response.data;
            }
            return [];
        } catch (error) {
            console.log('error: ', (error as Error).message);
            return [];
        }
    }

    static async create(topping: string[], jwt: string): Promise<void> {
        const url = "";
        console.log("increate:", topping)
        try {
            const response = await this.axios.post<ITopping>(url, topping, { headers: { Authorization: 'Bearer ' + jwt } });
            console.log('create response', response);
            if (response.status === 200) {
                return;
            }
            return;
        } catch (error) {
            console.log('error: ', (error as Error).message);
        }
    }

    static async edit(topping: IToppingEdit, jwt: string): Promise<void> {
        console.log("wwwwwwwwww", topping.Id)
        const url = "" + topping.Id;
        try {
            const response = await this.axios.put<IToppingEdit>(url, topping, { headers: { Authorization: 'Bearer ' + jwt } });
            console.log('edit response', response);
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
            const response = await this.axios.delete<ITopping>(url, { headers: { Authorization: 'Bearer ' + jwt } });
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
