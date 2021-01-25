import Axios from 'axios';
import { IPizzaType } from '@/domain/IPizzaType';

export abstract class PizzaTypeApi {
    private static axios = Axios.create(
        {
            baseURL: "https://localhost:5001/api/v1.0/PizzaTypes/",
            headers: {
                common: {
                    'Content-Type': 'application/json'
                }
            }
        }
    )

    static async getAll(): Promise<IPizzaType[]> {
        const url = "";
        try {
            const response = await this.axios.get<IPizzaType[]>(url);
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

    static async delete(id: string, jwt: string): Promise<void> {
        const url = "" + id;
        try {
            const response = await this.axios.delete<IPizzaType>(url, { headers: { Authorization: 'Bearer ' + jwt } });
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
