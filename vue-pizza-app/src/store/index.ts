import Vue from 'vue'
import Vuex, { Store } from 'vuex'
import JwtDecode from 'jwt-decode';
import { ILoginDTO } from '@/types/ILoginDTO';
import { AccountApi } from '@/services/AccountApi';
import { PizzaNameApi } from '@/services/PizzaNameApi';
import { IPizzaName } from './../domain/IPizzaName';
import { ToppingApi } from '@/services/ToppingApi';
import { ITopping } from './../domain/ITopping';
import { IToppingEdit } from './../domain/IToppingEdit';
import { PersonApi } from '@/services/PersonApi';
import { IPerson } from './../domain/IPerson';
import { IPizzaType } from '@/domain/IPizzaType';
import { PizzaTypeApi } from './../services/PizzaTypeApi';
import { IPizzaSize } from '@/domain/IPizzaSize';
import { PizzaSizeApi } from './../services/PizzaSizeApi';
import { IOrderRow } from '@/domain/IOrderRow';
import { OrderRowApi } from './../services/OrderRowApi';
import { IOrderRowCart } from '@/domain/IOrderRowCart';
import { PaymentApi } from '@/services/PaymentApi';
import { OrderApi } from '@/services/OrderApi';
import { IPayment } from './../domain/IPayment';
import { IPizzaNameEdit } from '@/domain/IPizzaNameEdit';

Vue.use(Vuex)

export default new Vuex.Store({
    state: {
        jwt: null as string | null,
        isAdmin: false,
        pizzaNames: [] as IPizzaName[],
        payments: [] as IPayment[],
        persons: [] as IPerson[],
        toppings: [] as ITopping[],
        pizzaTypes: [] as IPizzaType[],
        pizzaSizes: [] as IPizzaSize[],
        defaultToppings: [] as string[],
        orderRows: [] as IOrderRow[],
        orderRowCarts: [] as IOrderRowCart[]
    },
    mutations: {
        setJwt(state, jwt: string | null) {
            state.jwt = jwt;
        },
        setIsAdmin(state, isAdmin: boolean) {
            state.isAdmin = isAdmin;
        },
        setOrderRows(state, orderRows: IOrderRowCart[]) {
            state.orderRowCarts = orderRows;
        },
        setPizzaNames(state, pizzaNames: IPizzaName[]) {
            state.pizzaNames = pizzaNames;
        },
        setPersons(state, persons: IPerson[]) {
            state.persons = persons;
        },
        setPayments(state, payments: IPayment[]) {
            state.payments = payments;
        },
        setToppings(state, toppings: ITopping[]) {
            state.toppings = toppings;
        },
        setPizzaTypes(state, pizzaTypes: IPizzaType[]) {
            state.pizzaTypes = pizzaTypes;
        },
        setPizzaSizes(state, pizzaSizes: IPizzaSize[]) {
            state.pizzaSizes = pizzaSizes;
        }
    },
    getters: {
        isAuthenticated(context): boolean {
            console.log("contextjwt", context.jwt)
            return context.jwt !== null;
        },
        isAdmin(context): boolean {
            console.log("isadmin", context.jwt)
            if (context.jwt !== null) {
                const decoded = JwtDecode(context.jwt as string) as Record<string, string>;
                return context.isAdmin === true;
            }
            return false
        },
        getAppUserId(context): string {
            const decoded = JwtDecode(context.jwt as string) as Record<string, string>;
            console.log(decoded)
            return decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
        }
    },
    actions: {
        clearJwt(context): void {
            context.commit('setJwt', null);
        },
        async authenticateUser(context, loginDTO: ILoginDTO): Promise<boolean> {
            const jwt = await AccountApi.getJwt(loginDTO);
            context.commit('setJwt', jwt);
            return jwt !== null;
        },
        async checkAdmin(context, loginDTO: ILoginDTO): Promise<void> {
            const jwt = await AccountApi.getJwt(loginDTO);
            const decoded = JwtDecode(jwt as string) as Record<string, string>;
            console.log(decoded)
            console.log(decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"]);
            const isAdmin = decoded["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"].includes("admin");
            context.commit('setIsAdmin', isAdmin);
        },
        async getPizzaNames(context): Promise<void> {
            const pizzaNames = await PizzaNameApi.getAll();
            context.commit('setPizzaNames', pizzaNames);
        },
        async getPersons(context): Promise<void> {
            const persons = await PersonApi.getAll();
            context.commit('setPersons', persons);
        },
        async getPayments(context): Promise<void> {
            const payments = await PaymentApi.getAll();
            context.commit('setPayments', payments);
        },
        async getToppings(context): Promise<void> {
            const toppings = await ToppingApi.getAll();
            context.commit('setToppings', toppings);
        },
        async getPizzaTypes(context): Promise<void> {
            const pizzaTypes = await PizzaTypeApi.getAll();
            console.log("waiting", pizzaTypes)
            context.commit('setPizzaTypes', pizzaTypes);
        },
        async getPizzaSizes(context): Promise<void> {
            const pizzaSizes = await PizzaSizeApi.getAll();
            context.commit('setPizzaSizes', pizzaSizes);
        },
        async getOrderRows(context): Promise<void> {
            const orderRows = await OrderRowApi.getAllCarts(this.state.jwt as string);
            context.commit('setOrderRows', orderRows);
        },
        async createOrderRow(context, orderRow): Promise<void> {
            if (context.getters.isAuthenticated && context.state.jwt) {
                await OrderRowApi.create(orderRow, context.state.jwt);
            }
        },
        async createPizzaName(context, pizzaName: string[]): Promise<void> {
            console.log('createPizzaName', context.getters.isAuthenticated);
            if (context.getters.isAuthenticated && context.state.jwt) {
                await PizzaNameApi.create(pizzaName, context.state.jwt);
                await context.dispatch('getPizzaNames');
            }
        },
        async createTopping(context, topping: string[]): Promise<void> {
            console.log('createTopping', context.getters.isAuthenticated);
            if (context.getters.isAuthenticated && context.state.jwt) {
                await ToppingApi.create(topping, context.state.jwt);
                await context.dispatch('getToppings');
            }
        },
        async createOrder(context, appUserId: string): Promise<void> {
            console.log('createOrder', context.getters.isAuthenticated);
            if (context.getters.isAuthenticated && context.state.jwt) {
                await OrderApi.create(appUserId, context.state.jwt);
            }
        },
        async editPizzaName(context, pizzaName: IPizzaNameEdit): Promise<void> {
            console.log('editPizzaName', context.getters.isAuthenticated);
            if (context.getters.isAuthenticated && context.state.jwt) {
                await PizzaNameApi.edit(pizzaName, context.state.jwt);
                await context.dispatch('getPizzaNames');
            }
        },
        async editTopping(context, topping: IToppingEdit): Promise<void> {
            console.log('editTopping', context.getters.isAuthenticated);
            if (context.getters.isAuthenticated && context.state.jwt) {
                await ToppingApi.edit(topping, context.state.jwt);
                await context.dispatch('getToppings');
            }
        },
        async deletePizzaName(context, id: string): Promise<void> {
            console.log('deletePizzaName', context.getters.isAuthenticated);
            console.log('deletePizzaName', context.state.jwt);
            if (context.getters.isAuthenticated && context.state.jwt) {
                console.log("lastidcheck", id)
                await PizzaNameApi.delete(id, context.state.jwt);
                await context.dispatch('getPizzaNames');
            }
        },
        async deletePerson(context, id: string): Promise<void> {
            console.log('deletePerson', context.getters.isAuthenticated);
            if (context.getters.isAuthenticated && context.state.jwt) {
                await PersonApi.delete(id, context.state.jwt);
                await context.dispatch('getPersons');
            }
        },
        async deletePayment(context, id: string): Promise<void> {
            console.log('deletePayment', context.getters.isAuthenticated);
            if (context.getters.isAuthenticated && context.state.jwt) {
                await PaymentApi.delete(id, context.state.jwt);
                await context.dispatch('getPayments');
            }
        },
        async deleteOrderRow(context, id: string): Promise<void> {
            console.log('deleteOrderRow', context.getters.isAuthenticated);
            if (context.getters.isAuthenticated && context.state.jwt) {
                await OrderRowApi.delete(id, context.state.jwt);
                await context.dispatch('getOrderRows');
            }
        },
        async deleteTopping(context, id: string): Promise<void> {
            console.log('deleteTopping', context.getters.isAuthenticated);
            console.log(context.getters.isAuthenticated)
            console.log(context.state.jwt)
            if (context.getters.isAuthenticated && context.state.jwt) {
                await ToppingApi.delete(id, context.state.jwt);
                await context.dispatch('getToppings');
            }
        }
    },
    modules: {
    }
})
