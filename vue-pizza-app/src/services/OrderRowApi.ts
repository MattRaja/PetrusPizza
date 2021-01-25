import Axios from 'axios';
import { IOrderRow } from '@/domain/IOrderRow';
import { IOrderRowCart } from '@/domain/IOrderRowCart';
import store from "../store";

export abstract class OrderRowApi {
    private static axios = Axios.create(
        {
            baseURL: "https://localhost:5001/api/v1.0/OrderRows/",
            headers: {
                common: {
                    'Content-Type': 'application/json'
                }
            }
        }
    )

    static async getAll(): Promise<IOrderRowCart[]> {
        const url = "";
        try {
            const response = await this.axios.get<IOrderRowCart[]>(url);
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

    static async getAllCarts(jwt: string): Promise<IOrderRowCart[]> {
        const url = "";
        try {
            const response = await this.axios.get<IOrderRowCart[]>(url, { headers: { Authorization: 'Bearer ' + jwt } });
            console.log('getAll response cartrows', response);
            if (response.status === 200) {
                return response.data;
            }
            return [];
        } catch (error) {
            console.log('error: ', (error as Error).message);
            return [];
        }
    }

    static async create(orderRow: IOrderRow, jwt: string): Promise<IOrderRow[]> {
        const url = "";
        try {
            const response = await this.axios.post<IOrderRow[]>(url, orderRow, { headers: { Authorization: 'Bearer ' + jwt } });
            console.log('postOrderRow response', response);
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
            const response = await this.axios.put<IOrderRow>(url, { headers: { Authorization: 'Bearer ' + jwt } });
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
            const response = await this.axios.delete<IOrderRow>(url, { headers: { Authorization: 'Bearer ' + jwt } });
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
