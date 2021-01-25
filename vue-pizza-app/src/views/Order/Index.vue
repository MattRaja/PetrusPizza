<template>
    <div>
        <h1 class="container-fluid col-3">Cart</h1>
        <table class="table table-striped col-md-10">
            <tbody v-for="orderRow in orderRows" :key="orderRow.id">
                <tr scope="row">
                <td>{{orderRow.nameOfPizza}}</td>
                <td>{{orderRow.pizzaType}}</td>
                <td>{{orderRow.pizzaSize}}</td>
                <td>Total: {{orderRow.sumWithVAT}} €</td>
                <td>
                <button
                    @click="deleteOnClick(orderRow)"
                    type="button"
                    class="btn btn-danger">
                    Remove
                </button>
                </td>
                </tr>
            </tbody>
            <button
                @click="checkout()"
                type="button"
                class="btn btn-success mt-4"
                style="float: left;">
                Checkout
            </button>
        </table>
    </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import router from "../../router";
import { ITopping } from "../../domain/ITopping";
import { IOrderRowCart } from "../../domain/IOrderRowCart";
import store from "../../store";

@Component
export default class OrderIndex extends Vue {
    get orderRows(): IOrderRowCart[] {
        const orderRows = store.state.orderRowCarts;
        const appUserId = this.getAppUserId();
        const userOrderRows: IOrderRowCart[] = [];
        orderRows.forEach(element => {
            if (element.appUserId === appUserId) userOrderRows.push(element);
        });
        return userOrderRows
    }

    checkout() {
        const appUserId = this.getAppUserId();
        store.dispatch('createOrder', appUserId)
    }

    get isAdmin(): boolean {
        return store.getters.isAdmin;
    }

    getAppUserId(): string {
        return store.getters.getAppUserId;
    }

    deleteOnClick(orderRow: IOrderRowCart): void {
        store.dispatch('deleteOrderRow', orderRow.id);
    }

    mounted(): void {
        console.log("mounted");
        store.dispatch("getOrderRows");
    }
}
</script>
<style scoped>
div.card:hover {
  background-color: lightgray;
}
</style>
