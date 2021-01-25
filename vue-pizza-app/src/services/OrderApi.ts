import Axios from 'axios';
import { IOrder } from '@/domain/IOrder';
import store from "../store";

export abstract class OrderApi {
    private static axios = Axios.create(
        {
            baseURL: "https://localhost:5001/api/v1.0/Orders/",
            headers: {
                common: {
                    'Content-Type': 'application/json'
                }
            }
        }
    )

    static async getAll(): Promise<IOrder[]> {
        const url = "";
        try {
            const response = await this.axios.get<IOrder[]>(url);
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

    static async create(Order: string, jwt: string): Promise<IOrder[]> {
        const url = "";
        try {
            const response = await this.axios.post<IOrder[]>(url, Order, { headers: { Authorization: 'Bearer ' + jwt } });
            console.log('postOrder response', response);
            if (response.status === 200) {
                return response.data;
            }
            return [];
        } catch (error) {
            console.log('error: ', (error as Error).message);
            return [];
        }
    }

    static async edit(id: string, jwt: string): Promise<void> {
        const url = "" + id;
        try {
            const response = await this.axios.put<IOrder>(url, { headers: { Authorization: 'Bearer ' + jwt } });
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
            const response = await this.axios.delete<IOrder>(url, { headers: { Authorization: 'Bearer ' + jwt } });
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
